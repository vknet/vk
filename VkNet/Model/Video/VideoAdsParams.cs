using System;
using Newtonsoft.Json;
using VkNet.Enums;
using VkNet.Infrastructure;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// TODO: Undocumented structure, which returns inside ads field in Video
	/// </summary>
	[Serializable]
	public class VideoAdsParams
	{
		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// In my tests it contained my UserId
		/// </remarks>
		/// </summary>
		[JsonProperty("vk_id")]
		public long? VkId { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// Must be duration in seconds
		/// </remarks>
		/// </summary>
		[JsonProperty("duration")]
		public int? Duration { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <summary>
		/// In my tests it contained normal Vk VideoId in this format <c> OwnerId_Id </c>
		/// </summary>
		/// </summary>
		[JsonProperty("video_id")]
		public string VideoId { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// No idea what it can be, in my tests it contained basically random number
		/// </remarks>
		/// </summary>
		[JsonProperty("pl")]
		public int? Pl { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// No idea what it can be, in my tests it contained <c> -[18 digits] </c>
		/// </remarks>
		/// </summary>
		[JsonProperty("content_id")]
		public string ContentId { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// This must be a normal Vk <see cref="Language"> Language </see>
		/// </remarks>
		/// </summary>
		[JsonProperty("lang")]
		public int? Lang { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid1")]
		public string PuId1 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid2")]
		public int? PuId2 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid3")]
		public int? PuId3 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid4")]
		public int? PuId4 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid5")]
		public int? PuId5 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid6")]
		public int? PuId6 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid7")]
		public int? PuId7 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid8")]
		public int? PuId8 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid9")]
		public int? PuId9 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid10")]
		public int? PuId10 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid12")]
		public int? PuId12 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid13")]
		public int? PuId13 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid14")]
		public int? PuId14 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid15")]
		public int? PuId15 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid18")]
		public int? PuId18 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// All of the puid`s seems random.
		/// </remarks>
		/// </summary>
		[JsonProperty("puid21")]
		public int? PuId21 { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// In my tests it contained 40 random chars, so it must be some hash
		/// </remarks>
		/// </summary>
		[JsonProperty("sign")]
		public string Sign { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// In my tests it contained GroupId, from which I loaded the videos
		/// </remarks>
		/// </summary>
		[JsonProperty("groupId")]
		public long? GroupId { get; set; }

		/// <summary>
		/// TODO: Undocumented
		/// <remarks>
		/// Must be some Category Id, in my tests it was 4, 29
		/// </remarks>
		/// </summary>
		[JsonProperty("vk_catid")]
		public int? VkCatId { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static VideoAdsParams FromJson(VkResponse response)
		{
			return JsonConvert.DeserializeObject<VideoAdsParams>(response.ToString(), JsonConfigure.JsonSerializerSettings);
		}

	#endregion
	}
}