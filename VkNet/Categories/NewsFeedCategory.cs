using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с новостной лентой пользователя.
	/// </summary>
	public partial class NewsFeedCategory : INewsFeedCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с новостной лентой пользователя.
		/// </summary>
		/// <param name="vk"> API. </param>
		public NewsFeedCategory(VkApi vk)
		{
			_vk = vk;
		}

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
		public NewsFeed Get(NewsFeedGetParams @params)
		{
			var response = _vk.Call(methodName: "newsfeed.get", parameters: @params);

			var result = new NewsFeed
			{
					Items = response[key: "items"].ToReadOnlyCollectionOf<NewsItem>(selector: x => x)
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
					, NewOffset = response[key: "new_offset"]
					, NextFrom = response[key: "next_from"]
			};

			return result;
		}

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
		public NewsFeed GetRecommended(NewsFeedGetRecommendedParams @params)
		{
			var response = _vk.Call(methodName: "newsfeed.getRecommended", parameters: @params);

			var result = new NewsFeed
			{
					Items = response[key: "items"].ToReadOnlyCollectionOf<NewsItem>(selector: x => x)
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
					, NewOffset = response[key: "new_offset"]
					, NextFrom = response[key: "next_from"]
			};

			return result;
		}

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
		public NewsFeed GetComments(NewsFeedGetCommentsParams @params)
		{
			var response = _vk.Call(methodName: "newsfeed.getComments", parameters: @params);

			var result = new NewsFeed
			{
					Items = response[key: "items"].ToReadOnlyCollectionOf<NewsItem>(selector: x => x)
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
					, NewOffset = response[key: "new_offset"]
					, NextFrom = response[key: "next_from"]
			};

			return result;
		}

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
		public VkCollection<Mention> GetMentions(long? ownerId = null
												, DateTime? startTime = null
												, DateTime? endTime = null
												, long? offset = null
												, long? count = null)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", ownerId }
					, { "start_time", startTime }
					, { "end_time", endTime }
					, { "offset", offset }
			};

			if (count <= 50)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "newsfeed.getMentions", parameters: parameters).ToVkCollectionOf<Mention>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список пользователей и групп, которые текущий пользователь скрыл из
		/// ленты новостей.
		/// </summary>
		/// <returns> Возвращает результат выполнения метода. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/newsfeed.getBanned
		/// </remarks>
		public NewsBannedList GetBanned()
		{
			return _vk.Call(methodName: "newsfeed.getBanned", parameters: VkParameters.Empty);
		}

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
		public NewsBannedExList GetBannedEx(UsersFields fields = null, NameCase nameCase = null)
		{
			var parameters = new VkParameters
			{
					{ "extended", true }
					, { "fields", fields }
					, { "name_case", nameCase }
			};

			return _vk.Call(methodName: "newsfeed.getBanned", parameters: parameters);
		}

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
		public bool AddBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			var parameters = new VkParameters
			{
					{ "user_ids", userIds }
					, { "group_ids", groupIds }
			};

			return _vk.Call(methodName: "newsfeed.addBan", parameters: parameters);
		}

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
		public bool DeleteBan(IEnumerable<long> userIds, IEnumerable<long> groupIds)
		{
			var parameters = new VkParameters
			{
					{ "user_ids", userIds }
					, { "group_ids", groupIds }
			};

			return _vk.Call(methodName: "newsfeed.deleteBan", parameters: parameters);
		}

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
		public bool IgnoreItem(NewsObjectTypes type, long ownerId, long itemId)
		{
			var parameters = new VkParameters
			{
					{ "type", type }
					, { "owner_id", ownerId }
					, { "item_id", itemId }
			};

			return _vk.Call(methodName: "newsfeed.ignoreItem", parameters: parameters);
		}

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
		public bool UnignoreItem(NewsObjectTypes type, long ownerId, long itemId)
		{
			var parameters = new VkParameters
			{
					{ "type", type }
					, { "owner_id", ownerId }
					, { "item_id", itemId }
			};

			return _vk.Call(methodName: "newsfeed.unignoreItem", parameters: parameters);
		}

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
		public ReadOnlyCollection<NewsSearchResult> Search(NewsFeedSearchParams @params)
		{
			VkResponseArray response = _vk.Call(methodName: "newsfeed.search", parameters: @params);

			return response.ToReadOnlyCollectionOf<NewsSearchResult>(selector: x => x);
		}

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
		public VkCollection<NewsUserListItem> GetLists(IEnumerable<long> listIds, bool? extended = null)
		{
			var parameters = new VkParameters
			{
					{ "list_ids", listIds }
					, { "extended", extended }
			};

			return _vk.Call(methodName: "newsfeed.getLists", parameters: parameters).ToVkCollectionOf<NewsUserListItem>(selector: x => x);
		}

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
		public long SaveList(string title, IEnumerable<long> sourceIds, long? listId = null, bool? noReposts = null)
		{
			var parameters = new VkParameters
			{
					{ "list_id", listId }
					, { "title", title }
					, { "source_ids", sourceIds }
					, { "no_reposts", noReposts }
			};

			return _vk.Call(methodName: "newsfeed.saveList", parameters: parameters);
		}

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
		public bool DeleteList(long listId)
		{
			var parameters = new VkParameters
			{
					{ "list_id", listId }
			};

			return _vk.Call(methodName: "newsfeed.deleteList", parameters: parameters);
		}

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
		public bool Unsubscribe(CommentObjectType type, long itemId, long? ownerId = null)
		{
			var parameters = new VkParameters
			{
					{ "type", type }
					, { "owner_id", ownerId }
					, { "item_id", itemId }
			};

			return _vk.Call(methodName: "newsfeed.unsubscribe", parameters: parameters);
		}

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
		public NewsSuggestions GetSuggestedSources(long? offset = null, long? count = null, bool? shuffle = null, UsersFields fields = null)
		{
			var parameters = new VkParameters
			{
					{ "offset", offset }
					, { "shuffle", shuffle }
					, { "fields", fields }
			};

			if (count <= 1000)
			{
				parameters.Add(name: "count", nullableValue: count);
			}

			return _vk.Call(methodName: "newsfeed.getSuggestedSources", parameters: parameters);
		}
	}
}