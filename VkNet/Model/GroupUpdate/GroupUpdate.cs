using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// Обновление группы
/// </summary>
[Serializable]
public class GroupUpdate
{
	/// <summary>
	/// Экземпляр самого обновления группы.
	/// </summary>
	public IGroupUpdate Instance { get; set; }

	/// <summary>
	/// Тип обновления
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public GroupUpdateType? Type { get; set; }

	/// <summary>
	/// Сообщение для типов событий с сообщением в ответе.
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MessageNew MessageNew { get; set; }

	/// <summary>
	/// Собеседник набираеет сообщение
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MessageTypingState MessageTypingState { get; set; }

	/// <summary>
	/// Событие о новой отметке "Мне нравится"
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public LikeAdd LikeAdd { get; set; }

	/// <summary>
	/// Событие о удалении отметки "Мне нравится"
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public LikeRemove LikeRemove { get; set; }

	/// <summary>
	/// Событие о изменении настроек сообщества
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public GroupChangeSettings GroupChangeSettings { get; set; }

	/// <summary>
	/// Платёж через VK Pay
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public VkPayTransaction VkPayTransaction { get; set; }

	/// <summary>
	/// Сообщение callback кнопки для типов событий с сообщением callback кнопок в ответе.
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MessageEvent MessageEvent { get; set; }

	/// <summary>
	/// Сообщение для типов событий с сообщением в ответе
	/// (<c>MessageEdit</c>, <c>MessageReply</c>, для версий API ниже 5.103 также <c>MessageNew</c>).
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public Message Message { get; set; }

	/// <summary>
	/// Фотография для типов событий с фотографией в ответе(PhotoNew)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public Photo Photo { get; set; }

	/// <summary>
	/// Аудиозапись
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public Audio Audio { get; set; }

	/// <summary>
	/// Видеозапись
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public Video Video { get; set; }

	/// <summary>
	/// Подписка на сообщения от сообщества
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MessageAllow MessageAllow { get; set; }

	/// <summary>
	/// Новый запрет сообщений от сообщества(MessageDeny)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MessageDeny MessageDeny { get; set; }

	/// <summary>
	/// Добавление/редактирование/восстановление комментария к фотографии
	/// (<c>PhotoCommentNew</c>, <c>PhotoCommentEdit</c>, <c>PhotoCommentRestore</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public PhotoComment PhotoComment { get; set; }

	/// <summary>
	/// Удаление комментария к фотографии (<c>PhotoCommentDelete</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public PhotoCommentDelete PhotoCommentDelete { get; set; }

	/// <summary>
	/// Добавление/редактирование/восстановление комментария к видео
	/// (<c>VideoCommentNew</c>, <c>VideoCommentEdit</c>, <c>VideoCommentRestore</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public VideoComment VideoComment { get; set; }

	/// <summary>
	/// Удаление комментария к видео (<c>VideoCommentDelete</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public VideoCommentDelete VideoCommentDelete { get; set; }

	/// <summary>
	/// Добавление/редактирование/восстановление комментария в обсуждении
	/// (<c>BoardPostNew</c>, <c>BoardPostEdit</c>, <c>BoardPostRestore</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public BoardPost BoardPost { get; set; }

	/// <summary>
	/// Удаление комментария в обсуждении (<c>BoardPostDelete</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public BoardPostDelete BoardPostDelete { get; set; }

	/// <summary>
	/// Изменение главного фото
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public GroupChangePhoto GroupChangePhoto { get; set; }

	/// <summary>
	/// Добавление участника или заявки на вступление в сообщество
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public GroupJoin GroupJoin { get; set; }

	/// <summary>
	/// Удаление/выход участника из сообщества
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public GroupLeave GroupLeave { get; set; }

	/// <summary>
	/// Редактирование списка руководителей
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public GroupOfficersEdit GroupOfficersEdit { get; set; }

