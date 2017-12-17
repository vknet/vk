using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
    public interface IUsersCategory
    {
        /// <summary>
        /// Возвращает список пользователей в соответствии с заданным критерием поиска.
        /// </summary>
        /// <param name="params">Параметры запроса.</param>
        /// <returns>
        /// После успешного выполнения возвращает список объектов пользователей, найденных в соответствии с заданными критериями.
        /// </returns>
        /// <exception cref="ArgumentException">Query can not be <c>null</c> or empty.</exception>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.search
        /// </remarks>
        VkCollection<User> Search(UserSearchParams @params);

        /// <summary>
        /// Возвращает информацию о том, установил ли пользователь приложение.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя. целое число, по умолчанию идентификатор текущего пользователя (Целое число, по умолчанию идентификатор текущего пользователя).</param>
        /// <returns>
        /// После успешного выполнения возвращает 1 в случае, если пользователь установил у себя данное приложение, иначе 0.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.isAppUser
        /// </remarks>
        bool IsAppUser(long? userId);

        /// <summary>
        /// Возвращает расширенную информацию о пользователе.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="fields">Поля профиля, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <param name="skipAuthorization">Если <c>true</c>, то пропустить авторизацию</param>
        /// <returns>Объект, содержащий запрошенную информацию о пользователе.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/getProfiles
        /// </remarks>
        User Get(long userId, ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false);

        /// <summary>
        /// Возвращает расширенную информацию о пользователях. Метод не требует авторизацию
        /// </summary>
        /// <param name="userIds">Идентификаторы пользователей, о которых необходимо получить информацию.</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <param name="skipAuthorization">Если <c>true</c>, то пропустить авторизацию</param>
        /// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.get
        /// </remarks>
        ReadOnlyCollection<User> Get([NotNull] IEnumerable<long> userIds, ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false);

        /// <summary>
        /// Возвращает расширенную информацию о пользователях.
        /// </summary>
        /// <param name="screenNames">Короткие имена пользователей, о которых необходимо получить информацию.</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <param name="skipAuthorization">Если <c>true</c>, то пропустить авторизацию</param>
        /// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.get
        /// </remarks>
        ReadOnlyCollection<User> Get([NotNull] IEnumerable<string> screenNames, ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false);

        /// <summary>
        /// Возвращает расширенную информацию о пользователе.
        /// </summary>
        /// <param name="screenName">Короткое имя пользователя</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <param name="skipAuthorization">Если <c>true</c>, то пропустить авторизацию</param>
        /// <returns>Объект User</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.get
        /// </remarks>
        User Get([NotNull] string screenName, ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false);

        /// <summary>
        /// Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, подписки которого необходимо получить</param>
        /// <param name="count">Количество подписок, которые необходимо вернуть</param>
        /// <param name="offset">Смещение необходимое для выборки определенного подмножества подписок</param>
        /// <param name="fields">Список дополнительных полей для объектов user и group, которые необходимо вернуть.</param>
        /// <param name="skipAuthorization">Если <c>true</c>, то пропустить авторизацию</param>
        /// <returns>
        /// Пока возвращается только список групп.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.getSubscriptions
        /// </remarks>
        VkCollection<Group> GetSubscriptions(long? userId = null, int? count = null, int? offset = null, GroupsFields fields = null, bool skipAuthorization = false);

        /// <summary>
        /// Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="count">Количество подписчиков, информацию о которых нужно получить</param>
        /// <param name="offset">Смещение, необходимое для выборки определенного подмножества подписчиков</param>
        /// <param name="fields">Список дополнительных полей, которые необходимо вернуть</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <param name="skipAuthorization">Если <c>true</c>, то пропустить авторизацию</param>
        /// <returns>Список подписчиков</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.getFollowers
        /// </remarks>
        VkCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null, bool skipAuthorization = false);

        /// <summary>
        /// Позволяет пожаловаться на пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, на которого осуществляется жалоба</param>
        /// <param name="type">Тип жалобы</param>
        /// <param name="comment">Комментарий к жалобе на пользователя</param>
        /// <returns>В случае успешной жалобы метод вернет true.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.report
        /// </remarks>
        bool Report(long userId, ReportType type, string comment = "");

        /// <summary>
        /// Индексирует текущее местоположение пользователя и возвращает список пользователей, которые находятся вблизи.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>
        /// После успешного выполнения возвращает список объектов user.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте http://vk.com/dev/users.getNearby
        /// </remarks>
        VkCollection<User> GetNearby(UsersGetNearbyParams @params);
    }
}