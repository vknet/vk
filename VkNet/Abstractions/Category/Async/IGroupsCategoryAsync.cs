using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Groups;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Асинхронные методы для работы с сообществами (группами).
	/// </summary>
	public interface IGroupsCategoryAsync
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
		Task<bool> JoinAsync(long? groupId, bool? notSure = null);

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
		Task<bool> LeaveAsync(long groupId);

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
		Task<VkCollection<Group>> GetAsync(GroupsGetParams @params, bool skipAuthorization = false);

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
		Task<ReadOnlyCollection<Group>> GetByIdAsync(IEnumerable<string> groupIds, string groupId, GroupsFields fields,
													bool skipAuthorization = false);

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
		Task<VkCollection<User>> GetMembersAsync(GroupsGetMembersParams @params, bool skipAuthorization = false);

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
		Task<ReadOnlyCollection<GroupMember>> IsMemberAsync(string groupId, long? userId, IEnumerable<long> userIds, bool? extended,
															bool skipAuthorization = false);

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
		Task<VkCollection<Group>> SearchAsync(GroupsSearchParams @params, bool skipAuthorization = false);

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
		Task<VkCollection<Group>> GetInvitesAsync(long? count, long? offset, bool? extended = null);

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
		Task<bool> BanUserAsync(GroupsBanUserParams @params);

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
		Task<VkCollection<GetBannedResult>> GetBannedAsync(long groupId, long? offset = null, long? count = null,
															GroupsFields fields = null, long? ownerId = null);

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
		[Obsolete(ObsoleteText.UnbanUserAsync, true)]
		Task<bool> UnbanUserAsync(long groupId, long userId);

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
		Task<bool> UnbanAsync(long groupId, long userId);

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
		Task<bool> EditManagerAsync(GroupsEditManagerParams @params);

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
		Task<GroupsEditParams> GetSettingsAsync(ulong groupId);

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
		Task<bool> EditAsync(GroupsEditParams @params);

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
		[Obsolete(ObsoleteText.Obsolete)]
		Task<bool> EditPlaceAsync(long groupId, Place place = null);

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
		Task<VkCollection<User>> GetInvitedUsersAsync(long groupId, long? offset = null, long? count = null, UsersFields fields = null,
													NameCase nameCase = null);

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
		/// <returns>
		/// В случае успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.invite
		/// </remarks>
		Task<bool> InviteAsync(long groupId, long userId);

		/// <inheritdoc cref="IGroupsCategoryAsync.InviteAsync(long,long)" />
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		Task<bool> InviteAsync(long groupId, long userId, long? captchaSid, string captchaKey);

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
		Task<ExternalLink> AddLinkAsync(long groupId, Uri link, string text);

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
		Task<bool> DeleteLinkAsync(long groupId, ulong linkId);

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
		Task<bool> EditLinkAsync(long groupId, ulong linkId, string text);

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
		Task<bool> ReorderLinkAsync(long groupId, long linkId, long? after);

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
		Task<bool> RemoveUserAsync(long groupId, long userId);

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
		Task<bool> ApproveRequestAsync(long groupId, long userId);

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
		Task<Group> CreateAsync(string title, string description = null, GroupType type = null, GroupSubType? subtype = null,
								uint? publicCategory = null);

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
		Task<VkCollection<User>> GetRequestsAsync(long groupId, long? offset = null, long? count = null, UsersFields fields = null);

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
		Task<VkCollection<Group>> GetCatalogAsync(ulong? categoryId = null, ulong? subcategoryId = null);

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
		Task<GroupsCatalogInfo> GetCatalogInfoAsync(bool? extended = null, bool? subcategories = null);

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
		Task<long> AddCallbackServerAsync(ulong groupId, string url, string title, string secretKey = null);

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
		Task<bool> DeleteCallbackServerAsync(ulong groupId, ulong serverId);

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
		Task<bool> EditCallbackServerAsync(ulong groupId, ulong serverId, string url, string title, string secretKey);

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
		Task<string> GetCallbackConfirmationCodeAsync(ulong groupId);

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
		Task<VkCollection<CallbackServerItem>> GetCallbackServersAsync(ulong groupId, IEnumerable<ulong> serverIds = null);

		/// <summary>
		/// Позволяет получить настройки уведомлений Callback API для сообщества.
		/// </summary>
		/// <param name="groupId"> Идентификатор сообщества. </param>
		/// <param name="serverId"> Идентификатор сервера. </param>
		/// <returns> </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getCallbackSettings
		/// </remarks>
		Task<CallbackSettings> GetCallbackSettingsAsync(ulong groupId, ulong serverId);

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
		Task<bool> SetCallbackSettingsAsync(CallbackServerParams @params);

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
		Task<LongPollServerResponse> GetLongPollServerAsync(ulong groupId);

		/// <summary>
		/// Выключает статус «онлайн» в сообществе.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.disableOnline
		/// </remarks>
		Task<bool> DisableOnlineAsync(ulong groupId);

		/// <summary>
		/// Включает статус «онлайн» в сообществе.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.enableOnline
		/// </remarks>
		Task<bool> EnableOnlineAsync(ulong groupId);

		/// <summary>
		/// Возвращаем обновления событий группы
		/// </summary>
		/// <param name="params"> Параметры запроса к BotsLongPoll API </param>
		/// <returns>
		/// Новые события в группе
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/bots_longpoll
		/// </remarks>
		Task<BotsLongPollHistoryResponse> GetBotsLongPollHistoryAsync(BotsLongPollHistoryParams @params);

		/// <summary>
		/// Позволяет добавить адрес в сообщество.
		/// Список адресов может быть получен методом groups.getAddresses.
		/// Для того, чтобы воспользоваться этим методом, Вы должны быть администратором
		/// сообщества
		/// </summary>
		/// <param name="params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Данные о добавленном адресе сообщества
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.addAddress
		/// </remarks>
		Task<AddressResult> AddAddressAsync(AddAddressParams @params);

		/// <summary>
		/// Позволяет отредактировать адрес в сообществе.
		/// Список адресов может быть получен методом groups.getAddresses.
		/// Для того, чтобы воспользоваться этим методом, Вы должны быть администратором
		/// сообщества
		/// </summary>
		/// <param name="params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Данные об адресе отредактированного сообщества
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.editAddress
		/// </remarks>
		Task<AddressResult> EditAddressAsync(EditAddressParams @params);

		/// <summary>
		/// Позволяет удалить адрес в сообществе.
		/// </summary>
		/// <param name="groupId">
		/// Id группы положительное число, обязательный параметр
		/// </param>
		/// <param name="addressId">
		/// Id адреса положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.deleteAddress
		/// </remarks>
		Task<bool> DeleteAddressAsync(ulong groupId, ulong addressId);

		/// <summary>
		/// Получить данные об адресах.
		/// </summary>
		/// <param name="params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Коллекция адресов сообщества
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getAddresses
		/// </remarks>
		Task<VkCollection<AddressResult>> GetAddressesAsync(GetAddressesParams @params);

		/// <summary>
		/// Получает информацию о статусе «онлайн» в сообществе.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит поля:
		/// status — статус сообщества. Возможные значения:
		/// none — сообщество не онлайн;
		/// online — сообщество онлайн (отвечает мгновенно);
		/// answer_mark — сообщество отвечает быстро.
		/// minutes — оценка времени ответа в минутах (для status = answer_mark).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getOnlineStatus
		/// </remarks>
		Task<OnlineStatus> GetOnlineStatusAsync(ulong groupId);

		/// <summary>
		/// Возвращает настройки прав для ключа доступа сообщества.
		/// </summary>
		/// <returns>
		/// Возвращает объект, который содержит поля:
		/// mask (integer) — битовая маска ключа доступа;
		/// settings (array) — массив объектов, описывающих права доступа. Каждый объект в
		/// массиве содержит поля:
		/// setting (integer) — битовая маска права доступа;
		/// name (string) — название права доступа.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getTokenPermissions
		/// </remarks>
		Task<TokenPermissionsResult> GetTokenPermissionsAsync();

		/// <summary>
		/// Задаёт настройки для Bots Long Poll API в сообществе.
		/// </summary>
		/// <param name="params">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.setLongPollSettings
		/// </remarks>
		Task<bool> SetLongPollSettingsAsync(SetLongPollSettingsParams @params);

		/// <summary>
		/// Получает настройки Bots Longpoll API для сообщества.
		/// </summary>
		/// <param name="groupId">
		/// Идентификатор сообщества. положительное число, обязательный параметр
		/// </param>
		/// <returns>
		/// Возвращает объект, который содержит следующие поля:
		/// is_enabled (boolean) — true, если Bots Longpoll включен в сообществе.
		/// events (object) — настройки Bots Longpoll. объект, содержащий настройки
		/// уведомлений в формате «название события»
		/// : «статус» (0 — уведомления о событии выключены, 1 — уведомления о событии
		/// включены).
		/// Объект содержит следующие поля:
		/// message_new новое сообщение
		/// integer, [0,1] message_reply новое исходящее сообщение
		/// integer, [0,1] message_allow новая подписка на сообщения
		/// integer, [0,1] message_deny новый запрет сообщений
		/// integer, [0,1] photo_new добавление новой фотографии
		/// integer, [0,1] audio_new добавление новой аудиозаписи
		/// integer, [0,1] video_new добавление новой видеозаписи
		/// integer, [0,1] wall_reply_new добавление нового комментария на стене
		/// integer, [0,1] wall_reply_edit редактирование комментария на стене
		/// integer, [0,1] wall_reply_delete удаление комментария на стене
		/// integer, [0,1] wall_post_new добавление новой записи на стене
		/// integer, [0,1] wall_repost новый репост записи на стене
		/// integer, [0,1] board_post_new добавление нового комментария в обсуждении
		/// integer, [0,1] board_post_edit редактирование комментария в обсуждении
		/// integer, [0,1] board_post_delete удаление комментария в обсуждении
		/// integer, [0,1] board_post_restore восстановление комментария в обсуждении
		/// integer, [0,1] photo_comment_new добавление нового комментария к фото
		/// integer, [0,1] photo_comment_edit редактирование комментария к фото
		/// integer, [0,1] photo_comment_delete удаление комментария к фото
		/// integer, [0,1] photo_comment_restore восстановление комментария к фото
		/// integer, [0,1] video_comment_new добавление нового комментария к видео
		/// integer, [0,1] video_comment_edit редактирование комментария к видео
		/// integer, [0,1] video_comment_delete удаление комментария к видео
		/// integer, [0,1] video_comment_restore восстановление комментария к видео
		/// integer, [0,1] market_comment_new добавление нового комментария к товару
		/// integer, [0,1] market_comment_edit редактирование комментария к товару
		/// integer, [0,1] market_comment_delete удаление комментария к товару
		/// integer, [0,1] market_comment_restore восстановление удалённого комментария к
		/// товару
		/// integer, [0,1] poll_vote_new новый голос в публичном опросе
		/// integer, [0,1] group_join вступление в сообщество
		/// integer, [0,1] group_leave выход участника из сообщества
		/// integer, [0,1] user_block занесение пользователя в черный список
		/// integer, [0,1] user_unblock удаление пользователя из черного списка
		/// integer, [0,1] group_change_settings изменение настроек сообщества
		/// integer, [0,1] group_change_photo изменение главной фотографии
		/// integer, [0,1] group_officers_edit изменение руководства сообщества
		/// integer, [0,1]
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/groups.getLongPollSettings
		/// </remarks>
		Task<GetLongPollSettingsResult> GetLongPollSettingsAsync(ulong groupId);
	}
}