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
	/// </summary>
	[JsonProperty(propertyName: "count")]
	public long Count { get; set; }

	/// <summary>
	/// </summary>
	[JsonProperty(propertyName: "items")]
	public ReadOnlyCollection<AppGetScopes> Items { get; set; }
}