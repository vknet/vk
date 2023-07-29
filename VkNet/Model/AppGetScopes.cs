using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Получение скоупов приложения
/// </summary>
[Serializable]
public class AppGetScopes
{
	/// <summary>
	/// Описание.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Название.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }
}