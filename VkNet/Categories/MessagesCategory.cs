using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Messages;
using VkNet.Model.Results.Messages;
using VkNet.Utils;

// ReSharper disable MemberCanBePrivate.Global

namespace VkNet.Categories;

/// <inheritdoc />
public partial class MessagesCategory : IMessagesCategory
{
	private readonly IVkApi _vk;

	/// <summary>
	/// Методы для работы с сообщениями.
	/// </summary>
	/// <param name="vk"> API </param>
	public MessagesCategory(IVkApi vk) => _vk = vk;

	/// <inheritdoc />
	public bool AddChatUser(long chatId, long userId)
	{
		var parameters = new VkParameters
		{
			{
				"chat_id", chatId
			},
			{
				"user_id", userId
			}
		};

		return _vk.Call("messages.addChatUser", parameters);
	}

	/// <inheritdoc />
	public bool AllowMessagesFromGroup(long groupId, string key) => _vk.Call("messages.allowMessagesFromGroup",
		new()
		{
			{
				"group_id", groupId
			},
			{
				"key", key
			}
		});

	/// <inheritdoc />
	public bool DenyMessagesFromGroup(long groupId) => _vk.Call("messages.denyMessagesFromGroup",
		new()
		{
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	[Pure]
	public MessagesGetObject Get(MessagesGetParams @params) => _vk.Call<MessagesGetObject>("messages.get",
		new()
		{
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			},
			{
				"time_offset", @params.TimeOffset
			},
			{
				"filters", @params.Filters
			},
			{
				"preview_length", @params.PreviewLength
			},
			{
				"last_message_id", @params.LastMessageId
			}
		});

	/// <inheritdoc />
	[Pure]
	public MessageGetHistoryObject GetHistory(MessagesGetHistoryParams @params) => _vk.Call<MessageGetHistoryObject>("messages.getHistory",
		new()
		{
			{
				"user_id", @params.UserId
			},
			{
				"fields", @params.Fields
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			},
			{
				"peer_id", @params.PeerId
			},
			{
				"start_message_id", @params.StartMessageId
			},
			{
				"rev", @params.Reversed
			},
			{
				"extended", @params.Extended
			},
			{
				"group_id", @params.GroupId
			}
		});

	/// <inheritdoc />
	[Pure]
	public VkCollection<Message> GetById(IEnumerable<ulong> messageIds, IEnumerable<string> fields, ulong? previewLength = null,
										bool? extended = null, ulong? groupId = null) => _vk.Call<VkCollection<Message>>("messages.getById",
			new()
			{
				{
					"message_ids", messageIds
				},
				{
					"fields", fields
				},
				{
					"preview_length", previewLength
				},
				{
					"extended", extended
				},
				{
					"group_id", groupId
				}
			});

	/// <inheritdoc />
	[Pure]
	public MessagesGetObject GetDialogs(MessagesDialogsGetParams @params)
	{
		VkErrors.ThrowIfNumberIsNegative(() => @params.Count);

		return _vk.Call<MessagesGetObject>("messages.getDialogs",
			new()
			{
				{
					"start_message_id", @params.StartMessageId
				},
				{
					"offset", @params.Offset
				},
				{
					"count", @params.Count
				},
				{
					"unread", @params.Unread
				},
				{
					"preview_length", @params.PreviewLength
				},
				{
					"important", @params.Important
				},
				{
					"unanswered", @params.Unanswered
				}
			});
	}

	/// <inheritdoc />
	[Pure]
	public SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null)
	{
		var parameters = new VkParameters
		{
			{
				"q", query
			},
			{
				"fields", fields
			},
			{
				"limit", limit
			}
		};

		var response = _vk.Call("messages.searchDialogs", parameters);

		var result = new SearchDialogsResponse
		{
			Users = new List<User>(),
			Chats = new List<Chat>(),
			Groups = new List<Group>()
		};

		VkResponseArray responseArray = response;

		foreach (var record in responseArray)
		{
			string type = record[key: "type"];

			switch (type)
			{
				case "profile":

				{
					result.Users.Add(JsonConvert.DeserializeObject<User>(record.ToString()));

					break;
				}

				case "chat":

				{
					result.Chats.Add(JsonConvert.DeserializeObject<Chat>(record.ToString()));

					break;
				}

				case "email":

				{
					// TODO: Add email support.
					continue;
				}

				case "group":

				{
					result.Groups.Add(JsonConvert.DeserializeObject<Group>(record.ToString()));

					break;
				}
			}
		}

		return result;
	}

