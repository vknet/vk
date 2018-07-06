using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model.RequestParams.Stories;

namespace VkNet.Abstractions.Category
{
	/// <summary>
	/// Stories
	/// </summary>
	public interface IStoriesCategoryAsync
	{
		/// <summary>
		/// Позволяет скрыть из ленты новостей истории от выбранных источников.
		/// </summary>
		/// <param name = "ownersIds">
		/// Список идентификаторов источников. список целых чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.banOwner
		/// </remarks>
		Task<bool> BanOwnerAsync(IEnumerable<long> ownersIds);

		/// <summary>
		/// Удаляет историю.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца истории. целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр
		/// </param>
		/// <param name = "storyId">
		/// Идентификатор истории. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.delete
		/// </remarks>
		Task<bool> DeleteAsync(long ownerId, ulong storyId);

		/// <summary>
		/// Возвращает истории, доступные для текущего пользователя.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор пользователя, истории которого необходимо получить. целое число
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать в ответе дополнительную информацию о профилях пользователей. флаг, может принимать значения 1 или 0, по умолчанию 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число подборок в поле count и массив подборок историй  в поле items. Каждая подборка — массив историй от одного владельца.
		/// Если был задан параметр extended=1, дополнительно возвращает массив объектов пользователей в поле profiles (array) и сообществ в поле groups (array).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.get
		/// </remarks>
		Task<IEnumerable<object>> GetAsync(long? ownerId = null, bool? extended = null);

		/// <summary>
		/// Возвращает список источников историй, скрытых из ленты текущего пользователя.
		/// </summary>
		/// <param name = "fields">
		/// Дополнительные поля пользователей и сообществ, которые необходимо вернуть. список слов, разделенных через запятую
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать расширенную информацию о пользователях и сообществах. флаг, может принимать значения 1 или 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает общее количество скрытых источников в поле count (integer) и их идентификаторы в массиве items. Если extended = 1, items содержит два поля:
		/// profiles (array) — массив объектов, описывающих пользователей;
		/// groups (array) — массив объектов, описывающих сообщества.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getBanned
		/// </remarks>
		Task<IEnumerable<object>> GetBannedAsync(IEnumerable<string> fields, bool? extended = null);

		/// <summary>
		/// Возвращает информацию об истории по её идентификатору.
		/// </summary>
		/// <param name = "stories">
		/// Перечисленные через запятую идентификаторы, которые представляют собой идущие через знак подчеркивания идентификаторы владельцев историй и идентификаторы самих историй.
		/// Пример значения stories:
		/// 93388_21539,93388_20904 список слов, разделенных через запятую, обязательный параметр
		/// </param>
		/// <param name = "fields">
		/// Дополнительные поля профилей и сообществ, которые необходимо вернуть в ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать в ответе дополнительную информацию о пользователях. флаг, может принимать значения 1 или 0, по умолчанию 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число историй в поле count и массив объектов историй  в поле items.
		/// Если был задан параметр extended = 1, дополнительно возвращает массив объектов  пользователей в поле profiles и объектов сообществ в поле groups.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getById
		/// </remarks>
		Task<IEnumerable<object>> GetByIdAsync(IEnumerable<string> stories, IEnumerable<string> fields, bool? extended = null);

		/// <summary>
		/// Позволяет получить адрес для загрузки истории с фотографией.
		/// </summary>
		/// <param name = "getPhotoUploadServerParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// upload_url (string) — адрес сервера для загрузки файла;
		/// user_ids (array) — идентификаторы пользователей, которые могут видеть историю.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getPhotoUploadServer
		/// </remarks>
		Task<Uri> GetPhotoUploadServerAsync(GetPhotoUploadServerParams getPhotoUploadServerParams);

		/// <summary>
		/// Позволяет получить ответы на историю.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца истории. целое число, обязательный параметр
		/// </param>
		/// <param name = "storyId">
		/// Идентификатор истории. положительное число, обязательный параметр
		/// </param>
		/// <param name = "accessKey">
		/// Ключ доступа для приватного объекта. строка
		/// </param>
		/// <param name = "fields">
		/// Дополнительные поля профилей и сообществ, которые необходимо вернуть в ответе. список слов, разделенных через запятую
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать дополнительную информацию о профилях и сообществах. флаг, может принимать значения 1 или 0, по умолчанию
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число подборок в поле count и массив подборок историй  в поле items. Каждая подборка — массив историй от одного владельца.
		/// Если был задан параметр extended=1, дополнительно возвращает массив объектов пользователей в поле profiles (array) и сообществ в поле groups (array).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getReplies
		/// </remarks>
		Task<IEnumerable<object>> GetRepliesAsync(long ownerId, ulong storyId, string accessKey, IEnumerable<string> fields,
												bool? extended = null);

