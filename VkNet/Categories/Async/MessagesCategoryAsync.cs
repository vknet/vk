using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;
using System;

namespace VkNet.Categories;

public partial class MessagesCategory
{
	/// <inheritdoc/>
	public Task<bool> UnpinAsync(long peerId,
								ulong? groupId = null,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Unpin(peerId, groupId), token);

	/// <inheritdoc />
	public Task<GetImportantMessagesResult> GetImportantMessagesAsync(GetImportantMessagesParams getImportantMessagesParams,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetImportantMessages(getImportantMessagesParams), token);

	/// <inheritdoc />
	public Task<GetRecentCallsResult> GetRecentCallsAsync(IEnumerable<string> fields,
														ulong? count = null,
														ulong? startMessageId = null,
														bool? extended = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRecentCalls(fields, count, startMessageId, extended), token);

	/// <inheritdoc />
	public Task<bool> AddChatUserAsync(long chatId,
										long userId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddChatUser(chatId, userId), token);

	/// <inheritdoc />
	public Task<bool> AllowMessagesFromGroupAsync(long groupId,
												string key,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AllowMessagesFromGroup(groupId, key), token);

	/// <inheritdoc />
	public Task<long> CreateChatAsync(IEnumerable<ulong> userIds,
									string title,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateChat(userIds, title), token);