	/// <summary>
	/// Добавление/редактирование/восстановление комментария к товару
	/// (<c>MarketCommentNew</c>, <c>MarketCommentEdit</c>, <c>MarketCommentRestore</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MarketComment MarketComment { get; set; }

	/// <summary>
	/// Удаление комментария к товару (<c>MarketCommentDelete</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public MarketCommentDelete MarketCommentDelete { get; set; }

	/// <summary>
	/// Добавление голоса в публичном опросе
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public PollVoteNew PollVoteNew { get; set; }

	/// <summary>
	/// Добавление пользователя в чёрный список
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public UserBlock UserBlock { get; set; }

	/// <summary>
	/// Удаление пользователя из чёрного списка
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public UserUnblock UserUnblock { get; set; }

	/// <summary>
	/// Новая запись на стене (<c>WallPost</c>, <c>WallRepost</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public WallPost WallPost { get; set; }

	/// <summary>
	/// Добавление/редактирование/восстановление комментария на стене
	/// (<c>WallReplyNew</c>, <c>WallReplyEdit</c>, <c>WallReplyRestore</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public WallReply WallReply { get; set; }

	/// <summary>
	/// Удаление комментария к записи (<c>WallReplyDelete</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public WallReplyDelete WallReplyDelete { get; set; }

	/// <summary>
	/// Cоздание/Продление подписки
	/// (<c>DonutSubscriptionCreate</c>, <c>DonutSubscriptionProlonged</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public DonutNew DonutSubscriptionNew { get; set; }

	/// <summary>
	/// Подписка истекла/отменена
	/// (<c>DonutSubscriptionExpired</c>, <c>DonutSubscriptionCancelled</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public DonutEnd DonutSubscriptionEnd { get; set; }

	/// <summary>
	/// Изменение стоимости подписки (<c>DonutSubscriptionPriceChanged</c>)
	/// </summary>
	[Obsolete("Используйте свойство Instance")]
	public DonutChanged DonutSubscriptionPriceChanged { get; set; }

	/// <summary>
	/// Вывод денег
	/// (<c>DonutMoneyWithdraw</c>)
	/// </summary>
	[JsonProperty("donut_money_withdraw")]
	[Obsolete("Используйте свойство Instance")]
	public DonutWithdraw DonutMoneyWithdraw { get; set; }

	/// <summary>
	/// Вывод денег
	/// (<c>DonutMoneyWithdrawError</c>)
	/// </summary>
	[JsonProperty("donut_money_withdraw_error")]
	[Obsolete("Используйте свойство Instance")]
	private DonutWithdraw DonutMoneyWithdrawError
	{
		get => DonutMoneyWithdraw;
		set => DonutMoneyWithdraw = value;
	}

	/// <summary>
	/// ID группы
	/// </summary>
	[JsonProperty("group_id")]
	[Obsolete("Используйте свойство Instance")]
	public ulong? GroupId { get; set; }

	/// <summary>
	/// <c>Secret Key</c> для Callback
	/// </summary>
	[JsonProperty("secret")]
	[Obsolete("Используйте свойство Instance")]
	public string Secret { get; set; }

	/// <summary>
	/// <c>MarketOrderNew</c> для Callback
	/// </summary>
	[JsonProperty("market_order_new")]
	[Obsolete("Используйте свойство Instance")]
	public MarketOrder MarketOrderNew { get; set; }

	/// <summary>
	/// <c>MarketOrderEdit</c> для Callback
	/// </summary>
	[JsonProperty("market_order_edit")]
	[Obsolete("Используйте свойство Instance")]
	public MarketOrder MarketOrderEdit { get; set; }

	/// <summary>
	/// <c>AppPayload</c> для Callback
	/// </summary>
	[JsonProperty("app_payload")]
	[Obsolete("Используйте свойство Instance")]
	public AppPayload AppPayload { get; set; }

	/// <summary>
	/// Необработанные данные
	/// </summary>
	public VkResponse Raw { get; set; }
}