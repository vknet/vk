using System;
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
		/// <inheritdoc />
		public Task<bool> AddChatUserAsync(long chatId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => AddChatUser(chatId: chatId, userId: userId));
		}

		/// <inheritdoc />
		public Task<bool> AllowMessagesFromGroupAsync(long groupId, string key)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => AllowMessagesFromGroup(groupId: groupId, key: key));
		}

		/// <inheritdoc />
		public Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => CreateChat(userIds: userIds, title: title));
		}

		/// <inheritdoc />
		public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool spam, bool deleteForAll)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				Delete(messageIds: messageIds, spam: spam, deleteForAll: deleteForAll));
		}

		/// <inheritdoc />
		public Task<Chat> DeleteChatPhotoAsync(ulong chatId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteChatPhoto(messageId: out var _, chatId: chatId));
		}

		/// <inheritdoc />
		public Task<bool> DeleteConversationAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null,
												long? groupId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteConversation(userId, peerId, offset, count, groupId));
		}

		/// <inheritdoc />
		public async Task<ConversationResultObject> GetConversationsByIdAsync(IEnumerable<long> peerIds, IEnumerable<string> fields,
																			bool? extended = null, ulong? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetConversationsById(peerIds, fields, extended, groupId));
		}

		/// <inheritdoc />
		public async Task<GetConversationsResult> GetConversationsAsync(GetConversationsParams getConversationsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetConversations(getConversationsParams));
		}

		/// <inheritdoc />
		public async Task<GetConversationMembersResult> GetConversationMembersAsync(long peerId, IEnumerable<string> fields, ulong? groupId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => GetConversationMembers(peerId, fields, groupId));
		}

		/// <inheritdoc />
		public Task<bool> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				DeleteDialog(userId: userId, peerId: peerId, offset: offset, count: count));
		}

		/// <inheritdoc />
		public Task<bool> DenyMessagesFromGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DenyMessagesFromGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> EditChatAsync(long chatId, string title)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => EditChat(chatId: chatId, title: title));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetAsync(MessagesGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Get(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, uint? previewLength = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetById(messageIds: messageIds, previewLength: previewLength));
		}

		/// <inheritdoc />
		public Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				SearchDialogs(query: query, fields: fields, limit: limit));
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> SearchAsync(MessagesSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> SendAsync(MessagesSendParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Send(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => SendToUserIds(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(ulong messageId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Restore(messageId: messageId));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsReadAsync(IEnumerable<long> messageIds, string peerId, long? startMessageId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				MarkAsRead(messageIds: messageIds, peerId: peerId, startMessageId: startMessageId));
		}

		/// <inheritdoc />
		public Task<bool> SetActivityAsync(long userId, long? peerId = null, string type = "typing")
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => SetActivity(userId: userId, peerId: peerId, type: type));
		}

		/// <inheritdoc />
		public Task<LastActivity> GetLastActivityAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetLastActivity(userId: userId));
		}

		/// <inheritdoc />
		public Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetChat(chatId: chatId, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds
															, ProfileFields fields = null
															, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetChat(chatIds: chatIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetChatPreview(link: link, fields: fields));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetChatUsers(chatIds: chatIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetDialogs(@params: @params));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetHistoryAsync(MessagesGetHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetHistory(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> RemoveChatUserAsync(long chatId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => RemoveChatUser(chatId: chatId, userId: userId));
		}

		/// <inheritdoc />
		public Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetLongPollServer(needPts: needPts, lpVersion: lpVersion));
		}

		/// <inheritdoc />
		public Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetLongPollHistory(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> SetChatPhotoAsync(string file)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => SetChatPhoto(messageId: out var _, file: file));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				MarkAsImportant(messageIds: messageIds, important: important));
		}

		/// <inheritdoc />
		public Task<long> SendStickerAsync(MessagesSendStickerParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => SendSticker(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetHistoryAttachments(@params: @params, nextFrom: out var _));
		}

		/// <inheritdoc />
		public Task<string> GetInviteLinkAsync(ulong peerId, bool reset)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetInviteLink(peerId: peerId, reset: reset));
		}

		/// <inheritdoc />
		public Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				IsMessagesFromGroupAllowed(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public Task<long> JoinChatByInviteLinkAsync(string link)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => JoinChatByInviteLink(link: link));
		}

		public Task<bool> MarkAsAnsweredConversationAsync(long peerId, bool answered = true)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => MarkAsAnsweredDialog(peerId: peerId, answered: answered));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantConversationAsync(long peerId, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				MarkAsImportantConversation(peerId: peerId, important: important));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				MarkAsImportantDialog(peerId: peerId, important: important));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(MessageEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Edit(@params: @params));
		}
	}
}