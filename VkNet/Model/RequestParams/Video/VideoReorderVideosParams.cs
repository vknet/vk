﻿using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.reorderVideos
	/// </summary>
	public struct VideoReorderVideosParams
	{
		/// <summary>
		/// Параметры метода video.reorderVideos
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public VideoReorderVideosParams(bool gag = true)
		{
			TargetId = null;
			AlbumId = 0;
			OwnerId = 0;
			VideoId = 0;
			BeforeOwnerId = null;
			BeforeVideoId = null;
			AfterOwnerId = null;
			AfterVideoId = null;
		}


		/// <summary>
		/// Идентификатор пользователя или сообщества, в чьем альбоме нужно переместить видео. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? TargetId { get; set; }

		/// <summary>
		/// Идентификатор альбома с видеозаписью, которую нужно переместить. целое число, обязательный параметр.
		/// </summary>
		public long AlbumId { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи, которую нужно переместить (пользователь или сообщество). целое число, обязательный параметр.
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи, которую нужно переместить. положительное число, обязательный параметр.
		/// </summary>
		public long VideoId { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи, перед которой следует поместить текущую (пользователь или сообщество). целое число.
		/// </summary>
		public long? BeforeOwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи, перед которой следует поместить текущую. положительное число.
		/// </summary>
		public long? BeforeVideoId { get; set; }

		/// <summary>
		/// Идентификатор владельца видеозаписи, после которой следует поместить текущую (пользователь или сообщество). целое число.
		/// </summary>
		public long? AfterOwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи, после которой следует поместить текущую. положительное число.
		/// </summary>
		public long? AfterVideoId { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(VideoReorderVideosParams p)
		{
			var parameters = new VkParameters
			{
				{ "target_id", p.TargetId },
				{ "album_id", p.AlbumId },
				{ "owner_id", p.OwnerId },
				{ "video_id", p.VideoId },
				{ "before_owner_id", p.BeforeOwnerId },
				{ "before_video_id", p.BeforeVideoId },
				{ "after_owner_id", p.AfterOwnerId },
				{ "after_video_id", p.AfterVideoId }
			};

			return parameters;
		}
	}
}