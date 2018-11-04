using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class MessagesCategory
	{
		/// <inheritdoc/>
		public Task<bool> UnpinAsync(long peerId, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Unpin(peerId, groupId));
		}

		/// <inheritdoc />
		public Task<bool> AddChatUserAsync(long chatId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AddChatUser(chatId, userId));
		}

		/// <inheritdoc />
		public Task<bool> AllowMessagesFromGroupAsync(long groupId, string key)
		{
			return TypeHelper.TryInvokeMethodAsync(() => AllowMessagesFromGroup(groupId, key));
		}

		/// <inheritdoc />
		public Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title)
		{
			return TypeHelper.TryInvokeMethodAsync(() => CreateChat(userIds, title));
		}

		/// <inheritdoc />
		public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null,
														bool? deleteForAll = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				Delete(messageIds, spam, groupId, deleteForAll));
		}

		/// <inheritdoc />
		public Task<Chat> DeleteChatPhotoAsync(ulong chatId, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteChatPhoto(out var _, chatId, groupId));
		}

		/// <inheritdoc />
		public Task<bool> DeleteConversationAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null,
												long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DeleteConversation(userId, peerId, offset, count, groupId));
		}

		/// <inheritdoc />
		public Task<ConversationResultObject> GetConversationsByIdAsync(IEnumerable<long> peerIds, IEnumerable<string> fields,
																		bool? extended = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetConversationsById(peerIds, fields, extended, groupId));
		}

		/// <inheritdoc />
		public Task<GetConversationsResult> GetConversationsAsync(GetConversationsParams getConversationsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetConversations(getConversationsParams));
		}

		/// <inheritdoc />
		public Task<GetConversationMembersResult> GetConversationMembersAsync(long peerId, IEnumerable<string> fields,
																			ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetConversationMembers(peerId, fields, groupId));
		}

		/// <inheritdoc />
		public Task<GetByConversationMessageIdResult> GetByConversationMessageIdAsync(long peerId,
																					IEnumerable<ulong> conversationMessageIds,
																					IEnumerable<string> fields,
																					bool? extended = null,
																					ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetByConversationMessageId(peerId, conversationMessageIds, fields, extended, groupId));
		}

		/// <inheritdoc />
		public Task<SearchConversationsResult> SearchConversationsAsync(string q, IEnumerable<string> fields, ulong? count = null,
																		bool? extended = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SearchConversations(q, fields, count, extended, groupId));
		}

		/// <inheritdoc />
		public Task<PinnedMessage> PinAsync(long peerId, ulong? messageId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Pin(peerId, messageId));
		}

		/// <inheritdoc />
		public Task<bool> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				DeleteDialog(userId, peerId, offset, count));
		}

		/// <inheritdoc />
		public Task<bool> DenyMessagesFromGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => DenyMessagesFromGroup(groupId));
		}

		/// <inheritdoc />
		public Task<bool> EditChatAsync(long chatId, string title)
		{
			return TypeHelper.TryInvokeMethodAsync(() => EditChat(chatId, title));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetAsync(MessagesGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Get(@params));
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, IEnumerable<string> fields,
														ulong? previewLength = null, bool? extended = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetById(messageIds, fields, previewLength, extended, groupId));
		}

		/// <inheritdoc />
		public Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				SearchDialogs(query, fields, limit));
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> SearchAsync(MessagesSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Search(@params));
		}

		/// <inheritdoc />
		public Task<long> SendAsync(MessagesSendParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Send(@params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SendToUserIds(@params));
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(ulong messageId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Restore(messageId));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsReadAsync(string peerId, long? startMessageId = null, long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				MarkAsRead(peerId, startMessageId, groupId));
		}

		/// <inheritdoc />
		public Task<bool> SetActivityAsync(long userId, long? peerId = null, string type = "typing")
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetActivity(userId, peerId, type));
		}

		/// <inheritdoc />
		public Task<LastActivity> GetLastActivityAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLastActivity(userId));
		}

		/// <inheritdoc />
		public Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetChat(chatId, fields, nameCase));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds
															, ProfileFields fields = null
															, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetChat(chatIds, fields, nameCase));
		}

		/// <inheritdoc />
		public Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetChatPreview(link, fields));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetChatUsers(chatIds, fields, nameCase));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetDialogs(@params));
		}

		/// <inheritdoc />
		public Task<MessageGetHistoryObject> GetHistoryAsync(MessagesGetHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetHistory(@params));
		}

		/// <inheritdoc/>
		public async Task<bool> RemoveChatUserAsync(ulong chatId, long? userId = null, long? memberId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => RemoveChatUser(chatId, userId, memberId));
		}

		/// <inheritdoc />
		public Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetLongPollServer(needPts, lpVersion, groupId));
		}

		/// <inheritdoc />
		public Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLongPollHistory(@params));
		}

		/// <inheritdoc />
		public Task<long> SetChatPhotoAsync(string file)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SetChatPhoto(out var _, file));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				MarkAsImportant(messageIds, important));
		}

		/// <inheritdoc />
		public Task<long> SendStickerAsync(MessagesSendStickerParams parameters)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SendSticker(parameters));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetHistoryAttachments(@params, out var _));
		}

		/// <inheritdoc />
		public Task<string> GetInviteLinkAsync(ulong peerId, bool reset)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetInviteLink(peerId, reset));
		}

		/// <inheritdoc />
		public Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				IsMessagesFromGroupAllowed(groupId, userId));
		}

		/// <inheritdoc />
		public Task<long> JoinChatByInviteLinkAsync(string link)
		{
			return TypeHelper.TryInvokeMethodAsync(() => JoinChatByInviteLink(link));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsAnsweredConversationAsync(long peerId, bool? answered = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => MarkAsAnsweredConversation(peerId, answered, groupId));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true)
		{
			return TypeHelper.TryInvokeMethodAsync(() => MarkAsAnsweredDialog(peerId, answered));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantConversationAsync(long peerId, bool? important = null, ulong? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				MarkAsImportantConversation(peerId, important, groupId));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				MarkAsImportantDialog(peerId, important));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(MessageEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Edit(@params));
		}
	}
}