	/// <inheritdoc />
	public MessageSearchResult Search(MessagesSearchParams @params) => _vk.Call<MessageSearchResult>("messages.search",
		new()
		{
			{
				"q", @params.Query
			},
			{
				"fields", @params.Fields
			},
			{
				"peer_id", @params.PeerId
			},
			{
				"date", @params.Date
			},
			{
				"preview_length", @params.PreviewLength
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			},
			{
				"extended", @params.Extended
			},
			{
				"group_id", @params.GroupId
			}
		});

	/// <exception cref="ArgumentNullException"> </exception>
	/// <inheritdoc />
	public long Send(MessagesSendParams @params)
	{
		if (@params.UserIds != null && @params.UserIds.Any())
		{
			throw new ArgumentException($"This method not intended to use with many target users. Use {nameof(SendToUserIds)} instead.");
		}

		if (@params.PeerIds != null && @params.PeerIds.Any())
		{
			throw new ArgumentException($"This method not intended to use with many target peers. Use {nameof(SendToPeerIds)} instead.");
		}

		if (_vk.VkApiVersion.IsGreaterThanOrEqual(5, 90) && @params.RandomId == null)
		{
			throw new ArgumentException($"{nameof(@params.RandomId)} обязательное значение.");
		}

		return _vk.Call("messages.send",
			new()
			{
				{
					"user_id", @params.UserId
				},
				{
					"domain", @params.Domain
				},
				{
					"title", @params.Title
				},
				{
					"chat_id", @params.ChatId
				},
				{
					"user_ids", @params.UserIds
				},
				{
					"message", @params.Message
				},
				{
					"random_id", @params.RandomId
				},
				{
					"lat", @params.Lat
				},
				{
					"long", @params.Longitude
				},
				{
					"attachment", @params.Attachments
				},
				{
					"reply_to", @params.ReplyTo
				},
				{
					"forward_messages", @params.ForwardMessages
				},
				{
					"forward", @params.Forward != null
						? JsonConvert.SerializeObject(@params.Forward)
						: ""
				},
				{
					"keyboard", @params.Keyboard != null
						? JsonConvert.SerializeObject(@params.Keyboard)
						: ""
				},
				{
					"sticker_id", @params.StickerId
				},
				{
					"peer_id", @params.PeerId
				},
				{
					"payload", @params.Payload
				},
				{
					"content_source", @params.ContentSource != null
						? JsonConvert.SerializeObject(@params.ContentSource)
						: ""
				},
				{
					"group_id", @params.GroupId
				},
				{
					"dont_parse_links", @params.DontParseLinks
				},
				{
					"disable_mentions", @params.DisableMentions
				},
				{
					"intent", @params.Intent
				},
				{
					"subscribe_id", @params.SubscribeId
				},
				{
					"template", @params.Template != null
						? JsonConvert.SerializeObject(@params.Template)
						: ""
				}
			});
	}

	/// <inheritdoc />
	public ReadOnlyCollection<MessagesSendResult> SendToUserIds(MessagesSendParams @params) {
		if (@params.PeerIds != null && @params.PeerIds.Any())
		{
			throw new ArgumentException($"This method not intended to use with many target peers. Use {nameof(SendToPeerIds)} instead.");
		}

		return _vk.Call<ReadOnlyCollection<MessagesSendResult>>("messages.send",
			new()
			{
				{
					"user_id", @params.UserId
				},
				{
					"domain", @params.Domain
				},
				{
					"title", @params.Title
				},
				{
					"chat_id", @params.ChatId
				},
				{
					"user_ids", @params.UserIds
				},
				{
					"message", @params.Message
				},
				{
					"random_id", @params.RandomId
				},
				{
					"lat", @params.Lat
				},
				{
					"long", @params.Longitude
				},
				{
					"attachment", @params.Attachments
				},
				{
					"reply_to", @params.ReplyTo
				},
				{
					"forward_messages", @params.ForwardMessages
				},
				{
					"forward", @params.Forward != null
						? JsonConvert.SerializeObject(@params.Forward)
						: ""
				},
				{
					"keyboard", @params.Keyboard != null
						? JsonConvert.SerializeObject(@params.Keyboard)
						: ""
				},
				{
					"sticker_id", @params.StickerId
				},
				{
					"peer_id", @params.PeerId
				},
				{
					"payload", @params.Payload
				},
				{
					"content_source", @params.ContentSource != null
						? JsonConvert.SerializeObject(@params.ContentSource)
						: ""
				},
				{
					"group_id", @params.GroupId
				},
				{
					"dont_parse_links", @params.DontParseLinks
				},
				{
					"disable_mentions", @params.DisableMentions
				},
				{
					"intent", @params.Intent
				},
				{
					"subscribe_id", @params.SubscribeId
				},
				{
					"template", @params.Template != null
						? JsonConvert.SerializeObject(@params.Template)
						: ""
				}
			});
	}

