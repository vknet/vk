using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Notifications;
using VkNet.Model.Results.Notifications;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с Уведомлениями
/// </summary>
public interface INotificationsCategoryAsync
{
	/// <summary>
	/// Возвращает список оповещений об ответах других пользователей на записи текущего
	/// пользователя.
	/// </summary>
	/// <param name="count">
	/// Указывает, какое максимальное число оповещений следует возвращать.
	/// положительное число, по умолчанию 30,
	/// максимальное значение 100
	/// </param>
	/// <param name="startFrom">
	/// Строковый идентификатор оповещения, полученного последним в предыдущем вызове
	/// (см. описание поля next_from в
	/// результате). строка, доступен начиная с версии 5.27
	/// </param>
	/// <param name="filters">
	/// Перечисленные через запятую типы оповещений, которые необходимо получить.
	/// Возможные значения:
	/// wall — записи на стене пользователя;
	/// mentions — упоминания в записях на стене, в комментариях или в обсуждениях;
	/// comments — комментарии к записям на стене, фотографиям и видеозаписям;
	/// likes — отметки «Мне нравится»;
	/// reposts — скопированные у текущего пользователя записи на стене, фотографии и
	/// видеозаписи;
	/// followers — новые подписчики;
	/// friends — принятые заявки в друзья.
	/// Если параметр не задан, то будут получены все возможные типы оповещений. список
	/// слов, разделенных через запятую
	/// </param>
	/// <param name="startTime">
	/// Время в формате Unixtime, начиная с которого следует получить оповещения для
	/// текущего пользователя. Если параметр
	/// не задан, то он считается равным значению времени, которое было сутки назад.
	/// целое число
	/// </param>
	/// <param name="endTime">
	/// Время в формате Unixtime, до которого следует получить оповещения для текущего
	/// пользователя. Если параметр не
	/// задан, то он считается равным текущему времени. целое число
	/// </param>
	/// <param name="token">Токен отмены запроса</param>
	/// <returns>
	/// После успешного выполнения возвращает объект, содержащий поля:
	/// items
	/// arrayмассив оповещений для текущего пользователя. profiles
	/// arrayинформация о пользователях, которые находятся в списке оповещений. groups
	/// arrayинформация о сообществах, которые находятся в списке оповещений.
	/// last_viewed
	/// integerвремя последнего просмотра пользователем раздела оповещений в формате
	/// Unixtime.
	/// Описание поля items Поле items содержит массив объектов, каждый из которых
	/// соответствует одному оповещению. Каждый
	/// из объектов содержит поля: type
	/// stringтип оповещения. Подробнее см. ниже. date
	/// integerвремя появления ответа в формате Unixtime. parent
	/// object (отсутствует, если type= follow, mention или wall)информация о
	/// материале, к которому появился ответ (запись
	/// на стене, комментарий, фотографию, видеозапись или обсуждение). Подробнее см. в
	/// описании поля type ниже. feedback
	/// [object,array]объект (или массив объектов, если type равно follow, like_* или
	/// copy_*), описывающий поступивший
	/// ответ. Оповещения о новых подписчиках, пометках «Мне нравится» и скопированных
	/// записях могут быть сгруппированы в
	/// виде массива. reply
	/// objectобъект, описывающий комментарий текущего пользователя, отправленный в
	/// ответ на данное оповещение.
	/// Отсутствует, если пользователь ещё не давал ответа.
	/// Описание поля type Поле type описывает тип оповещения. От данного типа зависит
	/// наличие и содержание полей parent и
	/// feedback. В данный момент поддерживаются следующие типы оповещений:
	/// Значение type Тип поля parentТип поля feedbackОписание follow-user[]У
	/// пользователя появился один или несколько
	/// новых подписчиков. friend_accepted-user[]Заявка в друзья, отправленная
	/// пользователем, была принята.
	/// mention-postБыла создана запись на чужой стене, содержащая упоминание
	/// пользователя. mention_commentspostcommentБыл
	/// оставлен комментарий, содержащий упоминание пользователя. wall-postБыла
	/// добавлена запись на стене пользователя.
	/// wall_publish-postБыла опубликована новость, предложенная пользователем в
	/// публичной странице.
	/// comment_postpostcommentБыл добавлен новый комментарий к записи, созданной
	/// пользователем.
	/// comment_photophotocommentБыл добавлен новый комментарий к фотографии
	/// пользователя. comment_videovideocommentБыл
	/// добавлен новый комментарий к видеозаписи пользователя.
	/// reply_commentcommentcommentБыл добавлен новый ответ на
	/// комментарий пользователя. reply_comment_photocommentcommentБыл добавлен новый
	/// ответ на комментарий пользователя к
	/// фотографии. reply_comment_videocommentcommentБыл добавлен новый ответ на
	/// комментарий пользователя к видеозаписи.
	/// reply_comment_marketcommentcommentБыл добавлен новый ответ на комментарий
	/// пользователя к товару.
	/// reply_topictopiccommentБыл добавлен новый ответ пользователю в обсуждении.
	/// like_postpostuser[]У записи пользователя
	/// появилась одна или несколько новых отметок «Мне нравится».
	/// like_commentcommentuser[]У комментария пользователя
	/// появилась одна или несколько новых отметок «Мне нравится».
	/// like_photophotouser[]У фотографии пользователя появилась
	/// одна или несколько новых отметок «Мне нравится». like_videovideouser[]У
	/// видеозаписи пользователя появилась одна или
	/// несколько новых отметок «Мне нравится». like_comment_photocommentuser[]У
	/// комментария пользователя к фотографии
	/// появилась одна или несколько новых отметок «Мне нравится».
	/// like_comment_videocommentuser[]У комментария
	/// пользователя к видеозаписи появилась одна или несколько новых отметок «Мне
	/// нравится».
	/// like_comment_topiccommentuser[]У комментария пользователя в обсуждении
	/// появилась одна или несколько новых отметок
	/// «Мне нравится». copy_postpostcopy[]Один или несколько пользователей скопировали
	/// запись пользователя
	/// copy_photophotocopy[]Один или несколько пользователей скопировали фотографию
	/// пользователя.
	/// copy_videovideocopy[]Один или несколько пользователей скопировали видеозапись
	/// пользователя.
	/// mention_comment_photophotocommentПод фотографией был оставлен комментарий,
	/// содержащий упоминание пользователя.
	/// mention_comment_videovideocommentПод видео был оставлен комментарий, содержащий
	/// упоминание пользователя.
	/// Описание поля parent (post) Содержит информацию о записи на стене:
	/// id — идентификатор записи;
	/// to_id — идентификатор владельца записи;
	/// from_id — идентификатор пользователя, создавшего запись;
	/// date — время публикации записи в формате unixtime;
	/// text — текст записи;
	/// attachments — содержит массив объектов, которые присоединены к текущей записи
	/// (фотографии, ссылки и т.п.). Более
	/// подробная информация представлена на странице Описание поля attachments.
	/// geo — находится в записях со стен, в которых имеется информация о
	/// местоположении, содержит поля:
	/// place_id — идентификатор места;
	/// title — название места;
	/// type — тип места;
	/// country_id — идентификатор страны;
	/// city_id — идентификатор города;
	/// address — строка с указанием адреса места в городе;
	/// showmap — данный параметр указывается, если местоположение является
	/// прикреплённой картой.
	/// copy_owner_id — если запись является копией записи с чужой стены, то в поле
	/// содержится идентификатор владельца
	/// стены у которого была скопирована запись;
	/// copy_post_id — если запись является копией записи с чужой стены, то в поле
	/// содержится идентификатор скопированной
	/// записи на стене ее владельца
	/// Описание поля parent (comment) Содержит информацию о комментарии:
	/// id — идентификатор комментария;
	/// owner_id — идентификатор автора комментария;
	/// date — время публикации комментария в формате unixtime;
	/// text — текст комментария;
	/// post — запись, к которой оставлен комментарий (для типов reply_comment и
	/// like_comment);
	/// photo — фотография, к которой оставлен комментарий (для типов
	/// reply_comment_photo и like_comment_photo);
	/// video — видеозапись, к которой оставлен комментарий (для типов
	/// reply_comment_video и like_comment_video);
	/// topic — обсуждение, в котором оставлен комментарий (для типа
	/// like_comment_topic).
	/// Описание поля parent (photo) Содержит информацию о фотографии:
	/// id — идентификатор фотографии;
	/// owner_id — идентификатор владельца фотографии;
	/// aid — идентификатор альбома фотографии;
	/// src — ссылка на изображение в разрешении 130 пикселей по большей стороне;
	/// src_big — ccылка на изображение в разрешении 604 пикселя по большей стороне;
	/// src_small — ссылка на изображение в разрешении 75 пикселей по большей стороне;
	/// text — текст описания фотографии;
	/// created — дата загрузки фотографии в формате unixtime.
	/// Описание поля parent (video) Содержит информацию о видеозаписи:
	/// id — идентификатор видеозаписи;
	/// owner_id — идентификатор владельца видеозаписи;
	/// title — название видеозаписи;
	/// description — описание видеозаписи;
	/// duration — продолжительность видеозаписи в секундах;
	/// link — ссылка на видео;
	/// image — ссылка на изображение в разрешении 320 пикселей в ширину;
	/// image_medium — ссылка на изображение в разрешении 160 пикселей в ширину;
	/// date — дата добавления видеозаписи в формате unixtime;
	/// views — количество просмотров;
	/// player — ссылка на встраиваемый i_frame-видеоплеер.
	/// Описание поля parent (topic) Содержит информацию о теме в обсуждениях
	/// сообщества:
	/// id — идентификатор темы;
	/// owner_id — идентификатор сообщества, содержащего тему в обсуждениях (со знаком
	/// "минус");
	/// title — заголовок темы;
	/// created — дата создания темы в формате unixtime;
	/// created_by — идентификатор пользователя, создавшего тему;
	/// updated — дата последнего сообщения в формате unixtime;
	/// updated_by — идентификатор пользователя, оставившего последнее сообщение;
	/// is_closed — 1, если тема является закрытой (в ней нельзя оставлять сообщения);
	/// is_fixed — 1, если тема является прилепленной (находится в начале списка тем);
	/// comments — число сообщений в теме.
	/// Описание поля feedback Cодержит информацию об оповещении:
	/// id (отсутствует, если type равно follow или like_*) — идентификатор
	/// записи-ответа;
	/// to_id — идентификатор владельца стены, на которой размещена запись;
	/// from_id — идентификатор автора ответа;
	/// text (отсутствует, если type равно follow, like_* или copy_*) — текст ответа;
	/// likes — находится в записях со стен и содержит информацию о числе людей,
	/// которым понравилась данная запись,
	/// содержит поля:
	/// count — число пользователей, которым понравилась запись,
	/// user_likes — наличие отметки «Мне нравится» от текущего пользователя
	/// (1 — есть, 0 — нет),
	/// can_like — информация о том, может ли текущий пользователь поставить отметку
	/// «Мне нравится»
	/// (1 — может, 0 — не может),
	/// can_publish — информация о том, может ли текущий пользователь сделать репост
	/// записи
	/// (1 — может, 0 — не может);
	/// В случае, если ответ является записью на стене (тип post в таблице выше), в
	/// объекте feedback также содержатся
	/// следующие поля:
	/// attachments — содержит массив объектов, которые присоединены к текущей записи
	/// (фотографии, ссылки и т.п.). Более
	/// подробная информация представлена на странице Описание поля attachments.
	/// geo — находится в записях со стен, в которых имеется информация о
	/// местоположении, содержит поля:
	/// place_id — идентификатор места;
	/// title — название места;
	/// type — тип места;
	/// country_id — идентификатор страны;
	/// city_id — идентификатор города;
	/// address — строка с указанием адреса места в городе;
	/// showmap — данный параметр указывается, если местоположение является
	/// прикреплённой картой.
	/// Описание поля reply Cодержит информацию об ответе пользователя на оповещение:
	/// id — идентификатор комментария;
	/// date — время публикации комментария в формате unixtime;
	/// text — текст комментария.
	/// Описание поля profiles Поле profiles содержит массив объектов user с
	/// информацией о данных пользователей, которые
	/// присутствуют в новостях. Каждый из объектов содержит следующие поля:
	/// uid — идентификатор пользователя;
	/// first_name — имя пользователя;
	/// last_name — фамилия пользователя;
	/// photo — адрес фотографии пользователя размером 50x50px;
	/// photo_medium_rec — адрес фотографии пользователя размером 100x100px;
	/// screen_name — короткий адрес страницы пользователя (например, andrew или
	/// id6492).
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.get
	/// </remarks>
	Task<NotificationGetResult> GetAsync(ulong? count = null,
										string startFrom = null,
										IEnumerable<string> filters = null,
										long? startTime = null,
										long? endTime = null,
										CancellationToken token = default);

