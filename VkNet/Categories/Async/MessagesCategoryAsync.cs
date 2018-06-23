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
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.AddChatUser(chatId: chatId, userId: userId));
		}

		/// <inheritdoc />
		public Task<bool> AllowMessagesFromGroupAsync(long groupId, string key)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.AllowMessagesFromGroup(groupId: groupId, key: key));
		}

		/// <inheritdoc />
		public Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.CreateChat(userIds: userIds, title: title));
		}

		/// <inheritdoc />
		public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool spam, bool deleteForAll)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.Delete(messageIds: messageIds, spam: spam, deleteForAll: deleteForAll));
		}

		/// <inheritdoc />
		public Task<Chat> DeleteChatPhotoAsync(ulong chatId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.DeleteChatPhoto(messageId: out var _, chatId: chatId));
		}

		/// <inheritdoc />
		public Task<bool> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.DeleteDialog(userId: userId, peerId: peerId, offset: offset, count: count));
		}

		/// <inheritdoc />
		public Task<bool> DenyMessagesFromGroupAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.DenyMessagesFromGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public Task<bool> EditChatAsync(long chatId, string title)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.EditChat(chatId: chatId, title: title));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetAsync(MessagesGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Get(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, uint? previewLength = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetById(messageIds: messageIds, previewLength: previewLength));
		}

		/// <inheritdoc />
		public Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.SearchDialogs(query: query, fields: fields, limit: limit));
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> SearchAsync(MessagesSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Search(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> SendAsync(MessagesSendParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Send(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SendToUserIds(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(ulong messageId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Restore(messageId: messageId));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsReadAsync(IEnumerable<long> messageIds, string peerId, long? startMessageId = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.MarkAsRead(messageIds: messageIds, peerId: peerId, startMessageId: startMessageId));
		}

		/// <inheritdoc />
		public Task<bool> SetActivityAsync(long userId, long? peerId = null, string type = "typing")
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SetActivity(userId: userId, peerId: peerId, type: type));
		}

		/// <inheritdoc />
		public Task<LastActivity> GetLastActivityAsync(long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetLastActivity(userId: userId));
		}

		/// <inheritdoc />
		public Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetChat(chatId: chatId, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds
																, ProfileFields fields = null
																, NameCase nameCase = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetChat(chatIds: chatIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetChatPreview(link: link, fields: fields));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetChatUsers(chatIds: chatIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetDialogs(@params: @params));
		}

		/// <inheritdoc />
		public Task<MessagesGetObject> GetHistoryAsync(MessagesGetHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetHistory(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> RemoveChatUserAsync(long chatId, long userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.RemoveChatUser(chatId: chatId, userId: userId));
		}

		/// <inheritdoc />
		public Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetLongPollServer(needPts: needPts, lpVersion: lpVersion));
		}

		/// <inheritdoc />
		public Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetLongPollHistory(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> SetChatPhotoAsync(string file)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SetChatPhoto(messageId: out var _, file: file));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.MarkAsImportant(messageIds: messageIds, important: important));
		}

		/// <inheritdoc />
		public Task<long> SendStickerAsync(MessagesSendStickerParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SendSticker(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetHistoryAttachments(@params: @params, nextFrom: out var _));
		}

		/// <inheritdoc />
		public Task<string> GetInviteLinkAsync(ulong peerId, bool reset)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetInviteLink(peerId: peerId, reset: reset));
		}

		/// <inheritdoc />
		public Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.IsMessagesFromGroupAllowed(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public Task<long> JoinChatByInviteLinkAsync(string link)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.JoinChatByInviteLink(link: link));
		}

		public Task<bool> MarkAsAnsweredConversationAsync(long peerId, bool answered = true)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.MarkAsAnsweredDialog(peerId: peerId, answered: answered));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantConversationAsync(long peerId, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				_vk.Messages.MarkAsImportantConversation(peerId: peerId, important: important));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.MarkAsImportantDialog(peerId: peerId, important: important));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(MessageEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Edit(@params: @params));
		}
	}
}