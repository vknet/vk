using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Messages;
using VkNet.Model.Results.Messages;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IMessagesCategoryAsync"/>
	public interface IMessagesCategory : IMessagesCategoryAsync
	{
		/// <inheritdoc cref="IMessagesCategoryAsync.AddChatUserAsync"/>
		bool AddChatUser(long chatId, long userId);

		/// <inheritdoc cref="IMessagesCategoryAsync.AllowMessagesFromGroupAsync"/>
		bool AllowMessagesFromGroup(long groupId, string key);

		/// <inheritdoc cref="IMessagesCategoryAsync.CreateChatAsync"/>
		long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteAsync"/>
		IDictionary<ulong, bool> Delete([NotNull] IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null,
										bool? deleteForAll = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteAsync"/>
		IDictionary<ulong, bool> Delete([NotNull] IEnumerable<ulong> conversationMessageIds, ulong peerId, 
												bool? spam = null, ulong? groupId = null,
												bool? deleteForAll = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteChatPhotoAsync"/>
		Chat DeleteChatPhoto(out ulong messageId, ulong chatId, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.DenyMessagesFromGroupAsync"/>
		bool DenyMessagesFromGroup(long groupId);

		/// <inheritdoc cref="IMessagesCategoryAsync.EditChatAsync"/>
		bool EditChat(long chatId, [NotNull] string title);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetByIdAsync"/>
		VkCollection<Message> GetById([NotNull] IEnumerable<ulong> messageIds, IEnumerable<string> fields, ulong? previewLength = null,
									bool? extended = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SearchAsync"/>
		MessageSearchResult Search(MessagesSearchParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendAsync"/>
		long Send(MessagesSendParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendToUserIdsAsync"/>
		ReadOnlyCollection<MessagesSendResult> SendToUserIds(MessagesSendParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.RestoreAsync"/>
		bool Restore(ulong messageId, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsReadAsync"/>
		bool MarkAsRead(string peerId, long? startMessageId = null, long? groupId = null, bool? markConversationAsRead = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SetActivityAsync"/>
		bool SetActivity(string userId, MessageActivityType type, long? peerId = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetLastActivityAsync"/>
		LastActivity GetLastActivity(long userId);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatAsync(long, ProfileFields,NameCase)"/>
		Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatAsync(long, ProfileFields, NameCase)"/>
		ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatPreviewAsync"/>
		ChatPreview GetChatPreview(string link, ProfileFields fields);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetHistoryAsync"/>
		MessageGetHistoryObject GetHistory(MessagesGetHistoryParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.RemoveChatUserAsync"/>
		bool RemoveChatUser(ulong chatId, long? userId = null, long? memberId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetLongPollServerAsync"/>
		LongPollServerResponse GetLongPollServer(bool needPts = false, uint lpVersion = 2, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetLongPollHistoryAsync"/>
		LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.SetChatPhotoAsync"/>
		long SetChatPhoto(out long messageId, string file);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsImportantAsync"/>
		ReadOnlyCollection<long> MarkAsImportant([NotNull] IEnumerable<long> messageIds, bool important = true);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendStickerAsync"/>
		long SendSticker(MessagesSendStickerParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetHistoryAttachmentsAsync"/>
		ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetInviteLinkAsync"/>
		string GetInviteLink(ulong peerId, bool reset);

		/// <inheritdoc cref="IMessagesCategoryAsync.IsMessagesFromGroupAllowedAsync"/>
		bool IsMessagesFromGroupAllowed(ulong groupId, ulong userId);

		/// <inheritdoc cref="IMessagesCategoryAsync.JoinChatByInviteLinkAsync"/>
		long JoinChatByInviteLink(string link);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsAnsweredConversationAsync"/>
		bool MarkAsAnsweredConversation(long peerId, bool? answered = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsImportantConversationAsync"/>
		bool MarkAsImportantConversation(long peerId, bool? important = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.EditAsync"/>
		bool Edit(MessageEditParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteConversationAsync"/>
		ulong DeleteConversation(long? userId, long? peerId = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetConversationsByIdAsync"/>
		ConversationResult GetConversationsById(IEnumerable<long> peerIds, IEnumerable<string> fields = null, bool? extended = null,
												ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetConversationsAsync"/>
		GetConversationsResult GetConversations(GetConversationsParams getConversationsParams);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetConversationMembersAsync"/>
		GetConversationMembersResult GetConversationMembers(long peerId, IEnumerable<string> fields = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetByConversationMessageIdAsync"/>
		GetByConversationMessageIdResult GetByConversationMessageId(long peerId, [NotNull] IEnumerable<ulong> conversationMessageIds,
																	IEnumerable<string> fields,
																	bool? extended = null, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SearchConversationsAsync"/>
		SearchConversationsResult SearchConversations(string q, IEnumerable<string> fields, ulong? count = null, bool? extended = null,
													ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.PinAsync"/>
		PinnedMessage Pin(long peerId, ulong? messageId = null, ulong? conversationMessageId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.UnpinAsync"/>
		bool Unpin(long peerId, ulong? groupId = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetImportantMessagesAsync"/>
		GetImportantMessagesResult GetImportantMessages(GetImportantMessagesParams getImportantMessagesParams);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetRecentCallsAsync"/>
		GetRecentCallsResult GetRecentCalls(IEnumerable<string> fields, ulong? count = null, ulong? startMessageId = null,
											bool? extended = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.SendMessageEventAnswerAsync"/>
		bool SendMessageEventAnswer(string eventId, long userId, long peerId, EventData eventData = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsUnreadConversationAsync"/>
		bool MarkAsUnreadConversation(long peerId);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetIntentUsersAsync"/>
		GetIntentUsersResult GetIntentUsers(MessagesGetIntentUsersParams getIntentUsersParams);

	#region Obsoleted

		/// <inheritdoc cref="IMessagesCategoryAsync.DeleteDialogAsync"/>
		[Obsolete(ObsoleteText.MessageDeleteDialog)]
		ulong DeleteDialog(long? userId, long? peerId = null, uint? offset = null, uint? count = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsAnsweredDialogAsync"/>
		[Obsolete(ObsoleteText.MessageMarkAsAnsweredDialog)]
		bool MarkAsAnsweredDialog(long peerId, bool answered = true);

		/// <inheritdoc cref="IMessagesCategoryAsync.MarkAsImportantDialogAsync"/>
		[Obsolete(ObsoleteText.MessageMarkAsImportantDialog)]
		bool MarkAsImportantDialog(long peerId, bool important = true);

		/// <inheritdoc cref="IMessagesCategoryAsync.SearchDialogsAsync"/>
		[Obsolete(ObsoleteText.MessageSearchDialogs)]
		SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetAsync"/>
		[Obsolete(ObsoleteText.MessageGet)]
		MessagesGetObject Get(MessagesGetParams @params);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetChatUsersAsync"/>
		[Obsolete(ObsoleteText.MessageGetChatUsers)]
		ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase);

		/// <inheritdoc cref="IMessagesCategoryAsync.GetDialogsAsync"/>
		[Obsolete(ObsoleteText.MessageGet)]
		MessagesGetObject GetDialogs(MessagesDialogsGetParams @params);

	#endregion
	}
}