	/// <inheritdoc />
	public ReadOnlyCollection<MessagesSendResult> SendToPeerIds(MessagesSendParams @params)
	{
		if (@params.PeerIds == null || !@params.PeerIds.Any())
		{
			throw new ArgumentException("PeerIds cannot be null or empty");
		}

		if (@params.PeerId != null || @params.UserId != null)
		{
			throw new ArgumentException($"This method not intended to use with PeerId or UserId. Use {nameof(Send)} instead.");
		}

		if (@params.UserIds != null && @params.UserIds.Any())
		{
			throw new ArgumentException($"This method not intended to use with many target users. Use {nameof(SendToUserIds)} instead.");
		}

		return _vk.Call<ReadOnlyCollection<MessagesSendResult>>("messages.send",
			new()
			{
				{
					"domain", @params.Domain
				},
				{
					"title", @params.Title
				},
				{
					"chat_id", @params.ChatId
				},
				{
					"message", @params.Message
				},
				{
					"random_id", @params.RandomId
				},
				{
					"lat", @params.Lat
				},
				{
					"long", @params.Longitude
				},
				{
					"attachment", @params.Attachments
				},
				{
					"reply_to", @params.ReplyTo
				},
				{
					"forward_messages", @params.ForwardMessages
				},
				{
					"forward", @params.Forward != null
						? JsonConvert.SerializeObject(@params.Forward)
						: ""
				},
				{
					"keyboard", @params.Keyboard != null
						? JsonConvert.SerializeObject(@params.Keyboard)
						: ""
				},
				{
					"sticker_id", @params.StickerId
				},
				{
					"peer_id", @params.PeerId
				},
				{
					"peer_ids", @params.PeerIds
				},
				{
					"payload", @params.Payload
				},
				{
					"content_source", @params.ContentSource != null
						? JsonConvert.SerializeObject(@params.ContentSource)
						: ""
				},
				{
					"group_id", @params.GroupId
				},
				{
					"dont_parse_links", @params.DontParseLinks
				},
				{
					"disable_mentions", @params.DisableMentions
				},
				{
					"intent", @params.Intent
				},
				{
					"subscribe_id", @params.SubscribeId
				},
				{
					"template", @params.Template != null
						? JsonConvert.SerializeObject(@params.Template)
						: ""
				}
			});
	}


