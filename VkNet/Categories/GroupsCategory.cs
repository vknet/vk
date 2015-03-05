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
        /// <returns>Список групп</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.28")]
        public ReadOnlyCollection<Group> Get(long uid, bool extended = false, GroupsFilters filters = null, GroupsFields fields = null, int offset = 0, int count = 1000)
        {
            var parameters = new VkParameters { { "uid", uid }, { "extended", extended }, { "filter", filters }, { "fields", fields }, { "offset", offset }, { "count", count } };

            VkResponse response = _vk.Call("groups.get", parameters);

            if (!extended)
                return response.ToReadOnlyCollectionOf<Group>(id => new Group { Id = id });

            // в первой записи количество членов группы
            return response["items"].ToReadOnlyCollectionOf<Group>(r => r);
        }

        /// <summary>
        /// Возвращает информацию о нескольких группах.
        /// </summary>
        /// <param name="gids">Список групп</param>
        /// <param name="fields">Список полей информации о группах</param>
        /// <returns>Список групп</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getById"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Group> GetById(IEnumerable<long> gids, GroupsFields fields = null)
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
        /// <returns>Id пользователей состоящих в группе</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.getMembers"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<long> GetMembers(long gid, out int totalCount, int? count = null, int? offset = null, GroupsSort sort = null)
        {
            var parameters = new VkParameters { { "gid", gid }, { "offset", offset }, { "sort", sort } };

            if (count.HasValue && count.Value > 0 && count.Value < 1000)
                parameters.Add("count", count);

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
            var parameters = new VkParameters { { "gid", gid }, { "uid", uid } };

            return _vk.Call("groups.isMember", parameters);
        }

        /// <summary>
        /// Осуществляет поиск групп по заданной подстроке.
        /// </summary>
        /// <param name="query">Поисковый запрос</param>
        /// <param name="totalCount">Общее количество групп удовлетворяющих запросу</param>
        /// <param name="offset">Смещение</param>
        /// <param name="count">Количество в выбоке</param>
        /// <returns>Список объектов групп</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/groups.search"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Group> Search([NotNull] string query, out int totalCount, int? offset = null, int? count = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => query);
            
            var parameters = new VkParameters { { "q", query }, { "offset", offset }, { "count", count } };

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
                    {"comment_visible", commentVisible}
                };
            parameters.Add("reason", reason);

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
        public ReadOnlyCollection<User> GetBanned(long groupId, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => groupId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

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
    }
}