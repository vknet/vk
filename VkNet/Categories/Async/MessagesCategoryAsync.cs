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
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.AddChatUser(chatId, userId));
        }

        /// <inheritdoc />
        public async Task<bool> AllowMessagesFromGroupAsync(long groupId, string key)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.AllowMessagesFromGroup(groupId, key));
        }

        /// <inheritdoc />
        public async Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.CreateChat(userIds, title));
        }

        /// <inheritdoc />
        public async Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool spam, bool deleteForAll)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.Delete(messageIds, spam, deleteForAll));
        }

        /// <inheritdoc />
        public async Task<Chat> DeleteChatPhotoAsync(ulong chatId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.DeleteChatPhoto(out var _, chatId));
        }

        /// <inheritdoc />
        public async Task<bool> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.DeleteDialog(userId,peerId,offset,count));
        }

        /// <inheritdoc />
        public async Task<bool> DenyMessagesFromGroupAsync(long groupId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.DenyMessagesFromGroup(groupId));
        }

        /// <inheritdoc />
        public async Task<bool> EditChatAsync(long chatId, string title)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.EditChat(chatId, title));
        }

        /// <inheritdoc />
        public async Task<MessagesGetObject> GetAsync(MessagesGetParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.Get(@params));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, uint? previewLength = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetById(messageIds, previewLength));
        }

        /// <inheritdoc />
        public async Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.SearchDialogs(query,fields,limit));
        }

        /// <inheritdoc />
        public async Task<VkCollection<Message>> SearchAsync(MessagesSearchParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.Search(@params));
        }

        /// <inheritdoc />
        public async Task<long> SendAsync(MessagesSendParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.Send(@params));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.SendToUserIds(@params));
        }

        /// <inheritdoc />
        public async Task<bool> RestoreAsync(ulong messageId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.Restore(messageId));
        }

        /// <inheritdoc />
        public async Task<bool> MarkAsReadAsync(IEnumerable<long> messageIds, string peerId, long? startMessageId = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.MarkAsRead(messageIds, peerId, startMessageId));
        }

        /// <inheritdoc />
        public async Task<bool> SetActivityAsync(long userId, long? peerId = null, string type = "typing")
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.SetActivity(userId, peerId, type));
        }

        /// <inheritdoc />
        public async Task<LastActivity> GetLastActivityAsync(long userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetLastActivity(userId));
        }

        /// <inheritdoc />
        public async Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetChat(chatId,fields, nameCase));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetChat(chatIds, fields, nameCase));
        }

        /// <inheritdoc />
        public async Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetChatPreview(link, fields));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetChatUsers(chatIds, fields, nameCase));
        }

        /// <inheritdoc />
        public async Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetDialogs(@params));
        }

        /// <inheritdoc />
        public async Task<MessagesGetObject> GetHistoryAsync(MessagesGetHistoryParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetHistory(@params));
        }

        /// <inheritdoc />
        public async Task<bool> RemoveChatUserAsync(long chatId, long userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.RemoveChatUser(chatId, userId));
        }

        /// <inheritdoc />
        public async Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetLongPollServer(needPts, lpVersion));
        }

        /// <inheritdoc />
        public async Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetLongPollHistory(@params));
        }

        /// <inheritdoc />
        public async Task<long> SetChatPhotoAsync(string file)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.SetChatPhoto(out var _,file));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.MarkAsImportant(messageIds, important));
        }

        /// <inheritdoc />
        public async Task<long> SendStickerAsync(MessagesSendStickerParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.SendSticker(@params));
        }

        /// <inheritdoc />
        public async Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetHistoryAttachments(@params, out var _));
        }

        /// <inheritdoc />
        public async Task<string> GetInviteLinkAsync(ulong peerId, bool reset)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.GetInviteLink(peerId, reset));
        }

        /// <inheritdoc />
        public async Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.IsMessagesFromGroupAllowed(groupId, userId));
        }

        /// <inheritdoc />
        public async Task<long> JoinChatByInviteLinkAsync(string link)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.JoinChatByInviteLink(link));
        }

        /// <inheritdoc />
        public async Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.MarkAsAnsweredDialog(peerId, answered));
        }

        /// <inheritdoc />
        public async Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.MarkAsImportantDialog(peerId, important));
        }

        /// <inheritdoc />
        public async Task<bool> EditAsync(MessageEditParams @params)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Messages.Edit(@params));
        }
    }
}