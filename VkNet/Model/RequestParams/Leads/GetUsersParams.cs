using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Leads
{
	/// <summary>
	/// </summary>
	[Serializable]
	public class GetUsersParams
	{
		/// <summary>
		/// Идентификатор рекламной акции.
		/// </summary>
		[JsonProperty(propertyName: "offer_id")]
		public ulong OfferId { get; set; }

		/// <summary>
		/// Секретный ключ, доступный в интерфейсе редактирования рекламной акции.
		/// </summary>
		[JsonProperty(propertyName: "secret")]
		public string Secret { get; set; }

		/// <summary>
		/// Смещение необходимое для выборки определенного подмножества действий.
		/// </summary>
		[JsonProperty(propertyName: "offset")]
		public ulong Offset { get; set; }

		/// <summary>
		/// Количество действий, которые необходимо вернуть.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Тип действия
		/// </summary>
		[JsonProperty(propertyName: "status")]
		public GetUsersStatus Status { get; set; }

		/// <summary>
		/// 0 — сортировка в обратном хронологическом порядке;
		/// 1 — сортировка в прямом хронологическом порядке.
		/// </summary>
		[JsonProperty(propertyName: "reverse")]
		public bool Reverse { get; set; }
	}
}