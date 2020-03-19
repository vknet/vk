using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с информацией о пользователях.
	/// </summary>
	public partial class UsersCategory : IUsersCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public UsersCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список пользователей в соответствии с заданным критерием поиска.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов пользователей, найденных
		/// в соответствии с заданными
		/// критериями.
		/// </returns>
		/// <exception cref="ArgumentException"> Query can not be <c> null </c> or empty. </exception>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.search
		/// </remarks>
		[Pure]
		public VkCollection<User> Search(UserSearchParams @params)
		{
			return _vk.Call(methodName: "users.search", new VkParameters
			{
				{ "q", WebUtility.HtmlEncode(value: @params.Query) }
				, { "sort", @params.Sort }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
				, { "fields", @params.Fields }
				, { "city", @params.City }
				, { "country", @params.Country }
				, { "hometown", WebUtility.HtmlEncode(value: @params.Hometown) }
				, { "university_country", @params.UniversityCountry }
				, { "university", @params.University }
				, { "university_year", @params.UniversityYear }
				, { "university_faculty", @params.UniversityFaculty }
				, { "university_chair", @params.UniversityChair }
				, { "sex", @params.Sex }
				, { "status", @params.Status }
				, { "age_from", @params.AgeFrom }
				, { "age_to", @params.AgeTo }
				, { "birth_day", @params.BirthDay }
				, { "birth_month", @params.BirthMonth }
				, { "birth_year", @params.BirthYear }
				, { "online", @params.Online }
				, { "has_photo", @params.HasPhoto }
				, { "school_country", @params.SchoolCountry }
				, { "school_city", @params.SchoolCity }
				, { "school_class", @params.SchoolClass }
				, { "school", @params.School }
				, { "school_year", @params.SchoolYear }
				, { "religion", WebUtility.HtmlEncode(value: @params.Religion) }
				, { "interests", WebUtility.HtmlEncode(value: @params.Interests) }
				, { "company", WebUtility.HtmlEncode(value: @params.Company) }
				, { "position", WebUtility.HtmlEncode(value: @params.Position) }
				, { "group_id", @params.GroupId }
				, { "from_list", @params.FromList }
			}).ToVkCollectionOf<User>(selector: r => r);
		}

		/// <summary>
		/// Возвращает информацию о том, установил ли пользователь приложение.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя. целое число, по умолчанию идентификатор текущего
		/// пользователя (Целое
		/// число, по умолчанию идентификатор текущего пользователя).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 в случае, если пользователь установил у
		/// себя данное приложение, иначе 0.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.isAppUser
		/// </remarks>
		[Pure]
		public bool IsAppUser(long? userId)
		{
			var parameters = new VkParameters
			{
					{ "user_id", userId }
			};

			return _vk.Call(methodName: "users.isAppUser", parameters: parameters);
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователях. Метод не требует авторизацию
		/// </summary>
		/// <param name="userIds">
		/// Идентификаторы пользователей, о которых необходимо
		/// получить информацию.
		/// </param>
		/// <param name="fields"> Поля профилей, которые необходимо возвратить. </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Список объектов с запрошенной информацией о пользователях. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.get
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<User> Get(IEnumerable<long> userIds
											, ProfileFields fields = null
											, NameCase nameCase = null)
		{
			if (userIds == null)
			{
				throw new ArgumentNullException(paramName: nameof(userIds));
			}

			var parameters = new VkParameters
			{
					{ "fields", fields }
					, { "name_case", nameCase }
					, { "user_ids", userIds }
			};

			VkResponseArray response = _vk.Call(methodName: "users.get", parameters: parameters);

			return response.ToReadOnlyCollectionOf<User>(selector: x => x);
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователях.
		/// </summary>
		/// <param name="screenNames">
		/// Короткие имена пользователей, о которых необходимо
		/// получить информацию.
		/// </param>
		/// <param name="fields"> Поля профилей, которые необходимо возвратить. </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Список объектов с запрошенной информацией о пользователях. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.get
		/// </remarks>
		[Pure]
		[NotNull]
		[ContractAnnotation(contract: "screenNames:null => halt")]
		public ReadOnlyCollection<User> Get(IEnumerable<string> screenNames
											, ProfileFields fields = null
											, NameCase nameCase = null)
		{
			if (screenNames == null)
			{
				throw new ArgumentNullException(paramName: nameof(screenNames));
			}

			var parameters = new VkParameters
			{
					{ "user_ids", screenNames }
					, { "fields", fields }
					, { "name_case", nameCase }
			};

			VkResponseArray response = _vk.Call(methodName: "users.get", parameters: parameters);

			return response.ToReadOnlyCollectionOf<User>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список идентификаторов пользователей и групп, которые входят в
		/// список подписок пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, подписки которого необходимо
		/// получить
		/// </param>
		/// <param name="count"> Количество подписок, которые необходимо вернуть </param>
		/// <param name="offset">
		/// Смещение необходимое для выборки определенного
		/// подмножества подписок
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей для объектов user и group, которые необходимо
		/// вернуть.
		/// </param>
		/// <returns>
		/// Пока возвращается только список групп.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.getSubscriptions
		/// </remarks>
		[Pure]
		public VkCollection<Group> GetSubscriptions(long? userId = null
													, int? count = null
													, int? offset = null
													, GroupsFields fields = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "extended", true }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
			};

			return _vk.Call(methodName: "users.getSubscriptions", parameters: parameters)
					.ToVkCollectionOf<Group>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список идентификаторов пользователей, которые являются подписчиками
		/// пользователя.
		/// </summary>
		/// <param name="userId"> Идентификатор пользователя </param>
		/// <param name="count">
		/// Количество подписчиков, информацию о которых нужно
		/// получить
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного
		/// подмножества подписчиков
		/// </param>
		/// <param name="fields"> Список дополнительных полей, которые необходимо вернуть </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Список подписчиков </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.getFollowers
		/// </remarks>
		[Pure]
		public VkCollection<User> GetFollowers(long? userId = null
												, int? count = null
												, int? offset = null
												, ProfileFields fields = null
												, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "offset", offset }
					, { "count", count }
					, { "fields", fields }
					, { "name_case", nameCase }
			};

			return _vk.Call(methodName: "users.getFollowers", parameters: parameters)
					.ToVkCollectionOf(selector: x => x.ContainsKey(key: "id") ? x : new User { Id = x });
		}

		/// <summary>
		/// Позволяет пожаловаться на пользователя.
		/// </summary>
		/// <param name="userId">
		/// Идентификатор пользователя, на которого осуществляется
		/// жалоба
		/// </param>
		/// <param name="type"> Тип жалобы </param>
		/// <param name="comment"> Комментарий к жалобе на пользователя </param>
		/// <returns> В случае успешной жалобы метод вернет true. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.report
		/// </remarks>
		public bool Report(long userId, ReportType type, string comment = "")
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);

			var parameters = new VkParameters
			{
					{ "user_id", userId }
					, { "type", type }
					, { "comment", comment }
			};

			return _vk.Call(methodName: "users.report", parameters: parameters);
		}

		/// <summary>
		/// Индексирует текущее местоположение пользователя и возвращает список
		/// пользователей, которые находятся вблизи.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов user.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.getNearby
		/// </remarks>
		public VkCollection<User> GetNearby(UsersGetNearbyParams @params)
		{
			return _vk.Call(methodName: "users.getNearby", new VkParameters
			{
				{ "latitude", @params.Latitude.ToString(provider: CultureInfo.InvariantCulture) }
				, //Vk API не принимает дробные числа с запятой, нужна точка
				{ "longitude", @params.Longitude.ToString(provider: CultureInfo.InvariantCulture) }
				, { "accuracy", @params.Accuracy }
				, { "timeout", @params.Timeout }
				, { "radius", @params.Radius }
				, { "fields", @params.Fields }
				, { "name_case", @params.NameCase }
				, { "need_description", @params.NeedDescription }
			}).ToVkCollectionOf<User>(selector: x => x);
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователе.
		/// </summary>
		/// <param name="userId"> Идентификатор пользователя. </param>
		/// <param name="fields"> Поля профиля, которые необходимо возвратить. </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Объект, содержащий запрошенную информацию о пользователе. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/getProfiles
		/// </remarks>
		[Pure]
		public User Get(long userId, ProfileFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => userId);
			var users = Get(userIds: new[] { userId }, fields: fields, nameCase: nameCase);

			return users.FirstOrDefault();
		}

		/// <summary>
		/// Возвращает расширенную информацию о пользователе.
		/// </summary>
		/// <param name="screenName"> Короткое имя пользователя </param>
		/// <param name="fields"> Поля профилей, которые необходимо возвратить. </param>
		/// <param name="nameCase"> Падеж для склонения имени и фамилии пользователя </param>
		/// <returns> Объект User </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/users.get
		/// </remarks>
		public User Get([NotNull]
						string screenName
						, ProfileFields fields = null
						, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNullOrEmpty(expr: () => screenName);

			var users = Get(screenNames: new[] { screenName }, fields: fields, nameCase: nameCase);

			return users.Count > 0 ? users[index: 0] : null;
		}
	}
}