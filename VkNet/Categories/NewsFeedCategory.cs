using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.NewsFeed;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с новостной лентой пользователя.
	/// </summary>
	public class NewsFeedCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с новостной лентой пользователя.
		/// </summary>
		/// <param name="vk">API.</param>
		internal NewsFeedCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает данные, необходимые для показа списка новостей для текущего пользователя.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.get" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public NewsFeed Get(GetParams @params)
		{
			var parameters = new VkParameters
			{
				{ "filters", @params.Filters },
				{ "return_banned", @params.ReturnBanned },
				{ "start_time", @params.StartTime },
				{ "end_time", @params.EndTime },
				{ "max_photos", @params.MaxPhotos },
				{ "source_ids", @params.SourceIds },
				{ "start_from", @params.StartFrom },
				{ "count", @params.Count },
				{ "fields", @params.Fields }
			};
			var response = _vk.Call("newsfeed.get", parameters);
			var result = new NewsFeed
			{
				Items = response["items"].ToReadOnlyCollectionOf<NewsItem>(x => x),
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x),
				NewOffset = response["new_offset"],
				NextFrom = response["next_from"]
			};
			return result;
		}

		/// <summary>
		/// Получает список новостей, рекомендованных пользователю.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getRecommended" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public NewsFeed GetRecommended(GetRecommendedParams @params)
		{
			var parameters = new VkParameters
			{
				{ "start_time", @params.StartTime },
				{ "end_time", @params.EndTime },
				{ "max_photos", @params.MaxPhotos },
				{ "start_from", @params.StartFrom },
				{ "count", @params.Count },
				{ "fields", @params.Fields }
			};
			var response = _vk.Call("newsfeed.getRecommended", parameters);
			var result = new NewsFeed
			{
				Items = response["items"].ToReadOnlyCollectionOf<NewsItem>(x => x),
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x),
				NewOffset = response["new_offset"],
				NextFrom = response["next_from"]
			};
			return result;
		}

		/// <summary>
		/// Возвращает данные, необходимые для показа раздела комментариев в новостях пользователя.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getComments" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public NewsFeed GetComments(GetCommentsParams @params)
		{
			var parameters = new VkParameters
			{
				{ "count", @params.Count },
				{ "filters", @params.Filters },
				{ "reposts", @params.Reposts },
				{ "start_time", @params.StartTime },
				{ "end_time", @params.EndTime },
				{ "last_comments_count", @params.LastCommentsCount },
				{ "start_from", @params.StartFrom },
				{ "fields", @params.Fields }
			};
			var response = _vk.Call("newsfeed.getComments", parameters);
			var result = new NewsFeed
			{
				Items = response["items"].ToReadOnlyCollectionOf<NewsItem>(x => x),
				Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
				Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x),
				NewOffset = response["new_offset"],
				NextFrom = response["next_from"]
			};
			return result;
		}

		/// <summary>
		/// Возвращает список записей пользователей на своих стенах, в которых упоминается указанный пользователь.
		/// </summary>
		/// <param name="total">Количество.</param>
		/// <param name="ownerId">Идентификатор группы или сообщества. по умолчанию идентификатор текущего пользователя</param>
		/// <param name="startTime">Время в формате unixtime начиная с которого следует получать упоминания о пользователе.</param>
		/// <param name="endTime">Время, в формате unixtime, до которого следует получать упоминания о пользователе.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества новостей. По умолчанию 0.</param>
		/// <param name="count">Количество возвращаемых записей. Если параметр не задан, то считается, что он равен 20. Максимальное значение параметра 50.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getMentions" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<Mention> GetMentions(out int total, long ownerId = 0, ulong? startTime = null, ulong? endTime = null, ulong offset = 0, ulong count = 20)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "start_time", startTime },
				{ "end_time", endTime },
				{ "offset", offset }
			};
			if (count <= 50)
			{
				parameters.Add("count", count);
			}
			var response = _vk.Call("newsfeed.getMentions", parameters);
			total = response["count"];
			return response["items"].ToReadOnlyCollectionOf<Mention>(x => x);
		}

		/// <summary>
		/// Возвращает список пользователей и групп, которые текущий пользователь скрыл из ленты новостей.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getBanned" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public NewsBannedList GetBanned()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.getBanned", parameters);
		}

		/// <summary>
		/// Возвращает список пользователей и групп, которые текущий пользователь скрыл из ленты новостей.
		/// </summary>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть. </param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getBanned" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public NewsBannedExList GetBannedEx(UsersFields fields = null, NameCase nameCase = null)
		{
			var parameters = new VkParameters
			{
				{ "extended", true },
				{ "fields", fields },
				{ "name_case", nameCase }
			};
			return _vk.Call("newsfeed.getBanned", parameters);
		}

		/// <summary>
		/// Запрещает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.
		/// </summary>
		/// <param name="userIds">Перечисленные через запятую идентификаторы друзей пользователя, новости от которых необходимо скрыть из ленты новостей текущего пользователя.</param>
		/// <param name="groupIds">Перечисленные через запятую идентификаторы групп пользователя, новости от которых необходимо скрыть из ленты новостей текущего пользователя.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.addBan" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool AddBan(IEnumerable<ulong> userIds, IEnumerable<ulong> groupIds)
		{
			var parameters = new VkParameters
			{
				{ "user_ids", userIds },
				{ "group_ids", groupIds }
			};
			return _vk.Call("newsfeed.addBan", parameters);
		}

		/// <summary>
		/// Разрешает показывать новости от заданных пользователей и групп в ленте новостей текущего пользователя.
		/// </summary>
		/// <param name="userIds">Идентификаторы пользователей, новости от которых необходимо вернуть в ленту.</param>
		/// <param name="groupIds">Идентификаторы сообществ, новости от которых необходимо вернуть в ленту.</param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.deleteBan" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool DeleteBan(IEnumerable<ulong> userIds, IEnumerable<ulong> groupIds)
		{
			var parameters = new VkParameters
			{
				{ "user_ids", userIds },
				{ "group_ids", groupIds }
			};
			return _vk.Call("newsfeed.deleteBan", parameters);
		}

		/// <summary>
		/// Позволяет скрыть объект из ленты новостей.
		/// </summary>
		/// <param name="type">Тип объекта.</param>
		/// <param name="ownerId">Идентификатор владельца объекта (пользователь или сообщество).</param>
		/// <param name="itemId">Идентификатор объекта. </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.ignoreItem" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool IgnoreItem(NewsObjectTypes type, long ownerId, ulong itemId)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};
			return _vk.Call("newsfeed.ignoreItem", parameters);
		}

		/// <summary>
		/// Позволяет вернуть ранее скрытый объект в ленту новостей.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <param name="type">Тип объекта.</param>
		/// <param name="ownerId">Идентификатор владельца объекта (пользователь или сообщество).</param>
		/// <param name="itemId">Идентификатор объекта. </param>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.unignoreItem" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool UnignoreItem(NewsObjectTypes type, long ownerId, ulong itemId)
		{
			var parameters = new VkParameters
			{
				{ "type", type },
				{ "owner_id", ownerId },
				{ "item_id", itemId }
			};
			return _vk.Call("newsfeed.unignoreItem", parameters);
		}

		/// <summary>
		/// Возвращает результаты поиска по статусам. Новости возвращаются в порядке от более новых к более старым.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.search" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool Search()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.search", parameters);
		}

		/// <summary>
		/// Возвращает пользовательские списки новостей.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getLists" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool GetLists()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.getLists", parameters);
		}

		/// <summary>
		/// Метод позволяет создавать или редактировать пользовательские списки для просмотра новостей.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.saveList" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool SaveList()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.saveList", parameters);
		}

		/// <summary>
		/// Метод позволяет удалить пользовательский список новостей
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.deleteList" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool DeleteList()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.deleteList", parameters);
		}

		/// <summary>
		/// Отписывает текущего пользователя от комментариев к заданному объекту.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.unsubscribe" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool Unsubscribe()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.unsubscribe", parameters);
		}

		/// <summary>
		/// Возвращает сообщества и пользователей, на которые текущему пользователю рекомендуется подписаться.
		/// </summary>
		/// <returns>Возвращает результат выполнения метода.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <seealso cref="https://vk.com/dev/newsfeed.getSuggestedSources" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool GetSuggestedSources()
		{
			var parameters = new VkParameters
			{
			};
			return _vk.Call("newsfeed.getSuggestedSources", parameters);
		}

	}
}
