using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода PrettyCards.getById
	/// </summary>
	[Serializable]
	public class PrettyCardsGetByIdParams
	{
		/// <summary>
		/// Идентификатор владельца карточки.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Список идентификаторов карточек, которые необходимо вернуть.
		/// Строка с числами, разделёнными запятой.
		/// </summary>
		[JsonProperty("card_ids")]
		public IEnumerable<string> CardIds { get; set; }
	}
}