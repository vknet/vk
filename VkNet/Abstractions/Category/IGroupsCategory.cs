using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с сообществами (группами).
	/// </summary>
	public interface IGroupsCategory : IGroupsCategoryAsync
	{
		/// <summary>
		/// Данный метод позволяет вступить в группу, публичную страницу, а также
		/// подтвердить участие во встрече.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="notSure">
		/// Опциональный параметр, учитываемый, если group_id принадлежит встрече. 1 —
		/// Возможно пойду. 0 —
		/// Точно пойду. По умолчанию 0. строка (Строка).
		/// </param>
		/// <returns>
		/// В случае успешного вступления метод вернёт 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.join
		/// </remarks>
		bool Join(long? groupId, bool? notSure = null);

		/// <summary>
		/// Позволяет покинуть сообщество.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.leave
		/// </remarks>
		bool Leave(long groupId);

		/// <summary>
		/// Возвращает список сообществ указанного пользователя.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
		/// <returns>
		/// После успешного выполнения возвращает список идентификаторов сообществ id, в
		/// которых состоит пользователь user_id.
		/// Если был задан параметр extended=1,  возвращает список объектов group.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.get
		/// </remarks>
		VkCollection<Group> Get(GroupsGetParams @params, bool skipAuthorization = false);

		/// <summary>
		/// Возвращает информацию о заданном сообществе или о нескольких сообществах.
		/// </summary>
		/// <param name="groupIds">
		/// Идентификаторы или короткие имена сообществ. Максимальное число идентификаторов
		/// — 500. список
		/// строк, разделенных через запятую (Список строк, разделенных через запятую).
		/// </param>
		/// <param name="groupId">
		/// Идентификатор или короткое имя сообщества. строка
		/// (Строка).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей, которые необходимо вернуть. Возможные значения:
		/// city, country, place, description,
		/// wiki_page, members_count, counters, start_date, finish_date, can_post,
		/// can_see_all_posts, activity, status,
		/// contacts, links, fixed_post, verified, site,ban_info.
		/// Обратите внимание, для получения некоторых полей требуется право доступа
		/// groups. Подробнее см. описание полей
		/// объекта group список строк, разделенных через запятую (Список строк,
		/// разделенных через запятую).
		/// </param>
		/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
		/// <returns>
		/// После успешного выполнения возвращает массив объектов group.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getById
		/// </remarks>
		ReadOnlyCollection<Group> GetById(IEnumerable<string> groupIds
										, string groupId
										, GroupsFields fields
										, bool skipAuthorization = false);

		/// <summary>
		/// Возвращает список участников сообщества.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
		/// <returns>
		/// Возвращает общее количество участников сообщества count и список
		/// идентификаторов пользователей items.
		/// Если был передан параметр filter=managers, возвращается дополнительное поле
		/// role, которое содержит уровень
		/// полномочий руководителя:
		/// moderator — модератор;
		/// editor — редактор;
		/// administrator — администратор;
		/// creator — создатель сообщества.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getMembers
		/// </remarks>
		VkCollection<User> GetMembers(GroupsGetMembersParams @params, bool skipAuthorization = false);

		/// <summary>
		/// Возвращает информацию о том, является ли пользователь участником сообщества.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор или короткое имя сообщества. строка, обязательный параметр
		/// (Строка, обязательный
		/// параметр).
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя. положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="userIds">
		/// Идентификаторы пользователей, не более 500. список положительных чисел,
		/// разделенных запятыми
		/// (Список положительных чисел, разделенных запятыми).
		/// </param>
		/// <param name="extended">
		/// 1  — вернуть ответ в расширенной форме. По умолчанию — 0. флаг, может принимать
		/// значения 1 или 0
		/// (Флаг, может принимать значения 1 или 0).
		/// </param>
		/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
		/// <returns>
		/// возвращает <c> true </c> в случае, если пользователь с идентификатором user_id
		/// является участником сообщества с
		/// идентификатором group_id, иначе 0.
		/// При использовании параметра extended Возвращает объект, который содержит поля:
		/// member — является ли пользователь участником сообщества;
		/// и может содержать поля:
		/// request — есть ли непринятая заявка от пользователя на вступление в группу
		/// (такую заявку можно отозвать методом
		/// groups.leave);
		/// invitation — приглашён ли пользователь в группу или встречу.
		/// При передаче нескольких идентификаторов Возвращает результат в виде массива
		/// объектов, в которых есть поля user_id и
		/// member.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.isMember
		/// </remarks>
		ReadOnlyCollection<GroupMember> IsMember(string groupId
												, long? userId
												, IEnumerable<long> userIds
												, bool? extended
												, bool skipAuthorization = false);

		/// <summary>
		/// Осуществляет поиск сообществ по заданной подстроке.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c>, то пропустить авторизацию </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов group.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.search
		/// </remarks>
		VkCollection<Group> Search(GroupsSearchParams @params, bool skipAuthorization = false);

		/// <summary>
		/// Данный метод возвращает список приглашений в сообщества и встречи текущего
		/// пользователя.
		/// </summary>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определённого подмножества приглашений.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество приглашений, которое необходимо вернуть. положительное число, по
		/// умолчанию 20
		/// (Положительное число, по умолчанию 20).
		/// </param>
		/// <param name="extended">
		/// 1 — вернуть дополнительную информацию о пользователях, отправлявших
		/// приглашения. По умолчанию —
		/// 0. флаг, может принимать значения 1 или 0 (Флаг, может принимать значения 1 или
		/// 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов сообществ с
		/// дополнительным полем invited_by, содержащим
		/// идентификатор пользователя, который отправил приглашение.
		/// Если был передан параметр extended=1, дополнительно будет возвращен список
		/// profiles пользователей, отправивших
		/// приглашения. Каждый объект в списке содержит поля id, first_name, last_name.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getInvites
		/// </remarks>
		VkCollection<Group> GetInvites(long? count, long? offset, bool? extended = null);

		/// <summary>
		/// Добавляет пользователя в черный список сообщества.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.banUser
		/// </remarks>
		bool BanUser(GroupsBanUserParams @params);

		/// <summary>
		/// Возвращает список забаненных пользователей в сообществе.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// (Положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества черного списка.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество пользователей, которое необходимо вернуть. положительное число, по
		/// умолчанию 20,
		/// максимальное значение 200 (Положительное число, по умолчанию 20, максимальное
		/// значение 200).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: sex, bdate, city, country, photo_50, photo_100,
		/// photo_200_orig, photo_200, photo_400_orig,
		/// photo_max, photo_max_orig, online, online_mobile, lists, domain, has_mobile,
		/// contacts, connections, site,
		/// education, universities, schools, can_post, can_see_all_posts, can_see_audio,
		/// can_write_private_message, status,
		/// last_seen, common_count, relation, relatives, counters список строк,
		/// разделенных через запятую (Список строк,
		/// разделенных через запятую).
		/// </param>
		/// <param name="ownerId"> целое число </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов user с дополнительным
		/// полем ban_info.
		/// Объект ban_info — информация о внесении в черный список сообщества.
		/// admin_id идентификатор администратора, который добавил пользователя в черный
		/// список.
		/// положительное число date дата добавления пользователя в черный список в формате
		/// Unixtime.
		/// положительное число reason причина добавления пользователя в черный список.
		/// Возможные значения:
		/// 0 — другое (по умолчанию);
		/// 1 — спам;
		/// 2 — оскорбление участников;
		/// 3 — нецензурные выражения;
		/// 4 — сообщения не по теме.
		/// int (числовое значение) comment текст комментария.
		/// строка end_date дата окончания блокировки (0 — блокировка вечная).
		/// int (числовое значение).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getBanned
		/// </remarks>
		VkCollection<GetBannedResult> GetBanned(long groupId
												, long? offset = null
												, long? count = null
												, GroupsFields fields = null
												, long? ownerId = null);

		/// <summary>
		/// Убирает пользователя из черного списка сообщества.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества </param>
		/// <param name="userId">
		/// Идентификатор пользователя, которого нужно убрать из
		/// черного списка
		/// </param>
		/// <returns> После успешного выполнения возвращает <c> true </c>. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.unbanUser
		/// </remarks>
		bool UnbanUser(long groupId, long userId);

		/// <summary>
		/// Позволяет назначить/разжаловать руководителя в сообществе или изменить уровень
		/// его полномочий.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editManager
		/// </remarks>
		bool EditManager(GroupsEditManagerParams @params);

		/// <summary>
		/// Позволяет получать данные, необходимые для отображения страницы редактирования
		/// данных сообщества.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, данные которого необходимо получить. положительное
		/// число, обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения метод вернет объект, содержащий данные
		/// сообщества, которые позволят отобразить форму
		/// редактирования для метода groups.edit.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getSettings
		/// </remarks>
		GroupsEditParams GetSettings(ulong groupId);

		/// <summary>
		/// Редактирует сообщество.
		/// </summary>
		/// <param name="params"> Параметры запроса. </param>
		/// <returns>
		/// В случае успеха возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.edit
		/// </remarks>
		bool Edit(GroupsEditParams @params);

		/// <summary>
		/// Позволяет редактировать информацию о месте группы.
		/// Для удаления информации о местоположении нужно передать только group_id.
		/// Для обновления данных о местоположении необходимо указать как минимум id
		/// страны, широту и долготу.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор группы, информацию о месте которой нужно
		/// отредактировать.
		/// </param>
		/// <param name="place"> Местоположение. </param>
		/// <remarks>
		/// Для того, чтобы воспользоваться этим методом Вы должны быть администратором
		/// группы.
		/// Страница документации ВКонтакте https://vk.com/dev/groups.editPlace
		/// </remarks>
		bool EditPlace(long groupId, Place place = null);

		/// <summary>
		/// Возвращает список пользователей, которые были приглашены в группу.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор группы, список приглашенных в которую пользователей нужно
		/// вернуть. положительное
		/// число, обязательный параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определённого подмножества пользователей.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="count">
		/// Количество пользователей, информацию о которых нужно вернуть. положительное
		/// число, по умолчанию 20
		/// (Положительное число, по умолчанию 20).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: nickname, domain, sex, bdate, city, country, timezone,
		/// photo_50, photo_100, photo_200_orig,
		/// has_mobile, contacts, education, online, relation, last_seen, status,
		/// can_write_private_message, can_see_all_posts,
		/// can_post, universities список строк, разделенных через запятую (Список строк,
		/// разделенных через запятую).
		/// </param>
		/// <param name="nameCase">
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom,
		/// родительный – gen, дательный – dat, винительный – acc, творительный – ins,
		/// предложный – abl. По умолчанию nom.
		/// строка (Строка).
		/// </param>
		/// <returns> </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getInvitedUsers
		/// </remarks>
		VkCollection<User> GetInvitedUsers(long groupId
											, long? offset = null
											, long? count = null
											, UsersFields fields = null
											, NameCase nameCase = null);

		/// <summary>
		/// Позволяет приглашать друзей в группу.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор группы, в которую необходимо выслать приглашение положительное
		/// число, обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, которому необходимо выслать приглашение
		/// положительное число,
		/// обязательный параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="captchaSid"> Идентификатор капчи </param>
		/// <param name="captchaKey"> Код введенный пользователем </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.invite
		/// </remarks>
		bool Invite(long groupId, long userId, long? captchaSid = null, string captchaKey = null);

		/// <summary>
		/// Позволяет добавлять ссылки в сообщество.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, в которое добавляется ссылка положительное число,
		/// обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="link">
		/// Адрес ссылки строка, обязательный параметр (Строка,
		/// обязательный параметр).
		/// </param>
		/// <param name="text"> Текст ссылки строка (Строка). </param>
		/// <returns>
		/// В случае успешного выполнения возвращает объект со следующими полями:
		/// id — идентификатор ссылки;
		/// url — URL ссылки;
		/// name — название ссылки в блоке сообщества;
		/// edit_title — возвращается 1, если можно редактировать название ссылки (для
		/// внешних ссылок);
		/// desc — описание ссылки;
		/// image_processing — возвращается 1, если превью находится в процессе обработки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.addLink
		/// </remarks>
		ExternalLink AddLink(long groupId, Uri link, string text);

		/// <summary>
		/// Позволяет удалить ссылки из сообщества.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, ссылки которого нужно удалить положительное число,
		/// обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="linkId">
		/// Идентификатор ссылки, которую необходимо удалить положительное число,
		/// обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </param>
		/// <returns>
		/// В случае успешного выполнения метод возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.deleteLink
		/// </remarks>
		bool DeleteLink(long groupId, ulong linkId);

		/// <summary>
		/// Позволяет редактировать ссылки в сообществе.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества, в которое добавляется ссылка положительное число,
		/// обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="linkId">
		/// Идентификатор редактируемой ссылки положительное число, обязательный параметр
		/// (Положительное
		/// число, обязательный параметр).
		/// </param>
		/// <param name="text"> Новое описание ссылки строка (Строка). </param>
		/// <returns>
		/// В случае успешного редактирования ссылки метод возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editLink
		/// </remarks>
		bool EditLink(long groupId, ulong linkId, string text);

		/// <summary>
		/// Позволяет менять местоположение ссылки в списке.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор группы, внутри которой перемещается ссылка положительное число,
		/// обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="linkId">
		/// Идентификатор ссылки, которую необходимо переместить положительное число,
		/// обязательный параметр
		/// (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="after">
		/// Идентификатор ссылки после которой необходимо разместить перемещаемую ссылку. 0
		/// – если ссылку нужно
		/// разместить в начале списка. положительное число (Положительное число).
		/// </param>
		/// <returns>
		/// В случае успешного выполнение метод возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.reorderLink
		/// </remarks>
		bool ReorderLink(long groupId, long linkId, long? after);

		/// <summary>
		/// Позволяет исключить пользователя из группы или отклонить заявку на вступление.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор группы, из которой необходимо исключить
		/// пользователя.
		/// </param>
		/// <param name="userId"> Идентификатор пользователя, которого нужно исключить. </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/groups.removeUser
		/// </remarks>
		bool RemoveUser(long groupId, long userId);

		/// <summary>
		/// Позволяет одобрить заявку в группу от пользователя.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор группы, заявку в которую необходимо
		/// одобрить.
		/// </param>
		/// <param name="userId">
		/// Идентификатор пользователя, заявку которого необходимо
		/// одобрить.
		/// </param>
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/groups.approveRequest
		/// </remarks>
		bool ApproveRequest(long groupId, long userId);

		/// <summary>
		/// Создает новое сообщество.
		/// </summary>
		/// <param name="title">
		/// Название сообщества. строка, обязательный параметр (Строка, обязательный
		/// параметр).
		/// </param>
		/// <param name="description">
		/// Описание сообщества, (не учитывается при
		/// type=public). строка (Строка).
		/// </param>
		/// <param name="type">
		/// Тип создаваемого сообщества:
		/// group — группа;
		/// event — мероприятие;
		/// public — публичная страница.
		/// строка, по умолчанию group (Строка, по умолчанию group).
		/// </param>
		/// <param name="subtype">
		/// Вид публичной страницы (только при type=public):
		/// 1 — место или небольшая компания;
		/// 2 — компания, организация или веб-сайт;
		/// 3 — известная личность или коллектив;
		/// 4 — произведение или продукция.
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="publicCategory">
		/// Категория публичной страницы (только для type =
		/// public).
		/// </param>
		/// <returns>
		/// Возвращает идентификатор созданного сообщества.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.create
		/// </remarks>
		Group Create(string title, string description, GroupType type, GroupSubType? subtype, uint? publicCategory = null);

		/// <summary>
		/// Возвращает список заявок на вступление в сообщество.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества (указывается без знака «минус»). положительное число,
		/// обязательный
		/// параметр (Положительное число, обязательный параметр).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества результатов. По
		/// умолчанию — 0.
		/// положительное число (Положительное число).
		/// </param>
		/// <param name="count">
		/// Число результатов, которые необходимо вернуть. положительное число, по
		/// умолчанию 20, максимальное
		/// значение 200 (Положительное число, по умолчанию 20, максимальное значение 200).
		/// </param>
		/// <param name="fields">
		/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное
		/// описание.
		/// Доступные значения: sex, bdate, city, country, photo_50, photo_100,
		/// photo_200_orig, photo_200, photo_400_orig,
		/// photo_max, photo_max_orig, online, online_mobile, domain, has_mobile, contacts,
		/// connections, site, education,
		/// universities, schools, can_post, can_see_all_posts, can_see_audio,
		/// can_write_private_message, status, last_seen,
		/// common_count, relation, relatives, counters, screen_name, maiden_name,
		/// timezone, occupation,activities, interests,
		/// music, movies, tv, books, games, about, quotes список строк, разделенных через
		/// запятую (Список строк, разделенных
		/// через запятую).
		/// </param>
		/// <returns>
		/// Возвращает список идентификаторов пользователей, отправивших заявки на
		/// вступление в сообщество.
		/// Если было передано значение в параметре fields, возвращается список объектов
		/// пользователей.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getRequests
		/// </remarks>
		VkCollection<User> GetRequests(long groupId, long? offset, long? count, UsersFields fields);

		/// <summary>
		/// Возвращает список сообществ выбранной категории каталога.
		/// </summary>
		/// <param name="categoryId">
		/// Идентификатор категории, полученный в методе groups.getCatalogInfo.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <param name="subcategoryId">
		/// Идентификатор подкатегории, полученный в методе groups.getCatalogInfo.
		/// положительное число,
		/// максимальное значение 99 (Положительное число, максимальное значение 99).
		/// </param>
		/// <returns>
		/// Возвращает список объектов сообществ в соответствии с выбранной категорией
		/// каталога.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getCatalog
		/// </remarks>
		VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null);

		/// <summary>
		/// Возвращает список категорий для каталога сообществ.
		/// </summary>
		/// <param name="extended">
		/// 1 — вернуть информацию о количестве сообществ в категории и три сообщества для
		/// предпросмотра.
		/// По умолчанию 0. флаг, может принимать значения 1 или 0, по умолчанию 0,
		/// доступен начиная с версии 5.37 (Флаг, может
		/// принимать значения 1 или 0, по умолчанию 0, доступен начиная с версии 5.37).
		/// </param>
		/// <param name="subcategories">
		/// 1 — вернуть информацию об подкатегориях.
		/// По умолчанию 0. флаг, может принимать значения 1 или 0, по умолчанию 0,
		/// доступен начиная с версии 5.37 (Флаг, может
		/// принимать значения 1 или 0, по умолчанию 0, доступен начиная с версии 5.37).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает поле enabled (0 — каталог недоступен для
		/// пользователя, 1 — каталог доступен),
		/// и, если enabled=1, массив categories объектов — категорий товаров.
		/// Объект массива categories — категория каталога товаров.
		/// id идентификатор категории.
		/// положительное число name название категории.
		/// строка subcategories поле возвращается при использовании subcategories=1.
		/// Массив объектов-подкатегорий. Каждый из
		/// объектов содержит поля id и name, содержащие идентификатор и название
		/// подкатегории.
		/// Дополнительные поля (extended=1)
		/// page_count количество сообществ в категории.
		/// положительное число page_previews массив объектов сообществ для предпросмотра.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getCatalogInfo
		/// </remarks>
		GroupsCatalogInfo GetCatalogInfo(bool? extended = null, bool? subcategories = null);

		/// <summary>
		/// Добавляет сервер для Callback API в сообщество.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="url"> URL сервера. </param>
		/// <param name="title"> Название сервера. </param>
		/// <param name="secretKey"> Секретный ключ. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор добавленного сервера в поле
		/// server_id (integer).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.addCallbackServer
		/// </remarks>
		long AddCallbackServer(ulong groupId, string url, string title, string secretKey);

		/// <summary>
		/// Удаляет сервер для Callback API из сообщества.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="serverId"> идентификатор сервера, который нужно удалить. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.deleteCallbackServer
		/// </remarks>
		bool DeleteCallbackServer(ulong groupId, ulong serverId);

		/// <summary>
		/// Редактирует данные сервера для Callback API в сообществе.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="serverId">
		/// идентификатор сервера, данные которого нужно
		/// отредактировать
		/// </param>
		/// <param name="url"> URL сервера. </param>
		/// <param name="title"> Название сервера. </param>
		/// <param name="secretKey"> Секретный ключ. </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editCallbackServer
		/// </remarks>
		bool EditCallbackServer(ulong groupId, ulong serverId, string url, string title, string secretKey);

		/// <summary>
		/// Позволяет получить строку, необходимую для подтверждения адреса сервера в
		/// Callback API.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <returns>
		/// Возвращает строку, которую необходимо использовать в качестве ответа на
		/// уведомление с типом "confirmation"
		/// для подтверждения адреса сервера в Callback API.
		/// Обратите внимание, что код, возвращаемый методом, можно использовать только для
		/// настройки сервера средствами API.
		/// В настройках Вашего сообщества на сайте ВКонтакте код будет отличаться.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editCallbackServer
		/// </remarks>
		string GetCallbackConfirmationCode(ulong groupId);

		/// <summary>
		/// Получает информацию о серверах для Callback API в сообществе.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="serverIds">
		/// Идентификаторы серверов, данные о которых нужно получить.
		/// По умолчанию возвращаются все серверы.
		/// </param>
		/// <returns>
		/// Возвращает число серверов в поле count (integer) и массив объектов items с
		/// данными о серверах.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getCallbackServers
		/// </remarks>
		VkCollection<CallbackServerItem> GetCallbackServers(ulong groupId, IEnumerable<ulong> serverIds = null);

		/// <summary>
		/// Позволяет получить настройки уведомлений Callback API для сообщества.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="serverId"> Идентификатор сервера. </param>
		/// <returns> </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getCallbackSettings
		/// </remarks>
		CallbackSettings GetCallbackSettings(ulong groupId, ulong serverId);

		/// <summary>
		/// Позволяет задать настройки уведомлений о событиях в Callback API.
		/// </summary>
		/// <param name="params">
		/// Параметры настройки уведомлений о событиях в Callback
		/// API.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.setCallbackSettings
		/// </remarks>
		bool SetCallbackSettings(CallbackServerParams @params);

		/// <summary>
		/// Возвращает данные для подключения к Bots Longpoll API.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// key (string) — ключ;
		/// server (string) — url сервера;
		/// ts (integer) — timestamp.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getLongPollServer
		/// </remarks>
		LongPollServerResponse GetLongPollServer(ulong groupId);
	}
}