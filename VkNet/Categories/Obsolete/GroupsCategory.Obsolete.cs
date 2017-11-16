using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с сообществами (группами).
	/// </summary>
	public partial class GroupsCategory
	{

		/// <summary>
		/// Возвращает список групп указанного пользователя.
		/// </summary>
		/// <param name="uid">Id пользователя</param>
		/// <param name="extended">Возвращать полную информацию?</param>
		/// <param name="filters">Список фильтров сообществ</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <param name="offset">Смещение, необходимое для выборки определённого подмножества сообществ.</param>
		/// <param name="count">Количество сообществ, информацию о которых нужно вернуть (Максимальное значение 1000)</param>
		/// <returns>
		/// Список групп
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.get
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте Get(GroupsGetParams @params)")]
		public ReadOnlyCollection<Group> Get(long uid, bool extended = false, GroupsFilters filters = null, GroupsFields fields = null, uint offset = 0, uint count = 1000)
		{
			VkErrors.ThrowIfNumberIsNegative(() => uid);
			var parameters = new GroupsGetParams
			{
				Count = count,
				Extended = extended,
				Fields = fields,
				Filter = filters,
				Offset = offset,
				UserId = uid
			};

			return Get(parameters).ToReadOnlyCollection();
		}

		/// <summary>
		/// Возвращает информацию о нескольких группах.
		/// </summary>
		/// <param name="gids">Список идентификаторов или коротких имен сообществ.</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getById
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields)")]
		public ReadOnlyCollection<Group> GetById(IEnumerable<long> gids, GroupsFields fields = null)
		{
			foreach (var gid in gids)
				VkErrors.ThrowIfNumberIsNegative(() => gid);
			return GetById(gids.Select(x => x.ToString()), fields);
		}

		/// <summary>
		/// Возвращает информацию о нескольких группах.
		/// </summary>
		/// <param name="gids">Список идентификаторов или коротких имен сообществ.</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getById
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields)")]
		public ReadOnlyCollection<Group> GetById(IEnumerable<string> gids, GroupsFields fields = null)
		{
			return GetById(gids, null, fields);
		}

		/// <summary>
		/// Возвращает информацию о заданной группе.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getById
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields)")]
		public Group GetById(long gid, GroupsFields fields = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => gid);
			return GetById(new List<string>(), gid.ToString(), fields).FirstOrDefault();
		}

		/// <summary>
		/// Возвращает информацию о заданной группе.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества.</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getById
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields)")]
		public Group GetById(string gid, GroupsFields fields = null)
		{
			return GetById(new List<string>(), gid, fields).FirstOrDefault();
		}

		/// <summary>
		/// Возвращает список участников группы.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <param name="totalCount">Общее количество участников</param>
		/// <param name="count">Количество участников которое необходимо получить</param>
		/// <param name="offset">Смещение</param>
		/// <param name="sort">Сортировка Id пользователей</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть.</param>
		/// <param name="filters">Фильтр.</param>
		/// <returns>
		/// Id пользователей состоящих в группе
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getMembers
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetMembers(out int totalCount, GroupsGetMembersParams @params)")]
		public ReadOnlyCollection<User> GetMembers(long gid, out int totalCount, uint? count = null, uint? offset = null, GroupsSort sort = null, UsersFields fields = null, GroupsMemberFilters filters = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => gid);
			var parameters = new GroupsGetMembersParams
			{
				GroupId = gid.ToString(),
				Count = count,
				Offset = offset,
				Sort = sort,
				Fields = fields,
				Filter = filters
			};

			return GetMembers(out totalCount, parameters);
		}

		/// <summary>
		/// Возвращает список участников группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества</param>
		/// <param name="totalCount">Общее количество участников</param>
		/// <param name="count">Количество участников которое необходимо получить</param>
		/// <param name="offset">Смещение</param>
		/// <param name="sort">Сортировка Id пользователей</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть.</param>
		/// <param name="filters">Фильтр.</param>
		/// <returns>Id пользователей состоящих в группе</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getMembers
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте GetMembers(out int totalCount, GroupsGetMembersParams @params)")]
		public ReadOnlyCollection<User> GetMembers(string gid, out int totalCount, uint? count = null, uint? offset = null, GroupsSort sort = null, UsersFields fields = null, GroupsMemberFilters filters = null)
		{
			var parameters = new GroupsGetMembersParams
			{
				Offset = offset,
				Filter = filters,
				Fields = fields,
				Count = count,
				GroupId = gid,
				Sort = sort
			};

			return GetMembers(out totalCount, parameters);
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <param name="uid">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.isMember
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте IsMember(string groupId,Join long? userId, IEnumerable<string> userIds, bool? extended)")]
		public bool IsMember(long gid, long uid)
		{
			VkErrors.ThrowIfNumberIsNegative(() => gid);    // uid проверяет след. метод
			var result = IsMember(gid.ToString(), uid, null, null);

			return result.Count > 0 && result[0].Member;
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества. </param>
		/// <param name="uid">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.isMember
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте IsMember(string groupId, long? userId, IEnumerable<string> userIds, bool? extended)")]
		public bool IsMember(string gid, long uid)
		{
			VkErrors.ThrowIfNumberIsNegative(() => uid);
			var result = IsMember(gid, uid, null, null);

			return result.Count > 0 && result[0].Member;
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества. </param>
		/// <param name="uids">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.isMember
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте IsMember(string groupId, long? userId, IEnumerable<string> userIds, bool? extended)")]
		public ReadOnlyCollection<GroupMember> IsMember(string gid, IEnumerable<long> uids)
		{
			foreach (var uid in uids)
				VkErrors.ThrowIfNumberIsNegative(() => uid);

			return IsMember(gid, null, uids, null);
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества. </param>
		/// <param name="uids">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.isMember
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте IsMember(string groupId, long? userId, IEnumerable<string> userIds, bool? extended)")]
		public ReadOnlyCollection<GroupMember> IsMember(long gid, IEnumerable<long> uids)
		{
			VkErrors.ThrowIfNumberIsNegative(() => gid);    // uids проверяються в след. методе
			return IsMember(gid.ToString(), uids);
		}

		/// <summary>
		/// Осуществляет поиск групп по заданной подстроке.
		/// </summary>
		/// <param name="query">Поисковый запрос</param>
		/// <param name="totalCount">Общее количество групп удовлетворяющих запросу</param>
		/// <param name="offset">Смещение</param>
		/// <param name="count">Количество в выбоке</param>
		/// <param name="future">При передаче значения <c>true</c> будут выведены предстоящие события. Учитывается только при передаче в качестве <c>type</c> значения event.</param>
		/// <param name="sort">Порядок сортировки полученных групп.</param>
		/// <param name="type">Тип сообщества.</param>
		/// <param name="countryId">Идентификатор страны.</param>
		/// <param name="cityId">Идентификатор города. При передаче этого параметра поле country_id игнорируется.</param>
		/// <returns>
		/// Список объектов групп
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.search
		/// </remarks>
		[Pure]
		[Obsolete("Данный метод устарел. Используйте Search(out int totalCount, GroupsSearchParams @params)")]
		public ReadOnlyCollection<Group> Search([NotNull] string query, out int totalCount, uint? offset = null, uint? count = null, GroupSort sort = GroupSort.Normal, GroupType type = null, uint? countryId = null, uint? cityId = null, bool future = false)
		{
			VkErrors.ThrowIfNullOrEmpty(() => query);

			var parameters = new GroupsSearchParams
			{
				Query = query,
				Sort = sort,
				Count = count,
				Offset = offset,
				Type = type,
				CityId = cityId,
				CountryId = countryId,
				Future = future
			};
			var result = Search(parameters);

			totalCount = Convert.ToInt32(result.TotalCount);

			return result.ToReadOnlyCollection();
		}

		/// <summary>
		/// Позволяет назначить/разжаловать руководителя в сообществе или изменить уровень его полномочий.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества (указывается без знака «минус»)</param>
		/// <param name="userId">Идентификатор пользователя, чьи полномочия в сообществе нужно изменить</param>
		/// <param name="role">Уровень полномочий. Если параметр не задан, с пользователя user_id снимаются полномочия руководителя</param>
		/// <param name="isContact">Отображать ли пользователя в блоке контактов сообщества</param>
		/// <param name="contactPosition">Должность пользователя, отображаемая в блоке контактов</param>
		/// <param name="contactPhone">Телефон пользователя, отображаемый в блоке контактов</param>
		/// <param name="contactEmail">Email пользователя, отображаемый в блоке контактов</param>
		/// <returns>В случае успешного выполнения возвращает true</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editManager
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте EditManager(GroupsEditManagerParams @params)")]
		public bool EditManager(long groupId, long userId, ManagerRole role, bool? isContact = null, string contactPosition = null, string contactPhone = null, string contactEmail = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			var parameters = new GroupsEditManagerParams
			{
				GroupId = groupId,
				UserId = userId,
				ContactEmail = contactEmail,
				ContactPhone = contactPhone,
				ContactPosition = contactPosition,
				IsContact = isContact,
				Role = role
			};

			return EditManager(parameters);
		}
		/// <summary>
		/// Позволяет назначить/разжаловать руководителя в сообществе или изменить уровень его полномочий.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества (указывается без знака «минус»)</param>
		/// <param name="userId">Идентификатор пользователя, чьи полномочия в сообществе нужно изменить</param>
		/// <param name="role">Уровень полномочий. Если параметр не задан, с пользователя user_id снимаются полномочия руководителя</param>
		/// <returns>В случае успешного выполнения возвращает true</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editManager
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте EditManager(GroupsEditManagerParams @params)")]
		public bool EditManager(long groupId, long userId, ManagerRole role)
		{
			// Проверка на неотрицательные значения в след. методе
			return EditManager(groupId, userId, role, null);
		}

		/// <summary>
		/// Возвращает список участников сообщества.
		/// </summary>
		/// <param name="totalCount">Общее количество участников.</param>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// Возвращает общее количество участников сообщества count и список идентификаторов пользователей items.
		/// Если был передан параметр filter=managers, возвращается дополнительное поле role, которое содержит уровень полномочий руководителя:
		/// moderator — модератор;
		/// editor — редактор;
		/// administrator — администратор;
		/// creator — создатель сообщества.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getMembers
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте GetMembers(GroupsGetMembersParams @params)")]
		public ReadOnlyCollection<User> GetMembers(out int totalCount, GroupsGetMembersParams @params)
		{
			var response = GetMembers(@params);

			totalCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Осуществляет поиск сообществ по заданной подстроке.
		/// </summary>
		/// <param name="totalCount">Общее количество групп удовлетворяющих запросу.</param>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов group.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.search
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте Search(GroupsSearchParams @params)")]
		public ReadOnlyCollection<Group> Search(out int totalCount, GroupsSearchParams @params)
		{
			var response = Search(@params);

			totalCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}

		/// <summary>
		/// Добавляет пользователя в черный список группы.
		/// </summary>
		/// <param name="groupId">Идентификатор группы.</param>
		/// <param name="userId">Идентификатор пользователя, которого нужно добавить в черный список.</param>
		/// <param name="endDate">Дата завершения срока действия бана. Если параметр не указан пользователь будет заблокирован навсегда.</param>
		/// <param name="reason">Причина бана BanReason</param>
		/// <param name="comment">Текст комментария к бану.</param>
		/// <param name="commentVisible"><see langword="true"/> – текст комментария будет отображаться пользователю. false – текст комментария не доступен
		/// пользователю (по умолчанию).</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.banUser
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте BanUser(GroupsBanUserParams @params)")]
		public bool BanUser(long groupId, long userId, DateTime? endDate = null, BanReason? reason = null,
							string comment = "", bool commentVisible = false)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			var parameters = new VkParameters
			{
				{"group_id", groupId},
				{"user_id", userId},
				{"end_date", endDate},
				{"comment", comment},
				{"comment_visible", commentVisible},
				{"reason", reason}
			};

			return _vk.Call("groups.banUser", parameters);
		}

		/// <summary>
		/// Возвращает список пользователей, которые были приглашены в группу.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, список приглашенных в которую пользователей нужно вернуть. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="userCount"></param>
		/// <param name="offset">Смещение, необходимое для выборки определённого подмножества пользователей. положительное число (Положительное число).</param>
		/// <param name="count">Количество пользователей, информацию о которых нужно вернуть. положительное число, по умолчанию 20 (Положительное число, по умолчанию 20).</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка (Строка).</param>
		/// <returns></returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getInvitedUsers
		/// </remarks>
		[Obsolete("Данный метод устарел. Используйте GetInvitedUsers(long groupId, long? offset = null, long? count = null, UsersFields fields = null, NameCase nameCase = null)")]
		public ReadOnlyCollection<User> GetInvitedUsers(long groupId, out int userCount, long? offset = null, long? count = null, UsersFields fields = null, NameCase nameCase = null)
		{
			var response = GetInvitedUsers(groupId, offset, count, fields, nameCase);

			userCount = Convert.ToInt32(response.TotalCount);

			return response.ToReadOnlyCollection();
		}
	}
}