using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

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
	public UserOrGroupType? ContentType { get; set; }
}