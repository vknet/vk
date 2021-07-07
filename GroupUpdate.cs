using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
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
		/// Сообщение для типов событий с сообщением в ответе.
		/// </summary>
		public MessageNew MessageNew { get; set; }
		/// <summary>
		/// Собеседник набирает сообщение
		/// </summary>
		public MessageTypingState MessageTypingState { get; set; }

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
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GroupUpdate FromJson(VkResponse response)
		{
			var fromJson = JsonConvert.DeserializeObject<GroupUpdate>(response.ToString());

			var resObj = response["object"];

			if (fromJson.Type == GroupUpdateType.MessageNew
				|| fromJson.Type == GroupUpdateType.MessageEdit
				|| fromJson.Type == GroupUpdateType.MessageReply)
			{
				if (resObj.ContainsKey("client_info"))
				{
					fromJson.MessageNew = resObj;
				}
				else
				{
					fromJson.Message = resObj;
				}
			} else if (fromJson.Type == GroupUpdateType.MessageAllow)
			{
				fromJson.MessageAllow = MessageAllow.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.MessageDeny)
			{
				fromJson.MessageDeny = MessageDeny.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.PhotoNew)
			{
				fromJson.Photo = resObj;
			} else if (fromJson.Type == GroupUpdateType.PhotoCommentNew
						|| fromJson.Type == GroupUpdateType.PhotoCommentEdit
						|| fromJson.Type == GroupUpdateType.PhotoCommentRestore)
			{
				fromJson.PhotoComment = PhotoComment.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.PhotoCommentDelete)
			{
				fromJson.PhotoCommentDelete = PhotoCommentDelete.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.AudioNew)
			{
				fromJson.Audio = resObj;
			} else if (fromJson.Type == GroupUpdateType.VideoNew)
			{
				fromJson.Video = resObj;
			} else if (fromJson.Type == GroupUpdateType.VideoCommentNew
						|| fromJson.Type == GroupUpdateType.VideoCommentEdit
						|| fromJson.Type == GroupUpdateType.VideoCommentRestore)
			{
				fromJson.VideoComment = VideoComment.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.VideoCommentDelete)
			{
				fromJson.VideoCommentDelete = VideoCommentDelete.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.WallPostNew || fromJson.Type == GroupUpdateType.WallRepost)
			{
				fromJson.WallPost = WallPost.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.WallReplyNew
						|| fromJson.Type == GroupUpdateType.WallReplyEdit
						|| fromJson.Type == GroupUpdateType.WallReplyRestore)
			{
				fromJson.WallReply = WallReply.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.WallReplyDelete)
			{
				fromJson.WallReplyDelete = WallReplyDelete.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.BoardPostNew
						|| fromJson.Type == GroupUpdateType.BoardPostEdit
						|| fromJson.Type == GroupUpdateType.BoardPostRestore)
			{
				fromJson.BoardPost = BoardPost.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.BoardPostDelete)
			{
				fromJson.BoardPostDelete = BoardPostDelete.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.MarketCommentNew
						|| fromJson.Type == GroupUpdateType.MarketCommentEdit
						|| fromJson.Type == GroupUpdateType.MarketCommentRestore)
			{
				fromJson.MarketComment = MarketComment.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.MarketCommentDelete)
			{
				fromJson.MarketCommentDelete = MarketCommentDelete.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.GroupLeave)
			{
				fromJson.GroupLeave = GroupLeave.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.GroupJoin)
			{
				fromJson.GroupJoin = GroupJoin.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.UserBlock)
			{
				fromJson.UserBlock = UserBlock.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.UserUnblock)
			{
				fromJson.UserUnblock = UserUnblock.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.PollVoteNew)
			{
				fromJson.PollVoteNew = PollVoteNew.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.GroupChangePhoto)
			{
				fromJson.GroupChangePhoto = GroupChangePhoto.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.GroupOfficersEdit)
			{
				fromJson.GroupOfficersEdit = GroupOfficersEdit.FromJson(resObj);
			} else if (fromJson.Type == GroupUpdateType.MessageEvent)
			{
				fromJson.MessageEvent = MessageEvent.FromJson(resObj);
			}

			return fromJson;
		}
	}
}
