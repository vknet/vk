using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения метода PrettyCards.delete
	/// </summary>
	[Serializable]
	public class PrettyCardsDeleteResult
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