using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация об артисте/группе.
/// </summary>
[Serializable]
public class AudioArtist
{
	/// <summary>
	/// Идентификатор артиста/группы.
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	/// Имя артиста/название группы.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Неизвестно (получено экспериментально).
	/// </summary>
	[JsonProperty("domain")]
	public string Domain { get; set; }
}