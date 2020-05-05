using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода PrettyCardds.Create
	/// </summary>
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
		public string CardId { get; set; }
	}
}