using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Параметры запроса ads.removeTargetContacts
	/// </summary>
	[Serializable]
	public class RemoveTargetContactsParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("target_group_id")]
		public long TargetGroupId { get; set; }

		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("contacts")]
		public List<string> Contacts { get; set; }

		/// <summary>
		/// Массив объектов UserSpecification
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }
	}
}