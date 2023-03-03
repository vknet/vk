using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Внешние сервисы, в которые настроен экспорт из ВК
/// </summary>
[Serializable]
public class Exports
{
	/// <summary>
	/// Twitter
	/// </summary>
	[JsonProperty("twitter")]
	public bool Twitter { get; set; }

	/// <summary>
	/// Facebook
	/// </summary>
	[JsonProperty("facebook")]
	public bool Facebook { get; set; }

	/// <summary>
	/// LiveJournal
	/// </summary>
	[JsonProperty("livejournal")]
	public bool Livejournal { get; set; }

	/// <summary>
	/// Instagram
	/// </summary>
	[JsonProperty("instagram")]
	public bool Instagram { get; set; }
}