		/// <summary>
		/// Возвращает статистику истории.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца истории. целое число, обязательный параметр
		/// </param>
		/// <param name = "storyId">
		/// Идентификатор истории. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// views (object) — просмотры. Содержит поля:
		/// state (string) — доступность значения (on — доступно, off — недоступно);
		/// count (integer) — значение счётчика;
		/// replies  (object) — ответы на историю. Содержит поля:
		/// state (string) — доступность значения (on — доступно, off — недоступно);
		/// count (integer) — значение счётчика;
		/// answer (object) — число
		/// state (string) — доступность значения (on — доступно, off — недоступно);
		/// count (integer) — значение счётчика;
		/// shares  (object) — расшаривания истории. Содержит поля:
		/// state (string) — доступность значения (on — доступно, off — недоступно);
		/// count (integer) — значение счётчика;
		/// subscribers (object) — новые подписчики. Содержит поля:
		/// state (string) — доступность значения (on — доступно, off — недоступно);
		/// count (integer) — значение счётчика;
		/// bans  (object) — скрытия истории. Содержит поля:
		/// state (string) — доступность значения (on — доступно, off — недоступно);
		/// count (integer) — значение счётчика;
		/// open_link (object) — переходы по ссылке. Содержит поля:
		/// state (string) — доступность значения (on — доступно, hidden — недоступно);
		/// count (integer) — значение счётчика.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getStats
		/// </remarks>
		Task<object> GetStatsAsync(long ownerId, ulong storyId);

		/// <summary>
		/// Позволяет получить адрес для загрузки видеозаписи в историю.
		/// </summary>
		/// <param name = "getVideoUploadServerParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий следующие поля:
		/// upload_url (string) — адрес сервера для загрузки файла;
		/// user_ids (array) — идентификаторы пользователей, которые могут видеть историю.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getVideoUploadServer
		/// </remarks>
		Task<Uri> GetVideoUploadServerAsync(GetVideoUploadServerParams getVideoUploadServerParams);

		/// <summary>
		/// Возвращает список пользователей, просмотревших историю.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца истории. целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр
		/// </param>
		/// <param name = "storyId">
		/// Идентификатор истории. положительное число, обязательный параметр
		/// </param>
		/// <param name = "count">
		/// Максимальное число результатов в ответе. положительное число, по умолчанию 100
		/// </param>
		/// <param name = "offset">
		/// Сдвиг для получения определённого подмножества результатов. положительное число, по умолчанию 0
		/// </param>
		/// <param name = "extended">
		/// 1 — возвращать в ответе расширенную информацию о пользователях. флаг, может принимать значения 1 или 0, по умолчанию 0
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в поле count и идентификаторы пользователей в поле items (array). Если extended = 1, поле items (array) содержит массив объектов пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.getViewers
		/// </remarks>
		Task<IEnumerable<object>> GetViewersAsync(long ownerId, ulong storyId, ulong? count = null, ulong? offset = null,
												bool? extended = null);

		/// <summary>
		/// Скрывает все ответы автора за последние сутки на истории текущего пользователя.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор пользователя, ответы от которого нужно скрыть. целое число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.hideAllReplies
		/// </remarks>
		Task<bool> HideAllRepliesAsync(long ownerId);

		/// <summary>
		/// Скрывает ответ на историю.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца истории (ответной). целое число, обязательный параметр
		/// </param>
		/// <param name = "storyId">
		/// Идентификатор истории (ответной). положительное число, обязательный параметр
		/// </param>
		/// <param name = "accessKey">
		/// Ключ доступа к приватному объекту. строка
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.hideReply
		/// </remarks>
		Task<bool> HideReplyAsync(long ownerId, ulong storyId, string accessKey);

		/// <summary>
		/// Позволяет вернуть пользователя или сообщество в список отображаемых историй в ленте.
		/// </summary>
		/// <param name = "ownersIds">
		/// Список идентификаторов владельцев историй, разделённых запятой. список целых чисел, разделенных запятыми, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stories.unbanOwner
		/// </remarks>
		Task<bool> UnbanOwnerAsync(IEnumerable<long> ownersIds);
	}
}