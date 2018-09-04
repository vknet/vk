using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
    /// <summary>
    /// Асинхронные методы для работы с сообщениями.
    /// </summary>
    public interface IMessagesCategoryAsync
    {
        /// <summary>
        /// Добавляет в мультидиалог нового пользователя.
        /// </summary>
        /// <param name="chatId">Идентификатор беседы. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
        /// <param name="userId">Идентификатор пользователя, которого необходимо включить в беседу. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
        /// <returns>
        /// После успешного выполнения возвращает <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.addChatUser
        /// </remarks>
        Task<bool> AddChatUserAsync(long chatId, long userId);

        /// <summary>
        /// Позволяет разрешить отправку сообщений от сообщества текущему пользователю.
        /// </summary>
        /// <param name="groupId">Идентификатор сообщества.</param>
        /// <param name="key">
        /// Произвольная строка.
        /// Этот параметр можно использовать для идентификации пользователя.
        /// Его значение будет возвращено в событии message_allow Callback API.
        /// </param>
        /// <returns>
        /// После успешного выполнения возвращает <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.allowMessagesFromGroup
        /// </remarks>
        Task<bool> AllowMessagesFromGroupAsync(long groupId, string key);

        /// <summary>
        /// Создаёт беседу с несколькими участниками.
        /// </summary>
        /// <param name="userIds">Идентификаторы пользователей, которых нужно включить в мультидиалог. список положительных чисел, разделенных запятыми, обязательный параметр (Список положительных чисел, разделенных запятыми, обязательный параметр).</param>
        /// <param name="title">Название беседы. строка (Строка).</param>
        /// <returns>
        /// После успешного выполнения возвращает  идентификатор созданного чата (chat_id).
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.createChat
        /// </remarks>
        Task<long> CreateChatAsync(IEnumerable<ulong> userIds, [NotNull] string title);

        /// <summary>
        /// Удаляет сообщения пользователя.
        /// </summary>
        /// <param name="messageIds">Идентификаторы удаляемых сообщений.</param>
        /// <param name="spam">пометить сообщения как спам.</param>
        /// <param name="deleteForAll">1 — если сообщение нужно удалить для получателей</param>
        /// <returns>
        /// Возвращает словарь (идентификатор сообщения -&gt; признак было ли удаление сообщения успешным).
        /// </returns>
        /// <exception cref="System.ArgumentNullException">messageIds;Parameter messageIds can not be null.</exception>
        /// <exception cref="System.ArgumentException">Parameter messageIds has no elements.;messageIds</exception>
        /// <exception cref="ArgumentException">Элемент с таким ключом уже существует в словаре T:System</exception>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.delete
        /// </remarks>
        Task<IDictionary<ulong, bool>> DeleteAsync(IEnumerable<ulong> messageIds, bool spam, bool deleteForAll);

        /// <summary>
        /// Позволяет удалить фотографию мультидиалога.
        /// </summary>
        /// <param name="chatId">Идентификатор беседы. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
        /// <returns>
        /// После успешного выполнения возвращает объект, содержащий следующие поля:
        /// message_id — идентификатор отправленного системного сообщения;
        /// chat — объект мультидиалога.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.deleteChatPhoto
        /// </remarks>
        Task<Chat> DeleteChatPhotoAsync(ulong chatId);

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
        /// <param name="offset">Смещение, начиная с которого нужно удалить переписку (по умолчанию удаляются все сообщения,
        ///  начиная с первого).</param>
        /// <param name="count">Как много сообщений нужно удалить. Обратите внимание что на метод наложено ограничение, за один вызов
        /// нельзя удалить больше 10000 сообщений, поэтому если сообщений в переписке больше - метод нужно вызывать несколько раз.</param>
        /// <returns>Признак удалось ли удалить сообщения.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.deleteDialog
        /// </remarks>
        Task<bool> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null);

        /// <summary>
        /// Позволяет запретить отправку сообщений от сообщества текущему пользователю.
        /// </summary>
        /// <param name="groupId">Идентификатор сообщества. </param>
        /// <returns>
        /// После успешного выполнения возвращает <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/messages.denyMessagesFromGroup
        /// </remarks>
        Task<bool> DenyMessagesFromGroupAsync(long groupId);

        /// <summary>
        /// Изменяет название беседы.
        /// </summary>
        /// <param name="chatId">Идентификатор беседы. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
        /// <param name="title">Новое название для беседы. строка, обязательный параметр (Строка, обязательный параметр).</param>
        /// <returns>
        /// После успешного выполнения возвращает <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.editChat
        /// </remarks>
        Task<bool> EditChatAsync(long chatId, [NotNull] string title);

        /// <summary>
        /// Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>Список сообщений, удовлетворяющий условиям фильтрации.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.get
        /// </remarks>
        Task<MessagesGetObject> GetAsync(MessagesGetParams @params);

        /// <summary>
        /// Возвращает сообщения по их идентификаторам.
        /// </summary>
        /// <param name="messageIds">Идентификаторы сообщений, которые необходимо вернуть (не более 100).</param>
        /// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение.
        /// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).</param>
        /// <returns>
        /// Запрошенные сообщения.
        /// </returns>
        /// <exception cref="System.Exception">messageIds не может быть пустой</exception>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getById
        /// </remarks>
        Task<VkCollection<Message>> GetByIdAsync([NotNull] IEnumerable<ulong> messageIds, uint? previewLength = null);

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
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.searchDialogs
        /// </remarks>
        Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null);

        /// <summary>
        /// Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
        /// </summary>
        /// <param name="params">Параметры запроса messages.search</param>
        /// <returns>
        /// После успешного выполнения возвращает  объектов , найденных в соответствии с поисковым запросом '''q'''.
        /// </returns>
        /// <exception cref="System.ArgumentException">Query can not be null or empty.;query</exception>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.search
        /// </remarks>
        Task<VkCollection<Message>> SearchAsync(MessagesSearchParams @params);

        /// <summary>
        /// Посылает личное сообщение.
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <returns>
        /// Возвращается идентификатор отправленного сообщения.
        /// </returns>
        /// <exception cref="System.ArgumentException">Message can not be <c>null</c>.</exception>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.send
        /// </remarks>
        Task<long> SendAsync(MessagesSendParams @params);

        /// <summary>
        /// Посылает личное сообщение.
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <returns>
        /// Возвращается идентификатор отправленного сообщения.
        /// </returns>
        /// <exception cref="System.ArgumentException">Message can not be <c>null</c>.</exception>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.send
        /// </remarks>
        Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params);

        /// <summary>
        /// Восстанавливает удаленное сообщение.
        /// </summary>
        /// <param name="messageId">Идентификатор сообщения, которое нужно восстановить.</param>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.restore
        /// </remarks>
        Task<bool> RestoreAsync(ulong messageId);

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
        /// Страница документации ВКонтакте http://vk.com/dev/messages.markAsRead
        /// </remarks>
        Task<bool> MarkAsReadAsync(IEnumerable<long> messageIds, string peerId, long? startMessageId = null);

        /// <summary>
        /// Изменяет статус набора текста пользователем в диалоге.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="peerId">Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для сообщества: -id сообщества.</param>
        /// <param name="type">typing — пользователь начал набирать текст.</param>
        /// <returns>
        /// После успешного выполнения возвращает true, false в противном случае.
        /// Текст «N набирает сообщение...» отображается в течение 10 секунд после вызова метода, либо до момента отправки сообщения.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.setActivity
        /// </remarks>
        Task<bool> SetActivityAsync(long userId, long? peerId = null, string type = "typing");

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
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getLastActivity
        /// </remarks>
        Task<LastActivity> GetLastActivityAsync(long userId);

        /// <summary>
        /// Gets the chat.
        /// </summary>
        /// <param name="chatId">The chat identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="nameCase">The name case.</param>
        /// <returns>
        /// После успешного выполнения возвращает объект (или список объектов) мультидиалога. 
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/messages.getChat
        /// </remarks>
        Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null);

        /// <summary>
        /// Возвращает информацию о беседе.
        /// </summary>
        /// <param name="chatIds">Список идентификаторов бесед. список целых чисел, разделенных запятыми (Список целых чисел, разделенных запятыми).</param>
        /// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть.
        /// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, counters, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка (Строка).</param>
        /// <returns>
        /// После успешного выполнения возвращает объект (или список объектов) мультидиалога.
        /// Если был задан параметр fields, поле users содержит список объектов пользователей с дополнительным полем invited_by, содержащим идентификатор пользователя, пригласившего в беседу.
        /// </returns>
        /// <exception cref="System.ArgumentException">At least one chat ID must be defined;chatIds</exception>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getChat
        /// </remarks>
        Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds, ProfileFields fields = null,
            NameCase nameCase = null);

        /// <summary>
        /// Получает данные для превью чата с приглашением по ссылке.
        /// </summary>
        /// <param name="link">Ссылка-приглашение.</param>
        /// <param name="fields">Список полей профилей, данные о которых нужно получить.</param>
        /// <returns>Возвращает объект представляющий описание чата</returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/messages.getChatPreview
        /// </remarks>
        Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields);

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
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getChatUsers
        /// </remarks>
        Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase);

        /// <summary>
        /// Возвращает список диалогов аккаунта
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>В случае успеха возвращает список диалогов пользователя</returns>
        Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params);

        /// <summary>
        /// Возвращает историю сообщений текущего пользователя с указанным пользователя или групповой беседы.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>Возвращает историю сообщений с указанным пользователем или из указанной беседы</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getHistory
        /// </remarks>
        Task<MessagesGetObject> GetHistoryAsync(MessagesGetHistoryParams @params);

        /// <summary>
        /// Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
        /// </summary>
        /// <param name="chatId">Идентификатор беседы. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
        /// <param name="userId">Идентификатор пользователя, которого необходимо исключить из беседы. Может быть меньше нуля в случае, если пользователь приглашён по email. обязательный параметр (Обязательный параметр).</param>
        /// <param name="memberId">Идентификатор участника, которого необходимо исключить из беседы. Для сообществ — идентификатор сообщества со знаком «минус». </param>
        /// <returns>
        /// После успешного выполнения возвращает <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.removeChatUser
        /// </remarks>
        Task<bool> RemoveChatUserAsync(long chatId, long userId, long memberId = 0);

        /// <summary>
        /// Возвращает данные, необходимые для подключения к Long Poll серверу.
        /// Long Poll подключение позволит Вам моментально узнавать о приходе новых сообщений и других событий.
        /// </summary>
        /// <param name="lpVersion">версия для подключения к Long Poll. Актуальная версия: 2. </param>
        /// <param name="needPts"><c>true</c> — возвращать поле pts, необходимое для работы метода messages.getLongPollHistory </param>
        /// <returns>
        /// Возвращает объект, с помощью которого можно подключиться к серверу быстрых сообщений для мгновенного
        /// получения приходящих сообщений и других событий.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getLongPollServer
        /// </remarks>
        Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2);

        /// <summary>
        /// Возвращает обновления в личных сообщениях пользователя.
        /// Для ускорения работы с личными сообщениями может быть полезно кешировать уже загруженные ранее сообщения на
        /// мобильном устройстве / ПК пользователя, чтобы не получать их повторно при каждом обращении.
        /// Этот метод помогает осуществить синхронизацию локальной копии списка сообщений с актуальной версией.
        /// </summary>
        /// <param name="params">Параметры запроса к LongPool серверу MessagesGetLongPollHistoryParams</param>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getLongPollHistory
        /// </remarks>
        Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params);

        /// <summary>
        /// Позволяет установить фотографию мультидиалога, загруженную с помощью метода photos.getChatUploadServer.
        /// </summary>
        /// <param name="file">Содержимое поля response из ответа специального upload сервера, полученного в результате загрузки изображения на адрес, полученный методом photos.getChatUploadServer. строка, обязательный параметр (Строка, обязательный параметр).</param>
        /// <returns>
        /// После успешного выполнения возвращает объект, содержащий следующие поля:
        /// message_id — идентификатор отправленного системного сообщения;
        /// chat — объект мультидиалога.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.setChatPhoto
        /// </remarks>
        Task<long> SetChatPhotoAsync(string file);

        /// <summary>
        /// Помечает сообщения как важные либо снимает отметку.
        /// </summary>
        /// <param name="messageIds">Список идентификаторов сообщений, которые необходимо пометить.список положительных чисел, разделенных запятыми (Список положительных чисел, разделенных запятыми).</param>
        /// <param name="important">&#39;&#39;1&#39;&#39;, если сообщения необходимо пометить, как важные;&#39;&#39;0&#39;&#39;, если необходимо снять пометку.положительное число (Положительное число).</param>
        /// <returns>
        /// Возвращает список идентификаторов успешно помеченных сообщений.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.markAsImportant
        /// </remarks>
        Task<ReadOnlyCollection<long>> MarkAsImportantAsync(IEnumerable<long> messageIds, bool important = true);

        /// <summary>
        /// Отправляет стикер.
        /// </summary>
        /// <param name="parameters">Параметры запроса.</param>
        /// <returns>
        /// После успешного выполнения возвращает идентификатор отправленного сообщения (mid).
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.sendSticker
        /// </remarks>
        Task<long> SendStickerAsync(MessagesSendStickerParams parameters);

        /// <summary>
        /// Возвращает материалы диалога или беседы..
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <returns>
        /// После успешного выполнения возвращает массив объектов photo, video, audio или doc, в зависимости от значения media_type, а также дополнительное поле next_from, содержащее новое значение start_from.
        /// Если в media_type передано значение link, возвращает список объектов-ссылок:
        /// url URL ссылки.
        /// строка title заголовок сниппета.
        /// строка description описание сниппета.
        /// строка image_src URL изображения сниппета.
        /// строка.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getHistoryAttachments
        /// </remarks>
        Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params);

        /// <summary>
        /// Получает ссылку для приглашения пользователя в беседу.
        /// </summary>
        /// <param name="peerId">Идентификатор назначения.</param>
        /// <param name="reset">
        /// 1 — сгенерировать новую ссылку, сбросив предыдущую.
        /// 0 — получить предыдущую ссылку.
        /// </param>
        /// <returns>
        /// Возвращает объект с единственным полем link (string), которое содержит ссылку для приглашения в беседу.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getInviteLink
        /// </remarks>
        Task<string> GetInviteLinkAsync(ulong peerId, bool reset);

        /// <summary>
        /// Возвращает информацию о том, разрешена ли отправка сообщений от сообщества пользователю.
        /// </summary>
        /// <param name="groupId">Идентификатор сообщества.</param>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>
        /// Возвращает объект с единственным полем is_allowed (integer, [0,1]). Если отправка сообщений разрешена, поле содержит 1, иначе — 0.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.isMessagesFromGroupAllowed
        /// </remarks>
        Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId);

        /// <summary>
        /// Позволяет присоединиться к чату по ссылке-приглашению.
        /// </summary>
        /// <param name="link">Ссылка-приглашение.</param>
        /// <returns>
        /// Возвращает идентификатор чата в поле chat_id.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.joinChatByInviteLink
        /// </remarks>
        Task<long> JoinChatByInviteLinkAsync(string link);

        /// <summary>
        /// Помечает диалог как отвеченный либо снимает отметку.
        /// </summary>
        /// <param name="peerId">Идентификатор диалога</param>
        /// <param name="answered">флаг, может принимать значения 1 или 0, по умолчанию 1</param>
        /// <returns>
        /// После успешного выполнения возвращает 1.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.markAsAnsweredDialog
        /// </remarks>
        Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true);

        /// <summary>
        /// Помечает диалог как важный либо снимает отметку.
        /// </summary>
        /// <param name="peerId">Идентификатор диалога </param>
        /// <param name="important">
        /// <c>true</c>, если сообщения необходимо пометить, как важные;
        /// <c>0</c>, если необходимо снять пометку.положительное число (Положительное число).
        /// </param>
        /// <returns>
        /// После успешного выполнения возвращает 1.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.markAsImportantDialog
        /// </remarks>
        Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true);

        /// <summary>
        /// Редактирует сообщение.
        /// </summary>
        /// <param name="params">параметры запроса</param>
        /// <returns>
        /// После успешного выполнения возвращает 1.
        /// </returns>
        Task<bool> EditAsync(MessageEditParams @params);
    }
}