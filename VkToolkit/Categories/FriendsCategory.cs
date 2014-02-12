using System.Collections.ObjectModel;

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
        public ReadOnlyCollection<User> Get(long uid, ProfileFields fields = null, int? count = null, int? offset = null, FriendsOrder order = null)
        {
            var parameters = new VkParameters { { "uid", uid }, { "fields", fields }, { "count", count }, { "offset", offset }, { "order", order } };

            var response = _vk.Call("friends.get", parameters);

            if (fields != null)
                return response.ToReadOnlyCollectionOf<User>(x => x);

            return response.ToReadOnlyCollectionOf(id => new User { Id = id });
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
        public ReadOnlyCollection<long> GetAppUsers()
        {
            VkResponseArray response = _vk.Call("friends.getAppUsers", VkParameters.Empty);
            return response.ToReadOnlyCollectionOf<long>(x => x);
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
        public ReadOnlyCollection<long> GetOnline(long uid)
        {
            var parameters = new VkParameters { { "uid", uid } };

            VkResponseArray response = _vk.Call("friends.getOnline", parameters);
            return response.ToReadOnlyCollectionOf<long>(x => x);
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
        public ReadOnlyCollection<long> GetMutual(long targetUid, long sourceUid)
        {
            var parameters = new VkParameters { { "target_uid", targetUid }, { "source_uid", sourceUid } };

            VkResponseArray response = _vk.Call("friends.getMutual", parameters);
            return response.ToReadOnlyCollectionOf<long>(x => x);
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
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.addList"/>.
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
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.deleteList"/>.
        /// </remarks>
        public bool DeleteList(long listId)
        {
            VkErrors.ThrowIfNumberIsNegative(listId, "listId");

            var parameters = new VkParameters {{"list_id", listId}};

            VkResponse response = _vk.Call("friends.deleteList", parameters);

            return response;
        }

        /// <summary>
        /// Возвращает список меток друзей текущего пользователя.
        /// </summary>
        /// <returns>После успешного выполнения возвращает массив объектов <see cref="FriendList"/></returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.getLists"/>.
        /// </remarks>
        public ReadOnlyCollection<FriendList> GetLists()
        {
            VkResponseArray response = _vk.Call("friends.getLists", VkParameters.Empty);

            return response.ToReadOnlyCollectionOf<FriendList>(x => x);
        }

        /// <summary>
        /// Редактирует существующий список друзей текущего пользователя.
        /// </summary>
        /// <param name="listId">идентификатор списка друзей</param>
        /// <param name="name">название списка друзей</param>
        /// <param name="userIds">идентификаторы пользователей, включенных в список</param>
        /// <param name="addUserIds">идентификаторы пользователей, которых необходимо добавить в список. (в случае если не передан user_ids) </param>
        /// <param name="deleteUserIds">идентификаторы пользователей, которых необходимо изъять из списка. (в случае если не передан user_ids) </param>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.editList"/>.
        /// </remarks>
        public bool EditList(long listId, string name = null, IEnumerable<long> userIds = null, IEnumerable<long> addUserIds = null, IEnumerable<long> deleteUserIds = null)
        {
            VkErrors.ThrowIfNumberIsNegative(listId, "listId");

            var parameters = new VkParameters
                {
                    {"name", name},
                    {"list_id", listId}
                };
            parameters.Add("user_ids", userIds);
            parameters.Add("add_user_ids", addUserIds);
            parameters.Add("delete_user_ids", deleteUserIds);

            VkResponse response = _vk.Call("friends.editList", parameters);

            return response;
        }

        /// <summary>
        /// Отмечает все входящие заявки на добавление в друзья как просмотренные
        /// </summary>
        /// <returns>После успешного выполнения возвращает true.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.deleteAllRequests"/>.
        /// </remarks>
        public bool DeleteAllRequests()
        {
            return _vk.Call("friends.deleteAllRequests", VkParameters.Empty);
        }

        /// <summary>
        /// Одобряет или создает заявку на добавление в друзья.
        /// </summary>
        /// <param name="userId">идентификатор пользователя, которому необходимо отправить заявку, либо заявку от которого необходимо одобрить.</param>
        /// <param name="text">текст сопроводительного сообщения для заявки на добавление в друзья. Максимальная длина сообщения — 500 символов.</param>
        /// <returns>
        /// После успешного выполнения возвращает одно из следующих значений:
        /// 1 — заявка на добавление данного пользователя в друзья отправлена;
        /// 2 — заявка на добавление в друзья от данного пользователя одобрена;
        /// 4 — повторная отправка заявки.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.add"/>.
        /// </remarks>
        public AddFriendStatus Add(long userId, string text = "")
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");
            
            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"text", text}
                };

            VkResponse response = _vk.Call("friends.add", parameters);
            return response;
        }

        /// <summary>
        /// Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
        /// </summary>
        /// <param name="userId">идентификатор пользователя, которого необходимо удалить из списка друзей, либо заявку от которого необходимо отклонить.</param>
        /// <returns>
        /// После успешного выполнения возвращает одно из следующих значений:
        /// 1 — пользователь удален из списка друзей;
        /// 2 — заявка на добавление в друзья от данного пользователя отклонена;
        /// 3 — рекомендация добавить в друзья данного пользователя удалена.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/friends.delete"/>.
        /// </remarks>
        public DeleteFriendStatus Delete(long userId)
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");

            var parameters = new VkParameters {{"user_id", userId}};

            VkResponse response = _vk.Call("friends.delete", parameters);
            return response;
        }

        // todo add comment
        // todo add tests
        public bool Edit(long userId, IEnumerable<long> listIds)
        {
            VkErrors.ThrowIfNumberIsNegative(userId, "userId");

            var parameters = new VkParameters { { "user_id", userId } };
            parameters.Add("list_ids", listIds);

            VkResponse response = _vk.Call("friends.edit", parameters);

            throw new NotImplementedException();

            return response;
        }

        // todo add comment
        // todo add tests
        public ReadOnlyCollection<long> GetRecent(int? count = null)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");

            var parameters = new VkParameters { { "count", count } };

            VkResponseArray response = _vk.Call("friends.getRecent", parameters);

            throw new NotImplementedException();

            return response.ToReadOnlyCollectionOf<long>(x => x);
        }

        // todo add comment
        // todo add testes
        public ReadOnlyCollection<long> GetRequests(int? count = null, int? offset = null, bool extended = false, bool needMutual = false, bool @out = false, bool sort = false, bool suggested = false)
        {
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"offset", offset},
                    {"count", count},
                    {"extended", extended},
                    {"need_mutual", needMutual},
                    {"out", @out},
                    {"sort", sort},
                    {"suggested", suggested}
                };

            VkResponseArray response = _vk.Call("friends.getRequests", parameters);

            throw new NotImplementedException();

            return response.ToReadOnlyCollectionOf<long>(x => x);
        }
    }
}