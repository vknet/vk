using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.addOfficeUsers
	/// </summary>
	[Serializable]
	public class AdsDataSpecificationParams <TSpecification>
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Массив объектов UserSpecification
		/// </summary>
		[JsonProperty("data")]
		public TSpecification[] Data { get; set; }
	}
}