﻿namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Enums;
    using Enums.Filters;
    using Enums.SafetyEnums;
    using JetBrains.Annotations;
    using Model;
    using Model.Attachments;
    using Model.RequestParams;
    using Utils;

    /// <summary>
    /// Методы для работы с сообщениями.
    /// </summary>
    public interface IMessagesCategory
    {
        /// <summary>
        /// Возвращает список входящих либо исходящих личных сообщений текущего пользователя.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>Список сообщений, удовлетворяющий условиям фильтрации.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.get
        /// </remarks>
        MessagesGetObject Get(MessagesGetParams @params);

        /// <summary>
        /// Возвращает историю сообщений текущего пользователя с указанным пользователя или групповой беседы.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>Возвращает историю сообщений с указанным пользователем или из указанной беседы</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getHistory
        /// </remarks>
        MessagesGetObject GetHistory(MessagesGetHistoryParams @params);

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
        VkCollection<Message> GetById([NotNull] IEnumerable<ulong> messageIds, uint? previewLength = null);

        /// <summary>
        /// Ворзвращает указанное сообщение по его идентификатору.
        /// </summary>
        /// <param name="messageId">Идентификатор запрошенного сообщения.</param>
        /// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение.
        /// Укажите 0, если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).</param>
        /// <returns>Запрошенное сообщение, null если сообщение с заданным идентификатором не найдено.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getById
        /// </remarks>
        Message GetById(ulong messageId, uint? previewLength = null);

        /// <summary>
        /// Возвращает список диалогов аккаунта
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>В случае успеха возвращает список диалогов пользователя</returns>
        MessagesGetObject GetDialogs(MessagesDialogsGetParams @params);

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
        SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null);

        /// <summary>
        /// Возвращает список найденных личных сообщений текущего пользователя по введенной строке поиска.
        /// </summary>
        /// <param name="query">Подстрока, по которой будет производиться поиск.строка, обязательный параметр (Строка, обязательный параметр).</param>
        /// <param name="previewLength">Количество символов, по которому нужно обрезать сообщение. Укажите ''0'', если Вы не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).положительное число (Положительное число).</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества сообщений из списка найденных.положительное число (Положительное число).</param>
        /// <param name="count">Количество сообщений, которое необходимо получить.положительное число, по умолчанию 20, максимальное значение 100 (Положительное число, по умолчанию 20, максимальное значение 100).</param>
        /// <returns>
        /// После успешного выполнения возвращает  объектов , найденных в соответствии с поисковым запросом '''q'''.
        /// </returns>
        /// <exception cref="System.ArgumentException">Query can not be null or empty.;query</exception>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.search
        /// </remarks>
        VkCollection<Message> Search([NotNull] string query, long? previewLength, long? offset, long? count);

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
        long Send(MessagesSendParams @params);

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
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.deleteDialog
        /// </remarks>
        bool DeleteDialog(long userId, bool isChat, long? peerId = null, uint? offset = null, uint? count = null);

        /// <summary>
        /// Удаляет сообщения пользователя.
        /// </summary>
        /// <param name="messageIds">Идентификаторы удаляемых сообщений.</param>
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
        IDictionary<ulong, bool> Delete(IEnumerable<ulong> messageIds);

        /// <summary>
        /// Удаляет личное сообщение пользователя с заданным идентификатором.
        /// </summary>
        /// <param name="messageId">Идентификатор удаляемого сообщения.</param>
        /// <returns>
        /// Признак было ли удаление сообщения успешным.
        /// </returns>
        /// <exception cref="NotSupportedException">Свойство задано, и объект T:System</exception>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.delete
        /// </remarks>
        bool Delete(ulong messageId);

        /// <summary>
        /// Восстанавливает удаленное сообщение.
        /// </summary>
        /// <param name="messageId">Идентификатор сообщения, которое нужно восстановить.</param>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.restore
        /// </remarks>
        bool Restore(ulong messageId);

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
        bool MarkAsRead(IEnumerable<long> messageIds, string peerId, long? startMessageId = null);

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
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.setActivity
        /// </remarks>
        bool SetActivity(long userId, long? peerId = null);

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
        LastActivity GetLastActivity(long userId);

        /// <summary>
        /// Gets the chat.
        /// </summary>
        /// <param name="chatId">The chat identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="nameCase">The name case.</param>
        /// <returns></returns>
        Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null);

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
        ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null);

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
        long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title);

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
        bool EditChat(long chatId, [NotNull] string title);

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
        ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase);

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
        bool AddChatUser(long chatId, long userId);

        /// <summary>
        /// Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
        /// </summary>
        /// <param name="chatId">Идентификатор беседы. целое число, обязательный параметр (Целое число, обязательный параметр).</param>
        /// <param name="userId">Идентификатор пользователя, которого необходимо исключить из беседы. Может быть меньше нуля в случае, если пользователь приглашён по email. обязательный параметр (Обязательный параметр).</param>
        /// <returns>
        /// После успешного выполнения возвращает <c>true</c>.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.removeChatUser
        /// </remarks>
        bool RemoveChatUser(long chatId, long userId);

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
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей Settings.Messages
        /// Страница документации ВКонтакте http://vk.com/dev/messages.getLongPollServer
        /// </remarks>
        LongPollServerResponse GetLongPollServer(bool useSsl = false, bool needPts = false);

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
        LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params);

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
        /// Страница документации ВКонтакте http://vk.com/dev/messages.deleteChatPhoto
        /// </remarks>
        Chat DeleteChatPhoto(out ulong messageId, ulong chatId);

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
        /// Страница документации ВКонтакте http://vk.com/dev/messages.setChatPhoto
        /// </remarks>
        long SetChatPhoto(out long messageId, string file);

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
        ReadOnlyCollection<long> MarkAsImportant(IEnumerable<long> messageIds, bool important = true);

        /// <summary>
        /// Отправляет стикер.
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <returns>
        /// После успешного выполнения возвращает идентификатор отправленного сообщения (mid).
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/messages.sendSticker
        /// </remarks>
        long SendSticker(MessagesSendStickerParams @params);

        /// <summary>
        /// Возвращает материалы диалога или беседы..
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <param name="nextFrom">Новое значение start_from. </param>
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
        ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom);
    }
}