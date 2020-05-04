using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Keyboard;

namespace VkNet.Model.Template.Carousel
{
	/// <inheritdoc />
	[Serializable]
	[UsedImplicitly]
	public class CarouselElementBuilder : ICarouselElementBuilder
	{
		/// <inheritdoc />
		[CanBeNull]
		public string Title { get; private set; }

		/// <inheritdoc />
		[CanBeNull]
		public string Description { get; private set; }

		/// <inheritdoc />
		[CanBeNull]
		public string PhotoId { get; private set; }

		/// <inheritdoc />
		[CanBeNull]
		public CarouselElementAction Action { get; private set; }

		/// <inheritdoc />
		public List<MessageKeyboardButton> Buttons { get; private set; } = new List<MessageKeyboardButton>();

		private readonly string _type;

		private const string Button = "button";

		private int _totalPayloadLength;

		private const string ButtonPayloadLengthExceptionTemplate = "Для кнопки payload должен быть максимум 255 символов: {0}";

		private const string SumPayloadLengthExceptionTemplate =
			"Суммарная длина для payload всех кнопок должен быть максимум 1000 символов.";

		private const string TooMuchButtonsExceptionTemplate = "Количество кнопок не должно превышать трех";

		/// <inheritdoc />
		public CarouselElementBuilder() : this(Button)
		{
		}

		/// <summary>
		/// Тип.
		/// </summary>
		/// <param name="type"></param>
		public CarouselElementBuilder(string type)
		{
			_type = type;
		}

		/// <inheritdoc />
		public ICarouselElementBuilder AddButton(string label, string extra, KeyboardButtonColor color = default(KeyboardButtonColor), string type = null)
		{
			color ??= KeyboardButtonColor.Default;
			type ??= _type ?? Button;
			var payload = $"{{\"{type}\":\"{extra}\"}}";
			_totalPayloadLength += payload.Length;

			if (Buttons.Count >= 3)
			{
				throw new TooMuchButtonsException(TooMuchButtonsExceptionTemplate);
			}

			if (payload.Length > 255 && type == Button)
			{
				throw new VkKeyboardPayloadMaxLengthException(string.Format(ButtonPayloadLengthExceptionTemplate, payload));
			}

			if (_totalPayloadLength > 1000)
			{
				throw new VkKeyboardPayloadMaxLengthException(SumPayloadLengthExceptionTemplate);
			}

			Buttons.Add(new MessageKeyboardButton
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
		public ICarouselElementBuilder SetTitle(string title)
		{
			Title = title;

			return this;
		}

		/// <inheritdoc />
		public ICarouselElementBuilder SetDescription(string description)
		{
			Description = description;

			return this;
		}

		/// <inheritdoc />
		public ICarouselElementBuilder SetPhotoId(string photoId)
		{
			PhotoId = photoId;

			return this;
		}

		/// <inheritdoc />
		public ICarouselElementBuilder SetAction(CarouselElementAction action)
		{
			Action = action;

			return this;
		}

		/// <inheritdoc />
		public ICarouselElementBuilder ClearButtons()
		{
			Buttons.Clear();

			return this;
		}

		/// <inheritdoc />
		public CarouselElement Build()
		{
			return new CarouselElement()
			{
				Title = Title,
				Description = Description,
				PhotoId = PhotoId,
				Buttons = Buttons,
				Action = Action
			};
		}
	}
}