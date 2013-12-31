namespace VkToolkit.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Enums;
    using VkToolkit.Model;
    using VkToolkit.Utils;

    /// <summary>
    /// Методы для работы с информацией о пользователях.
    /// </summary>
    public class UsersCategory
    {
        private readonly VkApi _vk;

        public UsersCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список пользователей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="query">Строка поискового запроса. Например, Вася Бабич.</param>
        /// <param name="itemsCount">Общее количество пользователей, удовлетворяющих условиям запроса.</param>
        /// <param name="fields">Список дополнительных полей, которые необходимо вернуть.</param>
        /// <param name="count">Количество возвращаемых пользователей. 
        /// Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов.         
        /// </param>
        /// <param name="offset">Смещение относительно первого найденного пользователя для выборки определенного подмножества.</param>
        /// <returns>
        /// После успешного выполнения возвращает список объектов пользователей, найденных в соответствии с заданными критериями. 
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/users.search"/>.
        /// </remarks>
        public List<User> Search(string query, out int itemsCount, ProfileFields fields = null, int count = 20, int offset = 0)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty.");

            var parameters = new VkParameters { { "q", query }, { "fields", fields }, { "count", count } };
            if (offset > 0)
                parameters.Add("offset", offset);

            VkResponseArray response = _vk.Call("users.search", parameters);

            itemsCount = response[0];

            return response.Skip(1).ToListOf(r => (User)r);
        }

        /// <summary>
        /// Получает настройки текущего пользователя в данном приложении. .
        /// </summary>
        /// <param name="uid">идентификатор пользователя, информацию о настройках которого необходимо получить.</param>
        /// <returns>После успешного выполнения возвращает битовую маску настроек текущего пользователя в данном приложении. 
        /// 
        /// Пример:
        /// Если Вы хотите получить права на Доступ к друзьям и Доступ к статусам пользователя, то Ваша битовая маска будет 
        /// равна: 2 + 1024 = 1026. 
        /// Если, имея битовую маску 1026, Вы хотите проверить, имеет ли она доступ к друзьям — Вы можете сделать 1026 & 2. 
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/getUserSettings"/>.
        /// </remarks>
        public int GetUserSettings(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("getUserSettings", parameters);
        }

        /// <summary>
        /// Возвращает список сообществ указанного пользователя. 
        /// </summary>
        /// <param name="uid">Идентификатор пользователя, информацию о сообществах которого требуется получить.</param>
        /// <returns>После успешного выполнения возвращает список сообществ, в которых состоит пользователь. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/getGroups"/>.
        /// </remarks>
        public List<Group> GetGroups(int uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            var response = _vk.Call("getGroups", parameters);

            return response.ToListOf(id => new Group { Id = id });
        }

        /// <summary>
        /// Возвращает информацию о том, установил ли пользователь приложение.
        /// </summary>
        /// <param name="uid">Идентификатор пользователя.</param>
        /// <returns>После успешного выполнения возвращает true в случае, если пользователь установил у себя данное приложение, 
        /// иначе false. 
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/isAppUser"/>.
        /// </remarks>
        public bool IsAppUser(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("isAppUser", parameters);
        }

        /// <summary>
        /// Возвращает список сообществ данного пользователя. 
        /// </summary>
        /// <returns> 
        /// В случае успеха возвращается список сообществ данного пользователя.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/getGroupsFull"/>.
        /// </remarks>
        public List<Group> GetGroupsFull()
        {
            // TODO: заменить на groups.get
            return _vk.Call("getGroupsFull", VkParameters.Empty);
        }

        /// <summary>
        /// Возвращает стандартную информацию об указанных сообществах.
        /// </summary>
        /// <param name="gids">Список идентификаторов сообществ, о которых необходимо получить информацию</param>
        /// <returns>
        /// Список объектов, содержащих информацию о запрошенных сообществах.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/getGroupsFull"/>.
        /// </remarks>
        public List<Group> GetGroupsFull(IEnumerable<long> gids)
        {
            if (gids == null)
                throw new ArgumentNullException("gids");

            // TODO: заменить на groups.get
            var parameters = new VkParameters { { "gids", gids } };

            return _vk.Call("getGroupsFull", parameters);
        }

        /// <summary>
        /// Возвращает расширенную информацию о пользователе.
        /// </summary>
        /// <param name="uid">Идентификатор пользователя.</param>
        /// <param name="fields">Поля профиля, которые необходимо возвратить.</param>
        /// <returns>Объект, содержащий запрошенную информацию о пользователе.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/getProfiles"/>.
        /// </remarks>
        public User Get(long uid, ProfileFields fields = null)
        {
            // TODO: заменить на users.get
            var parameters = new VkParameters { { "uid", uid }, { "fields", fields } };

            VkResponseArray response = _vk.Call("getProfiles", parameters);

            return response[0];
        }

        /// <summary>
        /// Возвращает расширенную информацию о пользователе.
        /// </summary>
        /// <param name="uids">Идентификаторы пользователей, о которых необходимо получить информацию.</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/getProfiles"/>.
        /// </remarks>
        public List<User> Get(IEnumerable<long> uids, ProfileFields fields = null)
        {
            if (uids == null)
                throw new ArgumentNullException("uids");

            var parameters = new VkParameters { { "uids", uids }, { "fields", fields } };

            return _vk.Call("getProfiles", parameters);
        }
    }
}