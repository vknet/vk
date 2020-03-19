using System;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	/// Создаёт пиксель ретаргетинга.
	/// </summary>
	[Serializable]
	public class DeleteTargetGroupParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Id клиента, в рекламном кабинете которого будет создаваться пиксель.
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Id пикселя.
		/// </summary>
		[JsonProperty("target_group_id")]
		public long TargetGroupId { get; set; }
	}
}