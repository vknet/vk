using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о метаданных пользователя/сообщества.
	/// </summary>
	[Serializable]
	public class AudioCatalogItemMeta
	{
		/// <summary>
		/// Иконка.
		/// </summary>
		[JsonProperty("icon")]
		public string Icon { get; set; }

		/// <summary>
		/// Идентификатор владельца аудиозаписи.
		/// </summary>
		[JsonProperty("content_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public UserOrGroupType ContentType { get; set; }
	}
}