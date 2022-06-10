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
			var fromJson = JsonConvert.DeserializeObject<GroupUpdate>(response.ToString(), JsonConfigure.JsonSerializerSettings);

			var resObj = response["object"];

			if (fromJson.Type == GroupUpdateType.MessageNew
				|| fromJson.Type == GroupUpdateType.MessageEdit
				|| fromJson.Type == GroupUpdateType.MessageReply)
			{
				if (resObj.ContainsKey("client_info"))
				{
					fromJson = CreateTyped(u => u.MessageNew, resObj, fromJson.Type);
				}
				else
				{
					fromJson = CreateTyped(u => u.Message, resObj, fromJson.Type);
				}
			} else if (fromJson.Type == GroupUpdateType.MessageAllow)
			{
				fromJson = CreateTyped(u => u.MessageAllow, resObj, fromJson.Type);
			}  else if (fromJson.Type == GroupUpdateType.MessageTypingState)
			{
				fromJson = CreateTyped(u => u.MessageTypingState, resObj, fromJson.Type);
			}else if (fromJson.Type == GroupUpdateType.VkPayTransaction)
			{
				fromJson = CreateTyped(u => u.VkPayTransaction, resObj, fromJson.Type);
			}else if (fromJson.Type == GroupUpdateType.LikeAdd)
			{
				fromJson = CreateTyped(u => u.LikeAdd, resObj, fromJson.Type);
			}else if (fromJson.Type == GroupUpdateType.LikeRemove)
			{
				fromJson = CreateTyped(u => u.LikeRemove, resObj, fromJson.Type);
			}else if (fromJson.Type == GroupUpdateType.GroupChangeSettings)
			{
				fromJson = CreateTyped(u => u.GroupChangeSettings, resObj, fromJson.Type);
			}else if (fromJson.Type == GroupUpdateType.MessageDeny)
			{
				fromJson = CreateTyped(u => u.MessageDeny, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.PhotoNew)
			{
				fromJson = CreateTyped(u => u.Photo, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.PhotoCommentNew
						|| fromJson.Type == GroupUpdateType.PhotoCommentEdit
						|| fromJson.Type == GroupUpdateType.PhotoCommentRestore)
			{
				fromJson = CreateTyped(u => u.PhotoComment, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.PhotoCommentDelete)
			{
				fromJson = CreateTyped(u => u.PhotoCommentDelete, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.AudioNew)
			{
				fromJson = CreateTyped(u => u.Audio, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.VideoNew)
			{
				fromJson = CreateTyped(u => u.Video, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.VideoCommentNew
						|| fromJson.Type == GroupUpdateType.VideoCommentEdit
						|| fromJson.Type == GroupUpdateType.VideoCommentRestore)
			{
				fromJson = CreateTyped(u => u.VideoComment, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.VideoCommentDelete)
			{
				fromJson = CreateTyped(u => u.VideoCommentDelete, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.WallPostNew || fromJson.Type == GroupUpdateType.WallRepost)
			{
				fromJson = CreateTyped(u => u.WallPost, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.WallReplyNew
						|| fromJson.Type == GroupUpdateType.WallReplyEdit
						|| fromJson.Type == GroupUpdateType.WallReplyRestore)
			{
				fromJson = CreateTyped(u => u.WallReply, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.WallReplyDelete)
			{
				fromJson = CreateTyped(u => u.WallReplyDelete, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.BoardPostNew
						|| fromJson.Type == GroupUpdateType.BoardPostEdit
						|| fromJson.Type == GroupUpdateType.BoardPostRestore)
			{
				fromJson = CreateTyped(u => u.BoardPost, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.BoardPostDelete)
			{
				fromJson = CreateTyped(u => u.BoardPostDelete, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.MarketCommentNew
						|| fromJson.Type == GroupUpdateType.MarketCommentEdit
						|| fromJson.Type == GroupUpdateType.MarketCommentRestore)
			{
				fromJson = CreateTyped(u => u.MarketComment, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.MarketCommentDelete)
			{
				fromJson = CreateTyped(u => u.MarketCommentDelete, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.GroupLeave)
			{
				fromJson = CreateTyped(u => u.GroupLeave, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.GroupJoin)
			{
				fromJson = CreateTyped(u => u.GroupJoin, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.UserBlock)
			{
				fromJson = CreateTyped(u => u.UserBlock, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.UserUnblock)
			{
				fromJson = CreateTyped(u => u.UserUnblock, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.PollVoteNew)
			{
				fromJson = CreateTyped(u => u.PollVoteNew, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.GroupChangePhoto)
			{
				fromJson = CreateTyped(u => u.GroupChangePhoto, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.GroupOfficersEdit)
			{
				fromJson = CreateTyped(u => u.GroupOfficersEdit, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.MessageEvent)
			{
				fromJson = CreateTyped(u => u.MessageEvent, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.DonutSubscriptionCreate
				|| fromJson.Type == GroupUpdateType.DonutSubscriptionProlonged)
			{
				fromJson = CreateTyped(u => u.DonutSubscriptionNew, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.DonutSubscriptionCanceled
				|| fromJson.Type == GroupUpdateType.DonutSubscriptionExpired)
			{
				fromJson = CreateTyped(u => u.DonutSubscriptionEnd, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.DonutSubscriptionPriceChanged)
			{
				fromJson = CreateTyped(u => u.DonutSubscriptionPriceChanged, resObj, fromJson.Type);
			} else if (fromJson.Type == GroupUpdateType.DonutMoneyWithdraw
				|| fromJson.Type == GroupUpdateType.DonutMoneyWithdrawError)
			{
				fromJson = CreateTyped(u => u.DonutMoneyWithdraw, resObj, fromJson.Type);
			}

			fromJson.Raw = resObj;
			fromJson.GroupId = response["group_id"];

			return fromJson;
		}

	#region Приватные методы

		private static GroupUpdate CreateTyped<TGroupUpdate>(
			Expression<Func<GroupUpdate, TGroupUpdate>> propertySelector,
			TGroupUpdate instance,
			GroupUpdateType type)
			where TGroupUpdate : IGroupUpdate
		{
			var update = new GroupUpdate
			{
				Type = type,
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