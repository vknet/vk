using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// TODO: Undocumented enum, which is a part of sections field in VideoAds
	/// <remarks>
	/// This enum must be pointing to the positions at which ads can be played
	/// </remarks>
	/// </summary>
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class VideoAdsSection : SafetyEnum<VideoAdsSection>
	{
		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// This is probably in the start of the video
		/// </remarks>
		/// </summary>
		public static readonly VideoAdsSection Preroll = RegisterPossibleValue(value: "preroll");

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// This is probably in the middle of the video
		/// </remarks>
		/// </summary>
		public static readonly VideoAdsSection Midroll = RegisterPossibleValue(value: "midroll");

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// This is probably in the end of the video
		/// </remarks>
		/// </summary>
		public static readonly VideoAdsSection Postroll = RegisterPossibleValue(value: "postroll");
	}
}