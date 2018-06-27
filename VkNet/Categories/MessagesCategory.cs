using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с сообщениями.
	/// </summary>
	public partial class MessagesCategory : IMessagesCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с сообщениями.
		/// </summary>
		/// <param name="vk"> API </param>
		public MessagesCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public bool AddChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "user_id", userId }
			};

			return _vk.Call(methodName: "messages.addChatUser", parameters: parameters);
		}

		/// <inheritdoc />
		public bool AllowMessagesFromGroup(long groupId, string key)
		{
			return _vk.Call(methodName: "messages.allowMessagesFromGroup",
				parameters: new VkParameters
				{
					{ "group_id", groupId },
					{ "key", key }
				});
		}

		/// <inheritdoc />
		public bool DenyMessagesFromGroup(long groupId)
		{
			return _vk.Call(methodName: "messages.denyMessagesFromGroup", parameters: new VkParameters { { "group_id", groupId } });
		}

		/// <inheritdoc />
		[Pure]
		public MessagesGetObject Get(MessagesGetParams @params)
		{
			return _vk.Call(methodName: "messages.get", parameters: @params);
		}

		/// <inheritdoc />
		[Pure]
		public MessagesGetObject GetHistory(MessagesGetHistoryParams @params)
		{
			return _vk.Call(methodName: "messages.getHistory", parameters: @params);
		}

		/// <inheritdoc />
		[Pure]
		public VkCollection<Message> GetById(IEnumerable<ulong> messageIds, uint? previewLength = null)
		{
			if (!messageIds.Any())
			{
				throw new System.Exception(message: "messageIds не может быть пустой");
			}

			var parameters = new VkParameters
			{
				{ "message_ids", messageIds },
				{ "preview_length", previewLength }
			};

			return _vk.Call(methodName: "messages.getById", parameters: parameters).ToVkCollectionOf<Message>(selector: r => r);
		}

		/// <inheritdoc />
		[Pure]
		public MessagesGetObject GetDialogs(MessagesDialogsGetParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);

			return _vk.Call(methodName: "messages.getDialogs", parameters: @params);
		}

		/// <inheritdoc />
		[Pure]
		public SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null)
		{
			var parameters = new VkParameters
			{
				{ "q", query },
				{ "fields", fields },
				{ "limit", limit }
			};

			return _vk.Call(methodName: "messages.searchDialogs", parameters: parameters);
		}

		/// <inheritdoc />
		public VkCollection<Message> Search(MessagesSearchParams @params)
		{
			if (string.IsNullOrWhiteSpace(value: @params.Query))
			{
				throw new ArgumentException(message: "Query can not be null or empty.", paramName: nameof(@params.Query));
			}

			return _vk.Call(methodName: "messages.search", parameters: @params).ToVkCollectionOf<Message>(selector: r => r);
		}

		/// <inheritdoc />
		public long Send(MessagesSendParams @params)
		{
			if (string.IsNullOrEmpty(value: @params.Message) && @params.Attachments == null)
			{
				throw new ArgumentException(message: "Message can not be null.", paramName: nameof(@params.Message));
			}

			if (@params.UserIds != null)
			{
				throw new ArgumentException(
					message: "Для отправки сообщения нескольким пользователям используйте метод SendToUserIds(MessagesSendParams).",
					paramName: nameof(@params.Message));
			}

			return _vk.Call(methodName: "messages.send", parameters: @params);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<MessagesSendResult> SendToUserIds(MessagesSendParams @params)
		{
			if (@params.UserIds == null)
			{
				throw new ArgumentException(
					message: "Для отправки сообщения одному пользователю или в беседу используйте метод Send(MessagesSendParams).",
					paramName: nameof(@params.Message));
			}

			return _vk.Call(methodName: "messages.send", parameters: @params).ToReadOnlyCollectionOf<MessagesSendResult>(selector: x => x);
		}

		/// <inheritdoc />
		public bool DeleteConversation(long? userId, long? peerId = null, uint? offset = null, uint? count = null, long? groupId = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "offset", offset },
				{ "peer_id", peerId },
				{ "group_id", groupId }
			};

			if (count <= 10000)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "messages.deleteConversation", parameters: parameters);
		}

		/// <inheritdoc />
		public ConversationResultObject GetConversationsById(IEnumerable<long> peerIds, IEnumerable<string> fields, bool? extended = null,
															ulong? groupId = null)
		{
			return _vk.Call<ConversationResultObject>("messages.getConversationsById",
				new VkParameters
				{
					{ "peer_ids", peerIds },
					{ "fields", fields },
					{ "extended", extended },
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public GetConversationsResult GetConversations(GetConversationsParams getConversationsParams)
		{
			return _vk.Call<GetConversationsResult>("messages.getConversations",
				new VkParameters
				{
					{ "filter", getConversationsParams.Filter },
					{ "fields", getConversationsParams.Fields },
					{ "offset", getConversationsParams.Offset },
					{ "count", getConversationsParams.Count },
					{ "extended", getConversationsParams.Extended },
					{ "start_message_id", getConversationsParams.StartMessageId },
					{ "group_id", getConversationsParams.GroupId }
				});
		}

		/// <inheritdoc />
		public GetConversationMembersResult GetConversationMembers(long peerId, IEnumerable<string> fields, ulong? groupId = null)
		{
			return _vk.Call<GetConversationMembersResult>("messages.getConversationMembers",
				new VkParameters
				{
					{ "peer_id", peerId },
					{ "fields", fields },
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public GetByConversationMessageIdResult GetByConversationMessageId(long peerId, IEnumerable<ulong> conversationMessageIds,
																			IEnumerable<string> fields, bool? extended = null,
																			ulong? groupId = null)
		{
			return _vk.Call<GetByConversationMessageIdResult>("messages.getByConversationMessageId",
				new VkParameters
				{
					{ "peer_id", peerId },
					{ "conversation_message_ids", conversationMessageIds },
					{ "fields", fields },
					{ "extended", extended },
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc />
		public bool DeleteDialog(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
		{
			return DeleteConversation(userId, peerId, offset, count, null);
		}

		/// <inheritdoc />
		public IDictionary<ulong, bool> Delete(IEnumerable<ulong> messageIds, bool spam, bool deleteForAll)
		{
			if (messageIds == null)
			{
				throw new ArgumentNullException(paramName: nameof(messageIds), message: "Parameter messageIds can not be null.");
			}

			var ids = messageIds.ToList();

			if (ids.Count == 0)
			{
				throw new ArgumentException(message: "Parameter messageIds has no elements.", paramName: nameof(messageIds));
			}

			var parameters = new VkParameters
			{
				{ "message_ids", ids },
				{ "spam", spam },
				{ "delete_for_all", deleteForAll }
			};

			var response = _vk.Call(methodName: "messages.delete", parameters: parameters);

			var result = new Dictionary<ulong, bool>();

			foreach (var id in ids)
			{
				bool isDeleted = response[key: id.ToString(provider: CultureInfo.InvariantCulture)];
				result.Add(key: id, value: isDeleted);
			}

			return result;
		}

		/// <inheritdoc />
		public bool Restore(ulong messageId)
		{
			var parameters = new VkParameters
			{
				{ "message_id", messageId }
			};

			return _vk.Call(methodName: "messages.restore", parameters: parameters);
		}

		/// <inheritdoc />
		public bool MarkAsRead(IEnumerable<long> messageIds, string peerId, long? startMessageId = null)
		{
			var parameters = new VkParameters
			{
				{ "message_ids", messageIds },
				{ "peer_id", peerId },
				{ "start_message_id", startMessageId }
			};

			return _vk.Call(methodName: "messages.markAsRead", parameters: parameters);
		}

		/// <inheritdoc />
		public bool SetActivity(long userId, long? peerId = null, string type = "typing")
		{
			var parameters = new VkParameters
			{
				{ "used_id", userId },
				{ "type", type },
				{ "peer_id", peerId }
			};

			return _vk.Call(methodName: "messages.setActivity", parameters: parameters);
		}

		/// <inheritdoc />
		public LastActivity GetLastActivity(long userId)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId }
			};

			var response = _vk.Call(methodName: "messages.getLastActivity", parameters: parameters);

			LastActivity activity = response;
			activity.UserId = userId;

			return activity;
		}

		/// <inheritdoc />
		public Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null)
		{
			return GetChat(chatIds: new[] { chatId }, fields: fields, nameCase: nameCase).FirstOrDefault();
		}

		/// <inheritdoc />
		public ChatPreview GetChatPreview(string link, ProfileFields fields)
		{
			return _vk.Call(methodName: "messages.getChatPreview",
				parameters: new VkParameters
				{
					{ "link", link },
					{ "fields", fields }
				});
		}

		/// <inheritdoc />
		public ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null)
		{
			var isNoEmpty = chatIds == null || !chatIds.Any();

			if (isNoEmpty)
			{
				throw new ArgumentException(message: "At least one chat ID must be defined", paramName: nameof(chatIds));
			}

			var parameters = new VkParameters
			{
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			if (chatIds.Count() > 1)
			{
				parameters.Add(name: "chat_ids", collection: chatIds);
			} else
			{
				parameters.Add(name: "chat_id", value: chatIds.ElementAt(index: 0));
			}

			var response = _vk.Call(methodName: "messages.getChat", parameters: parameters);

			return chatIds.Count() > 1
				? response.ToReadOnlyCollectionOf<Chat>(selector: c => c)
				: new ReadOnlyCollection<Chat>(list: new List<Chat> { response });
		}

		/// <inheritdoc />
		public long CreateChat(IEnumerable<ulong> userIds, string title)
		{
			if (string.IsNullOrEmpty(value: title))
			{
				throw new ArgumentException(message: "Title can not be empty or null.", paramName: nameof(userIds));
			}

			var parameters = new VkParameters
			{
				{ "user_ids", userIds },
				{ "title", title }
			};

			return _vk.Call(methodName: "messages.createChat", parameters: parameters);
		}

		/// <inheritdoc />
		public bool EditChat(long chatId, string title)
		{
			if (string.IsNullOrEmpty(value: title))
			{
				throw new ArgumentException(message: "Title can not be empty or null.", paramName: nameof(title));
			}

			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "title", title }
			};

			return _vk.Call(methodName: "messages.editChat", parameters: parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
		{
			var collection = chatIds.ToList();

			var parameters = new VkParameters
			{
				{ "chat_ids", collection },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			var response = _vk.Call(methodName: "messages.getChatUsers", parameters: parameters);

			var list = new List<User>();

			foreach (var chatId in collection)
			{
				var chatResponse = response[key: chatId.ToString()];
				var users = chatResponse.ToReadOnlyCollectionOf(selector: x => fields != null ? x : new User { Id = (long) x });

				foreach (var user in users)
				{
					var exist = list.Exists(match: first => first.Id == user.Id);

					if (!exist)
					{
						list.Add(item: user);
					}
				}
			}

			return list.ToReadOnlyCollection();
		}

		/// <inheritdoc />
		public bool RemoveChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "user_id", userId }
			};

			return _vk.Call(methodName: "messages.removeChatUser", parameters: parameters);
		}

		/// <inheritdoc />
		[Pure]
		public LongPollServerResponse GetLongPollServer(bool needPts = false, uint lpVersion = 2)
		{
			var parameters = new VkParameters
			{
				{ "lp_version", lpVersion },
				{ "need_pts", needPts }
			};

			return _vk.Call(methodName: "messages.getLongPollServer", parameters: parameters);
		}

		/// <inheritdoc />
		public LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.PreviewLength);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.EventsLimit);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.MsgsLimit);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.MaxMsgId);

			return _vk.Call(methodName: "messages.getLongPollHistory", parameters: @params);
		}

		/// <inheritdoc />
		public Chat DeleteChatPhoto(out ulong messageId, ulong chatId)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId }
			};

			var result = _vk.Call(methodName: "messages.deleteChatPhoto", parameters: parameters);
			messageId = result[key: "message_id"];

			return result[key: "chat"];
		}

		/// <inheritdoc />
		public long SetChatPhoto(out long messageId, string file)
		{
			var parameters = new VkParameters
			{
				{ "file", file }
			};

			var result = _vk.Call(methodName: "messages.setChatPhoto", parameters: parameters);
			messageId = result[key: "message_id"];

			return result[key: "chat"];
		}

		/// <inheritdoc />
		public ReadOnlyCollection<long> MarkAsImportant(IEnumerable<long> messageIds, bool important = true)
		{
			var parameters = new VkParameters
			{
				{ "message_ids", messageIds },
				{ "important", important }
			};

			VkResponseArray result = _vk.Call(methodName: "messages.markAsImportant", parameters: parameters);

			return result.ToReadOnlyCollectionOf<long>(selector: x => x);
		}

		/// <inheritdoc />
		public long SendSticker(MessagesSendStickerParams @params)
		{
			var parameters = @params;

			return _vk.Call(methodName: "messages.sendSticker", parameters: parameters);
		}

		/// <inheritdoc />
		public ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom)
		{
			var result = _vk.Call(methodName: "messages.getHistoryAttachments", parameters: @params);

			nextFrom = result[key: "next_from"];

			return result.ToReadOnlyCollectionOf<HistoryAttachment>(selector: o => o);
		}

		/// <inheritdoc />
		public string GetInviteLink(ulong peerId, bool reset)
		{
			return _vk.Call(methodName: "messages.getInviteLink",
				parameters: new VkParameters
				{
					{ "peer_id", peerId },
					{ "reset", reset }
				})[key: "link"];
		}

		/// <inheritdoc />
		public bool IsMessagesFromGroupAllowed(ulong groupId, ulong userId)
		{
			return _vk.Call(methodName: "messages.isMessagesFromGroupAllowed",
				parameters: new VkParameters
				{
					{ "group_id", groupId },
					{ "user_id", userId }
				})[key: "is_allowed"];
		}

		/// <inheritdoc />
		public long JoinChatByInviteLink(string link)
		{
			return _vk.Call(methodName: "messages.joinChatByInviteLink", parameters: new VkParameters { { "link", link } })[key: "chat_id"];
		}

		/// <inheritdoc />
		public bool MarkAsAnsweredConversation(long peerId, bool answered = true)
		{
			return _vk.Call(methodName: "messages.markAsAnsweredConversation",
				parameters: new VkParameters
				{
					{ "peer_id", peerId },
					{ "answered", answered }
				});
		}

		/// <inheritdoc />
		public bool MarkAsAnsweredDialog(long peerId, bool answered = true)
		{
			return MarkAsAnsweredConversation(peerId, answered);
		}

		/// <inheritdoc />
		public bool MarkAsImportantConversation(long peerId, bool important = true)
		{
			return _vk.Call(methodName: "messages.markAsImportantConversation",
				parameters: new VkParameters
				{
					{ "peer_id", peerId },
					{ "important", important }
				});
		}

		/// <inheritdoc />
		public bool MarkAsImportantDialog(long peerId, bool important = true)
		{
			return MarkAsImportantConversation(peerId, important);
		}

		/// <inheritdoc />
		public bool Edit(MessageEditParams @params)
		{
			return _vk.Call(methodName: "messages.edit", parameters: @params);
		}

		/// <summary>
		/// Ворзвращает указанное сообщение по его идентификатору.
		/// </summary>
		/// <param name="messageId"> Идентификатор запрошенного сообщения. </param>
		/// <param name="previewLength">
		/// Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не
		/// обрезаются).
		/// </param>
		/// <returns>
		/// Запрошенное сообщение, null если сообщение с заданным идентификатором не
		/// найдено.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getById
		/// </remarks>
		[Pure]
		public Message GetById(ulong messageId, uint? previewLength = null)
		{
			var result = GetById(messageIds: new[] { messageId }, previewLength: previewLength);

			if (result.Count > 0)
			{
				return result.First();
			}

			throw new VkApiException(message: "Сообщения с таким ID не существует.");
		}
	}
}