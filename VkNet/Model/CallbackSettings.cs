using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Настройки уведомлений в формате «название события» : «статус»
	/// ( 0 — уведомления о событии выключены, 1 — уведомления о событии включены).
	/// </summary>
	[Serializable]
	public class CallbackSettings
	{
		#region Messages
		/// <summary>
		/// новое сообщение
		/// </summary>
		[JsonProperty(propertyName: "message_new")]
		public bool? MessageNew { get; set; }

		/// <summary>
		/// новое исходящее сообщение
		/// </summary>
		[JsonProperty(propertyName: "message_reply")]
		public bool? MessageReply { get; set; }

		/// <summary>
		/// редактирование сообщения
		/// </summary>
		[JsonProperty(propertyName: "message_edit")]
		public bool? MessageEdit { get; set; }

		/// <summary>
		/// новая подписка на сообщения
		/// </summary>
		[JsonProperty(propertyName: "message_allow")]
		public bool? MessageAllow { get; set; }

		/// <summary>
		/// новый запрет сообщений
		/// </summary>
		[JsonProperty(propertyName: "message_deny")]
		public bool? MessageDeny { get; set; }

		/// <summary>
		/// статус набора текста
		/// </summary>
		[JsonProperty(propertyName: "message_typing_state")]
		public bool? MessageTyping { get; set; }
		#endregion

		#region Photo
		/// <summary>
		/// добавление новой фотографии
		/// </summary>
		[JsonProperty(propertyName: "photo_new")]
		public bool? PhotoNew { get; set; }

		/// <summary>
		/// добавление нового комментария к фото
		/// </summary>
		[JsonProperty(propertyName: "photo_comment_new")]
		public bool? PhotoCommentNew { get; set; }

		/// <summary>
		/// редактирование комментария к фото
		/// </summary>
		[JsonProperty(propertyName: "photo_comment_edit")]
		public bool? PhotoCommentEdit { get; set; }

		/// <summary>
		/// удаление комментария к фото
		/// </summary>
		[JsonProperty(propertyName: "photo_comment_delete")]
		public bool? PhotoCommentDelete { get; set; }

		/// <summary>
		/// восстановление комментария к фото
		/// </summary>
		[JsonProperty(propertyName: "photo_comment_restore")]
		public bool? PhotoCommentRestore { get; set; }
		#endregion

		#region Audio
		/// <summary>
		/// добавление новой аудиозаписи
		/// </summary>
		[JsonProperty(propertyName: "audio_new")]
		public bool? AudioNew { get; set; }
		#endregion

		#region Video
		/// <summary>
		/// добавление новой видеозаписи
		/// </summary>
		[JsonProperty(propertyName: "video_new")]
		public bool? VideoNew { get; set; }

		/// <summary>
		/// добавление нового комментария к видео
		/// </summary>
		[JsonProperty(propertyName: "video_comment_new")]
		public bool? VideoCommentNew { get; set; }

		/// <summary>
		/// редактирование комментария к видео
		/// </summary>
		[JsonProperty(propertyName: "video_comment_edit")]
		public bool? VideoCommentEdit { get; set; }

		/// <summary>
		/// удаление комментария к видео
		/// </summary>
		[JsonProperty(propertyName: "video_comment_delete")]
		public bool? VideoCommentDelete { get; set; }

		/// <summary>
		/// восстановление комментария к видео
		/// </summary>
		[JsonProperty(propertyName: "video_comment_restore")]
		public bool? VideoCommentRestore { get; set; }
		#endregion

		#region Wall
		/// <summary>
		/// добавление новой записи на стене
		/// </summary>
		[JsonProperty(propertyName: "wall_post_new")]
		public bool? WallPostNew { get; set; }

		/// <summary>
		/// новый репост записи на стене
		/// </summary>
		[JsonProperty(propertyName: "wall_repost")]
		public bool? WallRepost { get; set; }
		#endregion

		#region Wall Comments
		/// <summary>
		/// добавление нового комментария на стене
		/// </summary>
		[JsonProperty(propertyName: "wall_reply_new")]
		public bool? WallReplyNew { get; set; }

		/// <summary>
		/// редактирование комментария на стене
		/// </summary>
		[JsonProperty(propertyName: "wall_reply_edit")]
		public bool? WallReplyEdit { get; set; }

		/// <summary>
		/// удаление комментария на стене
		/// </summary>
		[JsonProperty(propertyName: "wall_reply_delete")]
		public bool? WallReplyDelete { get; set; }

		/// <summary>
		/// восстановление комментария на стене
		/// </summary>
		[JsonProperty(propertyName: "wall_reply_restore")]
		public bool? WallReplyRestore { get; set; }
		#endregion

		#region Board
		/// <summary>
		/// добавление нового комментария в обсуждении
		/// </summary>
		[JsonProperty(propertyName: "board_post_new")]
		public bool? BoardPostNew { get; set; }

		/// <summary>
		/// редактирование комментария в обсуждении
		/// </summary>
		[JsonProperty(propertyName: "board_post_edit")]
		public bool? BoardPostEdit { get; set; }

		/// <summary>
		/// удаление комментария в обсуждении
		/// </summary>
		[JsonProperty(propertyName: "board_post_delete")]
		public bool? BoardPostDelete { get; set; }

		/// <summary>
		/// восстановление комментария в обсуждении
		/// </summary>
		[JsonProperty(propertyName: "board_post_restore")]
		public bool? BoardPostRestore { get; set; }
		#endregion

		#region Market
		/// <summary>
		/// добавление нового комментария к товару
		/// </summary>
		[JsonProperty(propertyName: "market_comment_new")]
		public bool? MarketCommentNew { get; set; }

		/// <summary>
		/// редактирование комментария к товару
		/// </summary>
		[JsonProperty(propertyName: "market_comment_edit")]
		public bool? MarketCommentEdit { get; set; }

		/// <summary>
		/// удаление комментария к товару
		/// </summary>
		[JsonProperty(propertyName: "market_comment_delete")]
		public bool? MarketCommentDelete { get; set; }

		/// <summary>
		/// восстановление удалённого комментария к товару
		/// </summary>
		[JsonProperty(propertyName: "market_comment_restore")]
		public bool? MarketCommentRestore { get; set; }
		#endregion

		#region Users
		/// <summary>
		/// вступление в сообщество
		/// </summary>
		[JsonProperty(propertyName: "group_join")]
		public bool? GroupJoin { get; set; }

		/// <summary>
		/// выход участника из сообщества
		/// </summary>
		[JsonProperty(propertyName: "group_leave")]
		public bool? GroupLeave { get; set; }

		/// <summary>
		/// занесение пользователя в черный список
		/// </summary>
		[JsonProperty(propertyName: "user_block")]
		public bool? UserBlock { get; set; }

		/// <summary>
		/// удаление пользователя из черного списка
		/// </summary>
		[JsonProperty(propertyName: "user_unblock")]
		public bool? UserUnblock { get; set; }
		#endregion

		#region Other
		/// <summary>
		/// изменение настроек сообщества
		/// </summary>
		[JsonProperty(propertyName: "group_change_settings")]
		public bool? GroupChangeSettings { get; set; }

		/// <summary>
		/// новый голос в публичном опросе
		/// </summary>
		[JsonProperty(propertyName: "poll_vote_new")]
		public bool? PollVoteNew { get; set; }

		/// <summary>
		/// изменение главной фотографии
		/// </summary>
		[JsonProperty(propertyName: "group_change_photo")]
		public bool? GroupChangePhoto { get; set; }

		/// <summary>
		/// изменение руководства сообщества
		/// </summary>
		[JsonProperty(propertyName: "group_officers_edit")]
		public bool? GroupOfficersEdit { get; set; }

		/// <summary>
		/// платёж через Vk Pay
		/// </summary>
		[JsonProperty(propertyName: "vkpay_transaction")]
		public bool? VkPayTransaction { get; set; }

		/// <summary>
		/// событие от Vk Apps
		/// </summary>
		[JsonProperty(propertyName: "app_payload")]
		public bool? VkAppEvent { get; set; }
		#endregion

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static CallbackSettings FromJson(VkResponse response)
		{
			return new CallbackSettings
			{
				MessageNew = response[key: "message_new"],
				MessageReply = response[key: "message_reply"],
				MessageEdit = response[key: "message_edit"],
				MessageAllow = response[key: "message_allow"],
				MessageDeny = response[key: "message_deny"],
				MessageTyping = response[key: "message_typing_state"],

				PhotoNew = response[key: "photo_new"],
				PhotoCommentNew = response[key: "photo_comment_new"],
				PhotoCommentEdit = response[key: "photo_comment_edit"],
				PhotoCommentDelete = response[key: "photo_comment_delete"],
				PhotoCommentRestore = response[key: "photo_comment_restore"],

				AudioNew = response[key: "audio_new"],

				VideoNew = response[key: "video_new"],
				VideoCommentNew = response[key: "video_comment_new"],
				VideoCommentEdit = response[key: "video_comment_edit"],
				VideoCommentDelete = response[key: "video_comment_delete"],
				VideoCommentRestore = response[key: "video_comment_restore"],

				WallPostNew = response[key: "wall_post_new"],
				WallRepost = response[key: "wall_repost"],

				WallReplyNew = response[key: "wall_reply_new"],
				WallReplyEdit = response[key: "wall_reply_edit"],
				WallReplyDelete = response[key: "wall_reply_delete"],
				WallReplyRestore = response[key: "wall_reply_restore"],

				BoardPostNew = response[key: "board_post_new"],
				BoardPostEdit = response[key: "board_post_edit"],
				BoardPostDelete = response[key: "board_post_delete"],
				BoardPostRestore = response[key: "board_post_restore"],

				MarketCommentNew = response[key: "market_comment_new"],
				MarketCommentEdit = response[key: "market_comment_edit"],
				MarketCommentDelete = response[key: "market_comment_delete"],
				MarketCommentRestore = response[key: "market_comment_restore"],

				GroupJoin = response[key: "group_join"],
				GroupLeave = response[key: "group_leave"],
				UserBlock = response[key: "user_block"],
				UserUnblock = response[key: "user_unblock"],

				GroupChangeSettings = response[key: "group_change_settings"],
				PollVoteNew = response[key: "poll_vote_new"],
				GroupChangePhoto = response[key: "group_change_photo"],
				GroupOfficersEdit = response[key: "group_officers_edit"],
				VkPayTransaction = response[key: "vkpay_transaction"],
				VkAppEvent = response[key: "app_payload"]
			};
		}
	}
}