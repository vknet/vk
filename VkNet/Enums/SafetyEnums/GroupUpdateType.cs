namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип обновления
	/// </summary>
	public class GroupUpdateType : SafetyEnum<GroupUpdateType>
	{
		/// <summary>
		/// Новое сообщение
		/// </summary>
		public GroupUpdateType MessageNew = RegisterPossibleValue("message_new");

		/// <summary>
		/// Новое исходящее сообщение
		/// </summary>
		public GroupUpdateType MessageReply = RegisterPossibleValue("message_reply"); 

		/// <summary>
		/// Редактирование сообщения
		/// </summary>
		public GroupUpdateType MessageEdit = RegisterPossibleValue("message_edit"); 

		/// <summary>
		/// Подписка на сообщения от сообщества
		/// </summary>
		public GroupUpdateType MessageAllow = RegisterPossibleValue("message_allow"); 

		/// <summary>
		/// Новый запрет сообщений от сообщества
		/// </summary>
		public GroupUpdateType MessageDeny = RegisterPossibleValue("message_deny"); 

		/// <summary>
		/// Добавление фотографии
		/// </summary>
		public GroupUpdateType PhotoNew = RegisterPossibleValue("photo_new"); 

		/// <summary>
		/// Добавление комментария к фотографии
		/// </summary>
		public GroupUpdateType PhotoCommentNew = RegisterPossibleValue("photo_comment_new"); 

		/// <summary>
		/// Редактирование комментария к фотографии
		/// </summary>
		public GroupUpdateType PhotoCommentEdit = RegisterPossibleValue("photo_comment_edit"); 

		/// <summary>
		/// Восстановление комментария к фотографии
		/// </summary>
		public GroupUpdateType PhotoCommentRestore = RegisterPossibleValue("photo_comment_restore"); 

		/// <summary>
		/// Удаление комментария к фотографии
		/// </summary>
		public GroupUpdateType PhotoCommentDelete = RegisterPossibleValue("photo_comment_delete"); 

		/// <summary>
		/// Добавление аудио
		/// </summary>
		public GroupUpdateType AudioNew = RegisterPossibleValue("audio_new"); 

		/// <summary>
		/// Добавление видео
		/// </summary>
		public GroupUpdateType VideoNew = RegisterPossibleValue("video_new"); 

		/// <summary>
		/// Добавление комментария к видео
		/// </summary>
		public GroupUpdateType VideoCommentNew = RegisterPossibleValue("video_comment_new"); 

		/// <summary>
		/// Редактирование комментария к видео
		/// </summary>
		public GroupUpdateType VideoCommentEdit = RegisterPossibleValue("video_comment_edit"); 

		/// <summary>
		/// Восстановление комментария к видео
		/// </summary>
		public GroupUpdateType VideoCommentRestore = RegisterPossibleValue("video_comment_restore"); 

		/// <summary>
		/// Удаление комментария к видео
		/// </summary>
		public GroupUpdateType VideoCommentDelete = RegisterPossibleValue("video_comment_delete"); 

		/// <summary>
		/// Добавление записи на стене
		/// </summary>
		public GroupUpdateType WallPostNew = RegisterPossibleValue("wall_post_new"); 

		/// <summary>
		/// Репост записи на стене
		/// </summary>
		public GroupUpdateType WallRepost = RegisterPossibleValue("wall_repost"); 

		/// <summary>
		/// Добавление комментария на стене
		/// </summary>
		public GroupUpdateType WallReplyNew = RegisterPossibleValue("wall_reply_new"); 

		/// <summary>
		/// Редактирование комментария на стене
		/// </summary>
		public GroupUpdateType WallReplyEdit = RegisterPossibleValue("wall_reply_edit"); 

		/// <summary>
		/// Восстановление комментария на стене
		/// </summary>
		public GroupUpdateType WallReplyRestore = RegisterPossibleValue("wall_reply_restore"); 

		/// <summary>
		/// Удаление комментария на стене
		/// </summary>
		public GroupUpdateType WallReplyDelete = RegisterPossibleValue("wall_reply_delete"); 

		/// <summary>
		/// Добавление комментария в обсуждении
		/// </summary>
		public GroupUpdateType BoardPostNew = RegisterPossibleValue("board_post_new"); 

		/// <summary>
		/// Редактирование комментария в обсуждении
		/// </summary>
		public GroupUpdateType BoardPostEdit = RegisterPossibleValue("board_post_edit"); 

		/// <summary>
		/// Восстановление комментария в обсуждении
		/// </summary>
		public GroupUpdateType BoardPostRestore = RegisterPossibleValue("board_post_restore"); 

		/// <summary>
		/// Удаление комментария в обсуждении
		/// </summary>
		public GroupUpdateType BoardPostDelete = RegisterPossibleValue("board_post_delete"); 

		/// <summary>
		/// Добавление комментария к товару
		/// </summary>
		public GroupUpdateType MarketCommentNew = RegisterPossibleValue("market_comment_new"); 

		/// <summary>
		/// Редактирование комментария к товару
		/// </summary>
		public GroupUpdateType MarketCommentEdit = RegisterPossibleValue("market_comment_edit"); 

		/// <summary>
		/// Восстановление комментария к товару
		/// </summary>
		public GroupUpdateType MarketCommentRestore = RegisterPossibleValue("market_comment_restore"); 

		/// <summary>
		/// Удаление комментария к товару
		/// </summary>
		public GroupUpdateType MarketCommentDelete = RegisterPossibleValue("market_comment_delete"); 

		/// <summary>
		/// Удаление участника из группы
		/// </summary>
		public GroupUpdateType GroupLeave = RegisterPossibleValue("group_leave"); 

		/// <summary>
		/// Добавление участника или заявки на вступление в сообщество
		/// </summary>
		public GroupUpdateType GroupJoin = RegisterPossibleValue("group_join"); 

		/// <summary>
		/// Добавление пользователя в черный список
		/// </summary>
		public GroupUpdateType UserBlock = RegisterPossibleValue("user_block"); 

		/// <summary>
		/// Удаление пользователя из черного списка
		/// </summary>
		public GroupUpdateType UserUnblock = RegisterPossibleValue("user_unblock"); 

		/// <summary>
		/// Добавление голоса в публичном опросе
		/// </summary>
		public GroupUpdateType PollVoteNew = RegisterPossibleValue("poll_vote_new"); 

		/// <summary>
		/// Редактирование списка руководителей
		/// </summary>
		public GroupUpdateType GroupOfficersEdit = RegisterPossibleValue("group_officers_edit"); 

		/// <summary>
		/// Изменение главного фото
		/// </summary>
		public GroupUpdateType GroupChangePhoto = RegisterPossibleValue("group_change_photo"); 
	}
}