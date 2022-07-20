using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Предоставляет доступ к аудитории ретаргетинга другому рекламному кабинету.
	/// </summary>
	[Serializable]
	public class ShareTargetGroupParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Идентификатор аудитории. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("target_group_id")]
		public long TargetGroupId { get; set; }

		/// <summary>
		/// Id клиента, в рекламном кабинете которого находится исходная аудитория.
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Id клиента, рекламному кабинету которого необходимо предоставить доступ к аудитории.
		/// </summary>
		[JsonProperty("share_with_client_id")]
		public long? ShareWithClientId { get; set; }
	}
}