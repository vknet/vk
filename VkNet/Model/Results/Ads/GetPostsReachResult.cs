using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Описание рекламного аккаунта.
	/// </summary>
	/// <remarks>
	/// См. описание https://vk.com/dev/ads.getAccounts
	/// </remarks>
	[Serializable]
	public class GetPostsReachResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("reach_subscribers")]
		public long ReachSubscribers { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("reach_total")]
		public long ReachTotal { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("links")]
		public long Links { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("to_group")]
		public long ToGroup { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("join_group")]
		public long JoinGroup { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("report")]
		public long Report { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("hide")]
		public long Hide { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("unsubscribe")]
		public long Unsubscribe { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("video_views_start")]
		public long VideoViewsStart { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("video_views_3s")]
		public long VideoViews3S { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("video_views_25p")]
		public long VideoViews25P { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("video_views_50p")]
		public long VideoViews50P { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("video_views_75p")]
		public long VideoViews75P { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("video_views_100p")]
		public long VideoViews100P { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetPostsReachResult FromJson(VkResponse response)
		{
			return new GetPostsReachResult
			{
				Id = response["user_id"],
				ReachSubscribers = response["reach_subscribers"],
				ReachTotal = response["reach_total"],
				Report = response["report"],
				ToGroup = response["to_group"],
				VideoViewsStart = response["video_views_start"],
				Unsubscribe = response["unsubscribe"],
				JoinGroup = response["join_group"],
				Links = response["links"],
				Hide = response["hide"],
				VideoViews3S = response["video_views_3s"],
				VideoViews25P = response["video_views_25p"],
				VideoViews50P = response["video_views_50p"],
				VideoViews75P = response["video_views_75p"],
				VideoViews100P = response["video_views_100p"]

			};
		}
	}
}