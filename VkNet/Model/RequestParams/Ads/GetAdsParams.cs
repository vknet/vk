using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.getAds
	/// </summary>
	[Serializable]
	public class GetAdsParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Доступно и обязательно для рекламных агентств. Идентификатор клиента, у которого запрашиваются рекламные объявления.
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Флаг, задающий необходимость вывода архивных объявлений. 0 — выводить только активные объявления; 1 — выводить все объявления.
		/// </summary>
		[JsonProperty("include_deleted")]
		public bool? IncludeDeleted { get; set; }

		/// <summary>
		/// Фильтр по рекламным кампаниям.
		/// Сериализованный JSON-массив, содержащий id кампаний.Если параметр равен null, то будут выводиться рекламные объявления всех кампаний.
		/// </summary>
		[JsonProperty("campaign_ids")]
		public IEnumerable<long> CampaignIds { get; set; }

		/// <summary>
		/// Фильтр по рекламным объявлениям.
		/// Сериализованный JSON-массив, содержащий id объявлений.Если параметр равен null, то будут выводиться все рекламные объявления.
		/// </summary>
		[JsonProperty("ad_ids")]
		public IEnumerable<long> AdIds { get; set; }

		/// <summary>
		/// Ограничение на количество возвращаемых объявлений.
		/// Используется, только если параметр ad_ids равен null, а параметр campaign_ids содержит id только одной кампании.
		/// </summary>
		[JsonProperty("limit")]
		public long? Limit { get; set; }

		/// <summary>
		/// Cмещение. Используется в тех же случаях, что и параметр limit.
		/// </summary>
		[JsonProperty("offset")]
		public long? Offset { get; set; }
	}
}