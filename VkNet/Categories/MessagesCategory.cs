using VkNet.Enums.Filters;
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
			ulong? lastMessageId = null)
		{
			var parameters = new VkParameters
			{
				{ "out", type },
				{ "offset", offset },
				{ "filters", filter },
				{ "preview_length", previewLength },
				{ "last_message_id", lastMessageId }
			};
			if (count <= 200)
			{
				parameters.Add("count", count);
			}
			if (timeOffset.HasValue)
			{
				parameters.Add("time_offset", timeOffset.Value.TotalSeconds);
			}
			var response = _vk.Call("messages.get", parameters);
			totalCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<Message>(item => item);
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
			var response = _vk.Call("messages.get", @params);
			return response;
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
		[ApiVersion("5.37")]
		[Obsolete("Устаревшая версия API. Используйте метод GetHistory(MessagesGetParams @params)")]
		public ReadOnlyCollection<Message> GetHistory(out int totalCount, bool isChat, ulong id, int? offset = null, uint? count = 20,
			long? startMessageId = null, bool inReverse = false)
		{
			var parameters = new VkParameters
			{
				{ isChat ? "chat_id" : "uid", id },
				{ "offset", offset },
				{ "start_mid", startMessageId },
				{ "rev", inReverse }
			};
			if (count <= 200)
			{
				parameters.Add("count", count);
			}
			var response = _vk.Call("messages.getHistory", parameters);

			totalCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<Message>(item => item);
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
		[ApiVersion("5.40")]
		public MessagesGetObject GetHistory(HistoryGetParams @params)
		{
			
			var response = _vk.Call("messages.getHistory", @params);
			return response;
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
		public ReadOnlyCollection<Message> GetById(out int totalCount, [NotNull] IEnumerable<ulong> messageIds,  uint? previewLength = null)
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
		[ApiVersion("5.37")]
		[Obsolete("Устаревшая версия API. Используйте метод GetDialogs(DialogsGetParams @params)")]
		public ReadOnlyCollection<Message> GetDialogs(out int totalCount, out int unreadCount, int count = 20, int? offset = null, bool unread = false, long? startMessageId = null, int? previewLength = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			var parameters = new VkParameters
			{
				{ "start_message_id", startMessageId },
				{ "offset", offset },
				{ "unread", unread },
				{ "preview_length", previewLength },
				{ "count", count }
			};
			var response = _vk.Call("messages.getDialogs", parameters);

			// При загрузке списка непрочитанных диалогов в параметре count передается значение unreadCount,
			// а значение totalCount не возвращаеться
			totalCount = response["count"];
			VkResponseArray items = response["items"];
			if (unread)
			{
				unreadCount = totalCount;
			}
			else
			{
				unreadCount = response.ContainsKey("unread_dialogs") ? response["unread_dialogs"] : 0;
			}
			return items.ToReadOnlyCollectionOf<Message>(r => r);
		}

		/// <summary>
		/// Возвращает список диалогов аккаунта
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>В случае успеха возвращает список диалогов пользователя</returns>
		[Pure]
		[ApiVersion("5.40")]
		public MessagesGetObject GetDialogs(DialogsGetParams @params)
		{
			var response = _vk.Call("messages.getDialogs", @params);
			return response;
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
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Message> Search([NotNull] string query, out int totalCount, int? count = null, int? offset = null)
		{
			if (string.IsNullOrEmpty(query))
				throw new ArgumentException("Query can not be null or empty.", "query");

			var parameters = new VkParameters { { "q", query }, { "count", count }, { "offset", offset } };
			// :TODO: Без приведения типа падает в этом месте, потому что возвращает VkResponseArray
			var response = _vk.Call("messages.search", parameters);

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
			Attachment attachment = null,
			IEnumerable<long> forwardMessagedIds = null,
			bool fromChat = false,
			double? latitude = null,
			double? longitude = null,
			string guid = null,
			long? captchaSid = null,
			string captchaKey = null)
		{
			if (string.IsNullOrEmpty(message))
			{
				throw new ArgumentException("Message can not be null.", "message");
			}
			var parameters = new VkParameters
			{
				{ isChat ? "chat_id" : "uid", id },
				{ "message", HttpUtility.UrlEncode(message) },
				{ "forward_messages", forwardMessagedIds },
				{ "title", HttpUtility.UrlEncode(title) },
				{ "type", fromChat },
				{ "lat", latitude },
				{ "long", longitude },
				{ "guid", HttpUtility.UrlEncode(guid) },
				{ "captcha_sid", captchaSid},
				{ "captcha_key", captchaKey}

			};

			// TODO: Yet not work with attachments. Fix it later.

			return _vk.Call("messages.send", parameters);
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
		[ApiVersion("5.37")]
		public ulong Send(MessageSendParams @params)
		{
			if (string.IsNullOrEmpty(@params.Message))
			{
				throw new ArgumentException("Message can not be null.", "Message");
			}

			// TODO: Yet not work with attachments. Fix it later.

			return _vk.Call("messages.send", @params);
		}

		/// <summary>
		/// Удаляет все личные сообщения в диалоге.
		/// </summary>
		/// <param name="id">
		/// Если параметр <paramref name="isChat"/> равен false, то задает идентификатор пользователя, из диалога с которым необходимо удалить свои личные сообщения.
		/// Если параметр <paramref name="isChat"/> равен true, то задает идентификатор беседы, из которой необходимо удалить свои личные сообщения.
		/// </param>
		/// <param name="isChat">Признак удаляются ли сообщения из беседы (true) или из диалога с указанным пользователем (false).</param>
		/// <param name="offset">Смещение, начиная с которого нужно удалить переписку (по умолчанию удаляются все сообщения,
		///  начиная с первого).</param>
		/// <param name="count">Как много сообщений нужно удалить. Обратите внимание что на метод наложено ограничение, за один вызов
		/// нельзя удалить больше 10000 сообщений, поэтому если сообщений в переписке больше - метод нужно вызывать несколько раз.</param>
		/// <returns>Признак удалось ли удалить сообщения.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.deleteDialog"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool DeleteDialog(long id, bool isChat, uint? offset = null, uint? count = null)
		{
			var parameters = new VkParameters { { isChat ? "chat_id" : "uid", id }, { "offset", offset }};
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
		[ApiVersion("5.37")]
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
		[ApiVersion("5.37")]
		public bool Restore(ulong messageId)
		{
			var parameters = new VkParameters { { "message_id", messageId } };

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
		[ApiVersion("5.37")]
		public bool MarkAsRead(IEnumerable<ulong> messageIds)
		{
			var parameters = new VkParameters { { "mids", messageIds } };

			return _vk.Call("messages.markAsRead", parameters);
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
		public bool MarkAsRead(ulong messageId)
		{
			return MarkAsRead(new[] { messageId });
		}

		/// <summary>
		/// Изменяет статус набора текста пользователем в диалоге.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает true, false в противном случае.
		/// Текст «N набирает сообщение...» отображается в течение 10 секунд после вызова метода, либо до момента отправки сообщения.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.setActivity"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool SetActivity(long userId)
		{
			var parameters = new VkParameters { { "used_id", userId }, { "type", "typing" } };

			return _vk.Call("messages.setActivity", parameters);
		}

		/// <summary>
		/// Возвращает текущий статус и дату последней активности указанного пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, информацию о последней активности которого требуется получить.
		/// </param>
		/// <returns>
		/// Возвращает объект, содержащий информацию об активности пользователя.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getLastActivity"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.37")]
		public LastActivity GetLastActivity(long userId)
		{
			var parameters = new VkParameters { { "user_id", userId } };

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
		/// Возвращает информацию о беседах.
		/// </summary>
		/// <param name="chatIds">Идентификаторы беседы.</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. </param>
		/// <returns>После успешного выполнения возварщает массив объектов, описывающих беседы (мультидиалог).</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getChat"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, Enums.SafetyEnums.NameCase nameCase = null)
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
			}
			else
			{
				parameters.Add("chat_id", chatIds.ElementAt(0));
			}
			var response = _vk.Call("messages.getChat", parameters);

			if (chatIds.Count() > 1)
			{
				return response.ToReadOnlyCollectionOf<Chat>(c => c);
			}
			return new ReadOnlyCollection<Chat>(new List<Chat> {response});
		}

		/// <summary>
		/// Создаёт беседу с несколькими участниками.
		/// </summary>
		/// <param name="userIds">Идентификаторы пользователей, которых нужно включить в беседу (мультидиалог).</param>
		/// <param name="title">Название беседы.</param>
		/// <returns>После успешного выполнения возвращает идентификатор созданной беседы.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.createChat"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title)
		{
			if (string.IsNullOrEmpty(title))
				throw new ArgumentException("Title can not be empty or null.", "userIds");

			var parameters = new VkParameters { { "uids", userIds }, { "title", HttpUtility.UrlEncode(title) } };

			return _vk.Call("messages.createChat", parameters);
		}

		/// <summary>
		/// Изменяет название беседы.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <param name="title">Новое название для беседы.</param>
		/// <returns>
		/// После успешного выполнения возвращает true, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.editChat"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool EditChat(long chatId, [NotNull] string title)
		{
			if (string.IsNullOrEmpty(title))
				throw new ArgumentException("Title can not be empty or null.", "title");

			var parameters = new VkParameters { { "chat_id", chatId }, { "title", HttpUtility.UrlEncode(title) } };

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
		[ApiVersion("5.37")]
		public ReadOnlyCollection<User> GetChatUsers(long chatId, ProfileFields fields)
		{
			var parameters = new VkParameters { { "chat_id", chatId }, { "fields", fields } };

			var response = _vk.Call("messages.getChatUsers", parameters);

			if (fields != null)
				return response.ToReadOnlyCollectionOf<User>(x => x);

			return response.ToReadOnlyCollectionOf(x => new User { Id = (long)x });
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
		public ReadOnlyCollection<long> GetChatUsers(long chatId)
		{
			var users = GetChatUsers(chatId, null);
			return users.Select(x => x.Id).ToReadOnlyCollection();
		}

		/// <summary>
		/// Добавляет в беседу нового пользователя.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <param name="userId">Идентификатор пользователя, которого необходимо включить в беседу.</param>
		/// <returns>
		/// После успешного выполнения возвращает true, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.addChatUser"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool AddChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters { { "chat_id", chatId }, { "uid", userId } };

			return _vk.Call("messages.addChatUser", parameters);
		}

		/// <summary>
		/// Исключает из беседы пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
		/// </summary>
		/// <param name="chatId">
		/// Идентификатор беседы.
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, которого необходимо исключить из беседы.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает true, false в противном случае.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.removeChatUser"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool RemoveChatUser(long chatId, long userId)
		{
			var parameters = new VkParameters { { "chat_id", chatId }, { "uid", userId } };

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
		[ApiVersion("5.37")]
		public LongPollServerResponse GetLongPollServer( bool useSsl = false, bool needPts = false)
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
		/// <param name="params">Параметры запроса к LongPool серверу <see cref="GetLongPollHistoryParams"/></param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.getLongPollHistory" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public LongPollHistoryResponse GetLongPollHistory(GetLongPollHistoryParams @params)
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
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// message_id — идентификатор отправленного системного сообщения;
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.deleteChatPhoto" />.
		/// </remarks>
		[ApiVersion("5.37")]
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
		/// <param name="messageId">Идентификатор отправленного системного сообщения;</param>
		/// <param name="file">Содержимое поля response из ответа специального upload сервера,
		/// полученного в результате загрузки изображения на адрес,
		/// полученный методом photos.getChatUploadServer.</param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// message_id — идентификатор отправленного системного сообщения;
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Messages" />.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/messages.setChatPhoto" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool SetChatPhoto(out ulong messageId, string file)
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
		/// <param name="messageIds">Список идентификаторов сообщений, которые необходимо пометить.</param>
		/// <param name="important"><see langword="true"/>, если сообщения необходимо пометить, как важные;
		/// <see langword="false"/>, если необходимо снять пометку.</param>
		/// <returns></returns>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<ulong> MarkAsImportant(IEnumerable<ulong> messageIds, bool important = true)
		{
			var parameters = new VkParameters
			{
				{ "message_ids", messageIds },
				{ "important", important }
			};
			VkResponseArray result = _vk.Call("messages.markAsImportant", parameters);
			return result.ToReadOnlyCollectionOf<ulong>(x => x);
		}
	}
}
