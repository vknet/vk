using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с новостной лентой пользователя.
	/// </summary>
	public interface INewsFeedCategoryAsync
	{
		/// <summary>
		/// Возвращает данные, необходимые для показа списка новостей для текущего
		/// пользователя.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.get
		/// </remarks>
		Task<NewsFeed> GetAsync(NewsFeedGetParams @params);

		/// <summary>
		/// Получает список новостей, рекомендованных пользователю.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getRecommended
		/// </remarks>
		Task<NewsFeed> GetRecommendedAsync(NewsFeedGetRecommendedParams @params);

		/// <summary>
		/// Возвращает данные, необходимые для показа раздела комментариев в новостях
		/// пользователя.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getComments
		/// </remarks>
		Task<NewsFeed> GetCommentsAsync(NewsFeedGetCommentsParams @params);

		/// <summary>
		/// Возвращает список записей пользователей на своих стенах, в которых упоминается
		/// указанный пользователь.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор группы или сообщества. по умолчанию идентификатор текущего
		/// пользователя
		/// </param>
		/// <param name="startTime">
		/// Время в формате unixtime начиная с которого следует получать упоминания о
		/// пользователе.
		/// </param>
		/// <param name="endTime">
		/// Время, в формате unixtime, до которого следует получать упоминания о
		/// пользователе.
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества новостей. По
		/// умолчанию 0.
		/// </param>
		/// <param name="count">
		/// Количество возвращаемых записей. Если параметр не задан, то считается, что он
		/// равен 20.
		/// Максимальное значение параметра 50.
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getMentions
		/// </remarks>
		Task<VkCollection<Mention>> GetMentionsAsync(long? ownerId = null
													, DateTime? startTime = null
													, DateTime? endTime = null
													, long? offset = null
													, long? count = null);

		/// <summary>
		/// Возвращает список пользователей и групп, которые текущий пользователь скрыл из
		/// ленты новостей.
		/// </summary>
		/// <returns> Возвращает результат выполнения метода. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getBanned
		/// </remarks>
		Task<NewsBannedList> GetBannedAsync();

		/// <summary>
		/// Возвращает список пользователей и групп, которые текущий пользователь скрыл из
		/// ленты новостей.
		/// </summary>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо
		/// вернуть.
		/// </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getBanned
		/// </remarks>
		Task<NewsBannedExList> GetBannedExAsync(UsersFields fields = null, NameCase nameCase = null);

		/// <summary>
		/// Запрещает показывать новости от заданных пользователей и групп в ленте новостей
		/// текущего пользователя.
		/// </summary>
		/// <param name="userIds">
		/// Перечисленные через запятую идентификаторы друзей пользователя, новости от
		/// которых необходимо
		/// скрыть из ленты новостей текущего пользователя.
		/// </param>
		/// <param name="groupIds">
		/// Перечисленные через запятую идентификаторы групп пользователя, новости от
		/// которых необходимо
		/// скрыть из ленты новостей текущего пользователя.
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.addBan
		/// </remarks>
		Task<bool> AddBanAsync(IEnumerable<long> userIds, IEnumerable<long> groupIds);

		/// <summary>
		/// Разрешает показывать новости от заданных пользователей и групп в ленте новостей
		/// текущего пользователя.
		/// </summary>
		/// <param name="userIds">
		/// Идентификаторы пользователей, новости от которых
		/// необходимо вернуть в ленту.
		/// </param>
		/// <param name="groupIds">
		/// Идентификаторы сообществ, новости от которых необходимо
		/// вернуть в ленту.
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.deleteBan
		/// </remarks>
		Task<bool> DeleteBanAsync(IEnumerable<long> userIds, IEnumerable<long> groupIds);

		/// <summary>
		/// Позволяет скрыть объект из ленты новостей.
		/// </summary>
		/// <param name="type"> Тип объекта. </param>
		/// <param name="ownerId">
		/// Идентификатор владельца объекта (пользователь или
		/// сообщество).
		/// </param>
		/// <param name="itemId"> Идентификатор объекта. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.ignoreItem
		/// </remarks>
		Task<bool> IgnoreItemAsync(NewsObjectTypes type, long ownerId, long itemId);

		/// <summary>
		/// Позволяет вернуть ранее скрытый объект в ленту новостей.
		/// </summary>
		/// <returns> Возвращает результат выполнения метода. </returns>
		/// <param name="type"> Тип объекта. </param>
		/// <param name="ownerId">
		/// Идентификатор владельца объекта (пользователь или
		/// сообщество).
		/// </param>
		/// <param name="itemId"> Идентификатор объекта. </param>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.unignoreItem
		/// </remarks>
		Task<bool> UnignoreItemAsync(NewsObjectTypes type, long ownerId, long itemId);

		/// <summary>
		/// Возвращает результаты поиска по статусам. Новости возвращаются в порядке от
		/// более новых к более старым.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.search
		/// </remarks>
		Task<NewsSearchResult> SearchAsync(NewsFeedSearchParams @params);

		/// <summary>
		/// Возвращает пользовательские списки новостей.
		/// </summary>
		/// <param name="listIds"> Идентификаторы списков. </param>
		/// <param name="extended">
		/// <c> true </c> — вернуть дополнительную информацию о списке (значения source_ids
		/// и no_reposts).
		/// </param>
		/// <returns>
		/// Метод возвращает список объектов пользовательских списков.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getLists
		/// </remarks>
		Task<VkCollection<NewsUserListItem>> GetListsAsync(IEnumerable<long> listIds, bool? extended = null);

		/// <summary>
		/// Метод позволяет создавать или редактировать пользовательские списки для
		/// просмотра новостей.
		/// </summary>
		/// <param name="title"> Название списка. </param>
		/// <param name="sourceIds">
		/// Идентификаторы пользователей и сообществ, которые должны быть включены в
		/// список. Идентификаторы
		/// сообществ нужно указывать со знаком «минус».
		/// </param>
		/// <param name="listId">
		/// Числовой идентификатор списка (если не передан, будет
		/// назначен автоматически).
		/// </param>
		/// <param name="noReposts">
		/// Нужно ли отображать копии постов в списке (
		/// <c> true </c> — не нужно).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает Идентификатор списка.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.saveList
		/// </remarks>
		Task<long> SaveListAsync(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null);

		/// <summary>
		/// Метод позволяет удалить пользовательский список новостей
		/// </summary>
		/// <param name="listId"> Числовой идентификатор списка . </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.deleteList
		/// </remarks>
		Task<bool> DeleteListAsync(long listId);

		/// <summary>
		/// Отписывает текущего пользователя от комментариев к заданному объекту.
		/// </summary>
		/// <param name="type">
		/// Тип объекта, от комментариев к которому необходимо
		/// отписаться.
		/// </param>
		/// <param name="ownerId"> Идентификатор владельца объекта. </param>
		/// <param name="itemId"> Идентификатор объекта. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.unsubscribe
		/// </remarks>
		Task<bool> UnsubscribeAsync(CommentObjectType type, long itemId, long? ownerId = null);

		/// <summary>
		/// Возвращает сообщества и пользователей, на которые текущему пользователю
		/// рекомендуется подписаться.
		/// </summary>
		/// <param name="offset">
		/// Отступ, необходимый для выборки определенного подмножества сообществ или
		/// пользователей.
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество сообществ или пользователей, которое необходимо вернуть.
		/// положительное число,
		/// максимальное значение 1000, по умолчанию 20 (Положительное число, максимальное
		/// значение 1000, по умолчанию 20).
		/// </param>
		/// <param name="shuffle">
		/// Перемешивать ли возвращаемый список. флаг, может принимать значения 1 или 0
		/// (Флаг, может
		/// принимать значения 1 или 0).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей, которые необходимо вернуть. См. возможные поля для
		/// пользователей и
		/// сообществ. список слов, разделенных через запятую (Список слов, разделенных
		/// через запятую).
		/// </param>
		/// <returns>
		/// Список объектов пользователей и групп.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getSuggestedSources
		/// </remarks>
		Task<NewsSuggestions> GetSuggestedSourcesAsync(long? offset = null
														, long? count = null
														, bool? shuffle = null
														, UsersFields fields = null);
	}
}