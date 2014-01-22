namespace VkToolkit.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Enums;
    using VkToolkit.Model;
    using VkToolkit.Utils;

    /// <summary>
    /// Методы для работы с сообществами (группами).
    /// </summary>
    public class GroupsCategory
    {
        private readonly VkApi _vk;

        public GroupsCategory(VkApi vk)
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.join"/>.
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.leave"/>.
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
        /// <returns>Список групп</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.get"/>.
        /// </remarks>
        public List<Group> Get(long uid, bool extended = false, GroupsFilters filters = null, GroupsFields fields = null)
        {
            var parameters = new VkParameters { { "uid", uid }, { "extended", extended }, { "filter", filters }, { "fields", fields } };

            VkResponseArray response = _vk.Call("groups.get", parameters);

            if (!extended)
                return response.Select(id => new Group { Id = id }).ToList();

            // в первой записи количество членов группы
            return response.Skip(1).ToListOf(r => (Group)r);
        }

        /// <summary>
        /// Возвращает информацию о нескольких группах.
        /// </summary>
        /// <param name="gids">Список групп</param>
        /// <param name="fields">Список полей информации о группах</param>
        /// <returns>Список групп</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.getById"/>.
        /// </remarks>
        public List<Group> GetById(IEnumerable<long> gids, GroupsFields fields = null)
        {
            var parameters = new VkParameters { { "gids", gids }, { "fields", fields } };

            return _vk.Call("groups.getById", parameters);
        }

        /// <summary>
        /// Возвращает информацию о заданной группе.
        /// </summary>
        /// <param name="gid">Id группы</param>
        /// <param name="fields">Список полей информации о группах</param>
        /// <returns>Список групп</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.getById"/>.
        /// </remarks>
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.getMembers"/>.
        /// </remarks>
        public List<long> GetMembers(long gid, out int totalCount, int? count = null, int? offset = null, GroupsSort sort = null)
        {
            var parameters = new VkParameters { { "gid", gid }, { "offset", offset }, { "sort", sort } };

            if (count.HasValue && count.Value > 0 && count.Value < 1000)
                parameters.Add("count", count);

            var response = _vk.Call("groups.getMembers", parameters);

            totalCount = response["count"];

            return response["users"];
        }

        /// <summary>
        /// Возвращает информацию о том является ли пользователь участником заданной группы.
        /// </summary>
        /// <param name="gid">Id группы</param>
        /// <param name="uid">Id пользователя</param>
        /// <returns>True если пользователь состоит в группе, иначе False</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.isMember"/>.
        /// </remarks>
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/groups.search"/>.
        /// </remarks>
        public List<Group> Search(string query, out int totalCount, int? offset = null, int? count = null)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("query");

            var parameters = new VkParameters { { "q", query }, { "offset", offset }, { "count", count } };

            VkResponseArray response = _vk.Call("groups.search", parameters);

            totalCount = response[0];

            return response.Skip(1).ToListOf(r => (Group)r);
        }
    }
}