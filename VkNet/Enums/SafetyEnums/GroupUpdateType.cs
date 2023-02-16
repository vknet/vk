using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип обновления
/// </summary>
[Obsolete("Типы обновлений теперь проверяются в GroupUpdate")]
public sealed class GroupUpdateType : SafetyEnum<GroupUpdateType>
{
	/// <summary>
	/// Новое сообщение
	/// </summary>
	[EnumMember(Value = "message_new")]
	public static readonly GroupUpdateType MessageNew = RegisterPossibleValue("message_new");

	/// <summary>
	/// Нажатие на callback кнопку
	/// </summary>
	[EnumMember(Value = "message_event")]
	public static readonly GroupUpdateType MessageEvent = RegisterPossibleValue("message_event");

	/// <summary>
	/// Собеседник печатает
	/// </summary>
	[EnumMember(Value = "message_typing_state")]
	public static readonly GroupUpdateType MessageTypingState = RegisterPossibleValue("message_typing_state");

	/// <summary>
	/// Событие о новой отметке "Мне нравится"
	/// </summary>
	[EnumMember(Value = "like_add")]
	public static readonly GroupUpdateType LikeAdd = RegisterPossibleValue("like_add");

	/// <summary>
	/// Событие о удалении отметки "Мне нравится"
	/// </summary>
	[EnumMember(Value = "like_remove")]
	public static readonly GroupUpdateType LikeRemove = RegisterPossibleValue("like_remove");

	/// <summary>
	/// Платёж через VK Pay
	/// </summary>
	[EnumMember(Value = "vkpay_transaction")]
	public static readonly GroupUpdateType VkPayTransaction = RegisterPossibleValue("vkpay_transaction");

	/// <summary>
	/// Событие о изменении настроек сообщества
	/// </summary>
	[EnumMember(Value = "group_change_settings")]
	public static readonly GroupUpdateType GroupChangeSettings = RegisterPossibleValue("group_change_settings");

	/// <summary>
	/// Новое исходящее сообщение
	/// </summary>
	[EnumMember(Value = "message_reply")]
	public static readonly GroupUpdateType MessageReply = RegisterPossibleValue("message_reply");

	/// <summary>
	/// Редактирование сообщения
	/// </summary>
	[EnumMember(Value = "message_edit")]
	public static readonly GroupUpdateType MessageEdit = RegisterPossibleValue("message_edit");

	/// <summary>
	/// Подписка на сообщения от сообщества
	/// </summary>
	[EnumMember(Value = "message_allow")]
	public static readonly GroupUpdateType MessageAllow = RegisterPossibleValue("message_allow");

	/// <summary>
	/// Новый запрет сообщений от сообщества
	/// </summary>
	[EnumMember(Value = "message_deny")]
	public static readonly GroupUpdateType MessageDeny = RegisterPossibleValue("message_deny");

	/// <summary>
	/// Добавление фотографии
	/// </summary>
	[EnumMember(Value = "photo_new")]
	public static readonly GroupUpdateType PhotoNew = RegisterPossibleValue("photo_new");

	/// <summary>
	/// Добавление комментария к фотографии
	/// </summary>
	[EnumMember(Value = "photo_comment_new")]
	public static readonly GroupUpdateType PhotoCommentNew = RegisterPossibleValue("photo_comment_new");

	/// <summary>
	/// Редактирование комментария к фотографии
	/// </summary>
	[EnumMember(Value = "photo_comment_edit")]
	public static readonly GroupUpdateType PhotoCommentEdit = RegisterPossibleValue("photo_comment_edit");

	/// <summary>
	/// Восстановление комментария к фотографии
	/// </summary>
	[EnumMember(Value = "photo_comment_restore")]
	public static readonly GroupUpdateType PhotoCommentRestore = RegisterPossibleValue("photo_comment_restore");

	/// <summary>
	/// Удаление комментария к фотографии
	/// </summary>
	[EnumMember(Value = "photo_comment_delete")]
	public static readonly GroupUpdateType PhotoCommentDelete = RegisterPossibleValue("photo_comment_delete");

