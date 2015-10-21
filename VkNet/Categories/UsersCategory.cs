namespace VkNet.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using JetBrains.Annotations;

    using Enums.Filters;
    using Enums.SafetyEnums;
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
        [Pure]
        public ReadOnlyCollection<User> Search([NotNull] string query, out int itemsCount, ProfileFields fields = null, int count = 20, int offset = 0)
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

        /// <summary> Возвращает список пользователей в соответствии с заданным критерием поиска. </summary>
        /// <param name="query">строка поискового запроса. Например, Вася Бабич.</param>
        /// <param name="itemsCount">Общее количество пользователей, удовлетворяющих условиям запроса.</param>
        /// <param name="fields">список дополнительных полей, которые необходимо вернуть.</param>
        /// <param name="count">количество возвращаемых пользователей.
        /// Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов.</param>
        /// <param name="offset">смещение относительно первого найденного пользователя для выборки определенного подмножества.</param>
        /// <param name="sort">сортировка результатов: 1 - по дате регистрации, 0 - по популярности</param>
        /// <param name="city">идентификатор города</param>
        /// <param name="country">идентификатор страны</param>
        /// <param name="hometown">название города строкой</param>
        /// <param name="university_country">идентификатор страны, в которой пользователи закончили ВУЗ</param>
        /// <param name="university">идентификатор ВУЗа</param>
        /// <param name="university_year">год окончания ВУЗа</param>
        /// <param name="university_faculty">идентификатор факультета</param>
        /// <param name="university_chair">идентификатор кафедры</param>
        /// <param name="sex">пол, 1 — женщина, 2 — мужчина, 0 (по умолчанию) — любой.</param>
        /// <param name="status">семейное положение: 1 — Не женат, 2 — Встречается, 3 — Помолвлен, 4 — Женат, 7 — Влюблён, 5 — Всё сложно, 6 — В активном поиске.</param>
        /// <param name="age_from">начиная с какого возраста</param>
        /// <param name="age_to">до какого возраста</param>
        /// <param name="birth_day">день рождения</param>
        /// <param name="birth_month">месяц рождения</param>
        /// <param name="birth_year">год рождения</param>
        /// <param name="online">true — только в сети, false — все пользователи</param>
        /// <param name="has_photo">true — только с фотографией, false — все пользователи</param>
        /// <param name="school_country">идентификатор страны, в которой пользователи закончили школу</param>
        /// <param name="school_city">идентификатор города, в котором пользователи закончили школу</param>
        /// <param name="school_class">положительное число</param>
        /// <param name="school">идентификатор школы, которую закончили пользователи</param>
        /// <param name="school_year">год окончания школы</param>
        /// <param name="religion">религиозные взгляды</param>
        /// <param name="interests">интересы</param>
        /// <param name="company">название компании, в которой работают пользователи</param>
        /// <param name="position">название должности</param>
        /// <param name="group_id">идентификатор группы, среди пользователей которой необходимо проводить поиск</param>
        /// <returns> После успешного выполнения возвращает список объектов пользователей, найденных в соответствии с заданными критериями. </returns>
        /// <remarks> Страница документации ВКонтакте <see href="http://vk.com/dev/users.search"/>. </remarks>
        [Pure]
        public ReadOnlyCollection<User> Search([NotNull] string query, out int itemsCount, ProfileFields fields = null, int count = 20, int offset = 0,
            int? sort = null, int? city = null, int? country = null, string hometown = null, int? university_country = null, int? university = null,
            int? university_year = null, int? university_faculty = null, int? university_chair = null, int? sex = null, int? status = null,
            int? age_from = null, int? age_to = null, int? birth_day = null, int? birth_month = null, int? birth_year = null, bool? online = null,
            bool? has_photo = null, int? school_country = null, int? school_city = null, int? school_class = null, int? school = null, int? school_year = null,
            string religion = null, string interests = null, string company = null, string position = null, int? group_id = null)
        {
            // TODO: не все аргументы проверены

            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Query can not be null or empty.");

            var parameters = new VkParameters
            {
                { "q", query },
                { "fields", fields },
                { "count", count },
                { "sort", sort },
                { "city", city },
                { "country", country },
                { "hometown", hometown },
                { "university_country", university_country },
                { "university", university },
                { "university_year", university_year },
                { "university_faculty", university_faculty },
                { "university_chair", university_chair },
                { "sex", sex },
                { "status", status },
                { "age_from", age_from },
                { "age_to", age_to },
                { "birth_day", birth_day },
                { "birth_month", birth_month },
                { "birth_year", birth_year },
                { "online", online },
                { "has_photo", has_photo },
                { "school_country", school_country },
                { "school_city", school_city },
                { "school_class", school_class },
                { "school", school },
                { "school_year", school_year },
                { "religion", religion },
                { "interests", interests },
                { "company", company },
                { "position", position },
                { "group_id", group_id },
            };
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
        [Pure]
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
        [Pure]
        [ApiVersion("5.9")]
        public bool IsAppUser(long userId)
        {   
            var parameters = new VkParameters { { "user_id", userId } };

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
        [Pure]
        [ApiVersion("5.9")]
        public User Get(long userId, ProfileFields fields = null,
                                            NameCase nameCase = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase }, { "user_ids", userId } };

            VkResponseArray response = _vk.Call("users.get", parameters, true);

            return response[0];
        }

        /// <summary>
        /// Возвращает расширенную информацию о пользователях. Метод не требует авторизацию
        /// </summary>
        /// <param name="userIds">Идентификаторы пользователей, о которых необходимо получить информацию.</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/users.get"/>.
        /// </remarks>
        [Pure]
        [ApiVersion("5.21")]
        public ReadOnlyCollection<User> Get([NotNull] IEnumerable<long> userIds, ProfileFields fields = null, NameCase nameCase = null)
        {
            if (userIds == null)
                throw new ArgumentNullException("userIds");

            var parameters = new VkParameters { { "fields", fields }, { "name_case", nameCase } };
            parameters.Add("user_ids", userIds);

            VkResponseArray response = _vk.Call("users.get", parameters);

            return response.ToReadOnlyCollectionOf<User>(x => x);
        }

        /// <summary>
        /// Возвращает расширенную информацию о пользователях.
        /// </summary>
        /// <param name="screenNames">Короткие имена пользователей, о которых необходимо получить информацию.</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <returns>Список объектов с запрошенной информацией о пользователях.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/users.get"/>.
        /// </remarks>
        [Pure, NotNull, ContractAnnotation("screenNames:null => halt")]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<User> Get([NotNull] IEnumerable<string> screenNames, ProfileFields fields = null, NameCase nameCase = null)
        {
            if (screenNames == null)
                throw new ArgumentNullException("screenNames");

            var parameters = new VkParameters
                {
                    { "user_ids", screenNames }, 
                    { "fields", fields }, 
                    { "name_case", nameCase }
                };

            VkResponseArray response = _vk.Call("users.get", parameters);
            return response.ToReadOnlyCollectionOf<User>(x => x);
        }

