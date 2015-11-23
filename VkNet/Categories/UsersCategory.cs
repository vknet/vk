using VkNet.Model.RequestParams.Users;

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
	using Utils;

	/// <summary>
	/// Методы для работы с информацией о пользователях.
	/// </summary>
	public class UsersCategory
	{
		private readonly VkApi _vk;

		internal UsersCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список пользователей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="itemsCount">Общее количество пользователей, удовлетворяющих условиям запроса.</param>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей, найденных в соответствии с заданными критериями.
		/// </returns>
		/// <exception cref="ArgumentException">Query can not be <c>null</c> or empty.</exception>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.search" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.37")]
		public ReadOnlyCollection<User> Search(out int itemsCount, UserSearchParams @params)
		{
			if (string.IsNullOrWhiteSpace(@params.Query))
			{
				throw new ArgumentException("Query can not be null or empty.");
			}
			var parameters = new VkParameters
			{
				{ "q", @params.Query },
				{ "sort", @params.Sort },
				{ "offset", @params.Offset },
				{ "count", @params.Count },
				{ "fields", @params.Fields },
				{ "city", @params.City },
				{ "country", @params.Country },
				{ "hometown", @params.Hometown },
				{ "university_country", @params.UniversityCountry },
				{ "university", @params.University },
				{ "university_year", @params.UniversityYear },
				{ "university_faculty", @params.UniversityFaculty },
				{ "university_chair", @params.UniversityChair },
				{ "sex", @params.Sex },
				{ "status", @params.Status },
				{ "age_from", @params.AgeFrom },
				{ "age_to", @params.AgeTo },
				{ "birth_day", @params.BirthDay },
				{ "birth_month", @params.BirthMonth },
				{ "birth_year", @params.BirthYear },
				{ "online", @params.Online },
				{ "has_photo", @params.HasPhoto },
				{ "school_country", @params.SchoolCountry },
				{ "school_city", @params.SchoolCity },
				{ "school_class", @params.SchoolClass },
				{ "school", @params.School },
				{ "school_year", @params.SchoolYear },
				{ "religion", @params.Religion },
				{ "interests", @params.Interests },
				{ "company", @params.Company },
				{ "position", @params.Position },
				{ "group_id", @params.GroupId },
				{ "from_list", @params.FromList }

			};
			var response = _vk.Call("users.search", parameters);

			itemsCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<User>(r => r);
		}

		/// <summary>
		/// Получает настройки текущего пользователя в данном приложении. .
		/// </summary>
		/// <param name="uid">Идентификатор пользователя, информацию о настройках которого необходимо получить.</param>
		/// <returns>После успешного выполнения возвращает битовую маску настроек текущего пользователя в данном приложении. 
		/// 
		/// Пример:
		/// Если Вы хотите получить права на Доступ к друзьям и Доступ к статусам пользователя, то Ваша битовая маска будет 
		/// равна: 2 + 1024 = 1026. 
		/// Если, имея битовую маску 1026, Вы хотите проверить, имеет ли она доступ к друзьям — Вы можете сделать 1026 &amp; 2. 
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/getUserSettings"/>.
		/// </remarks>
		[Pure]
		public int GetUserSettings(long uid)
		{   
			var parameters = new VkParameters { { "uid", uid } };

			return _vk.Call("getUserSettings", parameters);
		}

		/// <summary>
		/// Возвращает информацию о том, установил ли пользователь приложение.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя.</param>
		/// <returns>После успешного выполнения возвращает true в случае, если пользователь установил у себя данное приложение, 
		/// иначе false. 
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/isAppUser"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.9")]
		public bool IsAppUser(long userId)
		{   
			var parameters = new VkParameters { { "user_id", userId } };

			VkResponse response = _vk.Call("users.isAppUser", parameters);

			return 1 == Convert.ToInt32(response.ToString());
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
		[ApiVersion("5.9")]
		public User Get(long userId, ProfileFields fields = null,
											NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase }, { "user_ids", userId } };

			VkResponseArray response = _vk.Call("users.get", parameters, true);

			return response[0];
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
		[ApiVersion("5.21")]
		public ReadOnlyCollection<User> Get([NotNull] IEnumerable<long> userIds, ProfileFields fields = null, NameCase nameCase = null)
		{
			if (userIds == null)
				throw new ArgumentNullException("userIds");

			var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase } };
			parameters.Add("user_ids", userIds);

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
		[ApiVersion("5.9")]
		public ReadOnlyCollection<User> Get([NotNull] IEnumerable<string> screenNames, ProfileFields fields = null, NameCase nameCase = null)
		{
			if (screenNames == null)
				throw new ArgumentNullException("screenNames");

			var parameters = new VkParameters
				{
					{ "user_ids", screenNames }, 
					{ "fields", fields }, 
					{ "name_case", nameCase }
				};

			VkResponseArray response = _vk.Call("users.get", parameters);
			return response.ToReadOnlyCollectionOf<User>(x => x);
		}

