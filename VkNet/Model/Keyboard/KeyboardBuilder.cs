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
		public IKeyboardBuilder AddButton(string label, string extra, KeyboardButtonColor? color = default, string type = null,
										KeyboardButtonActionType? actionType = null, Intent? intent = null, byte? subscribeId = null,
										long? peerId = null)
		{
			type ??= _type ?? Button;
			actionType ??= KeyboardButtonActionType.Text;
			string? payload = extra != null ? $"{{\"{type}\":\"{extra}\"}}" : null;
			_totalPayloadLength += payload?.Length ?? 0;

			CheckKeyboardSize(payload);

			_currentLine.Add(new MessageKeyboardButton
			{
				Color = color,
				Action = new MessageKeyboardButtonAction
				{
					Label = label,
					Payload = payload,
					Type = actionType,
					Intent = intent,
					SubscribeId = subscribeId,
					PeerId = peerId,
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