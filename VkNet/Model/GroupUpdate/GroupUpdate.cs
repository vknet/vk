using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

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
		[JsonProperty("type")]
		public GroupUpdateType Type { get; set; }

		/// <summary>
		/// Сообщение для типов событий с сообщением в ответе(MessageNew, MessageEdit, MessageReply)
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
		/// Добавление/редактирование/восстановление комментария к фотографии(PhotoCommentNew, PhotoCommentEdit, PhotoCommentRestore)
		/// </summary>
		public PhotoComment PhotoComment { get; set; }

		/// <summary>
		/// Удаление комментария к фотографии(PhotoCommentDelete)
		/// </summary>
		public PhotoCommentDelete PhotoCommentDelete { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария к видео(VideoCommentNew, VideoCommentEdit, VideoCommentRestore)
		/// </summary>
		public VideoComment VideoComment { get; set; }

		/// <summary>
		/// Удаление комментария к видео(VideoCommentDelete)
		/// </summary>
		public VideoCommentDelete VideoCommentDelete { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария в обсуждении(BoardPostNew, BoardPostEdit, BoardPostRestore)
		/// </summary>
		public BoardPost BoardPost { get; set; }

		/// <summary>
		/// Удаление комментария в обсуждении(BoardPostDelete)
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
		/// Добавление/редактирование/восстановление комментария к товару(MarketCommentNew, MarketCommentEdit, MarketCommentRestore)
		/// </summary>
		public MarketComment MarketComment { get; set; }

		/// <summary>
		/// Удаление комментария к товару(MarketCommentDelete)
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
		/// Новая запись на стене(WallPost, WallRepost)
		/// </summary>
		public WallPost WallPost { get; set; }

		/// <summary>
		/// Добавление/редактирование/восстановление комментария на стене(WallReplyNew, WallReplyEdit, WallReplyRestore)
		/// </summary>
		public WallReply WallReply { get; set; }

		/// <summary>
		/// Удаление комментария к записи(WallReplyDelete)
		/// </summary>
		public WallReplyDelete WallReplyDelete { get; set; }

		/// <summary>
		/// ID группы
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// Secret Key для Callback
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
				fromJson.Message = resObj;
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
			}

			return fromJson;
		}
	}
}