	/// <summary>
	/// Добавление аудио
	/// </summary>
	[EnumMember(Value = "audio_new")]
	public static readonly GroupUpdateType AudioNew = RegisterPossibleValue("audio_new");

	/// <summary>
	/// Добавление видео
	/// </summary>
	[EnumMember(Value = "video_new")]
	public static readonly GroupUpdateType VideoNew = RegisterPossibleValue("video_new");

	/// <summary>
	/// Добавление комментария к видео
	/// </summary>
	[EnumMember(Value = "video_comment_new")]
	public static readonly GroupUpdateType VideoCommentNew = RegisterPossibleValue("video_comment_new");

	/// <summary>
	/// Редактирование комментария к видео
	/// </summary>
	[EnumMember(Value = "video_comment_edit")]
	public static readonly GroupUpdateType VideoCommentEdit = RegisterPossibleValue("video_comment_edit");

	/// <summary>
	/// Восстановление комментария к видео
	/// </summary>
	[EnumMember(Value = "video_comment_restore")]
	public static readonly GroupUpdateType VideoCommentRestore = RegisterPossibleValue("video_comment_restore");

	/// <summary>
	/// Удаление комментария к видео
	/// </summary>
	[EnumMember(Value = "video_comment_delete")]
	public static readonly GroupUpdateType VideoCommentDelete = RegisterPossibleValue("video_comment_delete");

	/// <summary>
	/// Добавление записи на стене
	/// </summary>
	[EnumMember(Value = "wall_post_new")]
	public static readonly GroupUpdateType WallPostNew = RegisterPossibleValue("wall_post_new");

	/// <summary>
	/// Репост записи на стене
	/// </summary>
	[EnumMember(Value = "wall_repost")]
	public static readonly GroupUpdateType WallRepost = RegisterPossibleValue("wall_repost");

	/// <summary>
	/// Добавление комментария на стене
	/// </summary>
	[EnumMember(Value = "wall_reply_new")]
	public static readonly GroupUpdateType WallReplyNew = RegisterPossibleValue("wall_reply_new");

	/// <summary>
	/// Редактирование комментария на стене
	/// </summary>
	[EnumMember(Value = "wall_reply_edit")]
	public static readonly GroupUpdateType WallReplyEdit = RegisterPossibleValue("wall_reply_edit");

	/// <summary>
	/// Восстановление комментария на стене
	/// </summary>
	[EnumMember(Value = "wall_reply_restore")]
	public static readonly GroupUpdateType WallReplyRestore = RegisterPossibleValue("wall_reply_restore");

	/// <summary>
	/// Удаление комментария на стене
	/// </summary>
	[EnumMember(Value = "wall_reply_delete")]
	public static readonly GroupUpdateType WallReplyDelete = RegisterPossibleValue("wall_reply_delete");

	/// <summary>
	/// Добавление комментария в обсуждении
	/// </summary>
	[EnumMember(Value = "board_post_new")]
	public static readonly GroupUpdateType BoardPostNew = RegisterPossibleValue("board_post_new");

	/// <summary>
	/// Редактирование комментария в обсуждении
	/// </summary>
	[EnumMember(Value = "board_post_edit")]
	public static readonly GroupUpdateType BoardPostEdit = RegisterPossibleValue("board_post_edit");

	/// <summary>
	/// Восстановление комментария в обсуждении
	/// </summary>
	[EnumMember(Value = "board_post_restore")]
	public static readonly GroupUpdateType BoardPostRestore = RegisterPossibleValue("board_post_restore");

	/// <summary>
	/// Удаление комментария в обсуждении
	/// </summary>
	[EnumMember(Value = "board_post_delete")]
	public static readonly GroupUpdateType BoardPostDelete = RegisterPossibleValue("board_post_delete");

	/// <summary>
	/// Добавление комментария к товару
	/// </summary>
	[EnumMember(Value = "market_comment_new")]
	public static readonly GroupUpdateType MarketCommentNew = RegisterPossibleValue("market_comment_new");

	/// <summary>
	/// Редактирование комментария к товару
	/// </summary>
	[EnumMember(Value = "market_comment_edit")]
	public static readonly GroupUpdateType MarketCommentEdit = RegisterPossibleValue("market_comment_edit");

