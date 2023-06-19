using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
///
/// </summary>
[Serializable]
public class CheckLinkParams
{
	/// <summary>
	///
	/// </summary>
	[JsonProperty(propertyName: "account_id")]
	public long AccountId { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty(propertyName: "link_type")]
	public AdsLinkType LinkType { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty(propertyName: "link_url")]
	public Uri LinkUrl { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty(propertyName: "campaign_id")]
	public long? CampaignId { get; set; }
}