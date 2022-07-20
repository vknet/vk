using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода prettyCards.edit
	/// </summary>
	[Serializable]
	public class PrettyCardsEditParams
	{
		/// <summary>
		/// Идентификатор владельца карточки.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор карточки.
		/// </summary>
		[JsonProperty("card_id")]
		public string CardId { get; set; }

		/// <summary>
		/// Новая фотография.
		/// </summary>
		[JsonProperty("photo")]
		public string Photo { get; set; }

		/// <summary>
		/// Новый заголовок.
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Новая ссылка.
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		/// <summary>
		/// Новая цена.
		/// </summary>
		[JsonProperty("price")]
		public string Price { get; set; }

		/// <summary>
		/// Обновлённая старая цена.
		/// </summary>
		[JsonProperty("price_old")]
		public string PriceOld { get; set; }

		/// <summary>
		/// Новая кнопка.
		/// </summary>
		[JsonProperty("button")]
		public string Button { get; set; }
	}
}