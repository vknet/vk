using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Видео файлы
	/// </summary>
	[Serializable]
	public class VideoFiles
	{
		/// <summary>
		/// Uri ролика с размером 320x240px.
		/// </summary>
		public Uri Mp4_240 { get; set; }

		/// <summary>
		/// Uri ролика с размером 640x360px.
		/// </summary>
		public Uri Mp4_360 { get; set; }

		/// <summary>
		/// Uri ролика с размером 640x480px.
		/// </summary>
		public Uri Mp4_480 { get; set; }

		/// <summary>
		/// Uri ролика с размером 1280x720px.
		/// </summary>
		public Uri Mp4_720 { get; set; }

		/// <summary>
		/// Uri ролика с размером 1920х1080px.
		/// </summary>
		public Uri Mp4_1080 { get; set; }

		/// <summary>
		/// Uri ролика с размером 1440х2560px.
		/// </summary>
		public Uri Mp4_1440 { get; set; }

		/// <summary>
		/// Uri ролика с размером 2160х3840px.
		/// </summary>
		public Uri Mp4_2160 { get; set; }

		/// <summary>
		/// Внешняя ссылка (например для видео из Youtube)
		/// </summary>
		public Uri External { get; set; }

		/// <summary>
		/// Ссылка на HLS плейлист
		/// <remarks>
		/// Содержит файл в формате .m3u8 (MPEG-2 TS)
		/// </remarks>
		/// </summary>
		public Uri Hls { get; set; }

		/// <summary>
		/// Ссылка на MPEG-DASH плейлист(тип 2)
		/// </summary>
		[JsonProperty("dash_uni")]
		public Uri DashUni { get; set; }

		/// <summary>
		/// Ссылка на MPEG-DASH плейлист(тип 1)
		/// </summary>
		[JsonProperty("dash_sep")]
		public Uri DashSep { get; set; }

		/// <summary>
		/// Ссылка на MPEG-DASH плейлист(тип 4) (video/webm)
		/// </summary>
		[JsonProperty("dash_webm")]
		public Uri DashWebm { get; set; }

		/// <summary>
		/// Ссылка на HLS плейлист по требованию. Файл .m3u8 (MPEG-2 TS)
		/// <remarks>
		/// Без понятия, что это означает
		/// </remarks>
		/// </summary>
		[JsonProperty("hls_ondemand")]
		public Uri HlsOnDemand { get; set; }

		/// <summary>
		/// Ссылка на MPEG-DASH плейлист по требованию (video/mp4)
		/// <remarks>
		/// Без понятия, что это означает
		/// </remarks>
		/// </summary>
		[JsonProperty("dash_ondemand")]
		public Uri DashOnDemand { get; set; }

	#region Live Uris

		/// <summary>
		/// Ссылка на HLS плейлист прямой трансляции. Файл .m3u8 (MPEG-2 TS)
		/// <remarks>
		/// В Postman выдаёт 403 ошибку
		/// </remarks>
		/// </summary>
		[JsonProperty("hls_live_playback")]
		public Uri HlsLivePlayback { get; set; }

		/// <summary>
		/// Ссылка на MPEG-DASH плейлист прямой трансляции (video/mp4)
		/// <remarks>
		/// В Postman выдаёт 403 ошибку
		/// </remarks>
		/// </summary>
		[JsonProperty("dash_live_playback")]
		public Uri DashLivePlayback { get; set; }

	#endregion

		/// <summary>
		/// Хост для запросов, в случае ошибки основного хоста, указанного в других Uri
		/// </summary>
		[JsonProperty("failover_host")]
		public string FailOverHost { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static VideoFiles FromJson(VkResponse response)
		{
			return new VideoFiles
			{
				Mp4_240 = response["mp4_240"],
				Mp4_360 = response["mp4_360"],
				Mp4_480 = response["mp4_480"],
				Mp4_720 = response["mp4_720"],
				Mp4_1080 = response["mp4_1080"],
				External = response["external"],
				Hls = response["hls"],
				DashUni = response["dash_uni"],
				DashSep = response["dash_sep"],
				DashWebm = response["dash_webm"],
				DashOnDemand = response["dash_ondemand"],
				HlsOnDemand = response["hls_ondemand"],
				HlsLivePlayback = response["hls_live_playback"],
				DashLivePlayback = response["dash_live_playback"],
				FailOverHost = response["failover_host"]
			};
		}

	#endregion
	}
}