	/// <summary>
	/// Сбрасывает счетчик непросмотренных оповещений об ответах других пользователей
	/// на записи текущего пользователя.
	/// </summary>
	/// <param name="token">Токен отмены запроса</param>
	/// <returns>
	/// Если у пользователя присутствовали непросмотренные ответы, возвращает 1 в
	/// случае успешного завершения. В противном
	/// случае возвращает 0.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.markAsViewed
	/// </remarks>
	Task<bool> MarkAsViewedAsync(CancellationToken token);

	/// <summary>
	/// Отправляет уведомление пользователю приложения VK Apps.
	/// </summary>
	/// <param name = "sendMessageParams">
	/// Входные параметры запроса.
	/// </param>
	/// <param name="token">Токен отмены запроса</param>
	/// <returns>
	/// После успешного выполнения возвращает массив объектов, каждый из которых содержит поля:
	/// user_id (integer) —  Идентификатор пользователя;
	/// status  (boolean)  —  true, если уведомление отправлено успешно. Иначе false.
	/// error (object) — в случае, если статус отправки имеет значение false, дополнительно вернётся объект ошибки, содержащий код ошибки в поле code (integer) и описание description (string).
	/// Возможные значения code:
	/// 1 —  уведомления приложения отключены;
	/// 2 — отправлено слишком много уведомлений за последний час;
	/// 3 — отправлено слишком много уведомлений за последние сутки;
	/// 4 —  приложение не установлено.
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте http://vk.com/dev/notifications.sendMessage
	/// </remarks>
	Task<IEnumerable<NotificationsSendMessageResult>> SendMessageAsync(NotificationsSendMessageParams sendMessageParams,
																		CancellationToken token);
}