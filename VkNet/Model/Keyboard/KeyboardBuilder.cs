using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Model.Keyboard
{
	/// <summary>
	/// Параметры для создания кнопки в билдере
	/// </summary>
	public class AddButtonParams
	{
		/// <summary>
		/// Надписть на кнопке
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Дополнительная информация о кнопке
		/// </summary>
		public string Extra { get; set; }

		/// <summary>
		/// Цвет кнопки
		/// </summary>
		public KeyboardButtonColor Color { get; set; } = default;

		/// <summary>
		/// Основная информация о кнопке
		/// </summary>
		public string? Type { get; set; } = null;

		/// <summary>
		/// Тип клавиши
		/// </summary>
		public KeyboardButtonActionType ActionType { get; set; }

		/// <summary>
		/// Любой из интентов, требующий подписки.
		/// </summary>
		public Intent Intent { get; set; }

		/// <summary>
		/// Дополнительное поле для confirmed_notification.
		/// </summary>
		public byte? SubscribeId { get; set; }

		/// <summary>
		/// user_id: 1-2e9
		/// </summary>
		public long? PeerId { get; set; }
	}

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

		public static readonly string ButtonPayloadLengthExceptionTemplate =
			"Для кнопки payload должен быть максимум " + MaxButtonPayload + " символов: {0}";

		public static readonly string SumPayloadLengthExceptionTemplate =
			"Суммарная длина для payload всех кнопок должен быть максимум " + MaxPayloadOfAllButtons + " символов.";

		public static readonly string MaxButtonsPerLineExceptionTemplate =
			"Количество кнопок на одной линии не должно превышать " + MaxButtonsPerLine;

		public static readonly string MaxButtonLinesExceptionTemplate = "Количество линий кнопок не должно превышать " + MaxButtonLines;

		private const int MaxButtonPayload = 255;

		private const int MaxPayloadOfAllButtons = 1000;

		public const int MaxButtonsPerLine = 4;

		public const int MaxButtonLines = 10;

		/// <inheritdoc />
		public KeyboardBuilder() : this(Button)
		{
		}

		/// <inheritdoc />
		public KeyboardBuilder(bool isOneTime) : this(Button, isOneTime)
		{
		}

		public KeyboardBuilder(string type, bool isOneTime = false)
		{
			IsOneTime = isOneTime;
			_type = type;
		}

		/// <inheritdoc />
		public IKeyboardBuilder AddButton(MessageKeyboardButtonAction buttonAction, KeyboardButtonColor color = default)
		{
			_totalPayloadLength += buttonAction.Payload.Length;

			CheckKeyboardSize(buttonAction.Payload);

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
					Type = addButtonParams.ActionType,
					Intent = addButtonParams.Intent,
					SubscribeId = addButtonParams.SubscribeId,
					PeerId = addButtonParams.PeerId,
				}
			});

			return this;
		}

		private void CheckKeyboardSize(string? payload)
		{
			if ((payload?.Length ?? 0) > 255)
			{
				throw new VkKeyboardPayloadMaxLengthException(string.Format(ButtonPayloadLengthExceptionTemplate, payload));
			}

			if (_totalPayloadLength > 1000)
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