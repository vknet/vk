using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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
		public Task<bool> AddChatUserAsync(long chatId, long userId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.addChatUser", new VkParameters
			{
				{ "chat_id", chatId },
				{ "user_id", userId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> AllowMessagesFromGroupAsync(long groupId, string key, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.allowMessagesFromGroup", new VkParameters
			{
				{ "group_id", groupId },
				{ "key", key }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<long> CreateChatAsync(IEnumerable<ulong> userIds, string title, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<long>("messages.createChat", new VkParameters
			{
				{ "user_ids", userIds },
				{ "title", title }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null, bool? deleteForAll = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<IDictionary<ulong, bool>>("messages.delete", new VkParameters
			{
				{ "message_ids", messageIds },
				{ "spam", spam },
				{ "group_id", groupId },
				{ "delete_for_all", deleteForAll }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<Chat> DeleteChatPhotoAsync(ulong chatId, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("messages.deleteChatPhoto", new VkParameters
									{
										{ "chat_id", chatId },
										{ "group_id", groupId }
									}, cancellationToken: cancellationToken)
									.ConfigureAwait(false);

			return response["chat"];
		}

		/// <inheritdoc />
		public Task<bool> DenyMessagesFromGroupAsync(long groupId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.denyMessagesFromGroup", new VkParameters { { "group_id", groupId } }, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> EditChatAsync(long chatId, string title, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.editChat", new VkParameters
			{
				{ "chat_id", chatId },
				{ "title", title }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<VkCollection<Message>> GetByIdAsync(IEnumerable<ulong> messageIds, IEnumerable<string> fields, ulong? previewLength = null, bool? extended = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<VkCollection<Message>>("messages.getById", new VkParameters
			{
				{ "message_ids", messageIds },
				{ "fields", fields },
				{ "preview_length", previewLength },
				{ "extended", extended },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<MessageSearchResult> SearchAsync(MessagesSearchParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<MessageSearchResult>("messages.search", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<long> SendAsync(MessagesSendParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<long>("messages.send", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<MessagesSendResult>>("messages.send", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> RestoreAsync(ulong messageId, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.restore", new VkParameters
			{
				{ "message_id", messageId },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> MarkAsReadAsync(string peerId, long? startMessageId = null, long? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.markAsRead", new VkParameters
			{
				{ "peer_id", peerId },
				{ "start_message_id", startMessageId },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> SetActivityAsync(string userId, MessageActivityType type, long? peerId = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.setActivity", new VkParameters
			{
				{ "used_id", userId },
				{ "type", type },
				{ "peer_id", peerId },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<LastActivity> GetLastActivityAsync(long userId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<LastActivity>("messages.getLastActivity", new VkParameters { { "user_id", userId } }, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null, CancellationToken cancellationToken = default)
		{
			var chats = await GetChatAsync(new[] { chatId }, fields, nameCase, cancellationToken).ConfigureAwait(false);

			return chats.FirstOrDefault();
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<Chat>>("messages.getChat", new VkParameters
			{
				{ "fields", fields },
				{ "name_case", nameCase },
				{ "chat_ids", chatIds }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ChatPreview>("messages.getChatPreview", new VkParameters
			{
				{ "link", link },
				{ "fields", fields }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<MessageGetHistoryObject> GetHistoryAsync(MessagesGetHistoryParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<MessageGetHistoryObject>("messages.getHistory", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> RemoveChatUserAsync(ulong chatId, long? userId = null, long? memberId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.removeChatUser", new VkParameters
			{
				{ "chat_id", chatId },
				{ "user_id", userId },
				{ "member_id", memberId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<LongPollServerResponse>("messages.getLongPollServer", new VkParameters
			{
				{ "group_id", groupId },
				{ "lp_version", lpVersion },
				{ "need_pts", needPts }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<LongPollHistoryResponse>("messages.getLongPollHistory", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<long> SetChatPhotoAsync(string file, CancellationToken cancellationToken = default)
		{
			var json = JObject.Parse(file);
			var rawResponse = json["response"];

			var parameters = new VkParameters { { "file", rawResponse } };

			var result = await _vk.CallAsync("messages.setChatPhoto", parameters, cancellationToken: cancellationToken);

			return result["chat"];
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<long>>("messages.markAsImportant", new VkParameters
			{
				{ "message_ids", messageIds },
				{ "important", important }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<long> SendStickerAsync(MessagesSendStickerParams parameters, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<long>("messages.sendSticker", parameters, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<HistoryAttachment>>("messages.getHistoryAttachments", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public async Task<string> GetInviteLinkAsync(ulong peerId, bool reset, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("messages.getInviteLink", new VkParameters
									{
										{ "peer_id", peerId },
										{ "reset", reset }
									}, cancellationToken: cancellationToken)
									.ConfigureAwait(false);

			return response["link"];
		}

		/// <inheritdoc />
		public async Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("messages.isMessagesFromGroupAllowed", new VkParameters
									{
										{ "group_id", groupId },
										{ "user_id", userId }
									}, cancellationToken: cancellationToken)
									.ConfigureAwait(false);

			return response["is_allowed"];
		}

		/// <inheritdoc />
		public async Task<long> JoinChatByInviteLinkAsync(string link, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("messages.joinChatByInviteLink", new VkParameters { { "link", link } }, cancellationToken: cancellationToken).ConfigureAwait(false);

			return response["chat_id"];
		}

		/// <inheritdoc />
		public Task<bool> MarkAsAnsweredConversationAsync(long peerId, bool? answered = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.markAsAnsweredConversation", new VkParameters
			{
				{ "peer_id", peerId },
				{ "answered", answered },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> MarkAsImportantConversationAsync(long peerId, bool? important = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.markAsImportantConversation", new VkParameters
			{
				{ "peer_id", peerId },
				{ "important", important },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(MessageEditParams @params, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.edit", @params, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> DeleteConversationAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null, long? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.deleteConversation", new VkParameters
			{
				{ "user_id", userId },
				{ "offset", offset },
				{ "peer_id", peerId },
				{ "group_id", groupId },
				{ "count", count }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<ConversationResultObject> GetConversationsByIdAsync(IEnumerable<long> peerIds, IEnumerable<string> fields, bool? extended = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ConversationResultObject>("messages.getConversationsById", new VkParameters
			{
				{ "peer_ids", peerIds },
				{ "fields", fields },
				{ "extended", extended },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<GetConversationsResult> GetConversationsAsync(GetConversationsParams getConversationsParams, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<GetConversationsResult>("messages.getConversations", new VkParameters
			{
				{ "filter", getConversationsParams.Filter },
				{ "fields", getConversationsParams.Fields },
				{ "offset", getConversationsParams.Offset },
				{ "count", getConversationsParams.Count },
				{ "extended", getConversationsParams.Extended },
				{ "start_message_id", getConversationsParams.StartMessageId },
				{ "group_id", getConversationsParams.GroupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<GetConversationMembersResult> GetConversationMembersAsync(long peerId, IEnumerable<string> fields, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<GetConversationMembersResult>("messages.getConversationMembers", new VkParameters
			{
				{ "peer_id", peerId },
				{ "fields", fields },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<GetByConversationMessageIdResult> GetByConversationMessageIdAsync(long peerId, IEnumerable<ulong> conversationMessageIds, IEnumerable<string> fields, bool? extended = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<GetByConversationMessageIdResult>("messages.getByConversationMessageId", new VkParameters
			{
				{ "peer_id", peerId },
				{ "conversation_message_ids", conversationMessageIds },
				{ "fields", fields },
				{ "extended", extended },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<SearchConversationsResult> SearchConversationsAsync(string q, IEnumerable<string> fields, ulong? count = null, bool? extended = null, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<SearchConversationsResult>("messages.searchConversations", new VkParameters
			{
				{ "q", q },
				{ "fields", fields },
				{ "count", count },
				{ "extended", extended },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<PinnedMessage> PinAsync(long peerId, ulong? messageId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<PinnedMessage>("messages.pin", new VkParameters
			{
				{ "peer_id", peerId },
				{ "message_id", messageId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> UnpinAsync(long peerId, ulong? groupId = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("messages.unpin", new VkParameters
			{
				{ "peer_id", peerId },
				{ "group_id", groupId }
			}, cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<GetImportantMessagesResult> GetImportantMessagesAsync(GetImportantMessagesParams getImportantMessagesParams, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<GetImportantMessagesResult>("messages.getImportantMessages", GetImportantMessagesParams.ToVkParameters(getImportantMessagesParams), cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<GetRecentCallsResult> GetRecentCallsAsync(IEnumerable<string> fields, ulong? count = null, ulong? startMessageId = null, bool? extended = null, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<GetRecentCallsResult>("messages.getRecentCalls", new VkParameters
			{
				{ "fields", fields },
				{ "count", count },
				{ "start_message_id", startMessageId },
				{ "extended", extended }
			}, cancellationToken: cancellationToken);
		}
	}
}