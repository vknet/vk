using System.Linq;
using System.Security.Policy;
using VkNet.Model.Attachments;

namespace VkNet.Categories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using Enums;
	using Enums.Filters;
	using Enums.SafetyEnums;
	using Model;
	using Utils;
	using Model.RequestParams;

	/// <summary>
	/// Методы для работы с сообществами (группами).
	/// </summary>
	public partial class GroupsCategory
	{
		private readonly VkApi _vk;

		internal GroupsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Данный метод позволяет вступить в группу, публичную страницу, а также подтвердить участие во встрече.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества. положительное число (Положительное число).</param>
		/// <param name="notSure">Опциональный параметр, учитываемый, если group_id принадлежит встрече. 1 — Возможно пойду. 0 — Точно пойду. По умолчанию 0. строка (Строка).</param>
		/// <returns>
		/// В случае успешного вступления метод вернёт 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.join" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Join(long? groupId, bool? notSure = null)
		{
			var parameters = new VkParameters {
				{ "group_id", groupId },
				{ "not_sure", notSure }
			};

			return _vk.Call("groups.join", parameters);
		}

		/// <summary>
		/// Позволяет покинуть сообщество.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.leave" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Leave(long groupId)
		{
			var parameters = new VkParameters {
				{ "group_id", groupId }
			};

			return _vk.Call("groups.leave", parameters);
		}

		/// <summary>
		/// Возвращает список сообществ указанного пользователя.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает список идентификаторов сообществ id, в которых состоит пользователь user_id.
		/// Если был задан параметр extended=1,  возвращает список объектов group.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.get" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Group> Get(GroupsGetParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(() => @params.UserId);
			var response = _vk.Call("groups.get", @params, true);
			// в первой записи количество членов группы для (response["items"])
			if (@params.Extended == null || !@params.Extended.Value)
			{
				return response["items"].ToReadOnlyCollectionOf(id => new Group { Id = id });
			}
			return response["items"].ToReadOnlyCollectionOf<Group>(r => r);
		}

		/// <summary>
		/// Возвращает информацию о заданном сообществе или о нескольких сообществах.
		/// </summary>
		/// <param name="groupIds">Идентификаторы или короткие имена сообществ. Максимальное число идентификаторов — 500. список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <param name="groupId">Идентификатор или короткое имя сообщества. строка (Строка).</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть. Возможные значения: city, country, place, description, wiki_page, members_count, counters, start_date, finish_date, can_post, can_see_all_posts, activity, status, contacts, links, fixed_post, verified, site,ban_info.
		/// Обратите внимание, для получения некоторых полей требуется право доступа groups. Подробнее см. описание полей объекта group список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов group.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getById" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds, string groupId, GroupsFields fields)
		{
			var parameters = new VkParameters {
				{ "group_ids", groupIds },
				{ "group_id", groupId },
				{ "fields", fields }
			};

			return _vk.Call("groups.getById", parameters).ToReadOnlyCollectionOf<Group>(x => x);
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
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getMembers" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetMembers(out int totalCount, GroupsGetMembersParams @params)
		{
			var response = _vk.Call("groups.getMembers", @params, true);
			totalCount = response["count"];
			VkResponseArray users = response["items"];
			return users.ToReadOnlyCollectionOf<User>(x => @params.Fields != null? x : new User {Id = x});
		}

		/// <summary>
		/// Возвращает информацию о том, является ли пользователь участником сообщества.
		/// </summary>
		/// <param name="groupId">Идентификатор или короткое имя сообщества. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="userId">Идентификатор пользователя. положительное число (Положительное число).</param>
		/// <param name="userIds">Идентификаторы пользователей, не более 500. список положительных чисел, разделенных запятыми (Список положительных чисел, разделенных запятыми).</param>
		/// <param name="extended">1  — вернуть ответ в расширенной форме. По умолчанию — 0. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// возвращает <c>true</c> в случае, если пользователь с идентификатором user_id является участником сообщества с идентификатором group_id, иначе 0.
		///
		/// При использовании параметра extended Возвращает объект, который содержит поля:
		///
		/// member — является ли пользователь участником сообщества;
		/// и может содержать поля:
		///
		/// request — есть ли непринятая заявка от пользователя на вступление в группу (такую заявку можно отозвать методом groups.leave);
		/// invitation — приглашён ли пользователь в группу или встречу.
		///
		///
		/// При передаче нескольких идентификаторов Возвращает результат в виде массива объектов, в которых есть поля user_id и member.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.isMember" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<GroupMember> IsMember(string groupId, long? userId, IEnumerable<long> userIds, bool? extended)
		{
			if (userId.HasValue)
			{
				if (userIds != null)
				{
					if (userIds.Any(id => id < 1))
					{
						throw new ArgumentException("Идентификатор пользователя должен быть больше 0");
					}
					userIds.ToList().Add(userId.Value);
				}
				else
				{
					if (userId.Value < 1)
					{
						throw new ArgumentException("Идентификатор пользователя должен быть больше 0");
					}
					userIds = new List<long>
					{
						userId.Value
					};
				}
			}
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_ids", userIds },
				{ "extended", extended }
			};
			var result = _vk.Call("groups.isMember", parameters, true);

			return result.ToReadOnlyCollectionOf<GroupMember>(x => x);
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
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.search" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Group> Search(out int totalCount, GroupsSearchParams @params)
		{
			var response = _vk.Call("groups.search", @params, true);

			totalCount = response["count"];

			return response["items"].ToReadOnlyCollectionOf<Group>(r => r);
		}

		/// <summary>
		/// Данный метод возвращает список приглашений в сообщества и встречи текущего пользователя.
		/// </summary>
		/// <param name="offset">Смещение, необходимое для выборки определённого подмножества приглашений. положительное число (Положительное число).</param>
		/// <param name="count">Количество приглашений, которое необходимо вернуть. положительное число, по умолчанию 20 (Положительное число, по умолчанию 20).</param>
		/// <param name="extended">1 — вернуть дополнительную информацию о пользователях, отправлявших приглашения. По умолчанию — 0. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов сообществ с дополнительным полем invited_by, содержащим идентификатор пользователя, который отправил приглашение.
		/// Если был передан параметр extended=1, дополнительно будет возвращен список profiles пользователей, отправивших приглашения. Каждый объект в списке содержит поля id, first_name, last_name.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getInvites" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Group> GetInvites( long? count, long? offset, bool? extended = null)
		{
			var parameters = new VkParameters {
				{ "offset", offset },
				{ "count", count },
				{ "extended", extended }
			};

			return _vk.Call("groups.getInvites", parameters).ToReadOnlyCollectionOf<Group>(x => x);
		}

		/// <summary>
		/// Добавляет пользователя в черный список группы.
		/// </summary>
		/// <param name="groupId">Идентификатор группы.</param>
		/// <param name="userId">Идентификатор пользователя, которого нужно добавить в черный список.</param>
		/// <param name="endDate">Дата завершения срока действия бана. Если параметр не указан пользователь будет заблокирован навсегда.</param>
		/// <param name="reason">Причина бана <see cref="BanReason"/>.</param>
		/// <param name="comment">Текст комментария к бану.</param>
		/// <param name="commentVisible"><see langword="true"/> – текст комментария будет отображаться пользователю. false – текст комментария не доступен
		/// пользователю (по умолчанию).</param>
		/// <returns>После успешного выполнения возвращает true.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.banUser"/>.
		/// </remarks>
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
		/// Добавляет пользователя в черный список сообщества.
		/// </summary>
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.banUser" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool BanUser(GroupsBanUserParams @params)
		{
			return _vk.Call("groups.banUser", @params);
		}

		/// <summary>
		/// Возвращает список забаненных пользователей в сообществе.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества черного списка. положительное число (Положительное число).</param>
		/// <param name="count">Количество пользователей, которое необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 200 (Положительное число, по умолчанию 20, максимальное значение 200).</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, lists, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <param name="userId">Идентификатор пользователя, который можно передать для получения статуса бана отдельного пользователя. положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов user с дополнительным полем ban_info.
		/// Объект ban_info — информация о внесении в черный список сообщества.
		/// admin_id идентификатор администратора, который добавил пользователя в черный список.
		///  положительное число date дата добавления пользователя в черный список в формате Unixtime.
		///  положительное число reason причина добавления пользователя в черный список. Возможные значения:
		///
		/// 0 — другое (по умолчанию);
		/// 1 — спам;
		/// 2 — оскорбление участников;
		/// 3 — нецензурные выражения;
		/// 4 — сообщения не по теме.
		///
		///  int (числовое значение) comment текст комментария.
		///  строка end_date дата окончания блокировки (0 — блокировка вечная).
		///  int (числовое значение).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getBanned" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetBanned(long groupId, long? offset = null, long? count = null, GroupsFields fields = null, long? userId = null)
		{
			var parameters = new VkParameters {
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields },
				{ "user_id", userId }
			};

			return _vk.Call("groups.getBanned", parameters).ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Убирает пользователя из черного списка сообщества.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества</param>
		/// <param name="userId">Идентификатор пользователя, которого нужно убрать из черного списка</param>
		/// <returns>После успешного выполнения возвращает <c>true</c>.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.unbanUser"/>.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool UnbanUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);
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
		/// <param name="params">Входные параметры выборки.</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.editManager" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool EditManager(GroupsEditManagerParams @params)
		{
			return _vk.Call("groups.editManager", @params);
		}

		/// <summary>
		/// Позволяет получать данные, необходимые для отображения страницы редактирования данных сообщества.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, данные которого необходимо получить. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения метод вернет объект, содержащий данные сообщества, которые позволят отобразить форму редактирования для метода groups.edit.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getSettings" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public GroupInfo GetSettings(long groupId)
		{
			// TODO требует доработки
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			var parameters = new VkParameters
			{
				{"group_id", groupId}
			};

			return _vk.Call("groups.getSettings", parameters);
		}


		/// <summary>
		/// Редактирует сообщество.
		/// </summary>
		/// <param name="params">Параметры запроса.</param>
		/// <returns>
		/// В случае успеха возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.edit" />.
		/// </remarks>
		public bool Edit(GroupsEditParams @params)
		{
			var parameters = @params;

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
		[ApiVersion("5.44")]
		public bool EditPlace(long groupId, Place place = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
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
		/// <param name="groupId">Идентификатор группы, список приглашенных в которую пользователей нужно вернуть. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="offset">Смещение, необходимое для выборки определённого подмножества пользователей. положительное число (Положительное число).</param>
		/// <param name="count">Количество пользователей, информацию о которых нужно вернуть. положительное число, по умолчанию 20 (Положительное число, по умолчанию 20).</param>
		/// <param name="fields">Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <param name="nameCase">Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка (Строка).</param>
		/// <returns></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getInvitedUsers" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetInvitedUsers(long groupId, out int userCount, long? offset = null, long? count = null, UsersFields fields = null, NameCase nameCase = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
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
		/// <param name="groupId">Идентификатор группы, в которую необходимо выслать приглашение положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="userId">Идентификатор пользователя, которому необходимо выслать приглашение положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.invite" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Invite(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.invite", parameters);
		}

		/// <summary>
		/// Позволяет добавлять ссылки в сообщество.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, в которое добавляется ссылка положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="link">Адрес ссылки строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="text">Текст ссылки строка (Строка).</param>
		/// <returns>
		/// В случае успешного выполнения возвращает объект со следующими полями:
		///
		///
		/// id — идентификатор ссылки;
		/// url — URL ссылки;
		/// name — название ссылки в блоке сообщества;
		/// edit_title — возвращается 1, если можно редактировать название ссылки (для внешних ссылок);
		/// desc — описание ссылки;
		/// image_processing — возвращается 1, если превью находится в процессе обработки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.addLink" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public Link AddLink(long groupId, Url link, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
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
		/// <param name="groupId">Идентификатор сообщества, ссылки которого нужно удалить положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="linkId">Идентификатор ссылки, которую необходимо удалить положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <returns>
		/// В случае успешного выполнения метод возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.deleteLink" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool DeleteLink(long groupId, ulong linkId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
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
		/// <param name="groupId">Идентификатор сообщества, в которое добавляется ссылка положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="linkId">Идентификатор редактируемой ссылки положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="text">Новое описание ссылки строка (Строка).</param>
		/// <returns>
		/// В случае успешного редактирования ссылки метод возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.editLink" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool EditLink(long groupId, ulong linkId, string text)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "text", text }
			};
			return _vk.Call("groups.editLink", parameters);
		}

		/// <summary>
		/// Позволяет менять местоположение ссылки в списке.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, внутри которой перемещается ссылка положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="linkId">Идентификатор ссылки, которую необходимо переместить положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="after">Идентификатор ссылки после которой необходимо разместить перемещаемую ссылку. 0 – если ссылку нужно разместить в начале списка. положительное число (Положительное число).</param>
		/// <returns>
		/// В случае успешного выполнение метод возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.reorderLink" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool ReorderLink(long groupId, long linkId, long? after)
		{
			var parameters = new VkParameters {
				{ "group_id", groupId },
				{ "link_id", linkId },
				{ "after", after }
			};

			return _vk.Call("groups.reorderLink", parameters);
		}

		/// <summary>
		/// Позволяет исключить пользователя из группы или отклонить заявку на вступление.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, из которой необходимо исключить пользователя.</param>
		/// <param name="userId">Идентификатор пользователя, которого нужно исключить.</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.removeUser" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool RemoveUser(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.removeUser", parameters);
		}

		/// <summary>
		/// Позволяет одобрить заявку в группу от пользователя.
		/// </summary>
		/// <param name="groupId">Идентификатор группы, заявку в которую необходимо одобрить.</param>
		/// <param name="userId">Идентификатор пользователя, заявку которого необходимо одобрить.</param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="https://vk.com/dev/groups.approveRequest" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool ApproveRequest(long groupId, long userId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);
			VkErrors.ThrowIfNumberIsNegative(() => userId);
			var parameters = new VkParameters
			{
				{ "group_id", groupId },
				{ "user_id", userId }
			};

			return _vk.Call("groups.approveRequest", parameters);
		}

		/// <summary>
		/// Создает новое сообщество.
		/// </summary>
		/// <param name="title">Название сообщества. строка, обязательный параметр (Строка, обязательный параметр).</param>
		/// <param name="description">Описание сообщества, (не учитывается при type=public). строка (Строка).</param>
		/// <param name="type">Тип создаваемого сообщества:
		///
		/// group — группа;
		/// event — мероприятие;
		/// public — публичная страница.
		/// строка, по умолчанию group (Строка, по умолчанию group).</param>
		/// <param name="subtype">Вид публичной страницы (только при type=public):
		///
		/// 1 — место или небольшая компания;
		/// 2 — компания, организация или веб-сайт;
		/// 3 — известная личность или коллектив;
		/// 4 — произведение или продукция.
		/// положительное число (Положительное число).</param>
		/// <returns>
		/// Возвращает идентификатор созданного сообщества.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.create" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public Group Create(string title, string description, GroupType type, GroupSubType? subtype)
		{
			var parameters = new VkParameters {
				{ "title", title },
				{ "description", description },
				{ "type", type },
				{ "subtype", subtype }
			};

			return _vk.Call("groups.create", parameters);
		}

		/// <summary>
		/// Возвращает список заявок на вступление в сообщество.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества (указывается без знака «минус»). положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества результатов. По умолчанию — 0. положительное число (Положительное число).</param>
		/// <param name="count">Число результатов, которые необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 200 (Положительное число, по умолчанию 20, максимальное значение 200).</param>
		/// <param name="fields">Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание.
		/// Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters, screen_name, maiden_name, timezone, occupation,activities, interests, music, movies, tv, books, games, about, quotes список строк, разделенных через запятую (Список строк, разделенных через запятую).</param>
		/// <returns>
		/// Возвращает список идентификаторов пользователей, отправивших заявки на вступление в сообщество.
		/// Если было передано значение в параметре fields, возвращается список объектов пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getRequests" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public ReadOnlyCollection<User> GetRequests(long groupId, long? offset, long? count, UsersFields fields)
		{
			var parameters = new VkParameters {
				{ "group_id", groupId },
				{ "offset", offset },
				{ "count", count },
				{ "fields", fields }
			};

			return _vk.Call("groups.getRequests", parameters).ToReadOnlyCollectionOf<User>(x => x);
		}

		/// <summary>
		/// Возвращает список сообществ выбранной категории каталога.
		/// </summary>
		/// <param name="categoryId">Идентификатор категории, полученный в методе groups.getCatalogInfo. положительное число (Положительное число).</param>
		/// <param name="subcategoryId">Идентификатор подкатегории, полученный в методе groups.getCatalogInfo. положительное число, максимальное значение 99 (Положительное число, максимальное значение 99).</param>
		/// <returns>
		/// Возвращает список объектов сообществ в соответствии с выбранной категорией каталога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getCatalog" />.
		/// </remarks>
		public VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null)
		{
			var parameters = new VkParameters {
				{ "category_id", categoryId },
				{ "subcategory_id", subcategoryId }
			};

			return new VkCollection<Group>(_vk.Call("groups.getCatalog", parameters, true));
		}

		/// <summary>
		/// Возвращает список категорий для каталога сообществ.
		/// </summary>
		/// <param name="extended">1 — вернуть информацию о количестве сообществ в категории и три сообщества для предпросмотра.
		/// По умолчанию 0. флаг, может принимать значения 1 или 0, по умолчанию 0, доступен начиная с версии 5.37 (Флаг, может принимать значения 1 или 0, по умолчанию 0, доступен начиная с версии 5.37).</param>
		/// <param name="subcategories">1 — вернуть информацию об подкатегориях.
		/// По умолчанию 0. флаг, может принимать значения 1 или 0, по умолчанию 0, доступен начиная с версии 5.37 (Флаг, может принимать значения 1 или 0, по умолчанию 0, доступен начиная с версии 5.37).</param>
		/// <returns>
		/// После успешного выполнения возвращает поле enabled (0 — каталог недоступен для пользователя, 1 — каталог доступен), и, если enabled=1, массив categories объектов — категорий товаров.
		/// Объект массива categories — категория каталога товаров.
		/// id идентификатор категории.
		///  положительное число name название категории.
		///  строка subcategories поле возвращается при использовании subcategories=1. Массив объектов-подкатегорий. Каждый из объектов содержит поля id и name, содержащие идентификатор и название подкатегории.
		/// Дополнительные поля (extended=1)
		/// page_count количество сообществ в категории.
		///  положительное число page_previews массив объектов сообществ для предпросмотра.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getCatalogInfo" />.
		/// </remarks>
		public GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null)
		{
			var parameters = new VkParameters {
				{ "extended", extended },
				{ "subcategories", subcategories }
			};

			return _vk.Call("groups.getCatalogInfo", parameters, true);
		}
	}
}
