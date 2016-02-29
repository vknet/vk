using System;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <summary>
    /// Методы для работы с друзьями.
    /// </summary>
    public partial class FriendsCategory
    {
        /// <summary>
        /// Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
        /// </summary>
        /// <param name="uid">Идентификатор пользователя, для которого необходимо получить список друзей.</param>
        /// <param name="fields">Поля анкеты (профиля), которые необходимо получить.</param>
        /// <param name="count">Количество друзей, которое нужно вернуть. (по умолчанию – все друзья).</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества друзей.</param>
        /// <param name="order">Порядок, в котором нужно вернуть список друзей.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя.</param>
        /// <param name="listId">Идентификатор списка друзей, полученный методом <see cref="FriendsCategory.GetLists"/>, друзей из которого необходимо получить. Данный параметр учитывается, только когда параметр uid равен идентификатору текущего пользователя.</param>
        /// <returns>Список друзей пользователя с заполненными полями (указанными в параметре <paramref name="fields"/>).
        /// Если значение поля <paramref name="fields"/> не указано, то у возвращаемых друзей заполняется только поле Id.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/friends.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.44")]
        [Obsolete("Данный метод устарел. Используйте Get(FriendsGetParams @params)")]
        public ReadOnlyCollection<User> Get(long uid, ProfileFields fields = null, int? count = null, int? offset = null, FriendsOrder order = null, NameCase nameCase = null, int? listId = null)
        {
            if (listId != null && listId < 0)
                throw new ArgumentOutOfRangeException("listId", "listId must be a positive number.");

            var parameters = new FriendsGetParams
            {
                UserId = uid,
                Count = count,
                Offset = offset,
                Fields = fields,
                NameCase = nameCase,
                ListId = listId,
                Order = order
            };

            return Get(parameters);
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
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/friends.getOnline"/>.
        /// </remarks>
        [Pure]
        [Obsolete("Данный метод устарел. Используйте GetOnline(FriendsGetOnlineParams @params)")]
        public ReadOnlyCollection<long> GetOnline(long uid)
        {
            var parameters = new FriendsGetOnlineParams { UserId = uid };

            return GetOnline(parameters);
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
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/friends.getMutual"/>.
        /// </remarks>
        [Pure]
        [Obsolete("Данный метод устарел. Используйте GetMutual(FriendsGetMutualParams @params)")]
        public ReadOnlyCollection<long> GetMutual(long targetUid, long sourceUid)
        {
            var parameters = new FriendsGetMutualParams
            {
                SourceUid = sourceUid,
                TargetUid = targetUid
            };

            return GetMutual(parameters);
        }

        /// <summary>
        /// Одобряет или создает заявку на добавление в друзья.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, которому необходимо отправить заявку, либо заявку от которого необходимо одобрить.</param>
        /// <param name="text">Текст сопроводительного сообщения для заявки на добавление в друзья. Максимальная длина сообщения — 500 символов.</param>
        /// <param name="captchaSid">Id капчи (только если для вызова метода необходимо ввести капчу)</param>
        /// <param name="captchaKey">Текст капчи (только если для вызова метода необходимо ввести капчу)</param>
        /// <returns>
        /// После успешного выполнения возвращает одно из следующих значений:
        /// 1 — заявка на добавление данного пользователя в друзья отправлена;
        /// 2 — заявка на добавление в друзья от данного пользователя одобрена;
        /// 4 — повторная отправка заявки.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/friends.add"/>.
        /// </remarks>
        [Obsolete("Данный метод устарел. Используйте Add(long userId, string text, bool? follow = null, long? captchaSid = null, string captchaKey = null)")]
        public AddFriendStatus Add(long userId, string text = "", long? captchaSid = null, string captchaKey = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            return Add(userId, text, null, captchaSid, captchaKey);
        }

        /// <summary>
        /// Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя
        /// </summary>
        /// <param name="count">Максимальное количество заявок на добавление в друзья, которые необходимо получить (не более 1000)</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества заявок на добавление в друзья</param>
        /// <param name="extended">Определяет, требуется ли возвращать в ответе сообщения от пользователей, подавших заявку на добавление
        /// в друзья. И отправителя рекомендации при <c>suggested</c>=<c>true</c>.</param>
        /// <param name="needMutual">Определяет, требуется ли возвращать в ответе список общих друзей, если они есть. Обратите внимание,
        /// что при использовании need_mutual будет возвращено не более 20 заявок.</param>
        /// <param name="out"><c>false</c> — возвращать полученные заявки в друзья (по умолчанию), <c>true</c> — возвращать отправленные пользователем
        /// заявки.</param>
        /// <param name="sort"><c>false</c> — сортировать по дате добавления, <c>true</c> — сортировать по количеству общих друзей. (Если <c>out</c> = <c>true</c>,
        /// данный параметр не учитывается).</param>
        /// <param name="suggested"><c>true</c> — возвращать рекомендованных другими пользователями друзей, <c>false</c> — возвращать заявки в друзья
        /// (по умолчанию).</param>
        /// <returns>
        /// - Если не установлен параметр need_mutual, то в случае успеха возвращает отсортированный в антихронологическом порядке по
        /// времени подачи заявки список идентификаторов (id) пользователей (кому или от кого пришла заявка).
        /// - Если установлен параметр need_mutual, то в случае успеха возвращает отсортированный в антихронологическом порядке по
        /// времени подачи заявки массив объектов, содержащих информацию о заявках на добавление в друзья. Каждый из объектов содержит
        /// поле uid, являющийся идентификатором пользователя. При наличии общих друзей, в объекте будет содержаться поле mutual, в
        /// котором будет находиться список идентификаторов общих друзей.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/friends.getRequests"/>.
        /// </remarks>
        [Pure]
        [Obsolete("Данный метод устарел. Используйте GetRequests(FriendsGetRequestsParams @params)")]
        public ReadOnlyCollection<long> GetRequests(int? count = null, int? offset = null, bool extended = false, bool needMutual = false, bool @out = false, bool sort = false, bool suggested = false)
        {
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new FriendsGetRequestsParams
            {
                Offset = offset,
                Count = count,
                Extended = extended,
                NeedMutual = needMutual,
                Out = @out,
                Sort = sort,
                Suggested = suggested
            };

            return GetRequests(parameters).Select(x => x.Key).ToReadOnlyCollection();
        }

    }
}