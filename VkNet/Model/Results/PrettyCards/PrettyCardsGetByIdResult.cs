using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения метода PrettyCards.getById
	/// </summary>
	[Serializable]
	public class PrettyCardsGetByIdResult
	{
		/// <summary>
		/// Идентификатор карточки.
		/// </summary>
		[JsonProperty("card_id")]
		public string CardId { get; set; }

		/// <summary>
		/// Целевая ссылка.
		/// </summary>
		[JsonProperty("link_url")]
		public string LinkUrl { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Идентификатор кнопки
		/// </summary>
		[JsonProperty("button")]
		public string Button { get; set; }

		/// <summary>
		/// Текст кнопки.
		/// </summary>
		[JsonProperty("button_text")]
		public string ButtonText { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Массив структур с разными размерами фотографии.
		/// </summary>
		[JsonProperty("images")]
		public ReadOnlyCollection<Photo> Images { get; set; }

		/// <summary>
		/// Цена.
		/// </summary>
		[JsonProperty("price")]
		public string Price { get; set; }

		/// <summary>
		/// Старая цена.
		/// </summary>
		[JsonProperty("price_old")]
		public string PriceOld { get; set; }
	}
}