using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model;

/// <summary>
/// Слой
/// </summary>
[Serializable]
public class Layout
{
	/// <summary>
	/// Идентификатор объявления.
	/// </summary>
	[JsonProperty("id")]
	public long Id { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("campaign_id")]
	public long CampaignId { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("ad_format")]
	public AdFormat AdFormat { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("cost_type")]
	public CostType CostType { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("goal_type")]
	public GoalType GoalType { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("video")]
	public long Video { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("repeat_video")]
	public long RepeatVideo { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("description")]
	public string Description { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("link_url")]
	public Uri LinkUrl { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("link_domain")]
	public Uri LinkDomain { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("link_title")]
	public Uri LinkTitle { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("link_button")]
	public Uri LinkButton { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("preview_link")]
	public Uri PreviewLink { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("image_src")]
	public Uri ImageSrc { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("image_src_2x")]
	public Uri ImageSrc2X { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("icon_src")]
	public Uri IconSrc { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty("icon_src_2x")]
	public Uri IconSrc2X { get; set; }
}