using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Параметры прямой трансляции
/// </summary>
[Serializable]
public class LiveSettings
{
	/// <summary>
	/// Можно ли перематывать прямую трансляцию
	/// </summary>
	[JsonProperty("can_rewind")]
	public int? CanRewind { get; set; }

	/// <summary>
	/// Является ли прямая трансляция бесконечной
	/// </summary>
	[JsonProperty("is_endless")]
	public int? IsEndless { get; set; }

	/// <summary>
	/// Максимальная длительность прямой трансляции в секундах
	/// </summary>
	[JsonProperty("max_duration")]
	public int? MaxDuration { get; set; }
}