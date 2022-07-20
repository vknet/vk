using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Параметры метода create.lookalikeRequest
	/// </summary>
	[Serializable]
	public class CreateLookALikeRequestParams
	{
		/// <summary>
		/// Идентификатор клиента, для которого будет создаваться аудитория.
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Тип источника исходной аудитории.
		/// </summary>
		[JsonProperty("source_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public SourceType SourceType { get; set; }

		/// <summary>
		/// Идентификатор аудитории ретаргетинга.
		/// </summary>
		[JsonProperty("retargeting_group_id")]
		public long? RetargetingGroupId { get; set; }
	}
}