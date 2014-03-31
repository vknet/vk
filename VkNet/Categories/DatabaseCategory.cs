using JetBrains.Annotations;

namespace VkNet.Categories
{
    using System.Linq;
    using System.Collections.ObjectModel;

    using Model;
    using Utils;

    /// <summary>
    /// Методы для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
    /// </summary>
    public class DatabaseCategory
    {
        private readonly VkApi _vk;

        public DatabaseCategory(VkApi vk)
        {
            _vk = vk;
        }

        /// <summary>
        /// Возвращает список стран.
        /// </summary>
        /// <param name="needAll">Флаг - вернуть список всех стран.</param>
        /// <param name="codes">Перечисленные через запятую двухбуквенные коды стран в стандарте ISO 3166-1 alpha-2 
        /// <see cref="http://vk.com/dev/country_codes"/>.</param>
        /// <param name="offset">Отступ, необходимый для выбора определенного подмножества стран.</param>
        /// <param name="count">Количество стран, которое необходимо вернуть.</param>
        /// <remarks>
        /// Если не заданы параметры needAll и code, то возвращается краткий список стран, расположенных наиболее близко к стране 
        /// текущего пользователя. Если задан параметр needAll, то будет возвращен список всех стран. Если задан параметр code, 
        /// то будут возвращены только страны с перечисленными ISO 3166-1 alpha-2 кодами.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getCountries"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Country> GetCountries(bool needAll = true, string codes = "", int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(offset, "offset", "Отступ должен быть положительным числом.");
            VkErrors.ThrowIfNumberIsNegative(count, "count", "Количество стран, которое необходимо вернуть должно быть положительным числом.");

            var parameters = new VkParameters { { "code", codes }, { "offset", offset }, { "count", count }, { "need_all", needAll } };

            VkResponseArray response = _vk.Call("database.getCountries", parameters, true);
            return response.ToReadOnlyCollectionOf<Country>(x => x);
        }

        /// <summary>
        /// Возвращает список регионов.
        /// </summary>
        /// <param name="countryId">Идентификатор страны.</param>
        /// <param name="query">Строка поискового запроса.</param>
        /// <param name="count">Количество регионов, которое необходимо вернуть.</param>
        /// <param name="offset">Отступ, необходимый для выбора определенного подмножества регионов.</param>
        /// <returns>Список регионов.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getRegions"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Region> GetRegions(int countryId, string query = "", int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(countryId, "countryId", "Идентификатор страны должен быть положительным числом.");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset", "Отступ должен быть положительным числом.");
            VkErrors.ThrowIfNumberIsNegative(count, "count", "Количество стран, которое необходимо вернуть должно быть положительным числом.");

            var parameters = new VkParameters { { "country_id", countryId }, { "q", query }, { "offset", offset }, { "count", count } };

            VkResponseArray response = _vk.Call("database.getRegions", parameters, true);
            
