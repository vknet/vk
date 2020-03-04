using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.createTargetGroup
	/// </summary>
	[Serializable]
	public class AddOfficeUsersParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Название аудитории ретаргетинга — строка до 64 символов. обязательный параметр, строка
		/// </summary>
		[JsonProperty("data")]
		public UserSpecification[] Data { get; set; }
	}
}