using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// TODO: Undocumented enum, which is a part of sections field in VideoAds
/// <remarks>
/// This enum must be pointing to the positions at which ads can be played
/// </remarks>
/// </summary>
public enum VideoAdsSection
{
	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This is probably in the start of the video
	/// </remarks>
	/// </summary>
	[EnumMember(Value = "preroll")]
	Preroll,

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This is probably in the middle of the video
	/// </remarks>
	/// </summary>
	[EnumMember(Value = "midroll")]
	Midroll,

	/// <summary>
	/// TODO: Undocumented
	/// <remarks>
	/// This is probably in the end of the video
	/// </remarks>
	/// </summary>
	[EnumMember(Value = "postroll")]
	Postroll
}