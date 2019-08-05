using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Настройки Bots Longpoll.
	/// </summary>
	[Serializable]
	public class BotsLongPollEvents
	{
		/// <summary>
		/// Уведомления о новых сообщениях (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("message_new")]
		public bool? MessageNew { get; set; }

		/// <summary>
		/// Уведомления об исходящем сообщении (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("message_reply")]
		public bool? MessageReply { get; set; }

		/// <summary>
		/// Уведомления о подписке на сообщения  (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("message_allow")]
		public bool? MessageAllow { get; set; }

		/// <summary>
		/// Уведомления о запрете на сообщения (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("message_deny")]
		public bool? MessageDeny { get; set; }

		/// <summary>
		/// Уведомления о редактировании сообщения (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("message_edit")]
		public bool? MessageEdit { get; set; }

		/// <summary>
		/// Флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("message_typing_state")]
		public bool? MessageTypingState { get; set; }

		/// <summary>
		/// Уведомления о добавлении новой фотографии (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("photo_new")]
		public bool? PhotoNew { get; set; }

		/// <summary>
		/// Уведомления о добавлении новой аудиозаписи (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("audio_new")]
		public bool? AudioNew { get; set; }

		/// <summary>
		/// Уведомления о добавлении новой видеозаписи (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("video_new")]
		public bool? VideoNew { get; set; }

		/// <summary>
		/// Уведомления о добавлении нового комментария на стене (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("wall_reply_new")]
		public bool? WallReplyNew { get; set; }

		/// <summary>
		/// Уведомления о редактировании комментария на стене (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("wall_reply_edit")]
		public bool? WallReplyEdit { get; set; }

		/// <summary>
		/// Уведомления об удалении комментария на стене (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("wall_reply_delete")]
		public bool? WallReplyDelete { get; set; }

		/// <summary>
		/// Уведомления о восстановлении комментария на стене (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("wall_reply_restore")]
		public bool? WallReplyRestore { get; set; }

		/// <summary>
		/// Уведомления о новой записи на стене (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("wall_post_new")]
		public bool? WallPostNew { get; set; }

		/// <summary>
		/// Уведомления о репосте записи (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("wall_repost")]
		public bool? WallRepost { get; set; }

		/// <summary>
		/// Уведомления о создании комментария в обсуждении (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("board_post_new")]
		public bool? BoardPostNew { get; set; }

		/// <summary>
		/// Уведомления о редактировании комментария в обсуждении (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("board_post_edit")]
		public bool? BoardPostEdit { get; set; }

		/// <summary>
		/// Уведомление о восстановлении комментария в обсуждении (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("board_post_restore")]
		public bool? BoardPostRestore { get; set; }

		/// <summary>
		/// Уведомления об удалении комментария в обсуждении (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("board_post_delete")]
		public bool? BoardPostDelete { get; set; }

		/// <summary>
		/// Уведомления о добавлении нового комментария к фото (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("photo_comment_new")]
		public bool? PhotoCommentNew { get; set; }

		/// <summary>
		/// Уведомления о редактировании комментария к фото (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("photo_comment_edit")]
		public bool? PhotoCommentEdit { get; set; }

		/// <summary>
		/// Уведомления об удалении комментария к фото (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("photo_comment_delete")]
		public bool? PhotoCommentDelete { get; set; }

		/// <summary>
		/// Уведомления о восстановлении комментария к фото (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("photo_comment_restore")]
		public bool? PhotoCommentRestore { get; set; }

		/// <summary>
		/// Уведомления о добавлении нового комментария к видео (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("video_comment_new")]
		public bool? VideoCommentNew { get; set; }

		/// <summary>
		/// Уведомления о редактировании комментария к видео (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("video_comment_edit")]
		public bool? VideoCommentEdit { get; set; }

		/// <summary>
		/// Уведомления об удалении комментария к видео (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("video_comment_delete")]
		public bool? VideoCommentDelete { get; set; }

		/// <summary>
		/// Уведомления о восстановлении комментария к видео (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("video_comment_restore")]
		public bool? VideoCommentRestore { get; set; }

		/// <summary>
		/// Уведомления о добавлении нового комментария к товару (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("market_comment_new")]
		public bool? MarketCommentNew { get; set; }

		/// <summary>
		/// Уведомления о редактировании комментария к товару (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("market_comment_edit")]
		public bool? MarketCommentEdit { get; set; }

		/// <summary>
		/// Уведомления об удалении комментария к товару (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("market_comment_delete")]
		public bool? MarketCommentDelete { get; set; }

		/// <summary>
		/// Уведомления о восстановлении комментария к товару (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("market_comment_restore")]
		public bool? MarketCommentRestore { get; set; }

		/// <summary>
		/// Уведомления о новом голосе в публичных опросах (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("poll_vote_new")]
		public bool? PollVoteNew { get; set; }

		/// <summary>
		/// Уведомления о вступлении в сообщество (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("group_join")]
		public bool? GroupJoin { get; set; }

		/// <summary>
		/// Уведомления о выходе из сообщества (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("group_leave")]
		public bool? GroupLeave { get; set; }

		/// <summary>
		/// Уведомления об внесении пользователя в чёрный список (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("user_block")]
		public bool? UserBlock { get; set; }

		/// <summary>
		/// Уведомления об исключении пользователя из чёрного списка (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("user_unblock")]
		public bool? UserUnblock { get; set; }

		/// <summary>
		/// Уведомления об изменении настроек (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("group_change_settings")]
		public bool? GroupChangeSettings { get; set; }

		/// <summary>
		/// Уведомления об изменении главной фотографии (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("group_change_photo")]
		public bool? GroupChangePhoto { get; set; }

		/// <summary>
		/// Уведомления об изменении руководства (0 — выключить, 1 — включить). флаг, может принимать значения 1 или 0
		/// </summary>
		[JsonProperty("group_officers_edit")]
		public bool? GroupOfficersEdit { get; set; }
	}
}