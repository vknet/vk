using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Fave;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с закладками.
	/// </summary>
	public partial interface IFaveCategoryAsync
	{
		/// <summary>
		/// Добавляет статью в закладки.
		/// </summary>
		/// <param name = "url">
		/// Ссылка на добавляемую статью.
		/// Обязательный параметр.
		/// </param>
		/// <param name = "ref"/>
		/// <param name = "trackCode"/>
		/// <param name = "source"/>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addArticle
		/// </remarks>
		Task<bool> AddArticleAsync(Uri url, string @ref = null, string trackCode = null, string source = null);

		/// <summary>
		/// Добавляет ссылку в закладки.
		/// </summary>
		/// <param name = "link">
		/// Адрес добавляемой ссылки.
		/// Поддерживаются только внутренние ссылки на vk.com.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addLink
		/// </remarks>
		Task<bool> AddLinkAsync(Uri link);

		/// <summary>
		/// Добавляет сообщество или пользователя в закладки.
		/// </summary>
		/// <param name = "userId">
		/// Идентификатор пользователя, которого нужно добавить в закладки.
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества, которое нужно добавить в закладки.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addPage
		/// </remarks>
		Task<bool> AddPageAsync(ulong? userId = null, ulong? groupId = null);

		/// <summary>
		/// Добавляет запись со стены пользователя или сообщества в закладки.
		/// </summary>
		/// <param name = "params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addPost
		/// </remarks>
		Task<bool> AddPostAsync(FaveAddPostParams @params);

		/// <summary>
		/// Добавляет товар в закладки.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор пользователя или сообщества, чей товар требуется добавить в закладки.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </param>
		/// <param name = "id">
		/// Идентификатор товара. целое число, обязательный параметр
		/// </param>
		/// <param name = "accessKey">
		/// Специальный код доступа для приватных товаров.
		/// </param>
		/// <param name="ref"/>
		/// <param name = "source"/>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addProduct
		/// </remarks>
		Task<bool> AddProductAsync(long ownerId, long id, string accessKey = null, string @ref = null, string source = null);

		/// <summary>
		/// Создает метку закладок.
		/// </summary>
		/// <param name = "name">
		/// Название метки.
		/// Максимальная длина 50.
		/// </param>
		/// <param name = "position">
		/// Строка, по умолчанию back
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает объект метки с полями name - названием метки и id - идентификатором созданной метки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addTag
		/// </remarks>
		Task<FaveTag> AddTagAsync(string name, string position);

		/// <summary>
		/// Добавляет видеозапись в закладки.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор пользователя или сообщества, владельца видеозаписи, которую требуется добавить в закладки.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </param>
		/// <param name = "id">
		/// Идентификатор видеозаписи.
		/// </param>
		/// <param name = "accessKey">
		/// Специальный код доступа для приватных видеозаписей.
		/// </param>
		/// <param name = "ref"/>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.addVideo
		/// </remarks>
		Task<bool> AddVideoAsync(long ownerId, long id, string accessKey = null, string @ref = null);

		/// <summary>
		/// Редактирует метку.
		/// </summary>
		/// <param name = "id">
		/// Идентификатор метки.
		/// </param>
		/// <param name = "name">
		/// Новое название метки.
		/// Обязательный параметр, максимальная длина 50.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.editTag
		/// </remarks>
		Task<bool> EditTagAsync(long id, string name);

		/// <summary>
		/// Возвращает объекты, добавленные в закладки пользователя.
		/// </summary>
		/// <param name = "params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в поле count и массив объектов, добавленных в закладки, в поле items.
		/// Каждый из объектов содержит следующие поля:
		/// type
		/// stringтип объекта, добавленного в закладки. Возможные значения:
		/// post — запись на стене;
		/// video — видеозапись;
		/// product — товар;
		/// article — статья;
		/// link — ссылки. seen
		/// booleanявляется ли закладка просмотренной. added_date
		/// integerдата добавления объекта в закладки в формате Unixtime. tags
		/// arrayмассив меток объекта в списке закладок. {object_type}
		/// objectобъект, добавленный в закладки.
		/// Если был задан параметр extended=1, возвращает число результатов в поле count, отдельно массив объектов пользователей в поле profiles и сообществ в поле groups.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.get
		/// </remarks>
		Task<VkCollection<FaveGetObject>> GetAsync(FaveGetParams @params);

		/// <summary>
		/// Возвращает страницы пользователей и сообществ, добавленных в закладки.
		/// </summary>
		/// <param name = "type">
		/// Типы объектов, которые необходимо вернуть. Возможные значения:
		/// users — вернуть только пользователей;
		/// groups — вернуть только сообщества;
		/// hints — топ сообществ и пользователей.
		/// Если параметр не указан — вернутся объекты пользователей и сообществ, добавленных в закладки, в порядке добавления.
		/// </param>
		/// <param name = "fields">
		/// Список дополнительных полей для объектов user и group, которые необходимо вернуть.
		/// </param>
		/// <param name = "offset">
		/// Смещение относительно первого объекта в закладках пользователя для выборки определенного подмножества. Максимальное значение 10000.
		/// </param>
		/// <param name = "count">
		/// Количество возвращаемых закладок. По умолчанию 50, минимальное значение 1, максимальное значение 500.
		/// </param>
		/// <param name = "tagId">
		/// Идентификатор метки, закладки отмеченные которой требуется вернуть.
		/// </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getPages
		/// </remarks>
		Task<VkCollection<FaveGetPagesObject>> GetPagesAsync(FavePageType type = null,
															 IEnumerable<string> fields = null,
															 ulong? offset = null,
															 ulong? count = null,
															 long? tagId = null);

		/// <summary>
		/// Возвращает список меток в закладках.
		/// </summary>
		/// <returns>
		/// После успешного выполнения возвращает объект, содержащий число результатов в поле count и массив объектов меток в поле items.
		/// Поля, описывающие объект метки: id - идентификатор метки и name - название.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.getTags
		/// </remarks>
		Task<VkCollection<FaveTag>> GetTagsAsync();

		/// <summary>
		/// Отмечает закладки как просмотренные.
		/// </summary>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.markSeen
		/// </remarks>
		Task<bool> MarkSeenAsync();

		/// <summary>
		/// Удаляет статью из закладок.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца статьи.
		/// </param>
		/// <param name = "articleId">
		/// Идентификатор статьи.
		/// </param>
		/// <param name = "ref"/>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeArticle
		/// </remarks>
		Task<bool> RemoveArticleAsync(long ownerId, ulong articleId, string @ref = null);

		/// <summary>
		/// Удаляет ссылку из списка закладок пользователя.
		/// </summary>
		/// <param name = "linkId">
		/// Идентификатор ссылки.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeLink
		/// </remarks>
		Task<bool> RemoveLinkAsync(string linkId);

		/// <summary>
		/// Удаляет из закладок сообщество или страницу пользователя.
		/// </summary>
		/// <param name = "userId">
		/// Идентификатор пользователя, которого следует удалить из закладок.
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества, которое следует удалить из закладок.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removePage
		/// </remarks>
		Task<bool> RemovePageAsync(long? userId = null, long? groupId = null);

		/// <summary>
		/// Удаляет из закладок запись на стене пользователя или сообщества.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор владельца записи.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </param>
		/// <param name = "id">
		/// Идентификатор записи на стене.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removePost
		/// </remarks>
		Task<bool> RemovePostAsync(long ownerId, long id);

		/// <summary>
		/// Удаляет товар из закладок.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор пользователя или сообщества, чей товар требуется удалить из закладок.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </param>
		/// <param name = "id">
		/// Идентификатор товара.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeProduct
		/// </remarks>
		Task<bool> RemoveProductAsync(long ownerId, long id);

		/// <summary>
		/// Удаляет метку закладок.
		/// </summary>
		/// <param name = "id">
		/// Идентификатор метки.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeTag
		/// </remarks>
		Task<bool> RemoveTagAsync(long id);

		/// <summary>
		/// Удаляет видеозапись из списка закладок.
		/// </summary>
		/// <param name = "ownerId">
		/// Идентификатор пользователя или сообщества, владельца видеозаписи, которую требуется удалить из закладок.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1).
		/// </param>
		/// <param name = "id">
		/// Идентификатор видеозаписи.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.removeVideo
		/// </remarks>
		Task<bool> RemoveVideoAsync(long ownerId, long id);

		/// <summary>
		/// Меняет порядок меток закладок в списке.
		/// </summary>
		/// <param name = "ids">
		/// Перечисленные через запятую все идентификаторы меток пользователя в том порядке, в котором их требуется отображать.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.reorderTags
		/// </remarks>
		Task<bool> ReorderTagsAsync(IEnumerable<long> ids);

		/// <summary>
		/// Устанавливает метку странице пользователя или сообщества.
		/// </summary>
		/// <param name = "userId">
		/// Идентификатор пользователя, которому требуется проставить метку в закладках.
		/// Обязательный параметр, если не задан параметр group_id.
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества, которому требуется проставить метку в закладках.
		/// Обязательный параметр, если не задан параметр user_id.
		/// </param>
		/// <param name = "tagIds">
		/// Перечисленные через запятую идентификаторы тегов, которые требуется присвоить странице.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.setPageTags
		/// </remarks>
		Task<bool> SetPageTagsAsync(ulong? userId = null, ulong? groupId = null, IEnumerable<long> tagIds = null);

		/// <summary>
		/// Устанавливает метку выбранному объекту в списке закладок.
		/// </summary>
		/// <param name = "params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.setTags
		/// </remarks>
		Task<bool> SetTagsAsync(FaveSetTagsParams @params);

		/// <summary>
		/// Устанавливает страницу пользователя или сообщества в топ закладок.
		/// </summary>
		/// <param name = "userId">
		/// Идентификатор пользователя, которому требуется проставить метку в закладках.
		/// Обязательный параметр, если не задан параметр group_id.
		/// </param>
		/// <param name = "groupId">
		/// Идентификатор сообщества, которому требуется проставить метку в закладках.
		/// Обязательный параметр, если не задан параметр user_id.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/fave.trackPageInteraction
		/// </remarks>
		Task<bool> TrackPageInteractionAsync(ulong? userId = null, ulong? groupId = null);
	}
}