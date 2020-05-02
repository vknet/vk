using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class PrettyCardsCreateResult
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
		public long? CardId { get; set; }
	}
}