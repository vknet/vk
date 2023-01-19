using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

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

/// <summary>
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