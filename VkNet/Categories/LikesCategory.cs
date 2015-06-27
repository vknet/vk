namespace VkNet.Categories
{
    using System.Collections.ObjectModel;

    using Enums.SafetyEnums;
    using Utils;
    using Model;

    public class LikesCategory
    {
        private readonly VkApi _vk;

        internal LikesCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Получает список идентификаторов пользователей, которые добавили заданный объект в свой список Мне нравится. 
        /// </summary>
        /// <param name="type">Тип объекта <see cref="LikeObjectType"/></param>
        /// <param name="ownerId">Идентификатор владельца Like-объекта: id пользователя, id сообщества (со знаком «минус») или id приложения. Если параметр type равен sitepage, то в качестве owner_id необходимо передавать id приложения. Если параметр не задан, то считается, что он равен либо идентификатору текущего пользователя, либо идентификатору текущего приложения (если type равен sitepage). целое число</param>
        /// <param name="itemId">Идентификатор Like-объекта. Если type равен sitepage, то параметр item_id может содержать значение параметра page_id, используемый при инициализации  виджета «Мне нравится».</param>
        /// <param name="pageUrl">Url страницы, на которой установлен виджет «Мне нравится». Используется вместо параметра item_id. строка</param>
        /// <param name="filter">Указывает, следует ли вернуть всех пользователей, добавивших объект в список &quot;Мне нравится&quot; или только тех, которые рассказали о нем друзьям. Параметр может принимать следующие значения: 
        /// 
        /// likes — возвращать информацию обо всех пользователях; 
        /// copies — возвращать информацию только о пользователях, рассказавших об объекте друзьям.
        /// По умолчанию возвращается информация обо всех пользователях. 
        /// строка</param>
        /// <param name="friendsOnly">Указывает, необходимо ли возвращать только пользователей, которые являются друзьями текущего пользователя. Параметр может принимать следующие значения: 
        /// 
        /// 0 — возвращать всех пользователей в порядке убывания времени добавления объекта; 
        /// 1 — возвращать только друзей текущего пользователя в порядке убывания времени добавления объекта;
        /// Если метод был вызван без авторизации или параметр не был задан, то считается, что он равен 0. 
        /// флаг, может принимать значения 1 или 0</param>
        /// <param name="extended">1 — возвращать расширенную информацию о пользователях и сообществах из списка поставивших отметку «Мне нравится» или сделавших репост. По умолчанию — 0. флаг, может принимать значения 1 или 0</param>
        /// <param name="offset">Смещение, относительно начала списка, для выборки определенного подмножества. Если параметр не задан, то считается, что он равен 0. положительное число</param>
        /// <param name="count">Количество возвращаемых идентификаторов пользователей.
        /// Если параметр не задан, то считается, что он равен 100, если не задан параметр friends_only, в противном случае 10.
        /// Максимальное значение параметра 1000, если не задан параметр friends_only, в противном случае 100. положительное число</param>
        /// <returns>После успешного выполнения возвращает объект со следующими полями: 
        /// 
        /// count — общее количество пользователей, которые добавили заданный объект в свой список Мне нравится. 
        /// items — список идентификаторов пользователей с учетом параметров offset и count, которые добавили заданный объект в свой список Мне нравится. 
        /// 
        /// Если параметр type равен sitepage, то будет возвращён список пользователей, воспользовавшихся виджетом «Мне нравится» на внешнем сайте. Адрес страницы задаётся при помощи параметра page_url или item_id. 
        /// Если extended=1, дополнительно возвращается массив items, содержащий расширенную информацию о пользователях или сообществах. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/likes.getList"/>.
        /// </remarks>
        [ApiVersion("5.29")]
        public ReadOnlyCollection<User> GetList(LikeObjectType type, long? ownerId = null, long? itemId = null, string pageUrl = null, string filter = null, bool? friendsOnly = null, bool? extended = null, long? offset = null, int? count = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => offset);
            VkErrors.ThrowIfNumberIsNegative(() => count);

            var parameters = new VkParameters
                {
                    {"type", type},
                    {"owner_id", ownerId},
                    {"item_id", itemId},
                    {"page_url", pageUrl},
                    {"filter", filter},
                    {"friends_only", friendsOnly},
                    {"extended", extended},
                    {"offset", offset},
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("likes.getList", parameters);

            if (extended == true)
                return response.ToReadOnlyCollectionOf<User>(x => x);
            else
                return response.ToReadOnlyCollectionOf<User>(x => new User() { Id = x });
        }

        /// <summary>
        /// Добавляет указанный объект в список Мне нравится текущего пользователя. 
        /// </summary>
        /// <param name="type">Тип объекта <see cref="LikeObjectType"/></param>
        /// <param name="itemId">Идентификатор объекта. положительное число, обязательный параметр</param>
        /// <param name="ownerId">Идентификатор владельца объекта. целое число, по умолчанию идентификатор текущего пользователя</param>
        /// <param name="accessKey">Ключ доступа в случае работы с приватными объектами. строка</param>
        /// <returns>В случае успеха возвращает объект с полем likes, в котором находится текущее количество пользователей, которые добавили данный объект в свой список Мне нравится. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/likes.add"/>.
        /// </remarks>
        [ApiVersion("5.29")]
        public long Add(LikeObjectType type, long itemId, long? ownerId = null, string accessKey = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => itemId);

            var parameters = new VkParameters
                {
                    {"type", type},
                    {"item_id", itemId},
                    {"owner_id", ownerId},
                    {"access_key", accessKey}
                };

            VkResponse response = _vk.Call("likes.add", parameters);

            return response["likes"];
        }

        /// <summary>
        /// Удаляет указанный объект из списка Мне нравится текущего пользователя 
        /// </summary>
        /// <param name="type">Тип объекта <see cref="LikeObjectType"/></param>
        /// <param name="itemId">Идентификатор объекта. положительное число, обязательный параметр</param>
        /// <param name="ownerId">Идентификатор владельца объекта. целое число, по умолчанию идентификатор текущего пользователя</param>
        /// <returns>В случае успеха возвращает объект с полем likes, в котором находится текущее количество пользователей, которые добавили данный объект в свой список Мне нравится. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/likes.delete"/>.
        /// </remarks>
        [ApiVersion("5.29")]
        public long Delete(LikeObjectType type, long itemId, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => itemId);

            var parameters = new VkParameters
                {
                    {"type", type},
                    {"item_id", itemId},
                    {"owner_id", ownerId}
                };

            VkResponse response = _vk.Call("likes.delete", parameters);

            return response["likes"];
        }
        /// <summary>
        /// Проверяет, находится ли объект в списке Мне нравится заданного пользователя. 
        /// </summary>
        /// <param name="type">Тип объекта <see cref="LikeObjectType"/></param>
        /// <param name="itemId">Идентификатор объекта. положительное число, обязательный параметр</param>
        /// <param name="userId">Идентификатор пользователя, у которого необходимо проверить наличие объекта в списке «Мне нравится». Если параметр не задан, то считается, что он равен идентификатору текущего пользователя. положительное число, по умолчанию идентификатор текущего пользователя</param>
        /// <param name="ownerId">Идентификатор владельца Like-объекта. Если параметр не задан, то считается, что он равен идентификатору текущего пользователя. целое число, по умолчанию идентификатор текущего пользователя</param>
        /// <returns>В случае успеха возвращает одно из следующих числовых значений: 
        /// 
        /// 0 — указанный Like-объект не входит в список Мне нравится пользователя с идентификатором user_id. 
        /// 1 — указанный Like-объект находится в списке Мне нравится пользователя с идентификатором user_id. </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/likes.isLiked"/>.
        /// </remarks>
        [ApiVersion("5.34")]
        public bool IsLiked(LikeObjectType type, long itemId, out bool copied, long? userId = null, long? ownerId = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => itemId);
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            var parameters = new VkParameters
                {
                    {"type", type},
                    {"item_id", itemId},
                    {"user_id", userId},
                    {"owner_id", ownerId}
                };

            var resp = _vk.Call("likes.isLiked", parameters, apiVersion: "5.34");

            copied = resp["copied"];
            return resp["liked"];
        }
    }
}
