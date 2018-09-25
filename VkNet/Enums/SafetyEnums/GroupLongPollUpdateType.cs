namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип обновления
	/// </summary>
	public class GroupLongPollUpdateType : SafetyEnum<GroupLongPollUpdateType>
	{
		/// <summary>
		/// Новое сообщение
		/// </summary>
		public GroupLongPollUpdateType MessageNew = RegisterPossibleValue("message_new");

		/// <summary>
		/// Новое исходящее сообщение
		/// </summary>
		public GroupLongPollUpdateType MessageReply = RegisterPossibleValue("message_reply"); 

		/// <summary>
		/// Редактирование сообщения
		/// </summary>
		public GroupLongPollUpdateType MessageEdit = RegisterPossibleValue("message_edit"); 

		/// <summary>
		/// Подписка на сообщения от сообщества
		/// </summary>
		public GroupLongPollUpdateType MessageAllow = RegisterPossibleValue("message_allow"); 

		/// <summary>
		/// Новый запрет сообщений от сообщества
		/// </summary>
		public GroupLongPollUpdateType MessageDeny = RegisterPossibleValue("message_deny"); 

		/// <summary>
		/// Добавление фотографии
		/// </summary>
		public GroupLongPollUpdateType PhotoNew = RegisterPossibleValue("photo_new"); 

		/// <summary>
		/// Добавление комментария к фотографии
		/// </summary>
		public GroupLongPollUpdateType PhotoCommentNew = RegisterPossibleValue("photo_comment_new"); 

		/// <summary>
		/// Редактирование комментария к фотографии
		/// </summary>
		public GroupLongPollUpdateType PhotoCommentEdit = RegisterPossibleValue("photo_comment_edit"); 

		/// <summary>
		/// Восстановление комментария к фотографии
		/// </summary>
		public GroupLongPollUpdateType PhotoCommentRestore = RegisterPossibleValue("photo_comment_restore"); 

		/// <summary>
		/// Удаление комментария к фотографии
		/// </summary>
		public GroupLongPollUpdateType PhotoCommentDelete = RegisterPossibleValue("photo_comment_delete"); 

		/// <summary>
		/// Добавление аудио
		/// </summary>
		public GroupLongPollUpdateType AudioNew = RegisterPossibleValue("audio_new"); 

		/// <summary>
		/// Добавление видео
		/// </summary>
		public GroupLongPollUpdateType VideoNew = RegisterPossibleValue("video_new"); 

		/// <summary>
		/// Добавление комментария к видео
		/// </summary>
		public GroupLongPollUpdateType VideoCommentNew = RegisterPossibleValue("video_comment_new"); 

		/// <summary>
		/// Редактирование комментария к видео
		/// </summary>
		public GroupLongPollUpdateType VideoCommentEdit = RegisterPossibleValue("video_comment_edit"); 

		/// <summary>
		/// Восстановление комментария к видео
		/// </summary>
		public GroupLongPollUpdateType VideoCommentRestore = RegisterPossibleValue("video_comment_restore"); 

		/// <summary>
		/// Удаление комментария к видео
		/// </summary>
		public GroupLongPollUpdateType VideoCommentDelete = RegisterPossibleValue("video_comment_delete"); 

		/// <summary>
		/// Добавление записи на стене
		/// </summary>
		public GroupLongPollUpdateType WallPostNew = RegisterPossibleValue("wall_post_new"); 

		/// <summary>
		/// Репост записи на стене
		/// </summary>
		public GroupLongPollUpdateType WallRepost = RegisterPossibleValue("wall_repost"); 

		/// <summary>
		/// Добавление комментария на стене
		/// </summary>
		public GroupLongPollUpdateType WallReplyNew = RegisterPossibleValue("wall_reply_new"); 

		/// <summary>
		/// Редактирование комментария на стене
		/// </summary>
		public GroupLongPollUpdateType WallReplyEdit = RegisterPossibleValue("wall_reply_edit"); 

		/// <summary>
		/// Восстановление комментария на стене
		/// </summary>
		public GroupLongPollUpdateType WallReplyRestore = RegisterPossibleValue("wall_reply_restore"); 

		/// <summary>
		/// Удаление комментария на стене
		/// </summary>
		public GroupLongPollUpdateType WallReplyDelete = RegisterPossibleValue("wall_reply_delete"); 

		/// <summary>
		/// Добавление комментария в обсуждении
		/// </summary>
		public GroupLongPollUpdateType BoardPostNew = RegisterPossibleValue("board_post_new"); 

		/// <summary>
		/// Редактирование комментария в обсуждении
		/// </summary>
		public GroupLongPollUpdateType BoardPostEdit = RegisterPossibleValue("board_post_edit"); 

		/// <summary>
		/// Восстановление комментария в обсуждении
		/// </summary>
		public GroupLongPollUpdateType BoardPostRestore = RegisterPossibleValue("board_post_restore"); 

		/// <summary>
		/// Удаление комментария в обсуждении
		/// </summary>
		public GroupLongPollUpdateType BoardPostDelete = RegisterPossibleValue("board_post_delete"); 

		/// <summary>
		/// Добавление комментария к товару
		/// </summary>
		public GroupLongPollUpdateType MarketCommentNew = RegisterPossibleValue("market_comment_new"); 

		/// <summary>
		/// Редактирование комментария к товару
		/// </summary>
		public GroupLongPollUpdateType MarketCommentEdit = RegisterPossibleValue("market_comment_edit"); 

		/// <summary>
		/// Восстановление комментария к товару
		/// </summary>
		public GroupLongPollUpdateType MarketCommentRestore = RegisterPossibleValue("market_comment_restore"); 

		/// <summary>
		/// Удаление комментария к товару
		/// </summary>
		public GroupLongPollUpdateType MarketCommentDelete = RegisterPossibleValue("market_comment_delete"); 

		/// <summary>
		/// Удаление участника из группы
		/// </summary>
		public GroupLongPollUpdateType GroupLeave = RegisterPossibleValue("group_leave"); 

		/// <summary>
		/// Добавление участника или заявки на вступление в сообщество
		/// </summary>
		public GroupLongPollUpdateType GroupJoin = RegisterPossibleValue("group_join"); 

		/// <summary>
		/// Добавление пользователя в черный список
		/// </summary>
		public GroupLongPollUpdateType UserBlock = RegisterPossibleValue("user_block"); 

		/// <summary>
		/// Удаление пользователя из черного списка
		/// </summary>
		public GroupLongPollUpdateType UserUnblock = RegisterPossibleValue("user_unblock"); 

		/// <summary>
		/// Добавление голоса в публичном опросе
		/// </summary>
		public GroupLongPollUpdateType PollVoteNew = RegisterPossibleValue("poll_vote_new"); 

		/// <summary>
		/// Редактирование списка руководителей
		/// </summary>
		public GroupLongPollUpdateType GroupOfficersEdit = RegisterPossibleValue("group_officers_edit"); 

		/// <summary>
		/// Изменение главного фото
		/// </summary>
		public GroupLongPollUpdateType GroupChangePhoto = RegisterPossibleValue("group_change_photo"); 
	}
}