	/// <inheritdoc />
	public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds,
													bool? spam = null,
													ulong? groupId = null,
													bool deleteForAll = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(messageIds, spam, groupId, deleteForAll), token);

	/// <inheritdoc />
	public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> conversationMessageIds,
													ulong peerId,
													bool? spam = null,
													ulong? groupId = null,
													bool deleteForAll = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(conversationMessageIds, peerId, spam, groupId, deleteForAll), token);

	/// <inheritdoc />
	public Task<DeleteChatPhotoResult> DeleteChatPhotoAsync(ulong chatId,
															ulong? groupId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteChatPhoto(chatId, groupId), token);

	/// <inheritdoc />
	public Task<ulong> DeleteConversationAsync(long? userId,
												long? peerId = null,
												ulong? groupId = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteConversation(userId, peerId, groupId), token);

	/// <inheritdoc />
	public Task<ConversationResult> GetConversationsByIdAsync(IEnumerable<long> peerIds,
															IEnumerable<string> fields = null,
															bool? extended = null,
															ulong? groupId = null,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetConversationsById(peerIds, fields, extended, groupId), token);

	/// <inheritdoc />
	public Task<GetConversationsResult> GetConversationsAsync(GetConversationsParams getConversationsParams,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetConversations(getConversationsParams), token);

	/// <inheritdoc />
	public Task<GetConversationMembersResult> GetConversationMembersAsync(long peerId,
																		IEnumerable<string> fields = null,
																		ulong? groupId = null,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetConversationMembers(peerId, fields, groupId), token);

	/// <inheritdoc />
	public Task<GetByConversationMessageIdResult> GetByConversationMessageIdAsync(long peerId,
																				IEnumerable<ulong> conversationMessageIds,
																				IEnumerable<string> fields,
																				bool? extended = null,
																				ulong? groupId = null,
																				CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetByConversationMessageId(peerId, conversationMessageIds, fields, extended, groupId), token);

	/// <inheritdoc />
	public Task<SearchConversationsResult> SearchConversationsAsync(string q,
																	IEnumerable<string> fields,
																	ulong? count = null,
																	bool? extended = null,
																	ulong? groupId = null,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SearchConversations(q, fields, count, extended, groupId), token);

	/// <inheritdoc />
	public Task<PinnedMessage> PinAsync(long peerId,
										ulong? messageId = null,
										ulong? conversationMessageId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Pin(peerId, messageId, conversationMessageId), token);


	/// <inheritdoc />
	public Task<bool> DenyMessagesFromGroupAsync(long groupId,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DenyMessagesFromGroup(groupId), token);

	/// <inheritdoc />
	public Task<bool> EditChatAsync(long chatId,
									string title,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditChat(chatId, title), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.MessageGet)]
	public Task<MessagesGetObject> GetAsync(MessagesGetParams @params,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds,
													IEnumerable<string> fields,
													ulong? previewLength = null,
													bool? extended = null,
													ulong? groupId = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(messageIds, fields, previewLength, extended, groupId), token);

	/// <inheritdoc />
	public Task<GetIntentUsersResult> GetIntentUsersAsync(MessagesGetIntentUsersParams getIntentUsersParams,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetIntentUsers(getIntentUsersParams), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.MessageSearchDialogs)]
	public Task<SearchDialogsResponse> SearchDialogsAsync(string query,
														ProfileFields fields = null,
														uint? limit = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SearchDialogs(query, fields, limit), token);

	/// <inheritdoc />
	public Task<MessageSearchResult> SearchAsync(MessagesSearchParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params), token);

	/// <inheritdoc />
	public Task<long> SendAsync(MessagesSendParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Send(@params), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendToUserIds(@params), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MessagesSendResult>> SendToPeerIdsAsync(MessagesSendParams @params,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendToPeerIds(@params), token);

	/// <inheritdoc />
	public Task<bool> RestoreAsync(ulong messageId,
									ulong? groupId = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(messageId, groupId), token);

	/// <inheritdoc />
	public Task<bool> MarkAsReadAsync(string peerId,
									long? startMessageId = null,
									long? groupId = null,
									bool? markConversationAsRead = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsRead(peerId, startMessageId, groupId, markConversationAsRead), token);

	/// <inheritdoc />
	public Task<bool> SetActivityAsync(string userId,
										MessageActivityType type,
										long? peerId = null,
										ulong? groupId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetActivity(userId, type, peerId, groupId), token);

	/// <inheritdoc />
	public Task<LastActivity> GetLastActivityAsync(long userId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLastActivity(userId), token);

	/// <inheritdoc />
	public Task<Chat> GetChatAsync(long chatId,
									ProfileFields fields = null,
									NameCase? nameCase = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChat(chatId, fields, nameCase), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds,
														ProfileFields fields = null,
														NameCase? nameCase = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChat(chatIds, fields, nameCase), token);

	/// <inheritdoc />
	public Task<ChatPreview> GetChatPreviewAsync(string link,
												ProfileFields fields,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChatPreview(link, fields), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.MessageGetChatUsers)]
	public Task<GetChatUsers> GetChatUsersAsync(IEnumerable<long> chatIds,
												UsersFields fields,
												NameCase? nameCase,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChatUsers(chatIds, fields, nameCase), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.MessageGetChatUsers)]
	public Task<ReadOnlyCollection<long>> GetChatUsersAsync(IEnumerable<long> chatIds,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChatUsers(chatIds), token);

	/// <inheritdoc />
	[Obsolete(ObsoleteText.MessageGet)]
	public Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetDialogs(@params), token);

	/// <inheritdoc />
	public Task<MessageGetHistoryObject> GetHistoryAsync(MessagesGetHistoryParams @params,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetHistory(@params), token);

	/// <inheritdoc/>
	public Task<bool> RemoveChatUserAsync(ulong chatId,
										long? userId = null,
										long? memberId = null,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RemoveChatUser(chatId, userId, memberId), token);

	/// <inheritdoc />
	public Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false,
																uint lpVersion = 2,
																ulong? groupId = null,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLongPollServer(needPts, lpVersion, groupId), token);

	/// <inheritdoc />
	public Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params,
																CancellationToken token = default) =>
		GetLongPollHistoryAsync<LongPollHistoryResponse>(@params, token);

	/// <inheritdoc />
	public Task<T> GetLongPollHistoryAsync<T>(MessagesGetLongPollHistoryParams @params,
											CancellationToken token = default) => TypeHelper.TryInvokeMethodAsync(() =>
		GetLongPollHistory<T>(@params), token);

	/// <inheritdoc />
	public Task<long> SetChatPhotoAsync(string file,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetChatPhoto(out var _, file), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds,
																bool important = true,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsImportant(messageIds, important), token);

	/// <inheritdoc />
	public Task<long> SendStickerAsync(MessagesSendStickerParams parameters,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendSticker(parameters), token);

	/// <inheritdoc />
	public Task<GetHistoryAttachmentsResult> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params,
																		CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetHistoryAttachments(@params), token);

	/// <inheritdoc />
	public Task<string> GetInviteLinkAsync(ulong peerId,
											bool reset,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetInviteLink(peerId, reset), token);

	/// <inheritdoc />
	public Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId,
													ulong userId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			IsMessagesFromGroupAllowed(groupId, userId), token);

	/// <inheritdoc />
	public Task<long> JoinChatByInviteLinkAsync(string link,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			JoinChatByInviteLink(link), token);

	/// <inheritdoc />
	public Task<bool> MarkAsAnsweredConversationAsync(long peerId,
													bool? answered = null,
													ulong? groupId = null,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsAnsweredConversation(peerId, answered, groupId), token);



	/// <inheritdoc />
	public Task<bool> MarkAsImportantConversationAsync(long peerId,
														bool? important = null,
														ulong? groupId = null,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsImportantConversation(peerId, important, groupId), token);



	/// <inheritdoc />
	public Task<bool> EditAsync(MessageEditParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	public Task<bool> SendMessageEventAnswerAsync(string eventId,
												long userId,
												long peerId,
												EventData eventData = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendMessageEventAnswer(eventId, userId, peerId, eventData), token);

	/// <inheritdoc />
	public Task<bool> MarkAsUnreadConversationAsync(long peerId,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			MarkAsUnreadConversation(peerId), token);

	/// <inheritdoc />
	public Task<bool> SetMemberRoleAsync(string role,
										long peerId,
										ulong memberId,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SetMemberRole(role, peerId, memberId), token);
}