	/// <summary>
	/// Восстановление комментария к товару
	/// </summary>
	[EnumMember(Value = "market_comment_restore")]
	public static readonly GroupUpdateType MarketCommentRestore = RegisterPossibleValue("market_comment_restore");

	/// <summary>
	/// Удаление комментария к товару
	/// </summary>
	[EnumMember(Value = "market_comment_delete")]
	public static readonly GroupUpdateType MarketCommentDelete = RegisterPossibleValue("market_comment_delete");

	/// <summary>
	/// Удаление участника из группы
	/// </summary>
	[EnumMember(Value = "group_leave")]
	public static readonly GroupUpdateType GroupLeave = RegisterPossibleValue("group_leave");

	/// <summary>
	/// Добавление участника или заявки на вступление в сообщество
	/// </summary>
	[EnumMember(Value = "group_join")]
	public static readonly GroupUpdateType GroupJoin = RegisterPossibleValue("group_join");

	/// <summary>
	/// Добавление пользователя в черный список
	/// </summary>
	[EnumMember(Value = "user_block")]
	public static readonly GroupUpdateType UserBlock = RegisterPossibleValue("user_block");

	/// <summary>
	/// Удаление пользователя из черного списка
	/// </summary>
	[EnumMember(Value = "user_unblock")]
	public static readonly GroupUpdateType UserUnblock = RegisterPossibleValue("user_unblock");

	/// <summary>
	/// Добавление голоса в публичном опросе
	/// </summary>
	[EnumMember(Value = "poll_vote_new")]
	public static readonly GroupUpdateType PollVoteNew = RegisterPossibleValue("poll_vote_new");

	/// <summary>
	/// Редактирование списка руководителей
	/// </summary>
	[EnumMember(Value = "group_officers_edit")]
	public static readonly GroupUpdateType GroupOfficersEdit = RegisterPossibleValue("group_officers_edit");

	/// <summary>
	/// Изменение главного фото
	/// </summary>
	[EnumMember(Value = "group_change_photo")]
	public static readonly GroupUpdateType GroupChangePhoto = RegisterPossibleValue("group_change_photo");

	/// <summary>
	/// Подтверждение адреса сервера
	/// </summary>
	[EnumMember(Value = "confirmation")]
	public static readonly GroupUpdateType Confirmation = RegisterPossibleValue("confirmation");

	/// <summary>
	/// Cоздание подписки
	/// </summary>
	[EnumMember(Value = "donut_subscription_create")]
	public static readonly GroupUpdateType DonutSubscriptionCreate = RegisterPossibleValue("donut_subscription_create");

	/// <summary>
	/// Продление подписки
	/// </summary>
	[EnumMember(Value = "donut_subscription_prolonged")]
	public static readonly GroupUpdateType DonutSubscriptionProlonged = RegisterPossibleValue("donut_subscription_prolonged");

	/// <summary>
	/// Подписка истекла
	/// </summary>
	[EnumMember(Value = "donut_subscription_expired")]
	public static readonly GroupUpdateType DonutSubscriptionExpired = RegisterPossibleValue("donut_subscription_expired");

	/// <summary>
	/// Отмена подписки
	/// </summary>
	[EnumMember(Value = "donut_subscription_cancelled")]
	public static readonly GroupUpdateType DonutSubscriptionCanceled = RegisterPossibleValue("donut_subscription_cancelled");

	/// <summary>
	/// Изменение стоимости подписки
	/// </summary>
	[EnumMember(Value = "donut_subscription_price_changed")]
	public static readonly GroupUpdateType DonutSubscriptionPriceChanged = RegisterPossibleValue("donut_subscription_price_changed");

	/// <summary>
	/// Вывод денег
	/// </summary>
	[EnumMember(Value = "donut_money_withdraw")]
	public static readonly GroupUpdateType DonutMoneyWithdraw = RegisterPossibleValue("donut_money_withdraw");

	/// <summary>
	/// Ошибка вывода денег
	/// </summary>
	[EnumMember(Value = "donut_money_withdraw_error")]
	public static readonly GroupUpdateType DonutMoneyWithdrawError = RegisterPossibleValue("donut_money_withdraw_error");
}