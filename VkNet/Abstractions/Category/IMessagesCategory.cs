using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc />
	public interface IMessagesCategory : IMessagesCategoryAsync
	{
		/// <inheritdoc cref="IMessagesCategoryAsync.AddChatUserAsync" />
		bool AddChatUser(long chatId, long userId);

		/// <inheritdoc cref="IMessagesCategoryAsync.AllowMessagesFromGroupAsync" />
		bool AllowMessagesFromGroup(long groupId, string key);

		/// <inheritdoc cref="IMessagesCategoryAsync.CreateChatAsync" />
		long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteAsync" />
		IDictionary<ulong, bool> Delete([NotNull] IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null, bool? deleteForAll = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteChatPhotoAsync" />
		Chat DeleteChatPhoto(out ulong messageId, ulong chatId, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.DenyMessagesFromGroupAsync" />
		bool DenyMessagesFromGroup(long groupId);

		/// <inheritdoc cref="IMessagesCategoryAsync.EditChatAsync" />
		bool EditChat(long chatId, [NotNull] string title);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetByIdAsync" />
		VkCollection<Message> GetById([NotNull] IEnumerable<ulong> messageIds, IEnumerable<string> fields, ulong? previewLength = null, bool? extended = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SearchAsync" />
		MessageSearchResult Search(MessagesSearchParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendAsync" />
		long Send(MessagesSendParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendToUserIdsAsync" />
		ReadOnlyCollection<MessagesSendResult> SendToUserIds(MessagesSendParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.RestoreAsync" />
		bool Restore(ulong messageId, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsReadAsync" />
		bool MarkAsRead(string peerId, long? startMessageId = null, long? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SetActivityAsync" />
		bool SetActivity(string userId, MessageActivityType type, long? peerId = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetLastActivityAsync" />
		LastActivity GetLastActivity(long userId);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatAsync(long,VkNet.Enums.Filters.ProfileFields,VkNet.Enums.SafetyEnums.NameCase,System.Threading.CancellationToken)" />
		Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatAsync(IEnumerable{long}, ProfileFields, NameCase)" />
		ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatPreviewAsync" />
		ChatPreview GetChatPreview(string link, ProfileFields fields);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetHistoryAsync" />
		MessageGetHistoryObject GetHistory(MessagesGetHistoryParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.RemoveChatUserAsync" />
		bool RemoveChatUser(ulong chatId, long? userId = null, long? memberId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetLongPollServerAsync" />
		LongPollServerResponse GetLongPollServer(bool needPts = false, uint lpVersion = 2, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetLongPollHistoryAsync" />
		LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.SetChatPhotoAsync" />
		long SetChatPhoto(out long messageId, string file);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsImportantAsync" />
		ReadOnlyCollection<long> MarkAsImportant([NotNull] IEnumerable<long> messageIds, bool important = true);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendStickerAsync" />
		long SendSticker(MessagesSendStickerParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetHistoryAttachmentsAsync" />
		ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetInviteLinkAsync" />
		string GetInviteLink(ulong peerId, bool reset);

		/// <inheritdoc cref="IMessagesCategoryAsync.IsMessagesFromGroupAllowedAsync" />
		bool IsMessagesFromGroupAllowed(ulong groupId, ulong userId);

		/// <inheritdoc cref="IMessagesCategoryAsync.JoinChatByInviteLinkAsync" />
		long JoinChatByInviteLink(string link);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsAnsweredConversationAsync" />
		bool MarkAsAnsweredConversation(long peerId, bool? answered = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsImportantConversationAsync" />
		bool MarkAsImportantConversation(long peerId, bool? important = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.EditAsync" />
		bool Edit(MessageEditParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteConversationAsync" />
		bool DeleteConversation(long? userId, long? peerId = null, uint? offset = null, uint? count = null, long? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetConversationsByIdAsync" />
		ConversationResultObject GetConversationsById(IEnumerable<long> peerIds, IEnumerable<string> fields, bool? extended = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetConversationsAsync" />
		GetConversationsResult GetConversations(GetConversationsParams getConversationsParams);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetConversationMembersAsync" />
		GetConversationMembersResult GetConversationMembers(long peerId, IEnumerable<string> fields, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetByConversationMessageIdAsync" />
		GetByConversationMessageIdResult GetByConversationMessageId(long peerId, [NotNull] IEnumerable<ulong> conversationMessageIds, IEnumerable<string> fields, bool? extended = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SearchConversationsAsync" />
		SearchConversationsResult SearchConversations(string q, IEnumerable<string> fields, ulong? count = null, bool? extended = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.PinAsync" />
		PinnedMessage Pin(long peerId, ulong? messageId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.UnpinAsync" />
		bool Unpin(long peerId, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetImportantMessagesAsync" />
		GetImportantMessagesResult GetImportantMessages(GetImportantMessagesParams getImportantMessagesParams);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetRecentCallsAsync" />
		GetRecentCallsResult GetRecentCalls(IEnumerable<string> fields, ulong? count = null, ulong? startMessageId = null, bool? extended = null);

		#region Obsoleted

		/// <summary>
		/// Удаляет все личные сообщения в диалоге.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя.
		/// Если требуется очистить историю беседы, используйте peer_id.
		/// </param>
		/// <param name="peerId">
		/// Идентификатор назначения.
		/// Для групповой беседы: 2000000000 + id беседы.
		/// Для сообщества: -id сообщества.
		/// </param>
		/// <param name="offset">
		/// Смещение, начиная с которого нужно удалить переписку (по умолчанию удаляются
		/// все сообщения,
		/// начиная с первого).
		/// </param>
		/// <param name="count">
		/// Как много сообщений нужно удалить. Обратите внимание что на метод наложено
		/// ограничение, за один вызов
		/// нельзя удалить больше 10000 сообщений, поэтому если сообщений в переписке
		/// больше - метод нужно вызывать несколько
		/// раз.
		/// </param>
		/// <returns> Признак удалось ли удалить сообщения. </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.deleteDialog
		/// </remarks>
		[Obsolete(ObsoleteText.MessageDeleteDialog)]
		bool DeleteDialog(long? userId, long? peerId = null, uint? offset = null, uint? count = null);

		/// <summary>
		/// Помечает диалог как отвеченный либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор диалога </param>
		/// <param name="answered"> флаг, может принимать значения 1 или 0, по умолчанию 1 </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsAnsweredDialog
		/// </remarks>
		[Obsolete(ObsoleteText.MessageMarkAsAnsweredDialog)]
		bool MarkAsAnsweredDialog(long peerId, bool answered = true);

		/// <summary>
		/// Помечает диалог как важный либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор диалога </param>
		/// <param name="important">
		/// <c> true </c>, если сообщения необходимо пометить, как важные;
		/// <c> 0 </c>, если необходимо снять пометку.положительное число (Положительное
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.markAsImportantDialog
		/// </remarks>
		[Obsolete(ObsoleteText.MessageMarkAsImportantDialog)]
		bool MarkAsImportantDialog(long peerId, bool important = true);

		/// <summary>
		/// Возвращает список найденных диалогов текущего пользователя по введенной строке
		/// поиска.
		/// </summary>
		/// <param name="query"> Подстрока, по которой будет производиться поиск. </param>
		/// <param name="limit"> Количество пользователей которое нужно вернуть. </param>
		/// <param name="fields"> Поля профилей собеседников, которые необходимо вернуть. </param>
		/// <returns>
		/// В результате выполнения данного метода будет возвращён массив объектов
		/// профилей, бесед и email.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		/// Query can not be null or
		/// empty.;query
		/// </exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.searchDialogs
		/// </remarks>
		[Obsolete(ObsoleteText.MessageSearchDialogs)]
		SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null);

		/// <summary>
		/// Возвращает список входящих либо исходящих личных сообщений текущего
		/// пользователя.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns> Список сообщений, удовлетворяющий условиям фильтрации. </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.get
		/// </remarks>
		[Obsolete(ObsoleteText.MessageGet)]
		MessagesGetObject Get(MessagesGetParams @params);

		/// <summary>
		/// Позволяет получить список пользователей мультидиалога по его id.
		/// </summary>
		/// <param name="chatIds">
		/// Идентификаторы бесед. список целых чисел, разделенных запятыми (Список целых
		/// чисел, разделенных
		/// запятыми).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone,
		/// photo_50, photo_100,
		/// photo_200_orig, has_mobile, contacts, education, online, counters, relation,
		/// last_seen, status,
		/// can_write_private_message, can_see_all_posts, can_post, universities список
		/// строк, разделенных через запятую
		/// (Список строк, разделенных через запятую).
		/// </param>
		/// <param name="nameCase">
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom,
		/// родительный – gen, дательный – dat, винительный – acc, творительный – ins,
		/// предложный – abl. По умолчанию nom.
		/// строка (Строка).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список идентификаторов участников беседы.
		/// Если был задан параметр fields, возвращает список объектов пользователей с
		/// дополнительным полем invited_by,
		/// содержащим идентификатор пользователя, пригласившего в беседу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getChatUsers
		/// </remarks>
		[Obsolete(ObsoleteText.MessageGetChatUsers)]
		ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase);

		/// <summary>
		/// Возвращает список диалогов аккаунта
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns> В случае успеха возвращает список диалогов пользователя </returns>
		[Obsolete(ObsoleteText.MessageGet)]
		MessagesGetObject GetDialogs(MessagesDialogsGetParams @params);

		#endregion
	}
}