using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с личными сообщениями. Для моментального получения входящих сообщений используйте LongPoll сервер.
	/// </summary>
	public interface IMessagesCategory : IMessagesCategoryAsync
	{
		/// <summary>
		/// Добавляет в мультидиалог нового пользователя.
		/// </summary>
		/// <param name = "chatId">
		/// Идентификатор беседы. положительное число, обязательный параметр, максимальное значение 100000000
		/// </param>
		/// <param name = "userId">
		/// Идентификатор пользователя, которого необходимо включить в беседу. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.addChatUser
		/// </remarks>
		bool AddChatUser(long chatId, long userId);

		/// <summary>
		/// Позволяет разрешить отправку сообщений от сообщества текущему пользователю.
		/// </summary>
		/// <param name = "groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// </param>
		/// <param name = "key">
		/// Произвольная строка. Этот параметр можно использовать для идентификации пользователя.
		/// Его значение будет возвращено в событии message_allow Callback API. строка
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.allowMessagesFromGroup
		/// </remarks>
		bool AllowMessagesFromGroup(long groupId, string key);

		/// <summary>
		/// Создаёт беседу с несколькими участниками.
		/// </summary>
		/// <param name = "title">
		/// Название беседы. строка
		/// </param>
		/// <param name = "userIds">
		/// Идентификаторы пользователей, которых нужно включить в мультидиалог.
		/// Должны быть в друзьях у текущего пользователя. список положительных чисел, разделенных запятыми
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает  идентификатор созданного чата (chat_id).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.createChat
		/// </remarks>
		long CreateChat(IEnumerable<ulong> userIds, [NotNull] string title);

		/// <summary>
		/// Удаляет сообщение.
		/// </summary>
		/// <param name = "messageIds">
		/// Список идентификаторов сообщений, разделённых через запятую. список положительных чисел, разделенных запятыми
		/// </param>
		/// <param name = "spam">
		/// Пометить сообщения как спам. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <param name = "deleteForAll">
		/// 1 — если сообщение нужно удалить для получателей (если с момента отправки сообщения прошло не более 24 часов ).
		/// флаг, может принимать значения 1 или 0, по умолчанию
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 для каждого удаленного сообщения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.delete
		/// </remarks>
		IDictionary<ulong, bool> Delete([NotNull] IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null,
										bool? deleteForAll = null);

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
		Chat DeleteChatPhoto(out ulong messageId, ulong chatId);

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
		bool DenyMessagesFromGroup(long groupId);

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
		bool EditChat(long chatId
					, [NotNull] string title);

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
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		MessagesGetObject Get(MessagesGetParams @params);

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
		VkCollection<Message> GetById([NotNull] IEnumerable<ulong> messageIds
									, uint? previewLength = null);

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
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		SearchDialogsResponse SearchDialogs(string query, ProfileFields fields = null, uint? limit = null);

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
		VkCollection<Message> Search(MessagesSearchParams @params);

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
		long Send(MessagesSendParams @params);

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
		ReadOnlyCollection<MessagesSendResult> SendToUserIds(MessagesSendParams @params);

		/// <summary>
		/// Восстанавливает удаленное сообщение.
		/// </summary>
		/// <param name="messageId"> Идентификатор сообщения, которое нужно восстановить. </param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.restore
		/// </remarks>
		bool Restore(ulong messageId);

		/// <summary>
		/// Помечает сообщения как прочитанные.
		/// </summary>
		/// <param name="peerId">
		/// Идентификатор чата или пользователя, если это диалог.
		/// строка (Строка).
		/// </param>
		/// <param name="startMessageId">
		/// При передаче этого параметра будут помечены как прочитанные все сообщения,
		/// начиная с
		/// данного. положительное число (Положительное число).
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsRead
		/// </remarks>
		bool MarkAsRead(string peerId, long? startMessageId = null, long? groupId = null);

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
		bool SetActivity(long userId, long? peerId = null, string type = "typing");

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
		LastActivity GetLastActivity(long userId);

		/// <summary>
		/// Gets the chat.
		/// </summary>
		/// <param name="chatId"> The chat identifier. </param>
		/// <param name="fields"> The fields. </param>
		/// <param name="nameCase"> The name case. </param>
		/// <returns>
		/// После успешного выполнения возвращает объект (или список объектов)
		/// мультидиалога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/messages.getChat
		/// </remarks>
		Chat GetChat(long chatId, ProfileFields fields = null, NameCase nameCase = null);

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
		ReadOnlyCollection<Chat> GetChat(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null);

		/// <summary>
		/// Получает данные для превью чата с приглашением по ссылке.
		/// </summary>
		/// <param name="link"> Ссылка-приглашение. </param>
		/// <param name="fields"> Список полей профилей, данные о которых нужно получить. </param>
		/// <returns> Возвращает объект представляющий описание чата </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/messages.getChatPreview
		/// </remarks>
		ChatPreview GetChatPreview(string link, ProfileFields fields);

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
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		ReadOnlyCollection<User> GetChatUsers(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase);

		/// <summary>
		/// Возвращает список диалогов аккаунта
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns> В случае успеха возвращает список диалогов пользователя </returns>
		[Obsolete("Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования.")]
		MessagesGetObject GetDialogs(MessagesDialogsGetParams @params);

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
		MessageGetHistoryObject GetHistory(MessagesGetHistoryParams @params);

		/// <summary>
		/// Исключает из мультидиалога пользователя, если текущий пользователь был создателем беседы либо пригласил исключаемого пользователя.
		/// </summary>
		/// <param name = "chatId">
		/// Идентификатор беседы. положительное число, обязательный параметр, максимальное значение 100000000
		/// </param>
		/// <param name = "userId">
		/// Идентификатор пользователя, которого необходимо исключить из беседы. Может быть меньше нуля в случае, если пользователь приглашён по email. целое число
		/// </param>
		/// <param name = "memberId">
		/// Идентификатор участника, которого необходимо исключить из беседы. Для сообществ — идентификатор сообщества со знаком «минус». целое число, доступен начиная с версии 5.81
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.removeChatUser
		/// </remarks>
		bool RemoveChatUser(ulong chatId, long? userId = null, long? memberId = null);

		/// <summary>
		/// Возвращает данные, необходимые для подключения к Long Poll серверу.
		/// Long Poll подключение позволит Вам моментально узнавать о приходе новых
		/// сообщений и других событий.
		/// </summary>
		/// <param name="lpVersion">
		/// Версия для подключения к Long Poll. Актуальная версия:
		/// 2.
		/// </param>
		/// <param name="needPts">
		/// <c> true </c> — возвращать поле pts, необходимое для работы метода
		/// messages.getLongPollHistory
		/// </param>
		/// <param name="groupId">
		/// Айди группы, от которой получать данные
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
		LongPollServerResponse GetLongPollServer(bool needPts = false, uint lpVersion = 2, ulong? groupId = null);

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
		LongPollHistoryResponse GetLongPollHistory(MessagesGetLongPollHistoryParams @params);

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
		long SetChatPhoto(out long messageId, string file);

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
		ReadOnlyCollection<long> MarkAsImportant(IEnumerable<long> messageIds, bool important = true);

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
		long SendSticker(MessagesSendStickerParams @params);

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
		ReadOnlyCollection<HistoryAttachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params, out string nextFrom);

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
		string GetInviteLink(ulong peerId, bool reset);

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
		bool IsMessagesFromGroupAllowed(ulong groupId, ulong userId);

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
		long JoinChatByInviteLink(string link);

		/// <summary>
		/// Помечает беседу как отвеченную либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор беседы </param>
		/// <param name="answered"> флаг, может принимать значения <c>true</c> или <c>false</c>, по умолчанию <c>true</c> </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsAnsweredConversation
		/// </remarks>
		bool MarkAsAnsweredConversation(long peerId, bool answered = true);

		/// <summary>
		/// Помечает беседу как важную либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор беседы</param>
		/// <param name="important">
		/// <c> true </c>, если сообщения необходимо пометить, как важные;
		/// <c> false </c>, если необходимо снять пометку. положительное число (Положительное число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.markAsImportantConversation
		/// </remarks>
		bool MarkAsImportantConversation(long peerId, bool important = true);

		/// <summary>
		/// Редактирует сообщение.
		/// </summary>
		/// <param name="params"> параметры запроса </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		bool Edit(MessageEditParams @params);

		/// <summary>
		/// Удаляет личные сообщения в беседе.
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
		/// <param name="groupId">
		/// Идентификатор группы
		/// </param>
		/// <returns> После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.deleteConversation
		/// </remarks>
		bool DeleteConversation(long? userId, long? peerId = null, uint? offset = null, uint? count = null, long? groupId = null);

		/// <summary>
		/// Позволяет получить беседу по её идентификатору.
		/// </summary>
		/// <param name = "peerIds">
		/// Идентификаторы назначений, разделённые запятой.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// список целых чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <param name = "fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <returns>
		/// Возвращает общее число результатов в поле count (integer) и массив объектов бесед в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getConversationsById
		/// </remarks>
		ConversationResultObject GetConversationsById(IEnumerable<long> peerIds, IEnumerable<string> fields, bool? extended = null,
													ulong? groupId = null);

		/// <summary>
		/// Возвращает список бесед пользователя.
		/// </summary>
		/// <param name = "getConversationsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// count
		/// integerчисло результатов. items
		/// array беседы. Массив объектов, каждый из которых содержит поля:
		/// conversation (object) — объект беседы.
		/// last_message (object) — объект, описывающий последнее сообщение в беседе. unread_count
		/// integer число непрочитанных бесед. profiles
		/// array массив объектов пользователей. groups
		/// array массив объектов сообществ.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getConversations
		/// </remarks>
		GetConversationsResult GetConversations(GetConversationsParams getConversationsParams);

		/// <summary>
		/// Позволяет получить список участников беседы.
		/// </summary>
		/// <param name = "peerId">
		/// Идентификатор назначения.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name = "fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <returns>
		/// Возвращает объет, который содержит следующие поля:
		/// count
		/// integerчисло участников беседы. items
		/// arrayучастники беседы. Массив объектов, каждый из которых содержит поля:
		/// member_id (integer) — идентификатор участника беседы;
		/// invited_by (integer) — идентификатор пользователя, который пригласил участника;
		/// join_date (integer) — дата добавления в беседу;
		/// is_admin (boolean) — является ли пользователь администратором. profiles
		/// arrayмассив объектов пользователей. groups
		/// arrayмассив объектов сообществ.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getConversationMembers
		/// </remarks>
		GetConversationMembersResult GetConversationMembers(long peerId, IEnumerable<string> fields, ulong? groupId = null);

		/// <summary>
		/// Возвращает сообщения по их идентификаторам в рамках беседы.
		/// </summary>
		/// <param name = "peerId">
		/// Идентификаторы назначений, разделённые запятой.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name = "conversationMessageIds">
		/// Идентификаторы сообщений. Максимум 100 идентификаторов. список положительных чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <param name = "fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в поле count и массив объектов, описывающих  сообщения, в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getByConversationMessageId
		/// </remarks>
		GetByConversationMessageIdResult GetByConversationMessageId(long peerId, IEnumerable<ulong> conversationMessageIds,
																	IEnumerable<string> fields,
																	bool? extended = null, ulong? groupId = null);

		/// <summary>
		/// Позволяет искать диалоги.
		/// </summary>
		/// <param name = "q">
		/// Поисковой запрос. строка
		/// </param>
		/// <param name = "fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name = "count">
		/// Максимальное число результатов для получения. положительное число, по умолчанию 20
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <returns>
		/// Возвращает общее число результатов в поле count (integer) и массив объектов диалогов в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.searchConversations
		/// </remarks>
		SearchConversationsResult SearchConversations(string q, IEnumerable<string> fields, ulong? count = null, bool? extended = null,
													ulong? groupId = null);

		/// <summary>
		/// Закрепляет сообщение.
		/// </summary>
		/// <param name = "peerId">
		/// Идентификатор назначения.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name = "messageId">
		/// Идентификатор сообщения, которое нужно закрепить. положительное число
		/// </param>
		/// <returns>
		/// Возвращает объект закрепленного сообщения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.pin
		/// </remarks>
		PinnedMessage Pin(long peerId, ulong? messageId = null);

		/// <summary>
		/// Открепляет сообщение.
		/// </summary>
		/// <param name = "peerId">
		/// Идентификатор назначения.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.unpin
		/// </remarks>
		bool Unpin(long peerId, ulong? groupId = null);

	#region Obsoleted

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
		[Obsolete(
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте DeleteConversation")]
		bool DeleteDialog(long? userId, long? peerId = null, uint? offset = null, uint? count = null);

		/// <summary>
		/// Помечает диалог как отвеченный либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор диалога </param>
		/// <param name="answered"> флаг, может принимать значения 1 или 0, по умолчанию 1 </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsAnsweredDialog
		/// </remarks>
		[Obsolete(
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте MarkAsAnsweredConversation")]
		bool MarkAsAnsweredDialog(long peerId, bool answered = true);

		/// <summary>
		/// Помечает диалог как важный либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор диалога </param>
		/// <param name="important">
		/// <c> true </c>, если сообщения необходимо пометить, как важные;
		/// <c> 0 </c>, если необходимо снять пометку.положительное число (Положительное
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.markAsImportantDialog
		/// </remarks>
		[Obsolete(
			"Данный метод устарел и может быть отключён через некоторое время, пожалуйста, избегайте его использования. Используйте MarkAsImportantConversation")]
		bool MarkAsImportantDialog(long peerId, bool important = true);

	#endregion
	}
}