	/// <inheritdoc />
	public ulong DeleteConversation(long? userId, long? peerId = null, ulong? groupId = null)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			},
			{
				"peer_id", peerId
			},
			{
				"group_id", groupId
			}
		};

		return _vk.Call("messages.deleteConversation", parameters)["last_deleted_id"];
	}

	/// <inheritdoc />
	public ConversationResult GetConversationsById(IEnumerable<long> peerIds, IEnumerable<string> fields = null, bool? extended = null,
													ulong? groupId = null) => _vk.Call<ConversationResult>("messages.getConversationsById",
		new()
		{
			{
				"peer_ids", peerIds
			},
			{
				"fields", fields
			},
			{
				"extended", extended
			},
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public GetConversationsResult GetConversations(GetConversationsParams getConversationsParams) => _vk.Call<GetConversationsResult>(
		"messages.getConversations",
		new()
		{
			{
				"filter", getConversationsParams.Filter
			},
			{
				"fields", getConversationsParams.Fields
			},
			{
				"offset", getConversationsParams.Offset
			},
			{
				"count", getConversationsParams.Count
			},
			{
				"extended", getConversationsParams.Extended
			},
			{
				"start_message_id", getConversationsParams.StartMessageId
			},
			{
				"group_id", getConversationsParams.GroupId
			}
		});

	/// <inheritdoc />
	public GetConversationMembersResult GetConversationMembers(long peerId, IEnumerable<string> fields = null, ulong? groupId = null) =>
		_vk.Call<GetConversationMembersResult>("messages.getConversationMembers",
			new()
			{
				{
					"peer_id", peerId
				},
				{
					"fields", fields
				},
				{
					"group_id", groupId
				}
			});

	/// <inheritdoc />
	public GetByConversationMessageIdResult GetByConversationMessageId(long peerId, IEnumerable<ulong> conversationMessageIds,
																		IEnumerable<string> fields, bool? extended = null,
																		ulong? groupId = null) =>
		_vk.Call<GetByConversationMessageIdResult>("messages.getByConversationMessageId",
			new()
			{
				{
					"peer_id", peerId
				},
				{
					"conversation_message_ids", conversationMessageIds
				},
				{
					"fields", fields
				},
				{
					"extended", extended
				},
				{
					"group_id", groupId
				}
			});

	/// <inheritdoc />
	public SearchConversationsResult SearchConversations(string q, IEnumerable<string> fields, ulong? count = null,
														bool? extended = null,
														ulong? groupId = null) => _vk.Call<SearchConversationsResult>(
		"messages.searchConversations",
		new()
		{
			{
				"q", q
			},
			{
				"fields", fields
			},
			{
				"count", count
			},
			{
				"extended", extended
			},
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public PinnedMessage Pin(long peerId, ulong? messageId = null, ulong? conversationMessageId = null) => _vk.Call<PinnedMessage>(
		"messages.pin",
		new()
		{
			{
				"peer_id", peerId
			},
			{
				"message_id", messageId
			},
			{
				"conversation_message_id", conversationMessageId
			}
		});

	/// <inheritdoc />
	public GetImportantMessagesResult GetImportantMessages(GetImportantMessagesParams getImportantMessagesParams) =>
		_vk.Call<GetImportantMessagesResult>("messages.getImportantMessages",
			new()
			{
				{
					"fields", getImportantMessagesParams.Fields
				},
				{
					"count", getImportantMessagesParams.Count
				},
				{
					"offset", getImportantMessagesParams.Offset
				},
				{
					"start_message_id", getImportantMessagesParams.StartMessageId
				},
				{
					"preview_length", getImportantMessagesParams.PreviewLength
				},
				{
					"extended", getImportantMessagesParams.Extended
				},
				{
					"group_id", getImportantMessagesParams.GroupId
				}
			});

	/// <inheritdoc />
	public GetIntentUsersResult GetIntentUsers(MessagesGetIntentUsersParams getIntentUsersParams) => _vk.Call<GetIntentUsersResult>(
		"messages.getIntentUsers",
		new()
		{
			{
				"intent", getIntentUsersParams.Intent
			},
			{
				"name_case", getIntentUsersParams.NameCase
			},
			{
				"fields", getIntentUsersParams.Fields
			},
			{
				"subscribe_id", getIntentUsersParams.SubscribeId
			},
			{
				"offset", getIntentUsersParams.Offset
			},
			{
				"count", getIntentUsersParams.Count
			},
			{
				"extended", getIntentUsersParams.Extended
			}
		});

	/// <inheritdoc />
	public ulong DeleteDialog(long? userId, long? peerId = null, uint? offset = null, uint? count = null) =>
		DeleteConversation(userId, peerId, null);

	private IDictionary<ulong, bool> ImplementationDelete(IEnumerable<ulong>? messageIds = null,
            IEnumerable<ulong>? conversationMessageIds = null,
            ulong? peerId = null, bool? spam = null, ulong? groupId = null,
            bool deleteForAll = false)
        {
            if (messageIds == null && conversationMessageIds == null)
            {
                throw new ArgumentNullException(nameof(conversationMessageIds), "Parameter conversationMessageIds or messageIds can not be null.");
            }

            var ids = messageIds != null
                ? messageIds.ToList()
                : conversationMessageIds!.ToList();

            if (ids.Count == 0)
            {
                throw new ArgumentException("Parameter Ids has no elements.", nameof(ids));
            }

            var parameters = new VkParameters
            {
                {"delete_for_all", deleteForAll}
            };

            //Наличие spam неприемлимо, в случаях, когда авторизация ApiVk произошла с ключом сообщества, а не ключом пользователя.
            if (spam != null)
            {
                parameters.Add("spam", spam);
            }

            //Наличие peerId в запросе без cmids не имеет значения и может вызвать неожиданные ошибки.
            if (peerId != null)
            {
                parameters.Add("peer_id",peerId);
            }

            //Использование предполагает пройденную авторизацию с ключом пользователя для удаления со стороны сообщества,
            //при использовании в одном наборе параметров, могут возникнут непредвиденные исключения.
            //Если используется в личке между двумя пользователями, а также если нужно удалить с пользовательским ключом(являсь администратором беседы) -
            //необходимость в использовании отпадает.
            //Если авторизация пройдена со стороны сообщества, то необходимости в использовании тоже нет.
            if (groupId != null)
            {
                parameters.Add("group_id", groupId);
            }

            //При использовании cmids нежелательно использовать ещё и message_ids в одном наборе параметров,
            //так как возникают неуправляемые исключения со стороны ApiVk, такие как oldMessage.
            //Хотя сообщение по id лежит менее 24 часов.
            parameters.Add(messageIds != null ? "message_ids" : "cmids", ids);

            //Если вы авторизованы с ключом доступа сообщества, то вы не можете удалять сообщения администратора беседы(также, как и не будете иметь данной возможности,
            //удаляя сообщения администратора, будучи обычным пользователем в беседе)
            //(На момент вызова возникнет ошибка запроса).
            var response = _vk.Call("messages.delete", parameters);

            var result = new Dictionary<ulong, bool>();

            foreach (var id in ids)
            {
                bool isDeleted = response[id.ToString(CultureInfo.InvariantCulture)];
                result.Add(id, isDeleted);
            }

            return result;
        }

	/// <inheritdoc />
	public IDictionary<ulong, bool> Delete(IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null,
            bool deleteForAll = false) => ImplementationDelete(messageIds:messageIds,spam:spam,groupId:groupId,deleteForAll:deleteForAll);

	/// <inheritdoc />
	public IDictionary<ulong, bool> Delete(IEnumerable<ulong> conversationMessageIds, ulong peerId, bool? spam = null, ulong? groupId = null,
            bool deleteForAll = false) => ImplementationDelete(conversationMessageIds:conversationMessageIds,peerId:peerId, groupId:groupId, spam:spam, deleteForAll:deleteForAll);

	/// <inheritdoc />
	public bool Restore(ulong messageId, ulong? groupId = null)
	{
		var parameters = new VkParameters
		{
			{
				"message_id", messageId
			},
			{
				"group_id", groupId
			}
		};

		return _vk.Call("messages.restore", parameters);
	}

	/// <inheritdoc />
	public bool MarkAsRead(string peerId, long? startMessageId = null, long? groupId = null, bool? markConversationAsRead = null)
	{
		var parameters = new VkParameters
		{
			{
				"peer_id", peerId
			},
			{
				"start_message_id", startMessageId
			},
			{
				"group_id", groupId
			},
			{
				"mark_conversation_as_read", markConversationAsRead
			}
		};

		return _vk.Call("messages.markAsRead", parameters);
	}

	/// <inheritdoc />
	public bool SetActivity(string userId, MessageActivityType type, long? peerId = null, ulong? groupId = null)
	{
		if (peerId is null && groupId is null)
		{
			throw new VkApiException("Either one of the parameters 'peerId' and 'groupId' must be specified.");
		}

		if (peerId is not null && groupId is not null)
		{
			throw new VkApiException("This method doesn't accept 'peerId' and 'groupId' being specified simultaneously");
		}

		var parameters = new VkParameters
		{
			{
				"used_id", userId
			},
			{
				"type", type
			},
			{
				"peer_id", peerId
			},
			{
				"group_id", groupId
			}
		};

		return _vk.Call("messages.setActivity", parameters);
	}

	/// <inheritdoc />
	public LastActivity GetLastActivity(long userId)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			}
		};

		var activity = _vk.Call<LastActivity>("messages.getLastActivity", parameters);
		activity.UserId = userId;

		return activity;
	}

	/// <inheritdoc />
	public Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null) => _vk.Call<Chat>("messages.getChat",
		new()
		{
			{
				"chat_id", chatId
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		});

	/// <inheritdoc />
	public ChatPreview GetChatPreview(string link, ProfileFields fields) => _vk.Call<ChatPreview>("messages.getChatPreview",
		new()
		{
			{
				"link", link
			},
			{
				"fields", fields
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null)
	{
		var isNoEmpty = chatIds == null || !chatIds.Any();

		if (isNoEmpty)
		{
			throw new ArgumentException("At least one chat ID must be defined", nameof(chatIds));
		}

		var parameters = new VkParameters
		{
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		if (chatIds.Count() > 1)
		{
			parameters.Add("chat_ids", chatIds);
		} else
		{
			parameters.Add("chat_id", chatIds.ElementAt(0));
		}

		return _vk.Call<ReadOnlyCollection<Chat>>("messages.getChat", parameters);

		/*return chatIds.Count() > 1
			? response.ToReadOnlyCollectionOf<Chat>()
			: new(new List<Chat>
			{
				response
			});*/
	}

	/// <inheritdoc />
	public long CreateChat(IEnumerable<ulong> userIds, string title)
	{
		if (string.IsNullOrEmpty(title))
		{
			throw new ArgumentException("Title can not be empty or null.", nameof(userIds));
		}

		var parameters = new VkParameters
		{
			{
				"user_ids", userIds
			},
			{
				"title", title
			}
		};

		return _vk.Call("messages.createChat", parameters);
	}

	/// <inheritdoc />
	public bool EditChat(long chatId, string title)
	{
		if (string.IsNullOrEmpty(title))
		{
			throw new ArgumentException("Title can not be empty or null.", nameof(title));
		}

		var parameters = new VkParameters
		{
			{
				"chat_id", chatId
			},
			{
				"title", title
			}
		};

		return _vk.Call("messages.editChat", parameters);
	}

	/// <inheritdoc />
	public ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
	{
		var collection = chatIds.ToList();

		var parameters = new VkParameters
		{
			{
				"chat_ids", collection
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		var response = _vk.Call("messages.getChatUsers", parameters);

		var list = new List<User>();

		foreach (var chatId in collection)
		{
			var chatResponse = response[chatId.ToString()];

			var users = chatResponse;

			foreach (var user in JsonConvert.DeserializeObject<ReadOnlyCollection<User>>(users.ToString()))
			{
				var exist = list.Exists(first => first.Id == user.Id);

				if (!exist)
				{
					list.Add(user);
				}
			}
		}

		return list.ToReadOnlyCollection();
	}

	/// <inheritdoc />
	public List<long> GetChatUsers(long chatId, NameCase nameCase)
	{
		var parameters = new VkParameters
		{
			{
				"chat_id", chatId
			},
			{
				"name_case", nameCase
			}
		};

		return _vk.Call<List<long>>("messages.getChatUsers", parameters);
	}

	/// <inheritdoc />
	public List<long> GetChatUsers(IEnumerable<long> chatIds, NameCase nameCase)
	{
		var collection = chatIds.ToList();

		var parameters = new VkParameters
		{
			{
				"chat_ids", collection
			},
			{
				"name_case", nameCase
			}
		};

		var response = _vk.Call("messages.getChatUsers", parameters);

		var list = new List<long>();

		foreach (var chatId in collection)
		{
			var chatResponse = response[chatId.ToString()];

			var users = chatResponse;

			foreach (var user in JsonConvert.DeserializeObject<ReadOnlyCollection<long>>(users.ToString()))
			{
				list.Add(user);
			}
		}

		return list;
	}

	/// <inheritdoc />
	public ReadOnlyCollection<User> GetChatUsers(long chatId, UsersFields fields, NameCase nameCase)
	{
		var parameters = new VkParameters
		{
			{
				"chat_id", chatId
			},
			{
				"fields", fields
			},
			{
				"name_case", nameCase
			}
		};

		return _vk.Call<ReadOnlyCollection<User>>("messages.getChatUsers", parameters);
	}

	/// <inheritdoc />
	public bool RemoveChatUser(ulong chatId, long? userId = null, long? memberId = null)
	{
		var parameters = new VkParameters
		{
			{
				"chat_id", chatId
			},
			{
				"user_id", userId
			},
			{
				"member_id", memberId
			}
		};

		return _vk.Call<bool>("messages.removeChatUser", parameters);
	}

	/// <inheritdoc />
	[Pure]
	public LongPollServerResponse GetLongPollServer(bool needPts = false, uint lpVersion = 2, ulong? groupId = null)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			},
			{
				"lp_version", lpVersion
			},
			{
				"need_pts", needPts
			}
		};

		return _vk.Call<LongPollServerResponse>("messages.getLongPollServer", parameters);
	}

	/// <inheritdoc />
	public LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params)
	{
		VkErrors.ThrowIfNumberIsNegative(() => @params.PreviewLength);
		VkErrors.ThrowIfNumberIsNegative(() => @params.EventsLimit);
		VkErrors.ThrowIfNumberIsNegative(() => @params.MsgsLimit);
		VkErrors.ThrowIfNumberIsNegative(() => @params.MaxMsgId);

		return _vk.Call<LongPollHistoryResponse>("messages.getLongPollHistory",
			new()
			{
				{
					"ts", @params.Ts
				},
				{
					"pts", @params.Pts
				},
				{
					"preview_length", @params.PreviewLength
				},
				{
					"onlines", @params.Onlines
				},
				{
					"fields", @params.Fields
				},
				{
					"events_limit", @params.EventsLimit
				},
				{
					"msgs_limit", @params.MsgsLimit
				},
				{
					"max_msg_id", @params.MaxMsgId
				},
				{
					"lp_version", @params.LpVersion
				},
				{
					"group_id", @params.GroupId
				}
			});
	}

	/// <inheritdoc />
	public Chat DeleteChatPhoto(out ulong messageId, ulong chatId, ulong? groupId = null)
	{
		var parameters = new VkParameters
		{
			{
				"chat_id", chatId
			},
			{
				"group_id", groupId
			}
		};

		var result = _vk.Call("messages.deleteChatPhoto", parameters);
		messageId = result["message_id"];

		return JsonConvert.DeserializeObject<Chat>(result["chat"]);
	}

	/// <inheritdoc />
	public long SetChatPhoto(out long messageId, string file)
	{
		var json = file.ToJObject();
		var rawResponse = json["response"];

		var parameters = new VkParameters
		{
			{
				"file", rawResponse
			}
		};

		var result = _vk.Call("messages.setChatPhoto", parameters);
		messageId = result["message_id"];

		return result["chat"]["id"];
	}

	/// <inheritdoc />
	public ReadOnlyCollection<long> MarkAsImportant(IEnumerable<long> messageIds, bool important = true)
	{
		var parameters = new VkParameters
		{
			{
				"message_ids", messageIds
			},
			{
				"important", important
			}
		};

		VkResponseArray result = _vk.Call("messages.markAsImportant", parameters);

		return result.ToReadOnlyCollectionOf<long>(x => x);
	}

	/// <inheritdoc />
	public long SendSticker(MessagesSendStickerParams @params) => _vk.Call("messages.sendSticker",
		new()
		{
			{
				"user_id", @params.UserId
			},
			{
				"domain", @params.Domain
			},
			{
				"peer_id", @params.PeerId
			},
			{
				"chat_id", @params.ChatId
			},
			{
				"random_id", @params.RandomId
			},
			{
				"sticker_id", @params.StickerId
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom)
	{
		var result = _vk.Call("messages.getHistoryAttachments",
			new()
			{
				{
					"peer_id", @params.PeerId
				},
				{
					"media_type", @params.MediaType
				},
				{
					"start_from", @params.StartFrom
				},
				{
					"count", @params.Count
				},
				{
					"photo_sizes", @params.PhotoSizes
				},
				{
					"fields", @params.Fields
				},
				{
					"group_id", @params.GroupId
				}
			});

		nextFrom = result["next_from"];

		return result.ToReadOnlyCollectionOf<HistoryAttachment>();
	}

	/// <inheritdoc />
	public string GetInviteLink(ulong peerId, bool reset) => _vk.Call("messages.getInviteLink",
		new()
		{
			{
				"peer_id", peerId
			},
			{
				"reset", reset
			}
		})["link"];

	/// <inheritdoc />
	public bool IsMessagesFromGroupAllowed(ulong groupId, ulong userId) => _vk.Call("messages.isMessagesFromGroupAllowed",
		new()
		{
			{
				"group_id", groupId
			},
			{
				"user_id", userId
			}
		})["is_allowed"];

	/// <inheritdoc />
	public long JoinChatByInviteLink(string link) => _vk.Call("messages.joinChatByInviteLink",
		new()
		{
			{
				"link", link
			}
		})["chat_id"];

	/// <inheritdoc />
	public bool MarkAsAnsweredConversation(long peerId, bool? answered = null, ulong? groupId = null) => _vk.Call(
		"messages.markAsAnsweredConversation",
		new()
		{
			{
				"peer_id", peerId
			},
			{
				"answered", answered
			},
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public bool MarkAsAnsweredDialog(long peerId, bool answered = true) => MarkAsAnsweredConversation(peerId, answered);

	/// <inheritdoc />
	public bool MarkAsImportantConversation(long peerId, bool? important = null, ulong? groupId = null) => _vk.Call(
		"messages.markAsImportantConversation",
		new()
		{
			{
				"peer_id", peerId
			},
			{
				"important", important
			},
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public bool MarkAsImportantDialog(long peerId, bool important = true) => MarkAsImportantConversation(peerId, important);

	/// <inheritdoc />
	public bool Edit(MessageEditParams @params) => _vk.Call("messages.edit",
		new()
		{
			{
				"peer_id", @params.PeerId
			},
			{
				"message", @params.Message
			},
			{
				"message_id", @params.MessageId
			},
			{
				"lat", @params.Latitude
			},
			{
				"long", @params.Longitude
			},
			{
				"attachment", @params.Attachments
			},
			{
				"keep_forward_messages", @params.KeepForwardMessages
			},
			{
				"keep_snippets", @params.KeepSnippets
			},
			{
				"group_id", @params.GroupId
			},
			{
				"dont_parse_links", @params.DontParseLinks
			},
			{
				"conversation_message_id", @params.ConversationMessageId
			},
			{
				"template", @params.Template != null
					? JsonConvert.SerializeObject(@params.Template)
					: ""
			},
			{
				"keyboard", @params.Keyboard != null
					? JsonConvert.SerializeObject(@params.Keyboard)
					: ""
			}
		});

	/// <inheritdoc />
	public bool Unpin(long peerId, ulong? groupId = null) => _vk.Call<bool>("messages.unpin",
		new()
		{
			{
				"peer_id", peerId
			},
			{
				"group_id", groupId
			}
		});

	/// <inheritdoc />
	public GetRecentCallsResult GetRecentCalls(IEnumerable<string> fields, ulong? count = null, ulong? startMessageId = null,
												bool? extended = null) => _vk.Call<GetRecentCallsResult>("messages.getRecentCalls",
		new()
		{
			{
				"fields", fields
			},
			{
				"count", count
			},
			{
				"start_message_id", startMessageId
			},
			{
				"extended", extended
			}
		});

	/// <inheritdoc />
	public bool SendMessageEventAnswer(string eventId, long userId, long peerId, EventData eventData = null) => _vk.Call<bool>(
		"messages.sendMessageEventAnswer",
		new()
		{
			{
				"event_id", eventId
			},
			{
				"user_id", userId
			},
			{
				"peer_id", peerId
			},
			{
				"event_data", eventData != null
					? JsonConvert.SerializeObject(eventData)
					: string.Empty
			}
		});

	/// <inheritdoc />
	public bool MarkAsUnreadConversation(long peerId) => _vk.Call<bool>("messages.markAsUnreadConversation",
		new()
		{
			{
				"peer_id", peerId
			}
		});

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
	[Obsolete(ObsoleteText.MessageGetById, true)]
	public Message GetById(ulong messageId, uint? previewLength = null)
	{
		var result = GetById(new[]
			{
				messageId
			},
			null,
			previewLength);

		if (result.Count > 0)
		{
			return result.First();
		}

		throw new VkApiException("Сообщения с таким ID не существует.");
	}
}
