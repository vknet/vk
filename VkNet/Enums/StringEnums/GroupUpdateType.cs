using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип обновления
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum GroupUpdateType
{
	/// <summary>
	/// Новое сообщение
	/// </summary>
	MessageNew,

	/// <summary>
	/// Нажатие на callback кнопку
	/// </summary>
	MessageEvent,

	/// <summary>
	/// Собеседник печатает
	/// </summary>
	MessageTypingState,

	/// <summary>
	/// Событие о новой отметке "Мне нравится"
	/// </summary>
	LikeAdd,

	/// <summary>
	/// Событие о удалении отметки "Мне нравится"
	/// </summary>
	LikeRemove,

	/// <summary>
	/// Платёж через VK Pay
	/// </summary>
	VkpayTransaction,

	/// <summary>
	/// Событие о изменении настроек сообщества
	/// </summary>
	GroupChangeSettings,

	/// <summary>
	/// Новое исходящее сообщение
	/// </summary>
	MessageReply,

	/// <summary>
	/// Редактирование сообщения
	/// </summary>
	MessageEdit,

	/// <summary>
	/// Подписка на сообщения от сообщества
	/// </summary>
	MessageAllow,

	/// <summary>
	/// Новый запрет сообщений от сообщества
	/// </summary>
	MessageDeny,

	/// <summary>
	/// Добавление фотографии
	/// </summary>
	PhotoNew,

	/// <summary>
	/// Добавление комментария к фотографии
	/// </summary>
	PhotoCommentNew,

	/// <summary>
	/// Редактирование комментария к фотографии
	/// </summary>
	PhotoCommentEdit,

	/// <summary>
	/// Восстановление комментария к фотографии
	/// </summary>
	PhotoCommentRestore,

	/// <summary>
	/// Удаление комментария к фотографии
	/// </summary>
	PhotoCommentDelete,

	/// <summary>
	/// Добавление аудио
	/// </summary>
	AudioNew,

	/// <summary>
	/// Добавление видео
	/// </summary>
	VideoNew,

	/// <summary>
	/// Добавление комментария к видео
	/// </summary>
	VideoCommentNew,

	/// <summary>
	/// Редактирование комментария к видео
	/// </summary>
	VideoCommentEdit,

	/// <summary>
	/// Восстановление комментария к видео
	/// </summary>
	VideoCommentRestore,

	/// <summary>
	/// Удаление комментария к видео
	/// </summary>
	VideoCommentDelete,

	/// <summary>
	/// Добавление записи на стене
	/// </summary>
	WallPostNew,

	/// <summary>
	/// Репост записи на стене
	/// </summary>
	WallRepost,

	/// <summary>
	/// Добавление комментария на стене
	/// </summary>
	WallReplyNew,

	/// <summary>
	/// Редактирование комментария на стене
	/// </summary>
	WallReplyEdit,

	/// <summary>
	/// Восстановление комментария на стене
	/// </summary>
	WallReplyRestore,

	/// <summary>
	/// Удаление комментария на стене
	/// </summary>
	WallReplyDelete,

	/// <summary>
	/// Добавление комментария в обсуждении
	/// </summary>
	BoardPostNew,

	/// <summary>
	/// Редактирование комментария в обсуждении
	/// </summary>
	BoardPostEdit,

	/// <summary>
	/// Восстановление комментария в обсуждении
	/// </summary>
	BoardPostRestore,

	/// <summary>
	/// Удаление комментария в обсуждении
	/// </summary>
	BoardPostDelete,

	/// <summary>
	/// Добавление комментария к товару
	/// </summary>
	MarketCommentNew,

	/// <summary>
	/// Редактирование комментария к товару
	/// </summary>
	MarketCommentEdit,

	/// <summary>
	/// Восстановление комментария к товару
	/// </summary>
	MarketCommentRestore,

	/// <summary>
	/// Удаление комментария к товару
	/// </summary>
	MarketCommentDelete,

	/// <summary>
	/// Удаление участника из группы
	/// </summary>
	GroupLeave,

	/// <summary>
	/// Добавление участника или заявки на вступление в сообщество
	/// </summary>
	GroupJoin,

	/// <summary>
	/// Добавление пользователя в черный список
	/// </summary>
	UserBlock,

	/// <summary>
	/// Удаление пользователя из черного списка
	/// </summary>
	UserUnblock,

	/// <summary>
	/// Добавление голоса в публичном опросе
	/// </summary>
	PollVoteNew,

	/// <summary>
	/// Редактирование списка руководителей
	/// </summary>
	GroupOfficersEdit,

	/// <summary>
	/// Изменение главного фото
	/// </summary>
	GroupChangePhoto,

	/// <summary>
	/// Подтверждение адреса сервера
	/// </summary>
	Confirmation,

	/// <summary>
	/// Cоздание подписки
	/// </summary>
	DonutSubscriptionCreate,

	/// <summary>
	/// Продление подписки
	/// </summary>
	DonutSubscriptionProlonged,

	/// <summary>
	/// Подписка истекла
	/// </summary>
	DonutSubscriptionExpired,

	/// <summary>
	/// Отмена подписки
	/// </summary>
	DonutSubscriptionCanceled,

	/// <summary>
	/// Изменение стоимости подписки
	/// </summary>
	DonutSubscriptionPriceChanged,

	/// <summary>
	/// Вывод денег
	/// </summary>
	DonutMoneyWithdraw,

	/// <summary>
	/// Ошибка вывода денег
	/// </summary>
	DonutMoneyWithdrawError,

	/// <summary>
	/// Новый заказ
	/// </summary>
	MarketOrderNew,

	/// <summary>
	/// Редактирование заказа
	/// </summary>
	MarketOrderEdit,

	/// <summary>
	/// Редактирование заказа
	/// </summary>
	AppPayload
}