using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
///
/// </summary>
[Serializable]
public class PrivacyViewListOwners
{
	/// <summary>
	/// Категория
	/// </summary>
	[JsonProperty("allowed")]
	public List<long> Allowed { get; set; }

	/// <summary>
	/// Категория
	/// </summary>
	[JsonProperty("excluded")]
	public List<long> Excluded { get; set; }
}