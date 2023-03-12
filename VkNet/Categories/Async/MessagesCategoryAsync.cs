using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Messages;
using VkNet.Model.Results.Messages;
using VkNet.Model.Results.Users;
using VkNet.Utils;

namespace VkNet.Categories;

public partial class MessagesCategory
{
	/// <inheritdoc/>
	public Task<bool> UnpinAsync(long peerId, ulong? groupId = null) => TypeHelper.TryInvokeMethodAsync(() => Unpin(peerId, groupId));

	/// <inheritdoc />
	public Task<GetImportantMessagesResult> GetImportantMessagesAsync(GetImportantMessagesParams getImportantMessagesParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetImportantMessages(getImportantMessagesParams));

	/// <inheritdoc />
	public Task<GetRecentCallsResult> GetRecentCallsAsync(IEnumerable<string> fields, ulong? count = null, ulong? startMessageId = null,
														bool? extended = null) => TypeHelper.TryInvokeMethodAsync(() =>
		GetRecentCalls(fields, count, startMessageId, extended));

	/// <inheritdoc />
	public Task<bool> AddChatUserAsync(long chatId, long userId) => TypeHelper.TryInvokeMethodAsync(() => AddChatUser(chatId, userId));

	/// <inheritdoc />
	public Task<bool> AllowMessagesFromGroupAsync(long groupId, string key) =>
		TypeHelper.TryInvokeMethodAsync(() => AllowMessagesFromGroup(groupId, key));

