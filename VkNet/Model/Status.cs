using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о статусе пользователя.
/// См. описание http://vk.com/dev/status.get
/// </summary>
[Serializable]
public class Status
{
	/// <summary>
	/// Текст статуса.
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Информация об играющей в текущей момент у пользователя аудиокомпозиции.
	/// </summary>
	[JsonProperty("audio")]
	public Audio Audio { get; set; }
}