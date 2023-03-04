using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// URL, сокращенный с помощью vk.cc.
/// </summary>
[Serializable]
public class ShortLink
{
	/// <summary>
	/// Время создания ссылки в Unixtime
	/// </summary>
	[JsonProperty(propertyName: "timestamp")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime Timestamp { get; set; }

	/// <summary>
	/// Сокращенный URL.
	/// </summary>
	[JsonProperty(propertyName: "short_url")]
	public Uri ShortUrl { get; set; }

	/// <summary>
	/// Оригинальный URL.
	/// </summary>
	[JsonProperty(propertyName: "url")]
	public Uri Url { get; set; }

	/// <summary>
	/// Содержательная часть ссылки (после "vk.cc");
	/// </summary>
	[JsonProperty(propertyName: "Key")]
	public string Key { get; set; }

	/// <summary>
	/// Ключ для доступа к приватной статистике ссылки;
	/// </summary>
	[JsonProperty(propertyName: "access_key")]
	public string AccessKey { get; set; }

	/// <summary>
	/// Число переходов
	/// </summary>
	[JsonProperty(propertyName: "views")]
	public int Views { get; set; }
}