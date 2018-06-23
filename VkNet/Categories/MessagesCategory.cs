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
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с сообщениями.
		/// </summary>
		/// <param name="vk"> API </param>
		public MessagesCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Добавляет в мультидиалог нового пользователя.
		/// </summary>
		/// <param name="chatId">
		/// Идентификатор беседы. положительное число, обязательный параметр (Положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, которого необходимо включить в беседу.
		/// положительное число,
		/// обязательный параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.addChatUser
		/// </remarks>
		public bool AddChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "user_id", userId }
			};

			return _vk.Call(methodName: "messages.addChatUser", parameters: parameters);
		}

		/// <summary>
		/// Позволяет разрешить отправку сообщений от сообщества текущему пользователю.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="key">
		/// Произвольная строка.
		/// Этот параметр можно использовать для идентификации пользователя.
		/// Его значение будет возвращено в событии message_allow Callback API.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.allowMessagesFromGroup
		/// </remarks>
		public bool AllowMessagesFromGroup(long groupId, string key)
		{
			return _vk.Call(methodName: "messages.allowMessagesFromGroup",
				parameters: new VkParameters
				{
					{ "group_id", groupId },
					{ "key", key }
				});
		}

		/// <summary>
		/// Позволяет запретить отправку сообщений от сообщества текущему пользователю.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// https://vk.com/dev/messages.denyMessagesFromGroup
		/// </remarks>
		public bool DenyMessagesFromGroup(long groupId)
		{
			return _vk.Call(methodName: "messages.denyMessagesFromGroup", parameters: new VkParameters { { "group_id", groupId } });
		}

		/// <summary>
		/// Возвращает список входящих либо исходящих личных сообщений текущего
		/// пользователя.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns> Список сообщений, удовлетворяющий условиям фильтрации. </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.get
		/// </remarks>
		[Pure]
		public MessagesGetObject Get(MessagesGetParams @params)
		{
			return _vk.Call(methodName: "messages.get", parameters: @params);
		}

		/// <summary>
		/// Возвращает историю сообщений текущего пользователя с указанным пользователя или
		/// групповой беседы.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns>
		/// Возвращает историю сообщений с указанным пользователем или из
		/// указанной беседы
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getHistory
		/// </remarks>
		[Pure]
		public MessagesGetObject GetHistory(MessagesGetHistoryParams @params)
		{
			return _vk.Call(methodName: "messages.getHistory", parameters: @params);
		}

		/// <summary>
		/// Возвращает сообщения по их идентификаторам.
		/// </summary>
		/// <param name="messageIds">
		/// Идентификаторы сообщений, которые необходимо вернуть
		/// (не более 100).
		/// </param>
		/// <param name="previewLength">
		/// Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не
		/// обрезаются).
		/// </param>
		/// <returns>
		/// Запрошенные сообщения.
		/// </returns>
		/// <exception cref="System.Exception"> messageIds не может быть пустой </exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getById
		/// </remarks>
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

		/// <summary>
		/// Возвращает список диалогов аккаунта
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns> В случае успеха возвращает список диалогов пользователя </returns>
		[Pure]
		public MessagesGetObject GetDialogs(MessagesDialogsGetParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.Count);

			return _vk.Call(methodName: "messages.getDialogs", parameters: @params);
		}

		/// <summary>
		/// Возвращает список найденных диалогов текущего пользователя по введенной строке
		/// поиска.
		/// </summary>
		/// <param name="query"> Подстрока, по которой будет производиться поиск. </param>
		/// <param name="limit"> Количество пользователей которое нужно вернуть. </param>
		/// <param name="fields"> Поля профилей собеседников, которые необходимо вернуть. </param>
		/// <returns>
		/// В результате выполнения данного метода будет возвращён массив объектов
		/// профилей, бесед и email.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		/// Query can not be null or
		/// empty.;query
		/// </exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.searchDialogs
		/// </remarks>
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

		/// <summary>
		/// Возвращает список найденных личных сообщений текущего пользователя по введенной
		/// строке поиска.
		/// </summary>
		/// <param name="params"> Параметры запроса messages.search </param>
		/// <returns>
		/// После успешного выполнения возвращает  объектов , найденных в соответствии с
		/// поисковым запросом '''q'''.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		/// Query can not be null or
		/// empty.;query
		/// </exception>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.search
		/// </remarks>
		public VkCollection<Message> Search(MessagesSearchParams @params)
		{
			if (string.IsNullOrWhiteSpace(value: @params.Query))
			{
				throw new ArgumentException(message: "Query can not be null or empty.", paramName: nameof(@params.Query));
			}

			return _vk.Call(methodName: "messages.search", parameters: @params).ToVkCollectionOf<Message>(selector: r => r);
		}

		/// <summary>
		/// Посылает личное сообщение.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращается идентификатор отправленного сообщения.
		/// </returns>
		/// <exception cref="System.ArgumentException"> Message can not be <c> null </c>. </exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.send
		/// </remarks>
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

		/// <summary>
		/// Посылает личное сообщение.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращается идентификатор отправленного сообщения.
		/// </returns>
		/// <exception cref="System.ArgumentException"> Message can not be <c> null </c>. </exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.send
		/// </remarks>
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

		/// <summary>
		/// Удаляет все личные сообщения в диалоге.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя.
		/// Если требуется очистить историю беседы, используйте peer_id.
		/// </param>
		/// <param name="peerId">
		/// Идентификатор назначения.
		/// Для групповой беседы: 2000000000 + id беседы.
		/// Для сообщества: -id сообщества.
		/// </param>
		/// <param name="offset">
		/// Смещение, начиная с которого нужно удалить переписку (по умолчанию удаляются
		/// все сообщения,
		/// начиная с первого).
		/// </param>
		/// <param name="count">
		/// Как много сообщений нужно удалить. Обратите внимание что на метод наложено
		/// ограничение, за один вызов
		/// нельзя удалить больше 10000 сообщений, поэтому если сообщений в переписке
		/// больше - метод нужно вызывать несколько
		/// раз.
		/// </param>
		/// <returns> Признак удалось ли удалить сообщения. </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.deleteDialog
		/// </remarks>
		public bool DeleteDialog(long? userId, long? peerId = null, uint? offset = null, uint? count = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "offset", offset },
				{ "peer_id", peerId }
			};

			if (count <= 10000)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "messages.deleteDialog", parameters: parameters);
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

		/// <summary>
		/// Восстанавливает удаленное сообщение.
		/// </summary>
		/// <param name="messageId"> Идентификатор сообщения, которое нужно восстановить. </param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.restore
		/// </remarks>
		public bool Restore(ulong messageId)
		{
			var parameters = new VkParameters
			{
				{ "message_id", messageId }
			};

			return _vk.Call(methodName: "messages.restore", parameters: parameters);
		}

		/// <summary>
		/// Помечает сообщения как прочитанные.
		/// </summary>
		/// <param name="messageIds">
		/// Идентификаторы сообщений. список положительных чисел, разделенных запятыми
		/// (Список
		/// положительных чисел, разделенных запятыми).
		/// </param>
		/// <param name="peerId">
		/// Идентификатор чата или пользователя, если это диалог.
		/// строка (Строка).
		/// </param>
		/// <param name="startMessageId">
		/// При передаче этого параметра будут помечены как прочитанные все сообщения,
		/// начиная с
		/// данного. положительное число (Положительное число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsRead
		/// </remarks>
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

		/// <summary>
		/// Изменяет статус набора текста пользователем в диалоге.
		/// </summary>
		/// <param name="userId"> Идентификатор пользователя </param>
		/// <param name="peerId">
		/// Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для
		/// сообщества: -id
		/// сообщества.
		/// </param>
		/// <param name="type"> typing — пользователь начал набирать текст. </param>
		/// <returns>
		/// После успешного выполнения возвращает true, false в противном случае.
		/// Текст «N набирает сообщение...» отображается в течение 10 секунд после вызова
		/// метода, либо до момента отправки
		/// сообщения.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.setActivity
		/// </remarks>
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

		/// <summary>
		/// Возвращает текущий статус и дату последней активности указанного пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, информацию о последней активности которого
		/// требуется получить. целое
		/// число, обязательный параметр (Целое число, обязательный параметр).
		/// </param>
		/// <returns>
		/// Возвращает объект, содержащий следующие поля:
		/// online — текущий статус пользователя (1 — в сети, 0 — не в сети);
		/// time — дата последней активности пользователя в формате unixtime.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getLastActivity
		/// </remarks>
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

		/// <summary>
		/// Gets the chat.
		/// </summary>
		/// <param name="chatId"> The chat identifier. </param>
		/// <param name="fields"> The fields. </param>
		/// <param name="nameCase"> The name case. </param>
		/// <returns> </returns>
		public Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null)
		{
			return GetChat(chatIds: new[] { chatId }, fields: fields, nameCase: nameCase).FirstOrDefault();
		}

		/// <summary>
		/// Получает данные для превью чата с приглашением по ссылке.
		/// </summary>
		/// <param name="link"> Ссылка-приглашение. </param>
		/// <param name="fields"> Список полей профилей, данные о которых нужно получить. </param>
		/// <returns> Возвращает объект представляющий описание чата </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/messages.getChatPreview
		/// </remarks>
		public ChatPreview GetChatPreview(string link, ProfileFields fields)
		{
			return _vk.Call(methodName: "messages.getChatPreview",
				parameters: new VkParameters
				{
					{ "link", link },
					{ "fields", fields }
				});
		}

		/// <summary>
		/// Возвращает информацию о беседе.
		/// </summary>
		/// <param name="chatIds">
		/// Список идентификаторов бесед. список целых чисел, разделенных запятыми (Список
		/// целых чисел,
		/// разделенных запятыми).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone,
		/// photo_50, photo_100,
		/// photo_200_orig, has_mobile, contacts, education, online, counters, relation,
		/// last_seen, status,
		/// can_write_private_message, can_see_all_posts, can_post, universities список
		/// строк, разделенных через запятую
		/// (Список строк, разделенных через запятую).
		/// </param>
		/// <param name="nameCase">
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom,
		/// родительный – gen, дательный – dat, винительный – acc, творительный – ins,
		/// предложный – abl. По умолчанию nom.
		/// строка (Строка).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект (или список объектов)
		/// мультидиалога.
		/// Если был задан параметр fields, поле users содержит список объектов
		/// пользователей с дополнительным полем
		/// invited_by, содержащим идентификатор пользователя, пригласившего в беседу.
		/// </returns>
		/// <exception cref="System.ArgumentException">
		/// At least one chat ID must be
		/// defined;chatIds
		/// </exception>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getChat
		/// </remarks>
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

		/// <summary>
		/// Создаёт беседу с несколькими участниками.
		/// </summary>
		/// <param name="userIds">
		/// Идентификаторы пользователей, которых нужно включить в мультидиалог. список
		/// положительных чисел,
		/// разделенных запятыми, обязательный параметр (Список положительных чисел,
		/// разделенных запятыми, обязательный
		/// параметр).
		/// </param>
		/// <param name="title"> Название беседы. строка (Строка). </param>
		/// <returns>
		/// После успешного выполнения возвращает  идентификатор созданного чата (chat_id).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.createChat
		/// </remarks>
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

		/// <summary>
		/// Изменяет название беседы.
		/// </summary>
		/// <param name="chatId">
		/// Идентификатор беседы. целое число, обязательный параметр (Целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="title">
		/// Новое название для беседы. строка, обязательный параметр (Строка, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.editChat
		/// </remarks>
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

		/// <summary>
		/// Позволяет получить список пользователей мультидиалога по его id.
		/// </summary>
		/// <param name="chatIds">
		/// Идентификаторы бесед. список целых чисел, разделенных запятыми (Список целых
		/// чисел, разделенных
		/// запятыми).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо вернуть.
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone,
		/// photo_50, photo_100,
		/// photo_200_orig, has_mobile, contacts, education, online, counters, relation,
		/// last_seen, status,
		/// can_write_private_message, can_see_all_posts, can_post, universities список
		/// строк, разделенных через запятую
		/// (Список строк, разделенных через запятую).
		/// </param>
		/// <param name="nameCase">
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom,
		/// родительный – gen, дательный – dat, винительный – acc, творительный – ins,
		/// предложный – abl. По умолчанию nom.
		/// строка (Строка).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список идентификаторов участников беседы.
		/// Если был задан параметр fields, возвращает список объектов пользователей с
		/// дополнительным полем invited_by,
		/// содержащим идентификатор пользователя, пригласившего в беседу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getChatUsers
		/// </remarks>
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

		/// <summary>
		/// Исключает из мультидиалога пользователя, если текущий пользователь был
		/// создателем беседы либо пригласил
		/// исключаемого пользователя.
		/// </summary>
		/// <param name="chatId">
		/// Идентификатор беседы. целое число, обязательный параметр (Целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, которого необходимо исключить из беседы. Может быть
		/// меньше нуля в
		/// случае, если пользователь приглашён по email. обязательный параметр
		/// (Обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.removeChatUser
		/// </remarks>
		public bool RemoveChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "user_id", userId }
			};

			return _vk.Call(methodName: "messages.removeChatUser", parameters: parameters);
		}

		/// <summary>
		/// Возвращает данные, необходимые для подключения к Long Poll серверу.
		/// Long Poll подключение позволит Вам моментально узнавать о приходе новых
		/// сообщений и других событий.
		/// </summary>
		/// <param name="lpVersion">
		/// версия для подключения к Long Poll. Актуальная версия:
		/// 2.
		/// </param>
		/// <param name="needPts">
		/// <c> true </c> — возвращать поле pts, необходимое для работы метода
		/// messages.getLongPollHistory
		/// </param>
		/// <returns>
		/// Возвращает объект, с помощью которого можно подключиться к серверу быстрых
		/// сообщений для мгновенного
		/// получения приходящих сообщений и других событий.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getLongPollServer
		/// </remarks>
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

		/// <summary>
		/// Возвращает обновления в личных сообщениях пользователя.
		/// Для ускорения работы с личными сообщениями может быть полезно кешировать уже
		/// загруженные ранее сообщения на
		/// мобильном устройстве / ПК пользователя, чтобы не получать их повторно при
		/// каждом обращении.
		/// Этот метод помогает осуществить синхронизацию локальной копии списка сообщений
		/// с актуальной версией.
		/// </summary>
		/// <param name="params">
		/// Параметры запроса к LongPool серверу
		/// MessagesGetLongPollHistoryParams
		/// </param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getLongPollHistory
		/// </remarks>
		public LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.PreviewLength);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.EventsLimit);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.MsgsLimit);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.MaxMsgId);

			return _vk.Call(methodName: "messages.getLongPollHistory", parameters: @params);
		}

		/// <summary>
		/// Позволяет удалить фотографию мультидиалога.
		/// </summary>
		/// <param name="messageId"> Идентификатор отправленного системного сообщения; </param>
		/// <param name="chatId">
		/// Идентификатор беседы. положительное число, обязательный параметр (Положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// message_id — идентификатор отправленного системного сообщения;
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.deleteChatPhoto
		/// </remarks>
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

		/// <summary>
		/// Позволяет установить фотографию мультидиалога, загруженную с помощью метода
		/// photos.getChatUploadServer.
		/// </summary>
		/// <param name="file">
		/// Содержимое поля response из ответа специального upload сервера, полученного в
		/// результате загрузки
		/// изображения на адрес, полученный методом photos.getChatUploadServer. строка,
		/// обязательный параметр (Строка,
		/// обязательный параметр).
		/// </param>
		/// <param name="messageId"> Идентификатор отправленного системного сообщения; </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// message_id — идентификатор отправленного системного сообщения;
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.setChatPhoto
		/// </remarks>
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

		/// <summary>
		/// Помечает сообщения как важные либо снимает отметку.
		/// </summary>
		/// <param name="messageIds">
		/// Список идентификаторов сообщений, которые необходимо пометить.список
		/// положительных чисел,
		/// разделенных запятыми (Список положительных чисел, разделенных запятыми).
		/// </param>
		/// <param name="important">
		/// &#39;&#39;1&#39;&#39;, если сообщения необходимо пометить, как важные;&#39;
		/// &#39;0&#39;&#39;,
		/// если необходимо снять пометку.положительное число (Положительное число).
		/// </param>
		/// <returns>
		/// Возвращает список идентификаторов успешно помеченных сообщений.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsImportant
		/// </remarks>
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

		/// <summary>
		/// Отправляет стикер.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор отправленного сообщения
		/// (mid).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.sendSticker
		/// </remarks>
		public long SendSticker(MessagesSendStickerParams @params)
		{
			var parameters = @params;

			return _vk.Call(methodName: "messages.sendSticker", parameters: parameters);
		}

		/// <summary>
		/// Возвращает материалы диалога или беседы..
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <param name="nextFrom"> Новое значение start_from. </param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов photo, video, audio или
		/// doc, в зависимости от значения
		/// media_type, а также дополнительное поле next_from, содержащее новое значение
		/// start_from.
		/// Если в media_type передано значение link, возвращает список объектов-ссылок:
		/// url URL ссылки.
		/// строка title заголовок сниппета.
		/// строка description описание сниппета.
		/// строка image_src URL изображения сниппета.
		/// строка.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.getHistoryAttachments
		/// </remarks>
		public ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom)
		{
			var result = _vk.Call(methodName: "messages.getHistoryAttachments", parameters: @params);

			nextFrom = result[key: "next_from"];

			return result.ToReadOnlyCollectionOf<HistoryAttachment>(selector: o => o);
		}

		/// <summary>
		/// Получает ссылку для приглашения пользователя в беседу.
		/// </summary>
		/// <param name="peerId"> Идентификатор назначения. </param>
		/// <param name="reset">
		/// 1 — сгенерировать новую ссылку, сбросив предыдущую.
		/// 0 — получить предыдущую ссылку.
		/// </param>
		/// <returns>
		/// Возвращает объект с единственным полем link (string), которое содержит ссылку
		/// для приглашения в беседу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getInviteLink
		/// </remarks>
		public string GetInviteLink(ulong peerId, bool reset)
		{
			return _vk.Call(methodName: "messages.getInviteLink",
				parameters: new VkParameters
				{
					{ "peer_id", peerId },
					{ "reset", reset }
				})[key: "link"];
		}

		/// <summary>
		/// Возвращает информацию о том, разрешена ли отправка сообщений от сообщества
		/// пользователю.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="userId"> Идентификатор пользователя. </param>
		/// <returns>
		/// Возвращает объект с единственным полем is_allowed (integer, [0,1]). Если
		/// отправка сообщений разрешена, поле
		/// содержит 1, иначе — 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.isMessagesFromGroupAllowed
		/// </remarks>
		public bool IsMessagesFromGroupAllowed(ulong groupId, ulong userId)
		{
			return _vk.Call(methodName: "messages.isMessagesFromGroupAllowed",
				parameters: new VkParameters
				{
					{ "group_id", groupId },
					{ "user_id", userId }
				})[key: "is_allowed"];
		}

		/// <summary>
		/// Позволяет присоединиться к чату по ссылке-приглашению.
		/// </summary>
		/// <param name="link"> Ссылка-приглашение. </param>
		/// <returns>
		/// Возвращает идентификатор чата в поле chat_id.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.joinChatByInviteLink
		/// </remarks>
		public long JoinChatByInviteLink(string link)
		{
			return _vk.Call(methodName: "messages.joinChatByInviteLink", parameters: new VkParameters { { "link", link } })[key: "chat_id"];
		}

		/// <summary>
		/// Помечает диалог как отвеченный либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор диалога </param>
		/// <param name="answered"> флаг, может принимать значения 1 или 0, по умолчанию 1 </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsAnsweredDialog
		/// </remarks>
		public bool MarkAsAnsweredDialog(long peerId, bool answered = true)
		{
			return _vk.Call(methodName: "messages.markAsAnsweredDialog",
				parameters: new VkParameters
				{
					{ "peer_id", peerId },
					{ "answered", answered }
				});
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