            return response.ToReadOnlyCollectionOf<Region>(r => r);
        }

        /// <summary>
        /// Возвращает информацию об улицах по их идентификаторам.
        /// </summary>
        /// <param name="streetIds">Идентификаторы улиц.</param>
        /// <returns>Информация об улицах.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getStreetsById"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Street> GetStreetsById(params int[] streetIds)
        {
            var parameters = new VkParameters();
            parameters.Add<int>("street_ids", streetIds);

            VkResponseArray response = _vk.Call("database.getStreetsById", parameters, true);
            return response.ToReadOnlyCollectionOf<Street>(x => x);
        }

        /// <summary>
        /// Возвращает информацию о странах по их идентификаторам.
        /// </summary>
        /// <param name="countryIds">Идентификаторы стран.</param>
        /// <returns>Информация о странах.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getCountriesById"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Country> GetCountriesById(params int[] countryIds)
        {
            var parameters = new VkParameters();
            parameters.Add<int>("country_ids", countryIds);

            VkResponseArray response = _vk.Call("database.getCountriesById", parameters, true);

            return response.ToReadOnlyCollectionOf<Country>(c => c);
        }

        /// <summary>
        /// Возвращает список городов.
        /// </summary>
        /// <param name="countryId">Идентификатор страны.</param>
        /// <param name="regionId">Идентификатор региона.</param>
        /// <param name="query">Строка поискового запроса. Например, Санкт.</param>
        /// <param name="needAll">true – возвращать все города. false – возвращать только основные города.</param>
        /// <param name="count">Количество городов, которые необходимо вернуть.</param>
        /// <param name="offset">Отступ, необходимый для получения определенного подмножества городов.</param>
        /// <returns>Cписок городов</returns>
        /// <remarks>
        /// Возвращает коллекцию городов, каждый из которых содержит поля <see cref="City.Id"/> и <see cref="City.Title"/>. 
        /// При наличии информации о регионе и/или области, в которых находится данный город, в объекте могут дополнительно 
        /// включаться поля <see cref="City.Area"/> и <see cref="City.Region"/>. 
        /// Если не задан параметр <paramref name="query"/>, то будет возвращен список самых крупных городов в заданной стране. 
        /// Если задан параметр <paramref name="query"/>, то будет возвращен список городов, которые релевантны поисковому запросу.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getCities"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<City> GetCities(int countryId, int? regionId = null, string query = "", bool? needAll = false, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(countryId, "countryId");
            VkErrors.ThrowIfNumberIsNegative(regionId, "regionId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    { "country_id", countryId }, 
                    { "region_id", regionId }, 
                    {"q", query},
                    {"need_all", needAll},
                    {"offset", offset},
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("database.getCities", parameters, true);
            return response.ToReadOnlyCollectionOf<City>(x => x);
        }

        /// <summary>
        /// Возвращает информацию о городах по их идентификаторам.
        /// </summary>
        /// <param name="cityIds">Идентификаторы городов.</param>
        /// <returns>Информация о городах.</returns>
        /// <remarks>
        /// Идентификаторы городов могут быть получены с помощью методов <see cref="UsersCategory.Get(long,VkNet.Enums.ProfileFields,VkNet.Enums.NameCase)"/>"/>, 
        /// places.getById, places.search, places.getCheckins.
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getCitiesById"/>. 
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<City> GetCitiesById(params int[] cityIds)
        {
            var parameters = new VkParameters();
            parameters.Add<int>("city_ids", cityIds);

            VkResponseArray response = _vk.Call("database.getCitiesById", parameters, true);
            return response.ToReadOnlyCollectionOf<City>(x => x);
        }

        /// <summary>
        /// Возвращает список высших учебных заведений.
        /// </summary>
        /// <param name="countryId">Идентификатор страны, учебные заведения которой необходимо вернуть.</param>
        /// <param name="cityId">Идентификатор города, учебные заведения которого необходимо вернуть.</param>
        /// <param name="query">Строка поискового запроса. Например, СПБ.</param>
        /// <param name="offset">Отступ, необходимый для получения определенного подмножества учебных заведений.</param>
        /// <param name="count">Количество учебных заведений, которое необходимо вернуть.</param>
        /// <returns>Список высших учебных заведений, удовлетворяющих заданным условиям.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getUniversities"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<University> GetUniversities(int countryId, int cityId, string query = "", int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(countryId, "countryId");
            VkErrors.ThrowIfNumberIsNegative(cityId, "cityId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");
            
            var parameters = new VkParameters
                {
                    {"q", query},
                    {"country_id", countryId},
                    {"city_id", cityId},
                    {"offset", offset},
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("database.getUniversities", parameters, true);
            return response.Skip(1).ToReadOnlyCollectionOf<University>(x => x);
        }

        /// <summary>
        /// Возвращает список школ.
        /// </summary>
        /// <param name="countryId">Идентификатор страны, школы которой необходимо вернуть.</param>
        /// <param name="cityId">Идентификатор города, школы которого необходимо вернуть. </param>
        /// <param name="query">Строка поискового запроса. Например, гимназия.</param>
        /// <param name="offset">Отступ, необходимый для получения определенного подмножества школ.</param>
        /// <param name="count">Количество школ, которое необходимо вернуть. </param>
        /// <returns>Cписок школ.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getSchools"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<School> GetSchools(int countryId, int cityId, string query = "", int? offset = null, int? count = null)
        {
            VkErrors.ThrowIfNumberIsNegative(countryId, "countryId");
            VkErrors.ThrowIfNumberIsNegative(cityId, "cityId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"q", query},
                    {"country_id", countryId},
                    {"city_id", cityId},
                    {"offset", offset},
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("database.getSchools", parameters, true);
            return response.Skip(1).ToReadOnlyCollectionOf<School>(x => x);
        }

        /// <summary>
        /// Возвращает список факультетов.
        /// </summary>
        /// <param name="universityId">Идентификатор университета, факультеты которого необходимо получить.</param>
        /// <param name="count">Отступ, необходимый для получения определенного подмножества факультетов.</param>
        /// <param name="offset">Количество факультетов которое необходимо получить.</param>
        /// <returns>Cписок факультетов.</returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see cref="http://vk.com/dev/database.getFaculties"/>.
        /// </remarks>
        [Pure]
        public ReadOnlyCollection<Faculty> GetFaculties(long universityId, int? count = null, int? offset = null)
        {
            VkErrors.ThrowIfNumberIsNegative(universityId, "universityId");
            VkErrors.ThrowIfNumberIsNegative(count, "count");
            VkErrors.ThrowIfNumberIsNegative(offset, "offset");

            var parameters = new VkParameters
                {
                    {"university_id", universityId},
                    {"offset", offset},
                    {"count", count}
                };

            VkResponseArray response = _vk.Call("database.getFaculties", parameters, true);
            return response.Skip(1).ToReadOnlyCollectionOf<Faculty>(x => x);
        }
    }
}