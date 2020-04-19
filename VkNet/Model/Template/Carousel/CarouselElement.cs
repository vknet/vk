using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Model.Keyboard;
using VkNet.Utils;

namespace VkNet.Model.Template.Carousel
{
	/// <summary>
	/// Объект элементов карусели.
	/// </summary>
	[Serializable]
	public class CarouselElement
	{
		/// <summary>
		/// Заголовок, максимум 80 символов
		/// </summary>
		[JsonProperty("title")]
		[CanBeNull]
		public string Title { get; set; }

		/// <summary>
		/// Подзаголовок, максимум 80 символов
		/// </summary>
		[JsonProperty("description")]
		[CanBeNull]
		public string Description { get; set; }

		/// <summary>
		/// Id изображения, которое надо прикрепить.
		/// Пропорции изображения: 13/8.
		/// Минимальный размер: 221х136.
		/// Пример: -123218_50548844
		/// </summary>
		[JsonProperty("photo_id")]
		[CanBeNull]
		public string PhotoId { get; set; }

		/// <summary>
		/// Массив с кнопками.
		/// </summary>
		[JsonProperty("buttons")]
		public IEnumerable<MessageKeyboardButton> Buttons { get; set; }

		/// <summary>
		/// Объект, описывающий действие, которое необходимо выполнить при нажатии на элемент карусели.
		/// </summary>
		[JsonProperty("action")]
		[CanBeNull]
		public CarouselElementAction Action { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CarouselElement FromJson(VkResponse response)
		{
			return new CarouselElement
			{
				Title = response[key: "title"],
				Description = response[key: "description"],
				Action = response[key: "action"],
				PhotoId = response[key: "photo_id"],
				Buttons = response[key: "buttons"].ToReadOnlyCollectionOf<MessageKeyboardButton>(selector: x => x)
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CarouselElement(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken() ? FromJson(response) : null;
		}
	}
}