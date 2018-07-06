using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.getAdsTargeting
	/// </summary>
	[Serializable]
	public class GetAdsTargetingParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Фильтр по рекламным кампаниям.
		/// Сериализованный JSON-массив, содержащий id кампаний. Если параметр равен null, то будут выводиться рекламные объявления всех кампаний. строка
		/// </summary>
		[JsonProperty("campaign_ids")]
		public string CampaignIds { get; set; }

		/// <summary>
		/// Фильтр по рекламным объявлениям.
		/// Сериализованный JSON-массив, содержащий id объявлений. Если параметр равен null, то будут выводиться все рекламные объявления. строка
		/// </summary>
		[JsonProperty("ad_ids")]
		public string AdIds { get; set; }

		/// <summary>
		/// Для рекламных агентств. id клиента, у которого запрашиваются рекламные объявления. целое число
		/// </summary>
		[JsonProperty("client_id")]
		public long ClientId { get; set; }

		/// <summary>
		/// Флаг, задающий необходимость вывода архивных объявлений.
		/// 0 — выводить только активные объявления;
		/// 1 — выводить все объявления.
		/// флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("include_deleted")]
		public bool IncludeDeleted { get; set; }

		/// <summary>
		/// Ограничение на количество возвращаемых объявлений. Используется, только если параметр ad_ids равен null, а параметр campaign_ids содержит id только одной кампании. целое число
		/// </summary>
		[JsonProperty("limit")]
		public long Limit { get; set; }

		/// <summary>
		/// Смещение, необходимо для выборки определенного подмножества значений. целое число
		/// </summary>
		[JsonProperty("offset")]
		public long Offset { get; set; }
	}
}