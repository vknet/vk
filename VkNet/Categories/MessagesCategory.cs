﻿using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
#if WINDOWS_PHONE
	using System.Net;
#else
	using System.Web;

#endif

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Linq;
	using JetBrains.Annotations;

	using Enums;
	using Model;
	using Model.RequestParams;
	using Utils;

	/// <summary>
	/// Методы для работы с сообщениями.
	/// </summary>
	public class MessagesCategory
	{
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с сообщениями.
		/// </summary>
		/// <param name="vk">API</param>
		internal MessagesCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
		/// </summary>
		/// <param name="type">Тип сообщений которые необходимо получить.
		/// Необходимо передать <see cref="MessageType.Received"/> для полученных сообщений и <see cref="MessageType.Sended"/>
		/// для отправленных пользователем сообщений.
		/// </param>
		/// <param name="totalCount">Общее количество сообщений, удовлетворяющих условиям фильтрации.</param>
		/// <param name="count">Количество сообщений, которое необходимо получить (по умолчанию 20, но не более 200).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений.</param>
		/// <param name="timeOffset">Максимальное время, прошедшее с момента отправки сообщения до текущего момента в секундах. 0, если Вы хотите получить сообщения любой давности.</param>
		/// <param name="filter">Фильтр возвращаемых сообщений.</param>
		/// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).
		/// Обратите внимание что сообщения обрезаются по словам.</param>
		/// <param name="lastMessageId">Идентификатор сообщения, полученного перед тем, которое нужно вернуть последним (при условии, что после него было получено не более count сообщений, иначе необходимо использовать с параметром offset).</param>
		/// <returns>Список сообщений, удовлетворяющий условиям фильтрации.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.get"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		[Obsolete("Устаревшая версия API. Используйте метод Get(MessagesGetParams @params)")]
		public ReadOnlyCollection<Message> Get(
			MessageType type,
			out int totalCount,
			uint? count = 20,
			uint? offset = null,
			TimeSpan? timeOffset = null,
			MessagesFilter? filter = null,
			uint? previewLength = 0,
			long? lastMessageId = null)
		{
			var parameters = new MessagesGetParams
			{
				Out = type,
				Offset = offset,
				Filters = filter,
				PreviewLength = previewLength,
				LastMessageId = lastMessageId
			};

			var response = _vk.Call("messages.get", parameters);
			totalCount = response["count"];

			return Get(parameters).Messages;
		}

		/// <summary>
		/// Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>Список сообщений, удовлетворяющий условиям фильтрации.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.get"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public MessagesGetObject Get(MessagesGetParams @params)
		{
			return _vk.Call("messages.get", @params);
		}

		/// <summary>
		/// Возвращает историю сообщений текущего пользователя с указанным пользователя или групповой беседы.
		/// </summary>
		/// <param name="totalCount">Общее количество сообщений в истории.</param>
		/// <param name="isChat">Если <see langword="true" /> то вернуть беседу, иначе диалог с пользователем.</param>
		/// <param name="id">Идентификатор пользователя или беседы (зависит от параметра <paramref name="isChat" />), историю переписки с которым необходимо вернуть.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений, должен быть &gt;= 0, если не передан параметр start_message_id, и должен быть &lt;= 0, если передан.</param>
		/// <param name="count">Количество сообщений, которое необходимо получить (но не более 200).</param>
		/// <param name="startMessageId">Если значение &gt; 0, то это идентификатор сообщения, начиная с которого нужно вернуть историю переписки, если же передано значение -1, то к значению параметра offset прибавляется количество входящих непрочитанных сообщений в конце диалога</param>
		/// <param name="inReverse">true – возвращать сообщения в хронологическом порядке. false – возвращать сообщения в обратном хронологическом порядке (по умолчанию), недоступен при переданном start_message_id.</param>
		/// <returns></returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getHistory" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		[Obsolete("Устаревшая версия API. Используйте метод GetHistory(MessagesGetParams @params)")]
		public ReadOnlyCollection<Message> GetHistory(out int totalCount, bool isChat, long id, int? offset = null, uint? count = 20,
			long? startMessageId = null, bool inReverse = false)
		{
			var parameters = new MessagesGetHistoryParams
			{
				Offset = offset,
				StartMessageId = startMessageId,
				Reversed = inReverse,
				ChatId = isChat ? id : (long?)null,
				UserId = isChat ? (long?)null : id,
				Count = count.Value
			};
			
			var response = _vk.Call("messages.getHistory", parameters);

			totalCount = response["count"];

			return GetHistory(parameters).Messages;
		}

		/// <summary>
		/// Возвращает историю сообщений текущего пользователя с указанным пользователя или групповой беседы.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>Возвращает историю сообщений с указанным пользователем или из указанной беседы</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getHistory" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public MessagesGetObject GetHistory(MessagesGetHistoryParams @params)
		{
			return _vk.Call("messages.getHistory", @params);
		}

		/// <summary>
		/// Возвращает сообщения по их идентификаторам.
		/// </summary>
		/// <param name="messageIds">Идентификаторы сообщений, которые необходимо вернуть (не более 100).</param>
		/// <param name="totalCount">Общее количество сообщений.</param>
		/// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).</param>
		/// <returns>Запрошенные сообщения.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getById"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Message> GetById(out int totalCount, [NotNull] IEnumerable<ulong> messageIds, uint? previewLength = null)
		{
			if (!messageIds.Any())
			{
				throw new Exception("messageIds не может быть пустой");
			}
			var parameters = new VkParameters { { "message_ids", messageIds }, { "preview_length", previewLength } };

			var response = _vk.Call("messages.getById", parameters);

			totalCount = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Message>(r => r);
		}

		/// <summary>
		/// Ворзвращает указанное сообщение по его идентификатору.
		/// </summary>
		/// <param name="messageId">Идентификатор запрошенного сообщения.</param>
		/// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).</param>
		/// <returns>Запрошенное сообщение, null если сообщение с заданным идентификатором не найдено.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getById"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public Message GetById(ulong messageId, uint? previewLength = null)
		{
			int totalCount;
			var result = GetById(out totalCount, new[] { messageId }, previewLength);
			if (result.Count > 0)
			{
				return result.First();
			}
			throw new VkApiException("Сообщения с таким ID не существует.");
		}

		/// <summary>
		/// Возвращает список диалогов текущего пользователя.
		/// </summary>
		/// <param name="totalCount">Общее количество диалогов с учетом фильтра. Если получены только диалоги, в которых есть непрочитанные сообщения, то вернет то же что и unreadCount</param>
		/// <param name="unreadCount">Количество диалогов с непрочитанными сообщениями</param>
		/// <param name="unread">Значение <c>true</c> означает, что нужно вернуть только диалоги в которых есть непрочитанные входящие сообщения. По умолчанию false.</param>
		/// <param name="startMessageId">
		/// Идентификатор сообщения, начиная с которого нужно вернуть список диалогов (подробности см. ниже).
		///
		/// Если был передан параметр <c>start_message_id</c>, будет найдена позиция диалога в списке,
		/// идентификатор последнего сообщения которого равен <c>start_message_id</c> (или ближайший к нему более ранний).
		/// Начиная с этой позиции будет возвращено <c>count</c> диалогов.
		/// Смещение <c>offset</c> в этом случае будет отсчитываться от этой позиции (оно может быть отрицательным).
		/// </param>
		/// <param name="count">Количество диалогов, которое необходимо получить (но не более 200).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества диалогов.</param>
		/// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение.
		/// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).</param>
		/// <returns>Список диалогов текущего пользователя.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getDialogs" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		[Obsolete("Устаревшая версия API. Используйте метод GetDialogs(DialogsGetParams @params)")]
		public ReadOnlyCollection<Message> GetDialogs(out int totalCount, out int unreadCount, uint count = 20, int? offset = null, bool unread = false, long? startMessageId = null, uint? previewLength = null)
		{
			var parameters = new MessagesDialogsGetParams
			{
				StartMessageId = startMessageId,
				Offset = offset.Value,
				PreviewLength = previewLength,
				Count = count,
				Unread = unread
			};
			var response = _vk.Call("messages.getDialogs", parameters);

			// При загрузке списка непрочитанных диалогов в параметре count передается значение unreadCount,
			// а значение totalCount не возвращаеться
			totalCount = response["count"];
			if (unread)
			{
				unreadCount = totalCount;
			} else
			{
				unreadCount = response.ContainsKey("unread_dialogs") ? response["unread_dialogs"] : 0;
			}
			return GetDialogs(parameters).Messages;
		}

		/// <summary>
		/// Возвращает список диалогов аккаунта
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>В случае успеха возвращает список диалогов пользователя</returns>
		[Pure]
		[ApiVersion("5.44")]
		public MessagesGetObject GetDialogs(MessagesDialogsGetParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(() => @params.Count);
			return _vk.Call("messages.getDialogs", @params);
		}

		/// <summary>
		/// Возвращает список найденных диалогов текущего пользователя по введенной строке поиска.
		/// </summary>
		/// <param name="query">Подстрока, по которой будет производиться поиск.</param>
		/// <param name="limit">Количество пользователей которое нужно вернуть.</param>
		/// <param name="fields">Поля профилей собеседников, которые необходимо вернуть.</param>
		/// <returns>
		/// В результате выполнения данного метода будет возвращён массив объектов профилей, бесед и email.
		/// </returns>
		/// <exception cref="System.ArgumentException">Query can not be null or empty.;query</exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.searchDialogs" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null)
		{
			var parameters = new VkParameters
			{
				{ "q", query },
				{ "fields", fields },
				{ "limit", limit }
			};

			return _vk.Call("messages.searchDialogs", parameters);
		}

		/// <summary>
		/// Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
		/// </summary>
		/// <param name="query">Подстрока, по которой будет производиться поиск.</param>
		/// <param name="totalCount">Общее количество найденных сообщений.</param>
		/// <param name="count">Количество сообщений, которое необходимо получить (но не более 100).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений из списка найденных.</param>
		/// <returns>Список личных сообщений пользователя, удовлетворяющих условиям запроса.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.search"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		[Obsolete("Устаревшая версия API. Используйте метод Search(out int totalCount, [NotNull] string query, long? previewLength, long? offset, long? count)")]
		public ReadOnlyCollection<Message> Search([NotNull] string query, out int totalCount, int? count = null, int? offset = null)
		{
			return Search(out totalCount, query, null, offset, count);
		}

		/// <summary>
		/// Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
		/// </summary>
		/// <param name="totalCount">Общее количество найденных сообщений.</param>
		/// <param name="query">Подстрока, по которой будет производиться поиск.строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение. Укажите ''0'', если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).положительное число (Положительное число).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений из списка найденных.положительное число (Положительное число).</param>
		/// <param name="count">Количество сообщений, которое необходимо получить.положительное число, по умолчанию 20, максимальное значение 100 (Положительное число, по умолчанию 20, максимальное значение 100).</param>
		/// <returns>
		/// После успешного выполнения возвращает  объектов , найденных в соответствии с поисковым запросом '''q'''.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.search" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Message> Search(out int totalCount, [NotNull] string query, long? previewLength, long? offset, long? count)
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				throw new ArgumentException("Query can not be null or empty.", "query");
			}

			var parameters = new VkParameters {
				{ "q", query },
				{ "preview_length", previewLength },
				{ "offset", offset },
				{ "count", count }
			};

			VkResponseArray response = _vk.Call("messages.search", parameters);

			totalCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<Message>(r => r);
		}

		/// <summary>
		/// Посылает личное сообщение.
		/// </summary>
		/// <param name="id">
		/// Если параметр <paramref name="isChat"/> равен false, то задает идентификатор пользователя, которому необходимо послать сообщение.
		/// Если параметр <paramref name="isChat"/> равен true, то задает идентификатор беседы, к которой будет относиться сообщение.
		/// </param>
		/// <param name="isChat">Признак посылается ли сообщение в беседу (true) или указанному пользователю (false).</param>
		/// <param name="message">Текст личного cообщения (является обязательным, если не задан параметр <paramref name="attachment"/>).</param>
		/// <param name="title">Заголовок сообщения.</param>
		/// <param name="attachment">Медиа-приложение к личному сообщению.</param>
		/// <param name="forwardMessagedIds">Идентификаторы пересылаемых сообщений. Перечисленные сообщения отправителя будут отображаться
		/// в теле письма у получателя.</param>
		/// <param name="fromChat">Задайте false для обычного сообщения и true для сообщения из часта.</param>
		/// <param name="latitude">Широта при добавлении местоположения.</param>
		/// <param name="longitude">Долгота при добавлении местоположения.</param>
		/// <param name="guid">Уникальный строковой идентификатор, предназначенный для предотвращения повторной отправки одинакового сообщения.</param>
		/// <param name="captchaSid">Id капчи (только если для вызова метода необходимо ввести капчу)</param>
		/// <param name="captchaKey">Текст капчи (только если для вызова метода необходимо ввести капчу)</param>
		/// <returns>Возвращается идентификатор отправленного сообщения.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.send"/>.
		/// </remarks>
		[Obsolete("Устаревшая версия API. Используйте метод Send(MessageSendParams @params)")]
		public long Send(
			long id,
			bool isChat,
			string message,
			string title = "",
			MediaAttachment attachment = null,
			IEnumerable<long> forwardMessagedIds = null,
			bool fromChat = false,
			double? latitude = null,
			double? longitude = null,
			string guid = null,
			long? captchaSid = null,
			string captchaKey = null)
		{

			var parameters = new MessagesSendParams
			{
				UserId = (isChat ? (long?)null : id),
				Message = message,
				ForwardMessages = forwardMessagedIds,
				Lat = latitude,
				Attachments = new List<MediaAttachment> { attachment },
				Guid = guid,
				CaptchaKey = captchaKey,
				CaptchaSid = captchaSid,
				Longitude = longitude,
				ChatId = (isChat ? (long?)null : id)
			};

			return Send(parameters);
		}

		/// <summary>
		/// Посылает личное сообщение.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// Возвращается идентификатор отправленного сообщения.
		/// </returns>
		/// <exception cref="System.ArgumentException">Message can not be <c>null</c>.</exception>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.send" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public long Send(MessagesSendParams @params)
		{
			if (string.IsNullOrEmpty(@params.Message))
			{
				throw new ArgumentException("Message can not be null.", "Message");
			}

			return _vk.Call("messages.send", @params);
		}

		/// <summary>
		/// Удаляет все личные сообщения в диалоге.
		/// </summary>
		/// <param name="userId">
		/// Если параметр <paramref name="isChat"/> равен false, то задает идентификатор пользователя, из диалога с которым необходимо удалить свои личные сообщения.
		/// Если параметр <paramref name="isChat"/> равен true, то задает идентификатор беседы, из которой необходимо удалить свои личные сообщения.
		/// </param>
		/// <param name="isChat">Признак удаляются ли сообщения из беседы (true) или из диалога с указанным пользователем (false).</param>
		/// <param name="peerId">Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для сообщества: -id сообщества. </param>
		/// <param name="offset">Смещение, начиная с которого нужно удалить переписку (по умолчанию удаляются все сообщения,
		///  начиная с первого).</param>
		/// <param name="count">Как много сообщений нужно удалить. Обратите внимание что на метод наложено ограничение, за один вызов
		/// нельзя удалить больше 10000 сообщений, поэтому если сообщений в переписке больше - метод нужно вызывать несколько раз.</param>
		/// <returns>Признак удалось ли удалить сообщения.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.deleteDialog"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool DeleteDialog(long userId, bool isChat, long? peerId = null, uint? offset = null, uint? count = null)
		{
			var parameters = new VkParameters
			{
				{ isChat ? "chat_id" : "user_id", userId },
				{ "offset", offset },
				{ "peer_id", peerId }
			};
			if (count <= 10000)
			{
				parameters.Add("count", count);
			}
			return _vk.Call("messages.deleteDialog", parameters);
		}

		/// <summary>
		/// Удаляет сообщения пользователя.
		/// </summary>
		/// <param name="messageIds">
		/// Идентификаторы удаляемых сообщений.
		/// </param>
		/// <returns>
		/// Возвращает словарь (идентификатор сообщения -> признак было ли удаление сообщения успешным).
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.delete"/>.
		/// </remarks>
		/// <exception cref="ArgumentNullException">Параметр <paramref name="key" /> имеет значение null.</exception>
		/// <exception cref="ArgumentException">Элемент с таким ключом уже существует в словаре <see cref="T:System.Collections.Generic.Dictionary`2" />.</exception>
		[ApiVersion("5.44")]
		public IDictionary<ulong, bool> Delete(IEnumerable<ulong> messageIds)
		{
			if (messageIds == null)
			{
				throw new ArgumentNullException("messageIds", "Parameter messageIds can not be null.");
			}
			var ids = messageIds.ToList();
			if (ids.Count == 0)
			{
				throw new ArgumentException("Parameter messageIds has no elements.", "messageIds");
			}
			var parameters = new VkParameters { { "message_ids", ids } };

			var response = _vk.Call("messages.delete", parameters);

			var result = new Dictionary<ulong, bool>();
			foreach (var id in ids)
			{
				bool isDeleted = response[id.ToString(CultureInfo.InvariantCulture)];
				result.Add(id, isDeleted);
			}

			return result;
		}

		/// <summary>
		/// Удаляет личное сообщение пользователя с заданным идентификатором.
		/// </summary>
		/// <param name="messageId">
		/// Идентификатор удаляемого сообщения.
		/// </param>
		/// <returns>
		/// Признак было ли удаление сообщения успешным.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.delete"/>.
		/// </remarks>
		/// <exception cref="ArgumentNullException">Параметр <paramref name="key" /> имеет значение null.</exception>
		/// <exception cref="KeyNotFoundException">Свойство получено и параметр <paramref name="key" /> не найден.</exception>
		/// <exception cref="NotSupportedException">Свойство задано, и объект <see cref="T:System.Collections.Generic.IDictionary`2" /> доступен только для чтения.</exception>
		[ApiVersion("5.44")]
		public bool Delete(ulong messageId)
		{
			var result = Delete(new[] { messageId });
			return result[messageId];
		}

		/// <summary>
		/// Восстанавливает удаленное сообщение.
		/// </summary>
		/// <param name="messageId">Идентификатор сообщения, которое нужно восстановить.</param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.restore"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Restore(ulong messageId)
		{
			var parameters = new VkParameters
			{
				{ "message_id", messageId }
			};

			return _vk.Call("messages.restore", parameters);
		}

		/// <summary>
		/// Помечает сообщения как непрочитанные.
		/// </summary>
		/// <param name="messageIds">
		/// Идентификаторы сообщений, которые нужно пометить как непрочитанные.
		/// </param>
		/// <returns>
		/// Возвращает true, если сообщения были успешно помечены как непрочитанные, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.markAsNew"/>.
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		public bool MarkAsNew(IEnumerable<ulong> messageIds)
		{
			var parameters = new VkParameters { { "mids", messageIds } };

			return _vk.Call("messages.markAsNew", parameters);
		}

		/// <summary>
		/// Помечает указанное сообщение как непрочитанное.
		/// </summary>
		/// <param name="messageId">
		/// Идентификатор сообщения, которое необходимо пометить как прочитанное.
		/// </param>
		/// <returns>
		/// Возвращает true, если сообщение были успешно помечено как непрочитанное, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.markAsNew"/>.
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		public bool MarkAsNew(ulong messageId)
		{
			return MarkAsNew(new[] { messageId });
		}

		/// <summary>
		/// Помечает сообщения как прочитанные.
		/// </summary>
		/// <param name="messageIds">
		/// Идентификаторы сообщений, которые нужно пометить как прочитанные.
		/// </param>
		/// <returns>
		/// Возвращает true, если сообщения были успешно помечены как прочитанные, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.markAsRead"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		[Obsolete("Устаревшая версия API. Используйте метод MarkAsRead(IEnumerable<long> messageIds, string peerId, long? startMessageId)")]
		public bool MarkAsRead(IEnumerable<long> messageIds)
		{
			return MarkAsRead(messageIds, null, null);
		}

		/// <summary>
		/// Помечает сообщение как прочитанное.
		/// </summary>
		/// <param name="messageId">
		/// Идентификатор сообщения, которое необходимо пометить как прочитанное.
		/// </param>
		/// <returns>
		/// Возвращает true, если сообщение были успешно помечено как прочитанное, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.markAsRead"/>.
		/// </remarks>
		[Obsolete("Устаревшая версия API. Используйте метод MarkAsRead(IEnumerable<long> messageIds, string peerId, long? startMessageId)")]
		public bool MarkAsRead(long messageId)
		{
			return MarkAsRead(new[] { messageId });
		}
		/// <summary>
		/// Помечает сообщения как прочитанные.
		/// </summary>
		/// <param name="messageIds">Идентификаторы сообщений. список положительных чисел, разделенных запятыми (Список положительных чисел, разделенных запятыми).</param>
		/// <param name="peerId">Идентификатор чата или пользователя, если это диалог. строка (Строка).</param>
		/// <param name="startMessageId">При передаче этого параметра будут помечены как прочитанные все сообщения, начиная с данного. положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.markAsRead" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool MarkAsRead(IEnumerable<long> messageIds, string peerId, long? startMessageId = null)
		{
			var parameters = new VkParameters {
				{ "message_ids", messageIds },
				{ "peer_id", peerId },
				{ "start_message_id", startMessageId }
			};

			return _vk.Call("messages.markAsRead", parameters);
		}
		/// <summary>
		/// Изменяет статус набора текста пользователем в диалоге.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя</param>
		/// <param name="peerId">Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для сообщества: -id сообщества.</param>
		/// <returns>
		/// После успешного выполнения возвращает true, false в противном случае.
		/// Текст «N набирает сообщение...» отображается в течение 10 секунд после вызова метода, либо до момента отправки сообщения.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.setActivity"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool SetActivity(long userId, long? peerId = null)
		{
			var parameters = new VkParameters
			{
				{ "used_id", userId },
				{ "type", "typing" },
				{ "peer_id", peerId }
			};

			return _vk.Call("messages.setActivity", parameters);
		}

		/// <summary>
		/// Возвращает текущий статус и дату последней активности указанного пользователя.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, информацию о последней активности которого требуется получить. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
		/// <returns>
		/// Возвращает объект, содержащий следующие поля: 
		/// 
		/// online — текущий статус пользователя (1 — в сети, 0 — не в сети); 
		/// time — дата последней активности пользователя в формате unixtime.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getLastActivity" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public LastActivity GetLastActivity(long userId)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId }
			};

			var response = _vk.Call("messages.getLastActivity", parameters);

			LastActivity activity = response;
			activity.UserId = userId;

			return activity;
		}

		/// <summary>
		/// Возвращает информацию о беседе
		/// </summary>
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. </param>
		/// <returns>
		/// После успешного выполнения возварщает список объектов, описывающих беседу (мультидиалог).
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// <a href="http://vk.com/dev/messages.getChat"/>Страница документации ВКонтакте</a> .
		/// </remarks>
		public Chat GetChat(long chatId, ProfileFields fields = null, Enums.SafetyEnums.NameCase nameCase = null)
		{
			return GetChat(new[] { chatId }, fields, nameCase).FirstOrDefault();
		}

		/// <summary>
		/// Возвращает информацию о беседе.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы. целое число (Целое число).</param>
		/// <param name="chatIds">Список идентификаторов бесед. список целых чисел, разделенных запятыми (Список целых чисел, разделенных запятыми).</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть. 
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка (Строка).</param>
		/// <returns>
		/// После успешного выполнения возвращает объект (или список объектов) мультидиалога. 
		/// Если был задан параметр fields, поле users содержит список объектов пользователей с дополнительным полем invited_by, содержащим идентификатор пользователя, пригласившего в беседу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getChat" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null)
		{
			var isNoEmpty = chatIds == null || !chatIds.Any();
			if (isNoEmpty)
			{
				throw new ArgumentException("At least one chat ID must be defined", "chatIds");
			}
			var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase } };
			if (chatIds.Count() > 1)
			{
				parameters.Add("chat_ids", chatIds);
			} else
			{
				parameters.Add("chat_id", chatIds.ElementAt(0));
			}
			var response = _vk.Call("messages.getChat", parameters);

			if (chatIds.Count() > 1)
			{
				return response.ToReadOnlyCollectionOf<Chat>(c => c);
			}
			return new ReadOnlyCollection<Chat>(new List<Chat> { response });
		}



		/// <summary>
		/// Создаёт беседу с несколькими участниками.
		/// </summary>
		/// <param name="userIds">Идентификаторы пользователей, которых нужно включить в мультидиалог. список положительных чисел, разделенных запятыми, обязательный параметр (Список положительных чисел, разделенных запятыми, обязательный параметр).</param>
		/// <param name="title">Название беседы. строка (Строка).</param>
		/// <returns>
		/// После успешного выполнения возвращает  идентификатор созданного чата (chat_id).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.createChat" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				throw new ArgumentException("Title can not be empty or null.", "userIds");
			}

			var parameters = new VkParameters
			{
				{ "uids", userIds },
				{ "title", title }
			};

			return _vk.Call("messages.createChat", parameters);
		}

		/// <summary>
		/// Изменяет название беседы.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
		/// <param name="title">Новое название для беседы. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.editChat" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool EditChat(long chatId, [NotNull] string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				throw new ArgumentException("Title can not be empty or null.", "title");
			}

			var parameters = new VkParameters
			{
				{ "chat_id", chatId },
				{ "title", title }
			};

			return _vk.Call("messages.editChat", parameters);
		}

		/// <summary>
		/// Позволяет получить список пользователей беседы по ее идентификатору.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть.</param>
		/// <returns>После успешного выполнения возвращает список идентификаторов участников беседы.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getChatUsers"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		[Obsolete("Устаревшая версия API. Используйте метод GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)")]
		public ReadOnlyCollection<User> GetChatUsers(long chatId, UsersFields fields)
		{
			return GetChatUsers(new List<long> { chatId }, fields, null);
		}

		/// <summary>
		/// Позволяет получить список пользователей беседы по ее идентификатору.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <returns>После успешного выполнения возвращает список идентификаторов участников беседы.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getChatUsers"/>.
		/// </remarks>
		[Pure]
		[Obsolete("Устаревшая версия API. Используйте метод GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)")]
		public ReadOnlyCollection<long> GetChatUsers(long chatId)
		{
			var users = GetChatUsers(chatId, null);
			return users.Select(x => x.Id).ToReadOnlyCollection();
		}

		/// <summary>
		/// Позволяет получить список пользователей мультидиалога по его id.
		/// </summary>
		/// <param name="chatIds">Идентификаторы бесед. список целых чисел, разделенных запятыми (Список целых чисел, разделенных запятыми).</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть. 
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка (Строка).</param>
		/// <returns>
		/// После успешного выполнения возвращает список идентификаторов участников беседы. 
		/// Если был задан параметр fields, возвращает список объектов пользователей с дополнительным полем invited_by, содержащим идентификатор пользователя, пригласившего в беседу.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getChatUsers" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)
		{
			var parameters = new VkParameters {

				{ "chat_ids", chatIds },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			var response = _vk.Call("messages.getChatUsers", parameters);

			return response.ToReadOnlyCollectionOf<User>(x => fields != null ? x : new User { Id = (long)x });
		}

		/// <summary>
		/// Добавляет в мультидиалог нового пользователя.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="userId">Идентификатор пользователя, которого необходимо включить в беседу. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.addChatUser" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool AddChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters { { "chat_id", chatId }, { "uid", userId } };

			return _vk.Call("messages.addChatUser", parameters);
		}

		/// <summary>
		/// Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
		/// <param name="userId">Идентификатор пользователя, которого необходимо исключить из беседы. Может быть меньше нуля в случае, если пользователь приглашён по email. обязательный параметр (Обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.removeChatUser" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool RemoveChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters {
				{ "chat_id", chatId },
				{ "user_id", userId }
			};

			return _vk.Call("messages.removeChatUser", parameters);
		}

		/// <summary>
		/// Возвращает данные, необходимые для подключения к Long Poll серверу.
		/// Long Poll подключение позволит Вам моментально узнавать о приходе новых сообщений и других событий.
		/// </summary>
		/// <param name="useSsl"><c>true</c> — Использовать SSL.</param>
		/// <param name="needPts"><c>true</c> — возвращать поле pts, необходимое для работы метода messages.getLongPollHistory </param>
		/// <returns>
		/// Возвращает объект, с помощью которого можно подключиться к серверу быстрых сообщений для мгновенного
		/// получения приходящих сообщений и других событий.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getLongPollServer" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public LongPollServerResponse GetLongPollServer(bool useSsl = false, bool needPts = false)
		{
			var parameters = new VkParameters
			{
				{ "use_ssl", useSsl },
				{ "need_pts", needPts }
			};
			return _vk.Call("messages.getLongPollServer", parameters);
		}

		/// <summary>
		/// Возвращает обновления в личных сообщениях пользователя.
		/// Для ускорения работы с личными сообщениями может быть полезно кешировать уже загруженные ранее сообщения на
		/// мобильном устройстве / ПК пользователя, чтобы не получать их повторно при каждом обращении.
		/// Этот метод помогает осуществить синхронизацию локальной копии списка сообщений с актуальной версией.
		/// </summary>
		/// <param name="params">Параметры запроса к LongPool серверу <see cref="MessagesGetLongPollHistoryParams"/></param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getLongPollHistory" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(() => @params.PreviewLength);
			VkErrors.ThrowIfNumberIsNegative(() => @params.EventsLimit);
			VkErrors.ThrowIfNumberIsNegative(() => @params.MsgsLimit);
			VkErrors.ThrowIfNumberIsNegative(() => @params.MaxMsgId);

			return _vk.Call("messages.getLongPollHistory", @params);
		}

		/// <summary>
		/// Позволяет удалить фотографию мультидиалога.
		/// </summary>
		/// <param name="messageId">Идентификатор отправленного системного сообщения;</param>
		/// <param name="chatId">Идентификатор беседы. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// message_id — идентификатор отправленного системного сообщения;
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.deleteChatPhoto" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public Chat DeleteChatPhoto(out ulong messageId, ulong chatId)
		{
			var parameters = new VkParameters
			{
				{ "chat_id", chatId }
			};
			var result = _vk.Call("messages.deleteChatPhoto", parameters);
			messageId = result["message_id"];
			return result["chat"];
		}

		/// <summary>
		/// Позволяет установить фотографию мультидиалога, загруженную с помощью метода photos.getChatUploadServer.
		/// </summary>
		/// <param name="file">Содержимое поля response из ответа специального upload сервера, полученного в результате загрузки изображения на адрес, полученный методом photos.getChatUploadServer. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="messageId">Идентификатор отправленного системного сообщения;</param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля: 
		/// message_id — идентификатор отправленного системного сообщения; 
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.setChatPhoto" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public long SetChatPhoto(out long messageId, string file)
		{
			var parameters = new VkParameters
			{
				{ "file", file }
			};
			var result = _vk.Call("messages.setChatPhoto", parameters);
			messageId = result["message_id"];
			return result["chat"];
		}


		/// <summary>
		/// Помечает сообщения как важные либо снимает отметку.
		/// </summary>
		/// <param name="messageIds">Список идентификаторов сообщений, которые необходимо пометить.список положительных чисел, разделенных запятыми (Список положительных чисел, разделенных запятыми).</param>
		/// <param name="important">&#39;&#39;1&#39;&#39;, если сообщения необходимо пометить, как важные;&#39;&#39;0&#39;&#39;, если необходимо снять пометку.положительное число (Положительное число).</param>
		/// <returns>
		/// Возвращает список идентификаторов успешно помеченных сообщений.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.markAsImportant" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<long> MarkAsImportant(IEnumerable<long> messageIds, bool important = true)
		{
			var parameters = new VkParameters
			{
				{ "message_ids", messageIds },
				{ "important", important }
			};

			VkResponseArray result = _vk.Call("messages.markAsImportant", parameters);
			return result.ToReadOnlyCollectionOf<long>(x => x);
		}
	}
}