#if false
		// todo start shit
		[Pure, NotNull, ContractAnnotation("screenNames:null => halt")]
		[ApiVersion("5.9")]
		public async Task<ReadOnlyCollection<User>> GetAsync([NotNull] IEnumerable<string> screenNames, ProfileFields fields = null, NameCase nameCase = null)
		{
			if (screenNames == null)
				throw new ArgumentNullException("screenNames");

			var parameters = new VkParameters
				{
					{ "user_ids", screenNames }, 
					{ "fields", fields }, 
					{ "name_case", nameCase }
				};

			VkResponseArray response = await _vk.CallAsync("users.get", parameters);
			return response.ToReadOnlyCollectionOf<User>(x => x);
		}
#endif

		// todo end shit

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
		[Pure, CanBeNull, ContractAnnotation("ScreenName:null => halt")]
		public User Get([NotNull] string screenName, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => screenName);

			ReadOnlyCollection<User> users = Get(new[] {screenName}, fields, nameCase);
			return users.Count > 0 ? users[0] : null;
		}

		
			// todo add tests for subscriptions for users
		/// <summary>
		/// Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.
		/// </summary>
		/// <param name="userId">Идентификатор пользователя, подписки которого необходимо получить</param>
		/// <param name="count">Количество подписок, которые необходимо вернуть</param>
		/// <param name="offset">Смещение необходимое для выборки определенного подмножества подписок</param>
		/// <returns>Пока возвращается только список групп.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/users.getSubscriptions"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.9")]
		public ReadOnlyCollection<Group> GetSubscriptions(long? userId = null, int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{"user_id", userId},
					{"extended", true},
					{"offset", offset},
					{"count", count}
				};

			VkResponseArray response = _vk.Call("users.getSubscriptions", parameters);
			
			return response.ToReadOnlyCollectionOf<Group>(x => x);
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
		[ApiVersion("5.9")]
		public ReadOnlyCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{"user_id", userId},
					{"offset", offset},
					{"count", count},
					{"fields", fields},
					{"name_case", nameCase}
				};

			VkResponseArray response = _vk.Call("users.getFollowers", parameters);

			// проверка: возвращается массив объектов или только идентификаторы пользователей
			if (response.Count > 0 && response[0].ContainsKey("id"))
			{
				return response.ToReadOnlyCollectionOf<User>(x => x);
			}

			return response.ToReadOnlyCollectionOf(x => new User{Id = x});
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
		[ApiVersion("5.9")]
		public bool Report(long userId, ReportType type, string comment = "")
		{
			VkErrors.ThrowIfNumberIsNegative(() => userId);

			var parameters = new VkParameters
				{
					{"user_id", userId},
					{"type", type},
					{"comment", comment}
				};

			return _vk.Call("users.report", parameters);
		}
	}
}
