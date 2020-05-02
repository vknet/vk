using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат выполнения метода PrettyCards.edit
	/// </summary>
	[Serializable]
	public class PrettyCardsEditResult
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