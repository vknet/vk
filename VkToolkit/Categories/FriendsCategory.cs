namespace VkToolkit.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Enums;
    using Model;
    using Utils;

    /// <summary>
    /// Методы для работы с друзьями.
    /// </summary>
    public class FriendsCategory
    {
        private readonly VkApi _vk;

        public FriendsCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
        /// </summary>
        /// <param name="uid">Идентификатор пользователя, для которого необходимо получить список друзей.</param>
        /// <param name="fields">Поля анкеты (профиля), которые необходимо получить.</param>
        /// <param name="count">Количество друзей, которое нужно вернуть. (по умолчанию – все друзья).</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества друзей.</param>
        /// <param name="order">Порядок, в котором нужно вернуть список друзей.</param>
        /// <returns>Список друзей пользователя с заполненными полями (указанными в параметре <paramref name="fields"/>).
        /// Если значение поля <paramref name="fields"/> не указано, то у возвращаемых друзей заполняется только поле Id.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.get"/>.
        /// </remarks>       
        public List<User> Get(long uid, ProfileFields fields = null, int? count = null, int? offset = null, FriendsOrder order = null)
        {
            var parameters = new VkParameters { { "uid", uid }, { "fields", fields }, { "count", count }, { "offset", offset }, { "order", order } };

            var response = _vk.Call("friends.get", parameters);

            if (fields != null)
                return response;

            return response.ToListOf(id => new User { Id = id });
        }

        /// <summary>
        /// Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.
        /// </summary>
        /// <returns>
        /// Список идентификаторов друзей текущего пользователя, которые установили данное приложение.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Friends"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.getAppUsers"/>.
        /// </remarks>       
        public List<long> GetAppUsers()
        {
            return _vk.Call("friends.getAppUsers", VkParameters.Empty);
        }

        /// <summary>
        /// Возвращает список идентификаторов друзей пользователя, которые сейчас находятся на сайте (online).
        /// </summary>
        /// <param name="uid">
        /// Идентификатор пользователя, для которого необходимо получить список друзей, находящихся на сайте.
        /// </param>
        /// <returns>
        /// В случае успеха список идентификаторов друзей пользователя, которые сейчас находятся на сайте.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Friends"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.getOnline"/>.
        /// </remarks>       
        public List<long> GetOnline(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            return _vk.Call("friends.getOnline", parameters);
        }

        /// <summary>
        /// Возвращает список идентификаторов общих друзей между парой пользователей.
        /// </summary>
        /// <param name="targetUid">Идентификатор пользователя, с которым необходимо искать общих друзей.</param>
        /// <param name="sourceUid">Идентификатор пользователя, чьи друзья пересекаются с друзьями пользователя с идентификатором <paramref name="targetUid"/>.</param>
        /// <returns>
        /// В случае успеха возвращает список идентификаторов (id) общих друзей между пользователями с идентификаторами <paramref name="targetUid"/> и <paramref name="sourceUid"/>.
        /// </returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Friends"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.getMutual"/>.
        /// </remarks>       
        public List<long> GetMutual(long targetUid, long sourceUid)
        {
            var parameters = new VkParameters { { "target_uid", targetUid }, { "source_uid", sourceUid } };

            return _vk.Call("friends.getMutual", parameters);
        }

        /// <summary>
        /// Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. 
        /// Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
        /// </summary>
        /// <param name="uids">Список проверяемых идентификаторов пользователей.</param>
        /// <returns>Метод возвращает словарь, ключом которого является идентификатор пользователя (uid), а значением значение типа <see cref="FriendStatus"/>.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Friends"/>.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.areFriends"/>.
        /// </remarks>       
        public IDictionary<long, FriendStatus> AreFriends(IEnumerable<long> uids)
        {
            if (uids == null)
                throw new ArgumentNullException("uids");

            var parameters = new VkParameters { { "uids", uids } };

            VkResponseArray ids = _vk.Call("friends.areFriends", parameters);

            return ids.ToDictionary(r => (long)r["uid"], r => (FriendStatus)r["friend_status"]);
        }

        /// <summary>
        /// Создает новый список друзей у текущего пользователя.
        /// </summary>
        /// <param name="name">название создаваемого списка друзей.</param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного списка друзей.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Friends"/>.
        ///  Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.addList"/>.
        /// </remarks>
        /// 
        public long AddList(string name)
        {
            return AddList(name, null);
        }

        /// <summary>
        /// Создает новый список друзей у текущего пользователя.
        /// </summary>
        /// <param name="name">название создаваемого списка друзей.</param>
        /// <param name="userIds">идентификаторы пользователей, которых необходимо поместить в созданный список. </param>
        /// <returns>После успешного выполнения возвращает идентификатор созданного списка друзей.</returns>
        /// <remarks>
        /// Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref="Settings.Friends"/>.
        ///  Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.addList"/>.
        /// </remarks>
        public long AddList(string name, IEnumerable<long> userIds)
        {
            VkErrors.ThrowIfNullOrEmpty(name);

            var parameters = new VkParameters
                {
                    {"name", name}
                };
            parameters.Add("user_ids", userIds);

            VkResponse response = _vk.Call("friends.addList", parameters);

            return response["lid"];
        }

        /// <summary>
        /// Удаляет существующий список друзей текущего пользователя.
        /// </summary>
        /// <param name="listId">идентификатор списка друзей, который необходимо удалить</param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        public bool DeleteList(long listId)
        {
            VkErrors.ThrowIfNumberIsNegative(listId, "listId");

            var parameters = new VkParameters {{"list_id", listId}};

            VkResponse response = _vk.Call("friends.deleteList", parameters);

            return response;
        }
    }
}