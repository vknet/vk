using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model;

/// <summary>
/// Текущее значение
/// </summary>
[Serializable]
public class PrivacySettingsValue
{
	/// <summary>
	/// Категория
	/// </summary>
	[JsonProperty("category")]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public Privacy Category { get; set; }

	/// <summary>
	/// Категория
	/// </summary>
	[JsonProperty("lists")]
	public PrivacyViewListOwners Lists { get; set; }

	/// <summary>
	/// Категория
	/// </summary>
	[JsonProperty("owners")]
	public PrivacyViewListOwners Owners { get; set; }
}