using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Model.Keyboard
{
	/// <inheritdoc />
	[Serializable]
	[UsedImplicitly]
	public class KeyboardBuilder : IKeyboardBuilder
	{
		private bool IsOneTime { get; set; }

		private bool IsInline { get; set; }

		private readonly List<List<MessageKeyboardButton>> _fullKeyboard = new List<List<MessageKeyboardButton>>();

		private List<MessageKeyboardButton> _currentLine = new List<MessageKeyboardButton>();

		private readonly string _type;

		private const string Button = "button";

		private int _totalPayloadLength;

		/// <summary>
		/// Шаблон сообщения для исключения максимальной длины полезной нагрузки сообщения
		/// </summary>
		public static readonly string ButtonPayloadLengthExceptionTemplate =
			"Для кнопки payload должен быть максимум " + MaxButtonPayload + " символов: {0}";

		/// <summary>
		/// Шаблон сообщения для исключения сумм всех максимальных длин полезной нагрузки сообщения
		/// </summary>
		public static readonly string SumPayloadLengthExceptionTemplate =
			"Суммарная длина для payload всех кнопок должен быть максимум " + MaxPayloadOfAllButtons + " символов.";

		/// <summary>
		/// Шаблон сообщения для исключения максимального количества кнопок в строке
		/// </summary>
		public static readonly string MaxButtonsPerLineExceptionTemplate =
			"Количество кнопок на одной линии не должно превышать " + MaxButtonsPerLine;

		/// <summary>
		/// Шаблон сообщения для исключения максимального количества строк
		/// </summary>
		public static readonly string MaxButtonLinesExceptionTemplate = "Количество линий кнопок не должно превышать " + MaxButtonLines;

		private const int MaxButtonPayload = 255;

		private const int MaxPayloadOfAllButtons = 1000;

		/// <summary>
		/// Максимальное количество кнопок в строке
		/// </summary>
		public const int MaxButtonsPerLine = 4;

		/// <summary>
		/// Максимальное количество строк
		/// </summary>
		public const int MaxButtonLines = 10;

		/// <inheritdoc />
		public KeyboardBuilder() : this(Button)
		{
		}

		/// <inheritdoc />
		public KeyboardBuilder(bool isOneTime) : this(Button, isOneTime)
		{
		}

		/// <summary>
		/// Конструктор клавиатур
		/// </summary>
		/// <param name="type">Тип</param>
		/// <param name="isOneTime">Одноразовая</param>
		public KeyboardBuilder(string type, bool isOneTime = false)
		{
			IsOneTime = isOneTime;
			_type = type;
		}

		/// <inheritdoc />
		public IKeyboardBuilder AddButton(MessageKeyboardButtonAction buttonAction, KeyboardButtonColor color = default)
		{
			if (buttonAction.Payload != null)
			{
				_totalPayloadLength += buttonAction.Payload.Length;

				CheckKeyboardSize(buttonAction.Payload);
			}

			_currentLine.Add(new MessageKeyboardButton
			{
				Color = color,
				Action = buttonAction
			});

			return this;
		}

		/// <inheritdoc />
		public IKeyboardBuilder AddButton(string label, string extra, KeyboardButtonColor color = default,
										string type = null)
		{
			color ??= KeyboardButtonColor.Default;
			type ??= _type ?? Button;
			var payload = $"{{\"{type}\":\"{extra}\"}}";
			_totalPayloadLength += payload.Length;

			CheckKeyboardSize(payload);

			_currentLine.Add(new MessageKeyboardButton
			{
				Color = color,
				Action = new MessageKeyboardButtonAction
				{
					Label = label,
					Payload = payload,
					Type = KeyboardButtonActionType.Text
				}
			});

			return this;
		}

		/// <inheritdoc />
		public IKeyboardBuilder AddButton(AddButtonParams addButtonParams)
		{
			addButtonParams.Type ??= _type ?? Button;
			addButtonParams.ActionType ??= KeyboardButtonActionType.Text;
			string? payload = addButtonParams.Extra != null ? $"{{\"{addButtonParams.Type}\":\"{addButtonParams.Extra}\"}}" : null;
			_totalPayloadLength += payload?.Length ?? 0;

			CheckKeyboardSize(payload);

			_currentLine.Add(new MessageKeyboardButton
			{
				Color = addButtonParams.Color,
				Action = new MessageKeyboardButtonAction
				{
					Label = addButtonParams.Label,
					Payload = payload,
					Link = addButtonParams.Link != null ? new Uri(addButtonParams.Link) : null,
					Hash = addButtonParams.Hash,
					Type = addButtonParams.ActionType,
					Intent = addButtonParams.Intent,
					SubscribeId = addButtonParams.SubscribeId,
					PeerId = addButtonParams.PeerId
				}
			});

			return this;
		}

		private void CheckKeyboardSize(string? payload)
		{
			if ((payload?.Length ?? 0) > MaxButtonPayload)
			{
				throw new VkKeyboardPayloadMaxLengthException(string.Format(ButtonPayloadLengthExceptionTemplate, payload));
			}

			if (_totalPayloadLength > MaxPayloadOfAllButtons)
			{
				throw new VkKeyboardPayloadMaxLengthException(SumPayloadLengthExceptionTemplate);
			}

			if (_currentLine.Count + 1 > MaxButtonsPerLine)
			{
				throw new VkKeyboardMaxButtonsException(MaxButtonsPerLineExceptionTemplate);
			}
		}

		/// <inheritdoc />
		public IKeyboardBuilder AddLine()
		{
			if (_fullKeyboard.Count + 1 > MaxButtonLines)
			{
				throw new VkKeyboardMaxButtonsException(MaxButtonLinesExceptionTemplate);
			}

			_fullKeyboard.Add(_currentLine);
			_currentLine = new List<MessageKeyboardButton>();

			return this;
		}

		/// <inheritdoc />
		public IKeyboardBuilder SetOneTime()
		{
			IsOneTime = true;

			return this;
		}

		/// <inheritdoc />
		public IKeyboardBuilder SetInline(bool inline = true)
		{
			IsInline = inline;

			return this;
		}

		/// <inheritdoc />
		public IKeyboardBuilder Clear()
		{
			_currentLine.Clear();
			_fullKeyboard.Clear();
			_totalPayloadLength = 0;

			return this;
		}

		/// <inheritdoc />
		public MessageKeyboard Build()
		{
			if (_currentLine.Any())
			{
				AddLine();
			}

			return new MessageKeyboard
			{
				OneTime = IsOneTime,
				Inline = IsInline,
				Buttons = _fullKeyboard.Select(e => e.ToReadOnlyCollection()).ToReadOnlyCollection()
			};
		}
	}
}