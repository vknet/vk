using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.deleteAds
	/// </summary>
	[Serializable]
	public class DeleteAdsParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Массив, содержащий id удаляемых администраторов
		/// </summary>
		[JsonProperty("ids")]
		public string[] Ids { get; set; }
	}
}