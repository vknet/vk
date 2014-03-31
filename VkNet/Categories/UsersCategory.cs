namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Enums;
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
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/users.search"/>.
        /// </remarks>
        public ReadOnlyCollection<User> Search(string query, out int itemsCount, ProfileFields fields = null, int count = 20, int offset = 0)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty.");

            var parameters = new VkParameters { { "q", query }, { "fields", fields }, { "count", count } };
            if (offset > 0)
                parameters.Add("offset", offset);

            VkResponseArray response = _vk.Call("users.search", parameters);

            itemsCount = response[0];

            return response.Skip(1).ToReadOnlyCollectionOf<User>(r => r);
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
        /// Если, имея битовую маску 1026, Вы хотите проверить, имеет ли она доступ к друзьям — Вы можете сделать 1026 &amp; 2. 
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/getUserSettings"/>.
        /// </remarks>
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
        public bool IsAppUser(long userId)
        {   
            var parameters = new VkParameters { { "user_id", userId }, {"v", _vk.ApiVersion} };

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
        public User Get(long userId, ProfileFields fields = null,
                                            NameCase nameCase = null)
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");

            var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase }, { "v", _vk.ApiVersion }, { "user_ids", userId } };

            VkResponseArray response = _vk.Call("users.get", parameters);

            return response[0];
        }

        /// <summary>
        /// Возвращает расширенную информацию о пользователе.
        /// </summary>
        /// <param name="userIds">Идентификаторы пользователей, о которых необходимо получить информацию.</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/getProfiles"/>.
        /// </remarks>
        public ReadOnlyCollection<User> Get(IEnumerable<long> userIds, ProfileFields fields = null, NameCase nameCase = null)
        {
            if (userIds == null)
                throw new ArgumentNullException("userIds");

            var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase }, {"v", _vk.ApiVersion} };
            parameters.Add("user_ids", userIds);

            VkResponseArray response = _vk.Call("users.get", parameters);

            return response.ToReadOnlyCollectionOf<User>(x => x);
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
        public ReadOnlyCollection<Group> GetSubscriptions(long? userId = null, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"extended", true},
                    {"offset", offset},
                    {"count", count},
                    {"v", _vk.ApiVersion}
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
        public ReadOnlyCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null)
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"offset", offset},
                    {"count", count},
                    {"fields", fields},
                    {"name_case", nameCase},
                    {"v", _vk.ApiVersion}
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
        public bool Report(long userId, ReportType type, string comment = "")
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"type", type},
                    {"comment", comment},
                    {"v", _vk.ApiVersion}
                };

            return _vk.Call("users.report", parameters);
        }
    }
}