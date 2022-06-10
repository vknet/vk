using System;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Infrastructure;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Обновление группы
	/// </summary>
	[Serializable]
	public class GroupUpdate
	{
		/// <summary>
		/// Тип обновления
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public GroupUpdateType Type { get; set; }

		/// <summary>
		/// Экземпляр самого обновления группы.
		/// </summary>
		public IGroupUpdate Instance { get; private set; }

		/// <summary>
		/// Сообщение для типов событий с сообщением в ответе.
		/// </summary>
		public MessageNew MessageNew { get; set; }

		/// <summary>
		/// Собеседник набираеет сообщение
		/// </summary>
		public MessageTypingState MessageTypingState { get; set; }

		/// <summary>
		/// Событие о новой отметке "Мне нравится"
		/// </summary>
		public LikeAdd LikeAdd { get; set; }

		/// <summary>
		/// Событие о удалении отметки "Мне нравится"
		/// </summary>
		public LikeRemove LikeRemove { get; set; }

		/// <summary>
		/// Событие о изменении настроек сообщества
		/// </summary>
		public GroupChangeSettings GroupChangeSettings { get; set; }

		/// <summary>
		/// Платёж через VK Pay
		/// </summary>
		public VkPayTransaction VkPayTransaction { get; set; }


		/// <summary>
		/// Сообщение callback кнопки для типов событий с сообщением callback кнопок в ответе.
		/// </summary>
		public MessageEvent MessageEvent { get; set; }

		/// <summary>
		/// Сообщение для типов событий с сообщением в ответе
		/// (<c>MessageEdit</c>, <c>MessageReply</c>, для версий API ниже 5.103 также <c>MessageNew</c>).
		/// </summary>
		public Message Message { get; set; }

		/// <summary>
		/// Фотография для типов событий с фотографией в ответе(PhotoNew)
		/// </summary>
		public Photo Photo { get; set; }

		/// <summary>
		/// Аудиозапись
		/// </summary>
		public Audio Audio { get; set; }

		/// <summary>
		/// Видеозапись
		/// </summary>
		public Video Video { get; set; }

		/// <summary>
		/// Подписка на сообщения от сообщества
		/// </summary>
		public MessageAllow MessageAllow { get; set; }

		/// <summary>
		/// Новый запрет сообщений от сообщества(MessageDeny)
		/// </summary>
		public MessageDeny MessageDeny { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к фотографии
		/// (<c>PhotoCommentNew</c>, <c>PhotoCommentEdit</c>, <c>PhotoCommentRestore</c>)
		/// </summary>
		public PhotoComment PhotoComment { get; set; }

		/// <summary>
		/// Удаление комментария к фотографии (<c>PhotoCommentDelete</c>)
		/// </summary>
		public PhotoCommentDelete PhotoCommentDelete { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к видео
		/// (<c>VideoCommentNew</c>, <c>VideoCommentEdit</c>, <c>VideoCommentRestore</c>)
		/// </summary>
		public VideoComment VideoComment { get; set; }

		/// <summary>
		/// Удаление комментария к видео (<c>VideoCommentDelete</c>)
		/// </summary>
		public VideoCommentDelete VideoCommentDelete { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария в обсуждении
		/// (<c>BoardPostNew</c>, <c>BoardPostEdit</c>, <c>BoardPostRestore</c>)
		/// </summary>
		public BoardPost BoardPost { get; set; }

		/// <summary>
		/// Удаление комментария в обсуждении (<c>BoardPostDelete</c>)
		/// </summary>
		public BoardPostDelete BoardPostDelete { get; set; }

		/// <summary>
		/// Изменение главного фото
		/// </summary>
		public GroupChangePhoto GroupChangePhoto { get; set; }

		/// <summary>
		/// Добавление участника или заявки на вступление в сообщество
		/// </summary>
		public GroupJoin GroupJoin { get; set; }

		/// <summary>
		/// Удаление/выход участника из сообщества
		/// </summary>
		public GroupLeave GroupLeave { get; set; }

		/// <summary>
		/// Редактирование списка руководителей
		/// </summary>
		public GroupOfficersEdit GroupOfficersEdit { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к товару
		/// (<c>MarketCommentNew</c>, <c>MarketCommentEdit</c>, <c>MarketCommentRestore</c>)
		/// </summary>
		public MarketComment MarketComment { get; set; }

		/// <summary>
		/// Удаление комментария к товару (<c>MarketCommentDelete</c>)
		/// </summary>
		public MarketCommentDelete MarketCommentDelete { get; set; }

		/// <summary>
		/// Добавление голоса в публичном опросе
		/// </summary>
		public PollVoteNew PollVoteNew { get; set; }

		/// <summary>
		/// Добавление пользователя в чёрный список
		/// </summary>
		public UserBlock UserBlock { get; set; }

		/// <summary>
		/// Удаление пользователя из чёрного списка
		/// </summary>
		public UserUnblock UserUnblock { get; set; }

		/// <summary>
		/// Новая запись на стене (<c>WallPost</c>, <c>WallRepost</c>)
		/// </summary>
		public WallPost WallPost { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария на стене
		/// (<c>WallReplyNew</c>, <c>WallReplyEdit</c>, <c>WallReplyRestore</c>)
		/// </summary>
		public WallReply WallReply { get; set; }

		/// <summary>
		/// Удаление комментария к записи (<c>WallReplyDelete</c>)
		/// </summary>
		public WallReplyDelete WallReplyDelete { get; set; }

		/// <summary>
		/// Cоздание/Продление подписки
		/// (<c>DonutSubscriptionCreate</c>, <c>DonutSubscriptionProlonged</c>)
		/// </summary>
		public DonutNew DonutSubscriptionNew { get; set; }

		/// <summary>
		/// Подписка истекла/отменена
		/// (<c>DonutSubscriptionExpired</c>, <c>DonutSubscriptionCancelled</c>)
		/// </summary>
		public DonutEnd DonutSubscriptionEnd { get; set; }

		/// <summary>
		/// Изменение стоимости подписки (<c>DonutSubscriptionPriceChanged</c>)
		/// </summary>
		public DonutChanged DonutSubscriptionPriceChanged { get; set; }

		/// <summary>
		/// Вывод денег
		/// (<c>DonutMoneyWithdraw</c>, <c>DonutMoneyWithdrawError</c>)
		/// </summary>
		public DonutWithdraw DonutMoneyWithdraw { get; set; }

		/// <summary>
		/// ID группы
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// <c>Secret Key</c> для Callback
		/// </summary>
		[JsonProperty("secret")]
		public string Secret { get; set; }

		/// <summary>
		/// Необработанные данные
		/// </summary>
		public VkResponse Raw { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupUpdate FromJson(VkResponse response)
		{
			string type = response["type"];
			var resObj = response["object"];

			var fromJson = type switch
			{
				"message_new" or "message_edit" or "message_reply"
					=> resObj.ContainsKey("client_info")
						? CreateTyped(u => u.MessageNew, resObj)
						: CreateTyped(u => u.Message, resObj),
				"message_allow" => CreateTyped(u => u.MessageAllow, resObj),
				"message_typing_state" => CreateTyped(u => u.MessageTypingState, resObj),
				"vkpay_transaction" => CreateTyped(u => u.VkPayTransaction, resObj),
				"like_add" => CreateTyped(u => u.LikeAdd, resObj),
				"like_remove" => CreateTyped(u => u.LikeRemove, resObj),
				"group_change_settings" => CreateTyped(u => u.GroupChangeSettings, resObj),
				"message_deny" => CreateTyped(u => u.MessageDeny, resObj),
				"photo_new" => CreateTyped(u => u.Photo, resObj),
				"photo_comment_new" or "photo_comment_edit" or "photo_comment_restore" => CreateTyped(u => u.PhotoComment, resObj),
				"photo_comment_delete" => CreateTyped(u => u.PhotoCommentDelete, resObj),
				"audio_new" => CreateTyped(u => u.Audio, resObj),
				"video_new" => CreateTyped(u => u.Video, resObj),
				"video_comment_new" or "video_comment_edit" or "video_comment_restore" => CreateTyped(u => u.VideoComment, resObj),
				"video_comment_delete" => CreateTyped(u => u.VideoCommentDelete, resObj),
				"wall_post_new" or "wall_repost" => CreateTyped(u => u.WallPost, resObj),
				"wall_reply_new" or "wall_reply_edit" or "wall_reply_restore" => CreateTyped(u => u.WallReply, resObj),
				"wall_reply_delete" => CreateTyped(u => u.WallReplyDelete, resObj),
				"board_post_new" or "board_post_edit" or "board_post_restore" => CreateTyped(u => u.BoardPost, resObj),
				"board_post_delete" => CreateTyped(u => u.BoardPostDelete, resObj),
				"market_comment_new" or "market_comment_edit" or "market_comment_restore" => CreateTyped(u => u.MarketComment, resObj),
				"market_comment_delete" => CreateTyped(u => u.MarketCommentDelete, resObj),
				"group_leave" => CreateTyped(u => u.GroupLeave, resObj),
				"group_join" => CreateTyped(u => u.GroupJoin, resObj),
				"user_block" => CreateTyped(u => u.UserBlock, resObj),
				"user_unblock" => CreateTyped(u => u.UserUnblock, resObj),
				"poll_vote_new" => CreateTyped(u => u.PollVoteNew, resObj),
				"group_change_photo" => CreateTyped(u => u.GroupChangePhoto, resObj),
				"group_officers_edit" => CreateTyped(u => u.GroupOfficersEdit, resObj),
				"message_event" => CreateTyped(u => u.MessageEvent, resObj),
				"donut_subscription_create" or "donut_subscription_prolonged" => CreateTyped(u => u.DonutSubscriptionNew, resObj),
				"donut_subscription_cancelled" or "donut_subscription_expired" => CreateTyped(u => u.DonutSubscriptionEnd, resObj),
				"donut_subscription_price_changed" => CreateTyped(u => u.DonutSubscriptionPriceChanged, resObj),
				"donut_money_withdraw" or "donut_money_withdraw_error" => CreateTyped(u => u.DonutMoneyWithdraw, resObj),
				var _ => JsonConvert.DeserializeObject<GroupUpdate>(response.ToString(), JsonConfigure.JsonSerializerSettings)
			};

			fromJson!.Type = GroupUpdateType.FromJsonString(type);
			fromJson.Raw = resObj;
			fromJson.GroupId = response["group_id"];

			return fromJson;
		}

	#region Приватные методы

		private static GroupUpdate CreateTyped<TGroupUpdate>(
			Expression<Func<GroupUpdate, TGroupUpdate>> propertySelector,
			TGroupUpdate instance)
			where TGroupUpdate : IGroupUpdate
		{
			var update = new GroupUpdate
			{
				Instance = instance,
			};

			if (propertySelector.Body is MemberExpression
				{
					Member: PropertyInfo propertyInfo
				})
			{
				propertyInfo.SetValue(update, instance);
			}

			return update;
		}

	#endregion
	}
}