using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.addOfficeUsers
	/// </summary>
	[Serializable]
	public class GetUploadUrlParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("ad_format")]
		public AdFormat AdFormat { get; set; }

		/// <summary>
		/// Массив объектов UserSpecification
		/// </summary>
		[JsonProperty("icon")]
		public AdIcon Icon { get; set; }
	}
}