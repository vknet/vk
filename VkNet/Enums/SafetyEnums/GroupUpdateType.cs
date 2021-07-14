namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип обновления
	/// </summary>
	public sealed class GroupUpdateType : SafetyEnum<GroupUpdateType>
	{
		/// <summary>
		/// Новое сообщение
		/// </summary>
		public static readonly GroupUpdateType MessageNew = RegisterPossibleValue("message_new");

		/// <summary>
		/// Нажатие на callback кнопку
		/// </summary>
		public static readonly GroupUpdateType MessageEvent = RegisterPossibleValue("message_event");

		/// <summary>
		/// Собеседник печатает
		/// </summary>
		public static readonly GroupUpdateType MessageTypingState = RegisterPossibleValue("message_typing_state");

		/// <summary>
		/// Событие о новой отметке "Мне нравится"
		/// </summary>
		public static readonly GroupUpdateType LikeAdd = RegisterPossibleValue("like_add");

		/// <summary>
		/// Событие о удалении отметки "Мне нравится"
		/// </summary>
		public static readonly GroupUpdateType LikeRemove = RegisterPossibleValue("like_remove");

		/// <summary>
		/// Новое исходящее сообщение
		/// </summary>
		public static readonly GroupUpdateType MessageReply = RegisterPossibleValue("message_reply");

		/// <summary>
		/// Редактирование сообщения
		/// </summary>
		public static readonly GroupUpdateType MessageEdit = RegisterPossibleValue("message_edit");

		/// <summary>
		/// Подписка на сообщения от сообщества
		/// </summary>
		public static readonly GroupUpdateType MessageAllow = RegisterPossibleValue("message_allow");

		/// <summary>
		/// Новый запрет сообщений от сообщества
		/// </summary>
		public static readonly GroupUpdateType MessageDeny = RegisterPossibleValue("message_deny");

		/// <summary>
		/// Добавление фотографии
		/// </summary>
		public static readonly GroupUpdateType PhotoNew = RegisterPossibleValue("photo_new");

		/// <summary>
		/// Добавление комментария к фотографии
		/// </summary>
		public static readonly GroupUpdateType PhotoCommentNew = RegisterPossibleValue("photo_comment_new");

		/// <summary>
		/// Редактирование комментария к фотографии
		/// </summary>
		public static readonly GroupUpdateType PhotoCommentEdit = RegisterPossibleValue("photo_comment_edit");

		/// <summary>
		/// Восстановление комментария к фотографии
		/// </summary>
		public static readonly GroupUpdateType PhotoCommentRestore = RegisterPossibleValue("photo_comment_restore");

		/// <summary>
		/// Удаление комментария к фотографии
		/// </summary>
		public static readonly GroupUpdateType PhotoCommentDelete = RegisterPossibleValue("photo_comment_delete");

		/// <summary>
		/// Добавление аудио
		/// </summary>
		public static readonly GroupUpdateType AudioNew = RegisterPossibleValue("audio_new");

		/// <summary>
		/// Добавление видео
		/// </summary>
		public static readonly GroupUpdateType VideoNew = RegisterPossibleValue("video_new");

		/// <summary>
		/// Добавление комментария к видео
		/// </summary>
		public static readonly GroupUpdateType VideoCommentNew = RegisterPossibleValue("video_comment_new");

		/// <summary>
		/// Редактирование комментария к видео
		/// </summary>
		public static readonly GroupUpdateType VideoCommentEdit = RegisterPossibleValue("video_comment_edit");

		/// <summary>
		/// Восстановление комментария к видео
		/// </summary>
		public static readonly GroupUpdateType VideoCommentRestore = RegisterPossibleValue("video_comment_restore");

		/// <summary>
		/// Удаление комментария к видео
		/// </summary>
		public static readonly GroupUpdateType VideoCommentDelete = RegisterPossibleValue("video_comment_delete");

		/// <summary>
		/// Добавление записи на стене
		/// </summary>
		public static readonly GroupUpdateType WallPostNew = RegisterPossibleValue("wall_post_new");

		/// <summary>
		/// Репост записи на стене
		/// </summary>
		public static readonly GroupUpdateType WallRepost = RegisterPossibleValue("wall_repost");

		/// <summary>
		/// Добавление комментария на стене
		/// </summary>
		public static readonly GroupUpdateType WallReplyNew = RegisterPossibleValue("wall_reply_new");

		/// <summary>
		/// Редактирование комментария на стене
		/// </summary>
		public static readonly GroupUpdateType WallReplyEdit = RegisterPossibleValue("wall_reply_edit");

		/// <summary>
		/// Восстановление комментария на стене
		/// </summary>
		public static readonly GroupUpdateType WallReplyRestore = RegisterPossibleValue("wall_reply_restore");

		/// <summary>
		/// Удаление комментария на стене
		/// </summary>
		public static readonly GroupUpdateType WallReplyDelete = RegisterPossibleValue("wall_reply_delete");

		/// <summary>
		/// Добавление комментария в обсуждении
		/// </summary>
		public static readonly GroupUpdateType BoardPostNew = RegisterPossibleValue("board_post_new");

		/// <summary>
		/// Редактирование комментария в обсуждении
		/// </summary>
		public static readonly GroupUpdateType BoardPostEdit = RegisterPossibleValue("board_post_edit");

		/// <summary>
		/// Восстановление комментария в обсуждении
		/// </summary>
		public static readonly GroupUpdateType BoardPostRestore = RegisterPossibleValue("board_post_restore");

		/// <summary>
		/// Удаление комментария в обсуждении
		/// </summary>
		public static readonly GroupUpdateType BoardPostDelete = RegisterPossibleValue("board_post_delete");

		/// <summary>
		/// Добавление комментария к товару
		/// </summary>
		public static readonly GroupUpdateType MarketCommentNew = RegisterPossibleValue("market_comment_new");

		/// <summary>
		/// Редактирование комментария к товару
		/// </summary>
		public static readonly GroupUpdateType MarketCommentEdit = RegisterPossibleValue("market_comment_edit");

		/// <summary>
		/// Восстановление комментария к товару
		/// </summary>
		public static readonly GroupUpdateType MarketCommentRestore = RegisterPossibleValue("market_comment_restore");

		/// <summary>
		/// Удаление комментария к товару
		/// </summary>
		public static readonly GroupUpdateType MarketCommentDelete = RegisterPossibleValue("market_comment_delete");

		/// <summary>
		/// Удаление участника из группы
		/// </summary>
		public static readonly GroupUpdateType GroupLeave = RegisterPossibleValue("group_leave");

		/// <summary>
		/// Добавление участника или заявки на вступление в сообщество
		/// </summary>
		public static readonly GroupUpdateType GroupJoin = RegisterPossibleValue("group_join");

		/// <summary>
		/// Добавление пользователя в черный список
		/// </summary>
		public static readonly GroupUpdateType UserBlock = RegisterPossibleValue("user_block");

		/// <summary>
		/// Удаление пользователя из черного списка
		/// </summary>
		public static readonly GroupUpdateType UserUnblock = RegisterPossibleValue("user_unblock");

		/// <summary>
		/// Добавление голоса в публичном опросе
		/// </summary>
		public static readonly GroupUpdateType PollVoteNew = RegisterPossibleValue("poll_vote_new");

		/// <summary>
		/// Редактирование списка руководителей
		/// </summary>
		public static readonly GroupUpdateType GroupOfficersEdit = RegisterPossibleValue("group_officers_edit");

		/// <summary>
		/// Изменение главного фото
		/// </summary>
		public static readonly GroupUpdateType GroupChangePhoto = RegisterPossibleValue("group_change_photo");

		/// <summary>
		/// Подтверждение адреса сервера
		/// </summary>
		public static readonly GroupUpdateType Confirmation = RegisterPossibleValue("confirmation");
	}
}