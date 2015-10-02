using System.Security.Policy;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using JetBrains.Annotations;
	
	using Enums;
	using Enums.Filters;
	using Enums.SafetyEnums;
	using Model;
	using Utils;

	/// <summary>
	/// Методы для работы с сообществами (группами).
	/// </summary>
	public class GroupsCategory
	{
		private readonly VkApi _vk;

		internal GroupsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Данный метод позволяет вступить в группу, публичную страницу, а также подтверждать об участии во встрече.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <param name="notSure">True - Возможно пойду. False - Точно пойду. По умолчанию false.</param>
		/// <returns>В случае успешного вступления в группу метод вернёт true, иначе false.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Groups"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.join"/>.
		/// </remarks>
		public bool Join(long gid, bool notSure = false)
		{
			var parameters = new VkParameters { { "gid", gid }, { "not_sure", notSure } };

			return _vk.Call("groups.join", parameters);
		}

		/// <summary>
		/// Данный метод позволяет выходить из группы, публичной страницы, или встречи.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <returns>В случае успешного выхода из группы метод вернёт true, иначе false.</returns>
		/// <remarks>
		/// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Groups"/>.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.leave"/>.
		/// </remarks>
		public bool Leave(long gid)
		{
			var parameters = new VkParameters { { "gid", gid } };

			return _vk.Call("groups.leave", parameters);
		}

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
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.get" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.28")]
		public ReadOnlyCollection<Group> Get(long uid, bool extended = false, GroupsFilters filters = null, GroupsFields fields = null, int offset = 0, uint count = 1000)
		{
			var parameters = new VkParameters
			{
				{ "uid", uid },
				{ "extended", extended },
				{ "filter", filters },
				{ "fields", fields },
				{ "offset", offset }
			};
			if (count < 1000)
			{
				parameters.Add("userCount", count);
			}
			var response = _vk.Call("groups.get", parameters);
			// в первой записи количество членов группы для (response["items"])
			return !extended ? response.ToReadOnlyCollectionOf(id => new Group { Id = id }) : response["items"].ToReadOnlyCollectionOf<Group>(r => r);
		}

		/// <summary>
		/// Возвращает информацию о нескольких группах.
		/// </summary>
		/// <param name="gids">Список идентификаторов или коротких имен сообществ.</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getById"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<Group> GetById(IEnumerable<long> gids, GroupsFields fields = null)
		{
			return GetById(gids.Select(x => x.ToString()), fields);
		}

		/// <summary>
		/// Возвращает информацию о нескольких группах.
		/// </summary>
		/// <param name="gids">Список идентификаторов или коротких имен сообществ.</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getById"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<Group> GetById(IEnumerable<string> gids, GroupsFields fields = null)
		{
			var parameters = new VkParameters { { "gids", gids }, { "fields", fields } };

			VkResponseArray response = _vk.Call("groups.getById", parameters);
			return response.ToReadOnlyCollectionOf<Group>(x => x);
		}

		/// <summary>
		/// Возвращает информацию о заданной группе.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getById"/>.
		/// </remarks>
		[Pure]
		public Group GetById(long gid, GroupsFields fields = null)
		{
			return GetById(gid.ToString(), fields);
		}


		/// <summary>
		/// Возвращает информацию о заданной группе.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества.</param>
		/// <param name="fields">Список полей информации о группах</param>
		/// <returns>Список групп</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getById"/>.
		/// </remarks>
		[Pure]
		public Group GetById(string gid, GroupsFields fields = null)
		{
			var parameters = new VkParameters { { "gid", gid }, { "fields", fields } };

			return _vk.Call("groups.getById", parameters)[0];
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
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getMembers" />.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<long> GetMembers(long gid, out int totalCount, int? count = null, int? offset = null, GroupsSort sort = null, GroupsFields fields = null, GroupsFilters filters = null)
		{
			return GetMembers(gid.ToString(), out totalCount, count, offset, sort, fields, filters);
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
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getMembers"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<long> GetMembers(string gid, out int totalCount, int? count = null, int? offset = null, GroupsSort sort = null, GroupsFields fields = null, GroupsFilters filters = null)
		{
			var parameters = new VkParameters
			{
				{ "gid", gid },
				{ "offset", offset },
				{ "sort", sort },
				{ "fields", fields },
				{ "filter", filters }
			};

			if (count.HasValue && count.Value > 0 && count.Value < 1000)
			{
				parameters.Add("count", count);
			}

			var response = _vk.Call("groups.getMembers", parameters, true);

			totalCount = response["count"];

			VkResponseArray users = response["users"];
			return users.ToReadOnlyCollectionOf<long>(x => x);
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Id группы</param>
		/// <param name="uid">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.isMember"/>.
		/// </remarks>
		[Pure]
		public bool IsMember(long gid, long uid)
		{
			return IsMember(gid.ToString(), uid);
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества. </param>
		/// <param name="uid">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.isMember"/>.
		/// </remarks>
		[Pure]
		public bool IsMember(string gid, long uid)
		{
			var parameters = new VkParameters
			{
				{ "gid", gid },
				{ "uid", uid }
			};

			return _vk.Call("groups.isMember", parameters);
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества. </param>
		/// <param name="uids">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.isMember"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<GroupMember> IsMember(string gid, IEnumerable<long> uids)
		{
			var parameters = new VkParameters
			{
				{ "group_id",  gid },
				{ "user_ids", string.Join(", ", uids) }
			};
			var response = _vk.Call("groups.isMember", parameters);
			return response.ToReadOnlyCollectionOf<GroupMember>(x => x);
		}

		/// <summary>
		/// Возвращает информацию о том является ли пользователь участником заданной группы.
		/// </summary>
		/// <param name="gid">Идентификатор или короткое имя сообщества. </param>
		/// <param name="uids">Id пользователя</param>
		/// <returns>True если пользователь состоит в группе, иначе False</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.isMember"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<GroupMember> IsMember(long gid, IEnumerable<long> uids)
		{
			return IsMember(gid.ToString(), uids);
		}

		/// <summary>
		/// Осуществляет поиск групп по заданной подстроке.
		/// </summary>
		/// <param name="query">Поисковый запрос</param>
		/// <param name="totalCount">Общее количество групп удовлетворяющих запросу</param>
		/// <param name="offset">Смещение</param>
		/// <param name="count">Количество в выбоке</param>
		/// <param name="fields">Поля. В документации не указан <see cref="http://vk.com/dev/groups.search"/>.</param>
		/// <param name="sort">Порядок сортировки полученных групп.</param>
		/// <param name="type">Тип сообщества.</param>
		/// <param name="countryId">Идентификатор страны.</param>
		/// <param name="cityId">Идентификатор города. При передаче этого параметра поле country_id игнорируется.</param>
		/// <returns>
		/// Список объектов групп
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.search" />.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<Group> Search([NotNull] string query, out int totalCount, int? offset = null, int? count = null, GroupsFields fields = null, GroupSort sort = GroupSort.Normal, GroupType type = null, int? countryId = null, int? cityId = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => query);
			
			var parameters = new VkParameters
			{
				{ "q", query },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "sort", sort },
				{ "type", type },
				{ "country_id", countryId },
				{ "city_id", cityId }
			};

			VkResponseArray response = _vk.Call("groups.search", parameters);

			totalCount = response[0];

			return response.Skip(1).ToReadOnlyCollectionOf<Group>(r => r);
		}

		/// <summary>
		/// Данный метод возвращает список приглашений в сообщества и встречи.
		/// </summary>
		/// <param name="count">количество приглашений, которое необходимо вернуть</param>
		/// <param name="offset">смещение, необходимое для выборки определённого подмножества приглашений</param>
		/// <returns>После успешного выполнения возвращает список объектов сообществ с дополнительным полем InvitedBy, содержащим идентификатор пользователя, который отправил приглашение.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getInvites"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<Group> GetInvites(int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
				{
					{"count", count},
					{"offset", offset}
				};
			VkResponseArray response = _vk.Call("groups.getInvites", parameters);

			return response.Skip(1).ToReadOnlyCollectionOf<Group>(x => x);
		}

		/// <summary>
		/// Добавляет пользователя в черный список группы.
		/// </summary>
		/// <param name="groupId">Идентификатор группы.</param>
		/// <param name="userId">Идентификатор пользователя, которого нужно добавить в черный список.</param>
		/// <param name="endDate">Дата завершения срока действия бана. Если параметр не указан пользователь будет заблокирован навсегда.</param>
		/// <param name="reason">Причина бана <see cref="BanReason"/>.</param>
		/// <param name="comment">Текст комментария к бану.</param>
		/// <param name="commentVisible">true – текст комментария будет отображаться пользователю. false – текст комментария не доступен 
		/// пользователю (по умолчанию).</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.banUser"/>.
		/// </remarks>
		public bool BanUser(ulong groupId, ulong userId, DateTime? endDate = null, BanReason? reason = null,
							string comment = "", bool commentVisible = false)
		{
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
		/// Возвращает список забаненных пользователей в сообществе
		/// </summary>
		/// <param name="groupId">идентификатор сообщества</param>
		/// <param name="count">количество записей, которое необходимо вернуть</param>
		/// <param name="offset">смещение, необходимое для выборки определенного подмножества черного списка</param>
		/// <returns>После успешного выполнения возвращает список объектов пользователей с дополнительным полем <see cref="BanInfo"/></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getBanned"/>.
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<User> GetBanned(ulong groupId, uint? count = null, uint? offset = null)
		{
			var parameters = new VkParameters
				{
					{"group_id", groupId},
					{"offset", offset},
					{"count", count}
				};

			VkResponseArray response = _vk.Call("groups.getBanned", parameters);

			return response.Skip(1).ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Убирает пользователя из черного списка сообщества.
		/// </summary>
		/// <param name="groupId">идентификатор сообщества</param>
		/// <param name="userId">идентификатор пользователя, которого нужно убрать из черного списка</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.unbanUser"/>.
		/// </remarks>
		public bool UnbanUser(ulong groupId, ulong userId)
		{
			var parameters = new VkParameters
				{
					{"group_id", groupId},
					{"user_id", userId}
				};

			return _vk.Call("groups.unbanUser", parameters);
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
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.editManager"/>.
		/// </remarks>
		[ApiVersion("5.28")]
		public bool EditManager(ulong groupId, ulong userId, AdminLevel? role, bool? isContact = null, string contactPosition = null, string contactPhone = null, string contactEmail = null)
		{
			var parameters = new VkParameters
				{
					{"group_id", groupId},
					{"user_id", userId},
					{"role", role},
					{"is_contact", isContact},
					{"contact_position", contactPosition},
					{"contact_phone", contactPhone},
					{"contact_email", contactEmail}
				};

			return _vk.Call("groups.unbanUser", parameters);
		}
		/// <summary>
		/// Позволяет назначить/разжаловать руководителя в сообществе или изменить уровень его полномочий.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества (указывается без знака «минус»)</param>
		/// <param name="userId">Идентификатор пользователя, чьи полномочия в сообществе нужно изменить</param>
		/// <param name="role">Уровень полномочий. Если параметр не задан, с пользователя user_id снимаются полномочия руководителя</param>
		/// <returns>В случае успешного выполнения возвращает true</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.editManager"/>.
		/// </remarks>
		public bool EditManager(ulong groupId, ulong userId, AdminLevel? role)
		{
			return EditManager(groupId, userId, role, null);
		}

		/// <summary>
		/// Позволяет получать данные, необходимые для отображения страницы редактирования данных сообщества.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, данные которого необходимо получить.</param>
		/// <returns>
		/// В случае успешного выполнения метод вернет объект, содержащий данные сообщества,
		/// которые позволят отобразить форму редактирования для метода <see href="http://vk.com/dev/groups.edit"/>.
		/// </returns>
		/// <remarks>
		/// Для того, чтобы воспользоваться этим методом Вы должны быть администратором группы.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getSettings"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public GroupInfo GetSettings(long groupId)
		{
			var parameters = new VkParameters
				{
					{"group_id", groupId}
				};
			return _vk.Call("groups.getSettings", parameters);
		}

		/// <summary>
		/// Позволяет редактировать информацию групп.
		/// </summary>
		/// <param name="groupId">Идентификатор группы.</param>
		/// <param name="groupInfo">Информация о группе.</param>
		/// <returns></returns>
		/// <remarks>
		/// Для того, чтобы воспользоваться этим методом Вы должны быть администратором группы.
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.edit"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool Edit(long groupId, GroupInfo groupInfo)
		{
			var parameters = new VkParameters
			{
				{"group_id", groupId},
				{"title", groupInfo.Title},
				{"description", groupInfo.Description},
				{"address", groupInfo.Address},
				{"place", groupInfo.Place},
				{"wall", groupInfo.Wall},
				{"photos", groupInfo.Photos},
				{"video", groupInfo.Video},
				{"audio", groupInfo.Audio},
				{"docs", groupInfo.Docs},
				{"topics", groupInfo.Topics},
				{"wiki", groupInfo.Wiki},
				{"access", groupInfo.Access},
				{"subject", groupInfo.Subject},
				{"website", groupInfo.Website},
				{"contacts", groupInfo.Contacts},
				{"places", groupInfo.Places},
				{"events", groupInfo.Events},
				{"links", groupInfo.Links},
				{"public_date", groupInfo.PublicDate},
				{"public_subcategory", groupInfo.PublicSubcategory},
				{"public_category", groupInfo.PublicCategory},
				{"event_group_id", groupInfo.EventGroupId},
				{"event_finish_date", groupInfo.EventFinishDate},
				{"event_start_date", groupInfo.EventStartDate},
				{"rss", groupInfo.Rss},
				{"phone", groupInfo.Phone},
				{"email", groupInfo.Email},
				{"screen_name", groupInfo.ScreenName}
			};
			return _vk.Call("groups.edit", parameters);
		}

		/// <summary>
		/// Позволяет редактировать информацию о месте группы.
		/// Для удаления информации о местоположении нужно передать только group_id.
		/// Для обновления данных о местоположении необходимо указать как минимум id страны, широту и долготу.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, информацию о месте которой нужно отредактировать.</param>
		/// <param name="place">Местоположение.</param>
		/// <remarks>
		/// Для того, чтобы воспользоваться этим методом Вы должны быть администратором группы.
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.editPlace"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool EditPlace(long groupId, Place place = null)
		{
			if (place == null)
			{
				place = new Place();
			}
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "title", place.Title },
				{ "address", place.Address },
				{ "country_id", place.CountryId },
				{ "city_id", place.CityId },
				{ "latitude", place.Latitude },
				{ "longitude", place.Longitude }
			};
			var result = _vk.Call("groups.editPlace", parameters);
			return result["success"];
		}

		/// <summary>
		/// Возвращает список пользователей, которые были приглашены в группу.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, список приглашенных в которую пользователей нужно вернуть.</param>
		/// <param name="userCount">Количество пользователей.</param>
		/// <param name="offset">Смещение, необходимое для выборки определённого подмножества пользователей. </param>
		/// <param name="count">Количество пользователей, информацию о которых нужно вернуть. </param>
		/// <param name="fields">Дополнительные поля с информацией о пользователе.</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. </param>
		/// <returns></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.getInvitedUsers"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<User> GetInvitedUsers(long groupId, out int userCount, uint offset = 0, uint count = 20, UsersFields fields = null, NameCase nameCase = null)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "name_case", nameCase }
			};
			var response = _vk.Call("groups.getInvitedUsers", parameters);
			userCount = response["count"];
			return response["items"].ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Позволяет приглашать друзей в группу.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, в которую необходимо выслать приглашение </param>
		/// <param name="userId">Идентификатор пользователя, которому необходимо выслать приглашение </param>
		/// <returns>В случае успешного выполнения возвращает 1.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.invite"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool Invite(ulong groupId, ulong userId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};
			return _vk.Call("groups.invite", parameters);
		}

		/// <summary>
		/// Позволяет приглашать друзей в группу.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, в которую необходимо выслать приглашение</param>
		/// <param name="link">Ссылка.</param>
		/// <param name="text">Текст ссылки.</param>
		/// <returns>
		/// В случае успешного выполнения возвращает объект ссылки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.addLink" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public Link AddLink(ulong groupId, Url link, string text)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link", link.Value },
				{ "text", text }
			};
			return _vk.Call("groups.addLink", parameters);
		}

		/// <summary>
		/// Позволяет удалить ссылки из сообщества.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, ссылки которого нужно удалить.</param>
		/// <param name="linkId">Идентификатор ссылки, которую необходимо удалить.</param>
		/// <returns>В случае успешного выполнения возвращает 1.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.deleteLink"/>.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool DeleteLink(ulong groupId, ulong linkId)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId }
			};
			return _vk.Call("groups.deleteLink", parameters);
		}

		/// <summary>
		/// Позволяет редактировать ссылки в сообществе.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, в которое добавляется ссылка.</param>
		/// <param name="linkId">Идентификатор редактируемой ссылки.</param>
		/// <param name="text">Новое описание ссылки.</param>
		/// <returns>
		/// В случае успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.editLink" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public bool EditLink(ulong groupId, ulong linkId, string text)
		{
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "text", text }
			};
			return _vk.Call("groups.editLink", parameters);
		}
	}
}
