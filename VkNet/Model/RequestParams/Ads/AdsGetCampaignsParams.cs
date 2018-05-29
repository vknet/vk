using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.search
	/// </summary>
	[Serializable]
	public class AdsGetCampaignsParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty(propertyName: "account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Идентификатор клиента, у которого запрашиваются рекламные кампании. Обязателен
		/// для рекламных агентств, в остальных
		/// случаях не используется.
		/// </summary>
		[JsonProperty(propertyName: "client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Флаг, задающий необходимость вывода архивных объявлений. 0 — выводить только
		/// активные кампании; 1 — выводить все
		/// кампании.
		/// </summary>
		[JsonProperty(propertyName: "include_deleted")]
		public bool IncludeDeleted { get; set; }

		/// <summary>
		/// Фильтр выводимых рекламных кампаний.
		/// Сериализованный JSON-массив, содержащий id кампаний.Выводиться будут только
		/// кампании, присутствующие в campaign_ids
		/// и являющиеся кампаниями указанного рекламного кабинета.Если параметр равен
		/// строке null, то выводиться будут все
		/// кампании.
		/// </summary>
		[JsonProperty(propertyName: "campaign_ids")]
		public IEnumerable<long> CampaignIds { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(AdsGetCampaignsParams p)
		{
			var parameters = new VkParameters
			{
					{ "account_id", p.AccountId }
					, { "client_id", p.ClientId }
					, { "include_deleted", p.IncludeDeleted }
					, { "campaign_ids", p.CampaignIds != null ? "[" + string.Join(separator: ",", values: p.CampaignIds) + "]" : null }
			};

			return parameters;
		}
	}
}