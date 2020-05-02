using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода PrettyCards.get
	/// </summary>
	[Serializable]
	public class PrettyCardsGetParams
	{
		/// <summary>
		/// Идентификатор владельца карточки.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Смещение относительно начала списка карточек
		/// </summary>
		[JsonProperty("offset")]
		public long? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых карточек.
		/// </summary>
		[JsonProperty("count")]
		public long? Count { get; set; }
	}
}