using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
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
	/// <summary>
	/// Методы для работы с личными сообщениями. Для моментального
	/// получения входящих сообщений используйте LongPoll сервер.
	/// </summary>
	public interface IMessagesCategoryAsync
	{
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
		Task<bool> AddChatUserAsync(long chatId, long userId);

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
		Task<bool> AllowMessagesFromGroupAsync(long groupId, string key);

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
		Task<long> CreateChatAsync(IEnumerable<ulong> userIds, [NotNull] string title);

		/// <summary>
		/// Удаляет сообщение.
		/// </summary>
		/// <param name="messageIds">
		/// Список идентификаторов сообщений.
		/// </param>
		/// <param name="spam">
		/// Пометить сообщения как спам. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <param name="deleteForAll">
		/// 1 — если сообщение нужно удалить для получателей (если с момента отправки
		/// сообщения прошло не более 24 часов ). флаг, может принимать значения 1 или 0,
		/// по умолчанию
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 для каждого удаленного сообщения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.delete
		/// </remarks>
		Task<IDictionary<ulong, bool>> DeleteAsync([NotNull] IEnumerable<ulong> messageIds, bool? spam = null, ulong? groupId = null,
													bool? deleteForAll = null);

		/// <summary>
		/// Удаляет сообщение в беседе.
		/// </summary>
		/// <param name="conversationMessageIds">
		/// Список идентификаторов сообщений.
		/// </param>
		/// <param name="peerId">
		/// Идентификатор назначения.
		/// </param>
		/// <param name="spam">
		/// Пометить сообщения как спам. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <param name="deleteForAll">
		/// 1 — если сообщение нужно удалить для получателей (если с момента отправки
		/// сообщения прошло не более 24 часов ). флаг, может принимать значения 1 или 0,
		/// по умолчанию
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 для каждого удаленного сообщения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.delete
		/// </remarks>
		Task<IDictionary<ulong, bool>> DeleteAsync([NotNull] IEnumerable<ulong> conversationMessageIds, ulong peerId, bool? spam = null,
													ulong? groupId = null,
													bool? deleteForAll = null);

		/// <summary>
		/// Позволяет удалить фотографию мультидиалога.
		/// </summary>
		/// <param name="chatId">
		/// Идентификатор беседы. положительное число, обязательный параметр, максимальное
		/// значение 100000000
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// message_id — идентификатор отправленного системного сообщения;
		/// chat — объект мультидиалога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.deleteChatPhoto
		/// </remarks>
		Task<Chat> DeleteChatPhotoAsync(ulong chatId, ulong? groupId = null);

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
		Task<bool> DenyMessagesFromGroupAsync(long groupId);

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
		Task<bool> EditChatAsync(long chatId
								, [NotNull] string title);

		/// <summary>
		/// Возвращает сообщения по их идентификаторам.
		/// </summary>
		/// <param name="messageIds">
		/// Идентификаторы сообщений. Максимум 100 идентификаторов. список положительных
		/// чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей для пользователей и сообществ. список слов,
		/// разделенных через запятую
		/// </param>
		/// <param name="previewLength">
		/// Количество символов, по которому нужно обрезать сообщение. Укажите 0, если Вы
		/// не хотите обрезать сообщение. (по умолчанию сообщения не обрезаются).
		/// положительное число, по умолчанию 0
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в
		/// поле count и массив объектов, описывающих  сообщения, в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getById
		/// </remarks>
		Task<VkCollection<Message>> GetByIdAsync([NotNull] IEnumerable<ulong> messageIds, IEnumerable<string> fields,
												ulong? previewLength = null, bool? extended = null,
												ulong? groupId = null);

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
		Task<MessageSearchResult> SearchAsync(MessagesSearchParams @params);

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
		Task<long> SendAsync(MessagesSendParams @params);

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
		Task<ReadOnlyCollection<MessagesSendResult>> SendToUserIdsAsync(MessagesSendParams @params);

		/// <summary>
		/// Восстанавливает удаленное сообщение.
		/// </summary>
		/// <param name="messageId">
		/// Идентификатор сообщения, которое нужно восстановить.
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской,
		/// содержащей Settings.Messages
		/// Страница документации ВКонтакте http://vk.com/dev/messages.restore
		/// </remarks>
		Task<bool> RestoreAsync(ulong messageId, ulong? groupId = null);

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
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя).
		/// </param>
		/// <param name="markConversationAsRead">Пометить обсуждение как прочитанное</param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.markAsRead
		/// </remarks>
		Task<bool> MarkAsReadAsync(string peerId, long? startMessageId = null, long? groupId = null, bool? markConversationAsRead = null);

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
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя).
		/// </param>
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
		Task<bool> SetActivityAsync(string userId, MessageActivityType type, long? peerId = null, ulong? groupId = null);

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
		Task<LastActivity> GetLastActivityAsync(long userId);

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
		Task<Chat> GetChatAsync(long chatId, ProfileFields fields = null, NameCase nameCase = null);

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
		Task<ReadOnlyCollection<Chat>> GetChatAsync(IEnumerable<long> chatIds, ProfileFields fields = null, NameCase nameCase = null);

		/// <summary>
		/// Получает данные для превью чата с приглашением по ссылке.
		/// </summary>
		/// <param name="link"> Ссылка-приглашение. </param>
		/// <param name="fields"> Список полей профилей, данные о которых нужно получить. </param>
		/// <returns> Возвращает объект представляющий описание чата </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/messages.getChatPreview
		/// </remarks>
		Task<ChatPreview> GetChatPreviewAsync(string link, ProfileFields fields);

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
		Task<MessageGetHistoryObject> GetHistoryAsync(MessagesGetHistoryParams @params);

		/// <summary>
		/// Исключает из мультидиалога пользователя, если текущий пользователь был
		/// создателем беседы либо пригласил исключаемого пользователя.
		/// </summary>
		/// <param name="chatId">
		/// Идентификатор беседы. положительное число, обязательный параметр, максимальное
		/// значение 100000000
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, которого необходимо исключить из беседы. Может быть
		/// меньше нуля в случае, если пользователь приглашён по email. целое число
		/// </param>
		/// <param name="memberId">
		/// Идентификатор участника, которого необходимо исключить из беседы. Для сообществ
		/// — идентификатор сообщества со знаком «минус». целое число, доступен начиная с
		/// версии 5.81
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.removeChatUser
		/// </remarks>
		Task<bool> RemoveChatUserAsync(ulong chatId, long? userId = null, long? memberId = null);

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
		Task<LongPollServerResponse> GetLongPollServerAsync(bool needPts = false, uint lpVersion = 2, ulong? groupId = null);

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
		Task<LongPollHistoryResponse> GetLongPollHistoryAsync(MessagesGetLongPollHistoryParams @params);

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
		Task<ReadOnlyCollection<long>> MarkAsImportantAsync([NotNull] IEnumerable<long> messageIds, bool important = true);

		/// <summary>
		/// Отправляет стикер.
		/// </summary>
		/// <param name="parameters"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор отправленного сообщения
		/// (mid).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.sendSticker
		/// </remarks>
		Task<long> SendStickerAsync(MessagesSendStickerParams parameters);

		/// <summary>
		/// Возвращает материалы диалога или беседы..
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
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
		Task<ReadOnlyCollection<HistoryAttachment>> GetHistoryAttachmentsAsync(MessagesGetHistoryAttachmentsParams @params);

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
		Task<string> GetInviteLinkAsync(ulong peerId, bool reset);

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
		Task<bool> IsMessagesFromGroupAllowedAsync(ulong groupId, ulong userId);

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
		Task<long> JoinChatByInviteLinkAsync(string link);

		/// <summary>
		/// Помечает беседу как отвеченную либо снимает отметку.
		/// </summary>
		/// <param name="peerId">
		/// Идентификатор беседы целое число, обязательный параметр
		/// </param>
		/// <param name="answered">
		/// <c> true </c> - беседа отмечена отвеченной, <c> false </c> - неотвеченной флаг,
		/// может принимать значения <c> true </c> или <c> false </c>, по умолчанию
		/// <c> true </c>
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.markAsAnsweredConversation
		/// </remarks>
		Task<bool> MarkAsAnsweredConversationAsync(long peerId, bool? answered = null, ulong? groupId = null);

		/// <summary>
		/// Помечает беседу как важную либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор беседы </param>
		/// <param name="important">
		/// <c> true </c>, если сообщения необходимо пометить, как важные;
		/// <c> false </c>, если необходимо снять пометку. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.markAsImportantConversation
		/// </remarks>
		Task<bool> MarkAsImportantConversationAsync(long peerId, bool? important = null, ulong? groupId = null);

		/// <summary>
		/// Редактирует сообщение.
		/// </summary>
		/// <param name="params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.edit
		/// </remarks>
		Task<bool> EditAsync(MessageEditParams @params);

		/// <summary>
		/// Удаляет беседу.
		/// </summary>
		/// <param name = "userId">
		/// Идентификатор пользователя. Если требуется очистить историю беседы, используйте peer_id. строка
		/// </param>
		/// <param name = "peerId">
		/// Идентификатор назначения.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, доступен начиная с версии 5.38
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает поле last_deleted_id, содержащее идентификатор последнего удалённого сообщения в переписке.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.deleteConversation
		/// </remarks>
		Task<ulong> DeleteConversationAsync(long? userId, long? peerId = null, ulong? groupId = null);

		/// <summary>
		/// Позволяет получить беседу по её идентификатору.
		/// </summary>
		/// <param name="peerIds">
		/// Идентификаторы назначений, разделённые запятой.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// список целых чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <param name="fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в
		/// ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// Возвращает общее число результатов в поле count (integer) и массив объектов
		/// бесед в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getConversationsById
		/// </remarks>
		Task<ConversationResult> GetConversationsByIdAsync(IEnumerable<long> peerIds, IEnumerable<string> fields = null,
															bool? extended = null, ulong? groupId = null);

		/// <summary>
		/// Возвращает список бесед пользователя.
		/// </summary>
		/// <param name="getConversationsParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// count
		/// integerчисло результатов. items
		/// arrayбеседы. Массив объектов, каждый из которых содержит поля:
		/// conversation (object) — объект беседы.
		/// last_message (object) — объект, описывающий последнее сообщение в беседе.
		/// unread_count
		/// integerчисло непрочитанных бесед. profiles
		/// arrayмассив объектов пользователей. groups
		/// arrayмассив объектов сообществ.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getConversations
		/// </remarks>
		Task<GetConversationsResult> GetConversationsAsync(GetConversationsParams getConversationsParams);

		/// <summary>
		/// Позволяет получить список участников беседы.
		/// </summary>
		/// <param name="peerId">
		/// Идентификатор назначения.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name="fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в
		/// ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
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
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.getConversationMembers
		/// </remarks>
		Task<GetConversationMembersResult> GetConversationMembersAsync(long peerId, IEnumerable<string> fields = null,
																		ulong? groupId = null);

		/// <summary>
		/// Возвращает сообщения по их идентификаторам в рамках беседы.
		/// </summary>
		/// <param name="peerId">
		/// Идентификаторы назначений, разделённые запятой.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name="conversationMessageIds">
		/// Идентификаторы сообщений. Максимум 100 идентификаторов. список положительных
		/// чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <param name="fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в
		/// ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в
		/// поле count и массив объектов, описывающих  сообщения, в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.getByConversationMessageId
		/// </remarks>
		Task<GetByConversationMessageIdResult> GetByConversationMessageIdAsync(
			long peerId, [NotNull] IEnumerable<ulong> conversationMessageIds,
			IEnumerable<string> fields, bool? extended = null,
			ulong? groupId = null);

		/// <summary>
		/// Позволяет искать диалоги.
		/// </summary>
		/// <param name="q">
		/// Поисковой запрос. строка
		/// </param>
		/// <param name="fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть в
		/// ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name="count">
		/// Максимальное число результатов для получения. положительное число, по умолчанию
		/// 20
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать дополнительные поля. флаг, может принимать значения 1 или 0
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// Возвращает общее число результатов в поле count (integer) и массив объектов
		/// диалогов в поле items.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.searchConversations
		/// </remarks>
		Task<SearchConversationsResult> SearchConversationsAsync(string q, IEnumerable<string> fields, ulong? count = null,
																bool? extended = null, ulong? groupId = null);

		/// <summary>
		/// Закрепляет сообщение.
		/// </summary>
		/// <param name="peerId">
		/// Идентификатор назначения.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name="messageId">
		/// Идентификатор сообщения, которое нужно закрепить. положительное число
		/// </param>
		/// <param name="conversationMessageId"></param>
		/// <returns>
		/// Возвращает объект закрепленного сообщения.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.pin
		/// </remarks>
		Task<PinnedMessage> PinAsync(long peerId, ulong? messageId = null, ulong? conversationMessageId = null);

		/// <summary>
		/// Открепляет сообщение.
		/// </summary>
		/// <param name="peerId">
		/// Идентификатор назначения.
		/// Для пользователя:
		/// id  пользователя.
		/// Для групповой беседы:
		/// 2000000000 + id беседы.
		/// Для сообщества:
		/// -id сообщества.
		/// целое число, обязательный параметр
		/// </param>
		/// <param name="groupId">
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа
		/// пользователя). положительное число
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.unpin
		/// </remarks>
		Task<bool> UnpinAsync(long peerId, ulong? groupId = null);

		/// <summary>
		/// Возвращает список важных сообщений пользователя.
		/// </summary>
		/// <param name="getImportantMessagesParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getImportantMessages
		/// </remarks>
		Task<GetImportantMessagesResult> GetImportantMessagesAsync(GetImportantMessagesParams getImportantMessagesParams);

		/// <summary>
		/// Возвращает информацию о недавних звонках.
		/// </summary>
		/// <param name="fields">
		/// Список дополнительных полей для пользователей и сообществ. список слов,
		/// разделенных через запятую
		/// </param>
		/// <param name="count">
		/// Максимальное число результатов, которые нужно получить. положительное число, по
		/// умолчанию 40, максимальное значение 500
		/// </param>
		/// <param name="startMessageId">
		/// Идентификатор сообщения, начиная с которого нужно возвращать звонки.
		/// положительное число
		/// </param>
		/// <param name="extended">
		/// 1 — возвращать дополнительные поля для пользователей и сообществ. флаг, может
		/// принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// count
		/// integerчисло результатов. items
		/// arrayбеседы. Массив объектов, каждый из которых содержит поля:
		/// call (object) — объект со следующими полями
		/// initiator_id (integer) — инициатор звонка.
		/// receiver_id (integer) — получатель звонка.
		/// state (string) — состояние.
		/// canceled_by_initiator — сброшен инициатором
		/// canceled_by_receiver — сброшен получателем
		/// reached — состоялся
		/// duration (integer) — длительность звонка в секундах.
		/// message_id  (integer) — индетификатор сообщения profiles
		/// arrayмассив объектов пользователей. groups
		/// arrayмассив объектов сообществ.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getRecentCalls
		/// </remarks>
		Task<GetRecentCallsResult> GetRecentCallsAsync(IEnumerable<string> fields, ulong? count = null, ulong? startMessageId = null,
														bool? extended = null);

		/// <summary>
		/// Отправляет событие с действием, которое произойдет при нажатии на callback-кнопку.
		/// </summary>
		/// <param name="eventId">случайная строка, которая возвращается в событии message_event</param>
		/// <param name="userId">идентификатор пользователя</param>
		/// <param name="peerId">идентификатор диалога со стороны сообщества</param>
		/// <param name="eventData">объект действия, которое должно произойти после нажатия на кнопку</param>
		/// <returns></returns>
		Task<bool> SendMessageEventAnswerAsync(string eventId, long userId, long peerId, EventData eventData = null);

		/// <summary>
		/// Метод отдает пользователей, которые подписались на определенные интенты.
		/// https://vk.com/dev/bots_reply_rules
		/// </summary>
		/// <param name = "getIntentUsersParams">
		/// Входные параметры запроса.
		/// </param>
		/// <param name="token">Токен отмены запроса</param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в поле count (integer) и массив идентификаторов пользователей в поле items ([integer]).
		/// Если указан параметр extended:
		/// profiles
		/// Возвращает объект, который содержит следующие поля:
		/// count
		/// integerчисло результатов. items
		/// arrayмассив идентификаторов пользователей в поле items ([integer]). profiles
		/// arrayмассив объектов пользователей. (Если был указан параметр extended)
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/messages.getIntentUsers
		/// </remarks>
		Task<GetIntentUsersResult> GetIntentUsersAsync(MessagesGetIntentUsersParams getIntentUsersParams, CancellationToken token);

		/// <summary>
		/// Помечает диалог пользователя непрочитанным.
		/// </summary>
		/// <param name="peerId">
		/// Идентификатор назначения. Для групповой беседы: 2000000000 + id беседы. Для
		/// сообщества: -id сообщества.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает true.
		/// </returns>
		Task<bool> MarkAsUnreadConversationAsync(long peerId);

	#region Obsoleted

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
		[Obsolete(ObsoleteText.MessageSearchDialogs)]
		Task<SearchDialogsResponse> SearchDialogsAsync(string query, ProfileFields fields = null, uint? limit = null);

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
		[Obsolete(ObsoleteText.MessageDeleteDialog, true)]
		Task<ulong> DeleteDialogAsync(long? userId, long? peerId = null, uint? offset = null, uint? count = null);

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
		[Obsolete(ObsoleteText.MessageMarkAsAnsweredDialog, true)]
		Task<bool> MarkAsAnsweredDialogAsync(long peerId, bool answered = true);

		/// <summary>
		/// Помечает диалог как важный либо снимает отметку.
		/// </summary>
		/// <param name="peerId"> Идентификатор диалога </param>
		/// <param name="important">
		/// <c> true </c>, если сообщения необходимо пометить, как важные;
		/// <c> false </c>, если необходимо снять пометку.положительное число
		/// (Положительное
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// http://vk.com/dev/messages.markAsImportantDialog
		/// </remarks>
		[Obsolete(ObsoleteText.MessageMarkAsImportantDialog, true)]
		Task<bool> MarkAsImportantDialogAsync(long peerId, bool important = true);

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
		[Obsolete(ObsoleteText.MessageGet)]
		Task<MessagesGetObject> GetAsync(MessagesGetParams @params);

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
		[Obsolete(ObsoleteText.MessageGetChatUsers)]
		Task<ReadOnlyCollection<User>> GetChatUsersAsync(IEnumerable<long> chatIds, UsersFields fields, NameCase nameCase);

		/// <summary>
		/// Возвращает список диалогов аккаунта
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns> В случае успеха возвращает список диалогов пользователя </returns>
		[Obsolete(ObsoleteText.MessageGet)]
		Task<MessagesGetObject> GetDialogsAsync(MessagesDialogsGetParams @params);

	#endregion
	}
}