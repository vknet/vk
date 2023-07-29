using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Приложение.
/// </summary>
[Serializable]
public class AppGetScopesResult
{
	/// <summary>
	/// Количество
	/// </summary>
	[JsonProperty(propertyName: "count")]
	public long Count { get; set; }

	/// <summary>
	/// Элементы
	/// </summary>
	[JsonProperty(propertyName: "items")]
	public ReadOnlyCollection<AppGetScopes> Items { get; set; }
}