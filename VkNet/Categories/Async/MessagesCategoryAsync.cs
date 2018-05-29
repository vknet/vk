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
		public async Task<bool> AddChatUserAsync(long chatId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.AddChatUser(chatId: chatId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<bool> AllowMessagesFromGroupAsync(long groupId, string key)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.AllowMessagesFromGroup(groupId: groupId, key: key));
		}

		/// <inheritdoc />
		public async Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.CreateChat(userIds: userIds, title: title));
		}

		/// <inheritdoc />
		public async Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool spam, bool deleteForAll)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.Delete(messageIds: messageIds, spam: spam, deleteForAll: deleteForAll));
		}

		/// <inheritdoc />
		public async Task<Chat> DeleteChatPhotoAsync(ulong chatId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.DeleteChatPhoto(messageId: out var _, chatId: chatId));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.DeleteDialog(userId: userId, peerId: peerId, offset: offset, count: count));
		}

		/// <inheritdoc />
		public async Task<bool> DenyMessagesFromGroupAsync(long groupId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.DenyMessagesFromGroup(groupId: groupId));
		}

		/// <inheritdoc />
		public async Task<bool> EditChatAsync(long chatId, string title)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.EditChat(chatId: chatId, title: title));
		}

		/// <inheritdoc />
		public async Task<MessagesGetObject> GetAsync(MessagesGetParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Get(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, uint? previewLength = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetById(messageIds: messageIds, previewLength: previewLength));
		}

		/// <inheritdoc />
		public async Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.SearchDialogs(query: query, fields: fields, limit: limit));
		}

		/// <inheritdoc />
		public async Task<VkCollection<Message>> SearchAsync(MessagesSearchParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Search(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> SendAsync(MessagesSendParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Send(@params: @params));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SendToUserIds(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> RestoreAsync(ulong messageId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Restore(messageId: messageId));
		}

		/// <inheritdoc />
		public async Task<bool> MarkAsReadAsync(IEnumerable<long> messageIds, string peerId, long? startMessageId = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.MarkAsRead(messageIds: messageIds, peerId: peerId, startMessageId: startMessageId));
		}

		/// <inheritdoc />
		public async Task<bool> SetActivityAsync(long userId, long? peerId = null, string type = "typing")
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SetActivity(userId: userId, peerId: peerId, type: type));
		}

		/// <inheritdoc />
		public async Task<LastActivity> GetLastActivityAsync(long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetLastActivity(userId: userId));
		}

		/// <inheritdoc />
		public async Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetChat(chatId: chatId, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds
																, ProfileFields fields = null
																, NameCase nameCase = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetChat(chatIds: chatIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public async Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetChatPreview(link: link, fields: fields));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetChatUsers(chatIds: chatIds, fields: fields, nameCase: nameCase));
		}

		/// <inheritdoc />
		public async Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetDialogs(@params: @params));
		}

		/// <inheritdoc />
		public async Task<MessagesGetObject> GetHistoryAsync(MessagesGetHistoryParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetHistory(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> RemoveChatUserAsync(long chatId, long userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.RemoveChatUser(chatId: chatId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetLongPollServer(needPts: needPts, lpVersion: lpVersion));
		}

		/// <inheritdoc />
		public async Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetLongPollHistory(@params: @params));
		}

		/// <inheritdoc />
		public async Task<long> SetChatPhotoAsync(string file)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SetChatPhoto(messageId: out var _, file: file));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.MarkAsImportant(messageIds: messageIds, important: important));
		}

		/// <inheritdoc />
		public async Task<long> SendStickerAsync(MessagesSendStickerParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.SendSticker(@params: @params));
		}

		/// <inheritdoc />
		public async Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.GetHistoryAttachments(@params: @params, nextFrom: out var _));
		}

		/// <inheritdoc />
		public async Task<string> GetInviteLinkAsync(ulong peerId, bool reset)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.GetInviteLink(peerId: peerId, reset: reset));
		}

		/// <inheritdoc />
		public async Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.IsMessagesFromGroupAllowed(groupId: groupId, userId: userId));
		}

		/// <inheritdoc />
		public async Task<long> JoinChatByInviteLinkAsync(string link)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.JoinChatByInviteLink(link: link));
		}

		/// <inheritdoc />
		public async Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.MarkAsAnsweredDialog(peerId: peerId, answered: answered));
		}

		/// <inheritdoc />
		public async Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Messages.MarkAsImportantDialog(peerId: peerId, important: important));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(MessageEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Messages.Edit(@params: @params));
		}
	}
}