	/// <inheritdoc />
	public Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateChat(userIds, title));

	/// <inheritdoc />
	public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null,
            bool deleteForAll = false) => TypeHelper.TryInvokeMethodAsync(
		() => Delete(messageIds, spam, groupId, deleteForAll));

	/// <inheritdoc />
	public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> conversationMessageIds, ulong peerId, bool? spam = null, ulong? groupId = null,
            bool deleteForAll = false) => TypeHelper.TryInvokeMethodAsync(
		() => Delete(conversationMessageIds, peerId, spam, groupId, deleteForAll));

	/// <inheritdoc />
	public Task<DeleteChatPhotoResult> DeleteChatPhotoAsync(ulong chatId, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteChatPhoto(chatId, groupId));

	/// <inheritdoc />
	public Task<ulong> DeleteConversationAsync(long? userId, long? peerId = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteConversation(userId, peerId, groupId));

	/// <inheritdoc />
	public Task<ConversationResult> GetConversationsByIdAsync(IEnumerable<long> peerIds, IEnumerable<string> fields = null,
															bool? extended = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetConversationsById(peerIds, fields, extended, groupId));

	/// <inheritdoc />
	public Task<GetConversationsResult> GetConversationsAsync(GetConversationsParams getConversationsParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetConversations(getConversationsParams));

	/// <inheritdoc />
	public Task<GetConversationMembersResult> GetConversationMembersAsync(long peerId, IEnumerable<string> fields = null,
																		ulong? groupId = null) => TypeHelper.TryInvokeMethodAsync(() =>
		GetConversationMembers(peerId, fields, groupId));

	/// <inheritdoc />
	public Task<GetByConversationMessageIdResult> GetByConversationMessageIdAsync(long peerId,
																				IEnumerable<ulong> conversationMessageIds,
																				IEnumerable<string> fields,
																				bool? extended = null,
																				ulong? groupId = null) => TypeHelper.TryInvokeMethodAsync(
		() =>
			GetByConversationMessageId(peerId, conversationMessageIds, fields, extended, groupId));

	/// <inheritdoc />
	public Task<SearchConversationsResult> SearchConversationsAsync(string q, IEnumerable<string> fields, ulong? count = null,
																	bool? extended = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => SearchConversations(q, fields, count, extended, groupId));

	/// <inheritdoc />
	public Task<PinnedMessage> PinAsync(long peerId, ulong? messageId = null, ulong? conversationMessageId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => Pin(peerId, messageId, conversationMessageId));

	/// <inheritdoc />
	public Task<ulong> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteDialog(userId, peerId, offset, count));

	/// <inheritdoc />
	public Task<bool> DenyMessagesFromGroupAsync(long groupId) => TypeHelper.TryInvokeMethodAsync(() => DenyMessagesFromGroup(groupId));

	/// <inheritdoc />
	public Task<bool> EditChatAsync(long chatId, string title) => TypeHelper.TryInvokeMethodAsync(() => EditChat(chatId, title));

	/// <inheritdoc />
	public Task<MessagesGetObject> GetAsync(MessagesGetParams @params) => TypeHelper.TryInvokeMethodAsync(() => Get(@params));

	/// <inheritdoc />
	public Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, IEnumerable<string> fields,
													ulong? previewLength = null, bool? extended = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => GetById(messageIds, fields, previewLength, extended, groupId));

	/// <inheritdoc />
	public Task<GetIntentUsersResult> GetIntentUsersAsync(MessagesGetIntentUsersParams getIntentUsersParams, CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => GetIntentUsers(getIntentUsersParams));

	/// <inheritdoc />
	public Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SearchDialogs(query, fields, limit));

	/// <inheritdoc />
	public Task<MessageSearchResult> SearchAsync(MessagesSearchParams @params) => TypeHelper.TryInvokeMethodAsync(() => Search(@params));

	/// <inheritdoc />
	public Task<long> SendAsync(MessagesSendParams @params) => TypeHelper.TryInvokeMethodAsync(() => Send(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => SendToUserIds(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MessagesSendResult>> SendToPeerIdsAsync(MessagesSendParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => SendToPeerIds(@params));

	/// <inheritdoc />
	public Task<bool> RestoreAsync(ulong messageId, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => Restore(messageId, groupId));

	/// <inheritdoc />
	public Task<bool> MarkAsReadAsync(string peerId, long? startMessageId = null, long? groupId = null,
									bool? markConversationAsRead = null) => TypeHelper.TryInvokeMethodAsync(() =>
		MarkAsRead(peerId, startMessageId, groupId, markConversationAsRead));

	/// <inheritdoc />
	public Task<bool> SetActivityAsync(string userId, MessageActivityType type, long? peerId = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => SetActivity(userId, type, peerId, groupId));

	/// <inheritdoc />
	public Task<LastActivity> GetLastActivityAsync(long userId) => TypeHelper.TryInvokeMethodAsync(() => GetLastActivity(userId));

	/// <inheritdoc />
	public Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase? nameCase = null) => TypeHelper.TryInvokeMethodAsync(
		() =>
			GetChat(chatId, fields, nameCase));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds
														, ProfileFields fields = null
														, NameCase? nameCase = null) => TypeHelper.TryInvokeMethodAsync(() =>
		GetChat(chatIds, fields, nameCase));

	/// <inheritdoc />
	public Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields) =>
		TypeHelper.TryInvokeMethodAsync(() => GetChatPreview(link, fields));

	/// <inheritdoc />
	public Task<GetChatUsers> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase? nameCase) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChatUsers(chatIds, fields, nameCase));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> GetChatUsersAsync(IEnumerable<long> chatIds) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChatUsers(chatIds));

	/// <inheritdoc />
	public Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetDialogs(@params));

	/// <inheritdoc />
	public Task<MessageGetHistoryObject> GetHistoryAsync(MessagesGetHistoryParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetHistory(@params));

	/// <inheritdoc/>
	public Task<bool> RemoveChatUserAsync(ulong chatId, long? userId = null, long? memberId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => RemoveChatUser(chatId, userId, memberId));

	/// <inheritdoc />
	public Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLongPollServer(needPts, lpVersion, groupId));

	/// <inheritdoc />
	public Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() => GetLongPollHistory(@params));

	/// <inheritdoc />
	public Task<long> SetChatPhotoAsync(string file) => TypeHelper.TryInvokeMethodAsync(() => SetChatPhoto(out var _, file));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsImportant(messageIds, important));

	/// <inheritdoc />
	public Task<long> SendStickerAsync(MessagesSendStickerParams parameters) =>
		TypeHelper.TryInvokeMethodAsync(() => SendSticker(parameters));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetHistoryAttachments(@params));

	/// <inheritdoc />
	public Task<string> GetInviteLinkAsync(ulong peerId, bool reset) => TypeHelper.TryInvokeMethodAsync(() => GetInviteLink(peerId, reset));

	/// <inheritdoc />
	public Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId) => TypeHelper.TryInvokeMethodAsync(() =>
		IsMessagesFromGroupAllowed(groupId, userId));

	/// <inheritdoc />
	public Task<long> JoinChatByInviteLinkAsync(string link) => TypeHelper.TryInvokeMethodAsync(() => JoinChatByInviteLink(link));

	/// <inheritdoc />
	public Task<bool> MarkAsAnsweredConversationAsync(long peerId, bool? answered = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() => MarkAsAnsweredConversation(peerId, answered, groupId));

	/// <inheritdoc />
	public Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true) =>
		TypeHelper.TryInvokeMethodAsync(() => MarkAsAnsweredDialog(peerId, answered));

	/// <inheritdoc />
	public Task<bool> MarkAsImportantConversationAsync(long peerId, bool? important = null, ulong? groupId = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsImportantConversation(peerId, important, groupId));

	/// <inheritdoc />
	public Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true) => TypeHelper.TryInvokeMethodAsync(() =>
		MarkAsImportantDialog(peerId, important));

	/// <inheritdoc />
	public Task<bool> EditAsync(MessageEditParams @params) => TypeHelper.TryInvokeMethodAsync(() => Edit(@params));

	/// <inheritdoc />
	public Task<bool> SendMessageEventAnswerAsync(string eventId, long userId, long peerId, EventData eventData = null) =>
		TypeHelper.TryInvokeMethodAsync(() => SendMessageEventAnswer(eventId, userId, peerId, eventData));

	/// <inheritdoc />
	public Task<bool> MarkAsUnreadConversationAsync(long peerId) => TypeHelper.TryInvokeMethodAsync(() => MarkAsUnreadConversation(peerId));
}
