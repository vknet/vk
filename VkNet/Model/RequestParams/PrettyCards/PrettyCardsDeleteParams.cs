using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода prettyCards.delete
	/// </summary>
	[Serializable]
	public class PrettyCardsDeleteParams
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
	}
}