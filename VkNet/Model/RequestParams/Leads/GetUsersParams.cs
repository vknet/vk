using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Leads
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class GetUsersParams
	{
		/// <summary>
		/// Идентификатор рекламной акции. 
		/// </summary>
		[JsonProperty("offer_id")]
		public ulong OfferId { get; set; }

		/// <summary>
		/// Секретный ключ, доступный в интерфейсе редактирования рекламной акции.
		/// </summary>
		[JsonProperty("secret")]
		public string Secret { get; set; }

		/// <summary>
		/// Смещение необходимое для выборки определенного подмножества действий.
		/// </summary>
		[JsonProperty("offset")]
		public ulong Offset { get; set; }

		/// <summary>
		/// Количество действий, которые необходимо вернуть. 
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Тип действия
		/// </summary>
		[JsonProperty("status")]
		public GetUsersStatus Status { get; set; }

		/// <summary>
		/// 0 — сортировка в обратном хронологическом порядке;
		/// 1 — сортировка в прямом хронологическом порядке.
		/// </summary>
		[JsonProperty("reverse")]
		public bool Reverse { get; set; }
	}
}