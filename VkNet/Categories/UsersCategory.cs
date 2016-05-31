namespace VkNet.Categories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using JetBrains.Annotations;
	using Enums.Filters;
	using Enums.SafetyEnums;
	using Model;
	using Model.RequestParams;
	using Utils;

	/// <summary>
	/// Методы для работы с информацией о пользователях.
	/// </summary>
	public partial class UsersCategory
	{
		private readonly VkApi _vk;

		internal UsersCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список пользователей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей, найденных в соответствии с заданными критериями.
		/// </returns>
		/// <exception cref="ArgumentException">Query can not be <c>null</c> or empty.</exception>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.search" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public VkCollection<User> Search(UserSearchParams @params)
		{
			return _vk.Call("users.search", @params, true).ToVkCollectionOf<User>(r => r);
		}

		/// <summary>
		/// Возвращает информацию о том, установил ли пользователь приложение.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя. целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
		/// <returns>
		/// После успешного выполнения возвращает 1 в случае, если пользователь установил у себя данное приложение, иначе 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.isAppUser" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public bool IsAppUser(long? userId)
		{
			var parameters = new VkParameters {
				{ "user_id", userId }
			};

			return _vk.Call("users.isAppUser", parameters, true);
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователе.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <param name="fields">Поля профиля, которые необходимо возвратить.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
		/// <returns>Объект, содержащий запрошенную информацию о пользователе.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/getProfiles"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public User Get(long userId, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			var users = Get(new[] { userId }, fields, nameCase);
			return users.FirstOrDefault();
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователях. Метод не требует авторизацию
		/// </summary>
		/// <param name="userIds">Идентификаторы пользователей, о которых необходимо получить информацию.</param>
		/// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
		/// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.get"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> Get([NotNull] IEnumerable<long> userIds, ProfileFields fields = null, NameCase nameCase = null)
		{
			if (userIds == null)
			{
				throw new ArgumentNullException("userIds");
			}

			var parameters = new VkParameters
			{
				{ "fields", fields },
				{ "name_case", nameCase },
				{ "user_ids", userIds }
			};

			VkResponseArray response = _vk.Call("users.get", parameters);

			return response.ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователях.
		/// </summary>
		/// <param name="screenNames">Короткие имена пользователей, о которых необходимо получить информацию.</param>
		/// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
		/// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.get"/>.
		/// </remarks>
		[Pure, NotNull, ContractAnnotation("screenNames:null => halt")]
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> Get([NotNull] IEnumerable<string> screenNames, ProfileFields fields = null, NameCase nameCase = null)
		{
			if (screenNames == null)
			{
				throw new ArgumentNullException("screenNames");
			}

			var parameters = new VkParameters
				{
					{ "user_ids", screenNames },
					{ "fields", fields },
					{ "name_case", nameCase }
				};

			VkResponseArray response = _vk.Call("users.get", parameters);
			return response.ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователе.
		/// </summary>
		/// <param name="screenName">Короткое имя пользователя</param>
		/// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
		/// <returns>Объект <see cref="User"/> с запрошенной информацией о пользователе.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.get"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public User Get([NotNull] string screenName, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => screenName);

			var users = Get(new[] { screenName }, fields, nameCase);
			return users.Count > 0 ? users[0] : null;
		}

		/// <summary>
		/// Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, подписки которого необходимо получить</param>
		/// <param name="count">Количество подписок, которые необходимо вернуть</param>
		/// <param name="offset">Смещение необходимое для выборки определенного подмножества подписок</param>
		/// <param name="fields">Список дополнительных полей для объектов user и group, которые необходимо вернуть.</param>
		/// <returns>
		/// Пока возвращается только список групп.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.getSubscriptions" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public VkCollection<Group> GetSubscriptions(long? userId = null, int? count = null, int? offset = null, GroupsFields fields = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "extended", true },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields }
			};

			return _vk.Call("users.getSubscriptions", parameters).ToVkCollectionOf<Group>(x => x);
		}

		/// <summary>
		/// Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя</param>
		/// <param name="count">Количество подписчиков, информацию о которых нужно получить</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества подписчиков</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
		/// <returns>Список подписчиков</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.getFollowers"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public VkCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "name_case", nameCase }
			};

			return _vk.Call("users.getFollowers", parameters).ToVkCollectionOf(x => x.ContainsKey("id") ? x : new User { Id = x });
		}

		/// <summary>
		/// Позволяет пожаловаться на пользователя.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, на которого осуществляется жалоба</param>
		/// <param name="type">Тип жалобы</param>
		/// <param name="comment">Комментарий к жалобе на пользователя</param>
		/// <returns>В случае успешной жалобы метод вернет true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.report"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Report(long userId, ReportType type, string comment = "")
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "type", type },
				{ "comment", comment }
			};

			return _vk.Call("users.report", parameters);
		}

		/// <summary>
		/// Индексирует текущее местоположение пользователя и возвращает список пользователей, которые находятся вблизи.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов user.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.getNearby" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public VkCollection<User> GetNearby(UsersGetNearbyParams @params)
		{
			return _vk.Call("users.getNearby", @params).ToVkCollectionOf<User>(x => x);
		}
	}
}
