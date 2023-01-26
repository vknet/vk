using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Предложения новостей.
/// </summary>
[Serializable]
public class NewsSuggestions
{
	/// <summary>
	/// Предложения по пользователям.
	/// </summary>
	[JsonProperty("profile")]
	public List<User> Users { get; set; }

	/// <summary>
	/// Предложения по группам.
	/// </summary>
	[JsonProperty("group")]
	public List<Group> Groups { get; set; }
}