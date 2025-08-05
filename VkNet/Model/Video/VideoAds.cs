using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// TODO: Undocumented structure which returns inside Video
/// <remarks>
/// This might be all the info for the end application to play ads in the video
/// </remarks>
/// </summary>
[Serializable]
public class VideoAds
{
	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	///	In my tests it contained basically random number
	/// </remarks>>
	/// </summary>
	[JsonProperty("slot_id")]
	public long? SlotId { get; set; }

	/// <summary>
	/// TODO: Undocumented
	/// </summary>
	[JsonProperty("timeout")]
	public float? Timeout { get; set; }

	/// <summary>
	/// TODO: Undocumented
	/// </summary>
	[JsonProperty("can_play")]
	public int? CanPlay { get; set; }

	/// <summary>
	/// TODO: Undocumented
	/// </summary>
	[JsonProperty("params")]
	public VideoAdsParams Params { get; set; }

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// Known values are: <c> preroll </c>, <c> midroll </c>, <c> postroll </c>
	/// </remarks>
	/// </summary>
	[JsonProperty("sections")]
	public VideoAdsSection?[] Sections { get; set; }

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This field should be pointing to normalized video positions, where the ads
	/// should be played
	/// </remarks>
	/// </summary>
	[JsonProperty("midroll_percents")]
	public ReadOnlyCollection<float> MidrollPercents { get; set; }

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// Должен ли преролл проигрываться автоматически ???
	/// </remarks>
	/// </summary>
	[JsonProperty("autoplay_preroll")]
	public int? AutoPlayPreroll { get; set; }
}