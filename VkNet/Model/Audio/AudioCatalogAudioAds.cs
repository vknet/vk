using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация об рекламе в аудиозаписи каталога.
/// </summary>
[Serializable]
public class AudioCatalogAudioAds
{
	/// <summary>
	/// Идентификатор контента.
	/// </summary>
	[JsonProperty("content_id")]
	public string ContentId { get; set; }

	/// <summary>
	/// Длительность.
	/// </summary>
	[JsonProperty("duration")]
	public string Duration { get; set; }

	/// <summary>
	/// Тип возрастной группы пользователей
	/// </summary>
	[JsonProperty("account_age_type")]
	public string AccountAgeType { get; set; }

	/// <summary>
	/// Идентификатор
	/// </summary>
	[JsonProperty("puid1")]
	public int Puid1 { get; set; }

	/// <summary>
	/// Идентификатор
	/// </summary>
	[JsonProperty("puid22")]
	public long Puid22 { get; set; }
}