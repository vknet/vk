using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с сообщениями.
	/// </summary>
	public partial class MessagesCategory
	{

		/// <summary>
		/// Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
		/// </summary>
		/// <param name="type">Тип сообщений которые необходимо получить.
		/// Необходимо передать MessageType.Received
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.get
		/// </remarks>
		[Pure]
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getHistory
		/// </remarks>
		[Pure]
		[Obsolete("Устаревшая версия API. Используйте метод GetHistory(MessagesGetParams @params)")]
		public ReadOnlyCollection<Message> GetHistory(out int totalCount, bool isChat, long id, int? offset = null, uint? count = 20,
			long? startMessageId = null, bool inReverse = false)
		{
			var parameters = new MessagesGetHistoryParams
			{
				Offset = offset,
				StartMessageId = startMessageId,
				Reversed = inReverse,
				PeerId = isChat ? id : (long?)null,
				UserId = isChat ? (long?)null : id,
				Count = count.Value
			};

			var response = _vk.Call("messages.getHistory", parameters);

			totalCount = response["count"];

			return GetHistory(parameters).Messages;
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getDialogs
		/// </remarks>
		[Pure]
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
			}
			else
			{
				unreadCount = response.ContainsKey("unread_dialogs") ? response["unread_dialogs"] : 0;
			}
			return GetDialogs(parameters).Messages;
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.search
		/// </remarks>
		[Pure]
		[Obsolete("Устаревшая версия API. Используйте метод Search(out int totalCount, [NotNull] string query, long? previewLength, long? offset, long? count)")]
		public ReadOnlyCollection<Message> Search([NotNull] string query, out int totalCount, int? count = null, int? offset = null)
		{
			return Search(out totalCount, query, null, offset, count);
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
		/// <param name="randomId"></param>
		/// <param name="captchaSid">Id капчи (только если для вызова метода необходимо ввести капчу)</param>
		/// <param name="captchaKey">Текст капчи (только если для вызова метода необходимо ввести капчу)</param>
		/// <returns>Возвращается идентификатор отправленного сообщения.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.send
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
			long? randomId = null,
			long? captchaSid = null,
			string captchaKey = null)
		{

			var parameters = new MessagesSendParams
			{
				UserId = (isChat ? (long?)null : id),
				Message = message,
				ForwardMessages = forwardMessagedIds,
				Lat = latitude,
				Attachments = attachment == null ? null : new List<MediaAttachment> { attachment },
				RandomId = randomId,
				CaptchaKey = captchaKey,
				CaptchaSid = captchaSid,
				Longitude = longitude,
				ChatId = (isChat ? (long?)null : id)
			};

			return Send(parameters);
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsNew
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		public bool MarkAsNew(IEnumerable<ulong> messageIds)
		{
			throw new System.Exception("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.");
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsNew
		/// </remarks>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		public bool MarkAsNew(ulong messageId)
		{
			throw new System.Exception("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.");
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsRead
		/// </remarks>
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsRead
		/// </remarks>
		[Obsolete("Устаревшая версия API. Используйте метод MarkAsRead(IEnumerable<long> messageIds, string peerId, long? startMessageId)")]
		public bool MarkAsRead(long messageId)
		{
			return MarkAsRead(new[] { messageId });
		}

		/// <summary>
		/// Позволяет получить список пользователей беседы по ее идентификатору.
		/// </summary>
		/// <param name="chatId">Идентификатор беседы.</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть.</param>
		/// <returns>После успешного выполнения возвращает список идентификаторов участников беседы.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getChatUsers
		/// </remarks>
		[Pure]
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getChatUsers
		/// </remarks>
		[Pure]
		[Obsolete("Устаревшая версия API. Используйте метод GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase)")]
		public ReadOnlyCollection<long> GetChatUsers(long chatId)
		{
			var users = GetChatUsers(chatId, null);
			return users.Select(x => x.Id).ToReadOnlyCollection();
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
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getById
		/// </remarks>
		[Pure]
		[Obsolete("Устаревшая версия API. Используйте метод GetById([NotNull] IEnumerable<ulong> messageIds, uint? previewLength = null)")]
		public ReadOnlyCollection<Message> GetById(out int totalCount, [NotNull] IEnumerable<ulong> messageIds, uint? previewLength = null)
		{
			var response = GetById(messageIds, previewLength);

			totalCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
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
		/// Страница документации ВКонтакте http://vk.com/dev/messages.search
		/// </remarks>
		[Obsolete("Устаревшая версия API. Используйте метод Search([NotNull] string query, long? previewLength, long? offset, long? count)")]
		public ReadOnlyCollection<Message> Search(out int totalCount, [NotNull] string query, long? previewLength, long? offset, long? count)
		{
			var response = Search(query, previewLength, offset, count);

			totalCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}
	}
}