#if false
        // todo start shit
        [Pure, NotNull, ContractAnnotation("screenNames:null => halt")]
        [ApiVersion("5.9")]
        public async Task<ReadOnlyCollection<User>> GetAsync([NotNull] IEnumerable<string> screenNames, ProfileFields fields = null, NameCase nameCase = null)
        {
            if (screenNames == null)
                throw new ArgumentNullException("screenNames");

            var parameters = new VkParameters
                {
                    { "user_ids", screenNames }, 
                    { "fields", fields }, 
                    { "name_case", nameCase }
                };

            VkResponseArray response = await _vk.CallAsync("users.get", parameters);
            return response.ToReadOnlyCollectionOf<User>(x => x);
        }
#endif

        // todo end shit

        /// <summary>
        /// Возвращает расширенную информацию о пользователе.
        /// </summary>
        /// <param name="screenName">Короткое имя пользователя</param>
        /// <param name="fields">Поля профилей, которые необходимо возвратить.</param>
        /// <param name="nameCase">Падеж для склонения имени и фамилии пользователя</param>
        /// <returns>Объект <see cref="User"/> с запрошенной информацией о пользователе.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="http://vk.com/dev/users.get"/>.
        /// </remarks>
        [Pure, CanBeNull, ContractAnnotation("screenName:null => halt")]
        public User Get([NotNull] string screenName, ProfileFields fields = null, NameCase nameCase = null)
        {
            VkErrors.ThrowIfNullOrEmpty(() => screenName);

            ReadOnlyCollection<User> users = Get(new[] {screenName}, fields, nameCase);
            return users.Count > 0 ? users[0] : null;
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
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<Group> GetSubscriptions(long? userId = null, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => userId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"extended", true},
                    {"offset", offset},
                    {"count", count}
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
        [Pure]
        [ApiVersion("5.9")]
        public ReadOnlyCollection<User> GetFollowers(long? userId = null, int? count = null, int? offset = null, ProfileFields fields = null, NameCase nameCase = null)
        {
            VkErrors.ThrowIfNumberIsNegative(() => userId);
            VkErrors.ThrowIfNumberIsNegative(() => count);
            VkErrors.ThrowIfNumberIsNegative(() => offset);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"offset", offset},
                    {"count", count},
                    {"fields", fields},
                    {"name_case", nameCase}
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
        [ApiVersion("5.9")]
        public bool Report(long userId, ReportType type, string comment = "")
        {
            VkErrors.ThrowIfNumberIsNegative(() => userId);

            var parameters = new VkParameters
                {
                    {"user_id", userId},
                    {"type", type},
                    {"comment", comment}
                };

            return _vk.Call("users.report", parameters);
        }
    }
}
