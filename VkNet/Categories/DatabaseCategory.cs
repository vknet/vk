using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Database;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для получения справочной информации (страны, города, школы, учебные
	/// заведения и т.п.).
	/// </summary>
	public partial class DatabaseCategory : IDatabaseCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public DatabaseCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список стран.
		/// </summary>
		/// <param name="needAll"> Флаг - вернуть список всех стран. </param>
		/// <param name="codes">
		/// Перечисленные через запятую двухбуквенные коды стран в стандарте ISO 3166-1
		/// alpha-2
		/// http://vk.com/dev/country_codes
		/// </param>
		/// <param name="offset">
		/// Отступ, необходимый для выбора определенного подмножества
		/// стран.
		/// </param>
		/// <param name="count">
		/// Количество стран, которое необходимо вернуть (по умолчанию 100, максимальное
		/// значение 1000).
		/// </param>
		/// <remarks>
		/// Если не заданы параметры needAll и code, то возвращается краткий список стран,
		/// расположенных наиболее близко к
		/// стране
		/// текущего пользователя. Если задан параметр needAll, то будет возвращен список
		/// всех стран. Если задан параметр code,
		/// то будут возвращены только страны с перечисленными ISO 3166-1 alpha-2 кодами.
		/// Страница документации ВКонтакте http://vk.com/dev/database.getCountries
		/// </remarks>
		[Pure]
		public VkCollection<Country> GetCountries(bool? needAll = null
												, IEnumerable<Iso3166> codes = null
												, int? count = null
												, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);

			var parameters = new VkParameters
			{
					{ "code", codes }
					, { "offset", offset }
					, { "count", count }
					, { "need_all", needAll }
			};

			return _vk.Call(methodName: "database.getCountries", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<Country>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список регионов.
		/// </summary>
		/// <param name="countryId"> Идентификатор страны. </param>
		/// <param name="query"> Строка поискового запроса. </param>
		/// <param name="count"> Количество регионов, которое необходимо вернуть. </param>
		/// <param name="offset">
		/// Отступ, необходимый для выбора определенного подмножества
		/// регионов.
		/// </param>
		/// <returns> Список регионов. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getRegions
		/// </remarks>
		[Pure]
		public VkCollection<Region> GetRegions(int countryId, string query = "", int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => countryId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);

			var parameters = new VkParameters
			{
					{ "country_id", countryId }
					, { "q", query }
					, { "offset", offset }
					, { "count", count }
			};

			return _vk.Call(methodName: "database.getRegions", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<Region>(selector: r => r);
		}

		/// <summary>
		/// Возвращает информацию об улицах по их идентификаторам.
		/// </summary>
		/// <param name="streetIds"> Идентификаторы улиц. </param>
		/// <returns> Информация об улицах. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getStreetsById
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<Street> GetStreetsById(params int[] streetIds)
		{
			var parameters = new VkParameters
			{
					{ "street_ids", streetIds.JoinNonEmpty() }
			};

			return _vk.Call(methodName: "database.getStreetsById", parameters: parameters, skipAuthorization: true)
					.ToReadOnlyCollectionOf<Street>(selector: x => x);
		}

		/// <summary>
		/// Возвращает информацию о странах по их идентификаторам.
		/// </summary>
		/// <param name="countryIds"> Идентификаторы стран. </param>
		/// <returns> Информация о странах. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getCountriesById
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<Country> GetCountriesById(params int[] countryIds)
		{
			var parameters = new VkParameters
			{
					{ "country_ids", countryIds.JoinNonEmpty() }
			};

			return _vk.Call(methodName: "database.getCountriesById", parameters: parameters, skipAuthorization: true)
					.ToReadOnlyCollectionOf<Country>(selector: c => c);
		}

		/// <summary>
		/// Возвращает список городов.
		/// </summary>
		/// <param name="params"> Параметры запроса database.getCities </param>
		/// <returns> Cписок городов </returns>
		/// <remarks>
		/// Возвращает коллекцию городов, каждый из которых содержит поля City.Id
		/// При наличии информации о регионе и/или области, в которых находится данный
		/// город, в объекте могут дополнительно
		/// включаться поля City.Area
		/// Если не задан параметр <paramref name="params.query" />, то будет возвращен
		/// список самых крупных городов в заданной
		/// стране.
		/// Если задан параметр <paramref name="params.query" />, то будет возвращен список
		/// городов, которые релевантны
		/// поисковому запросу.
		/// Страница документации ВКонтакте http://vk.com/dev/database.getCities
		/// </remarks>
		[Pure]
		public VkCollection<City> GetCities(GetCitiesParams @params)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.CountryId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => @params.RegionId);

			return _vk.Call(methodName: "database.getCities", parameters: @params, skipAuthorization: true)
					.ToVkCollectionOf<City>(selector: x => x);
		}

		/// <summary>
		/// Возвращает информацию о городах по их идентификаторам.
		/// </summary>
		/// <param name="cityIds"> Идентификаторы городов. </param>
		/// <returns> Информация о городах. </returns>
		/// <remarks>
		/// Идентификаторы городов могут быть получены с помощью методов UsersCategory.Get,
		/// places.getById, places.search, places.getCheckins.
		/// Страница документации ВКонтакте http://vk.com/dev/database.getCitiesById
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<City> GetCitiesById(params int[] cityIds)
		{
			var parameters = new VkParameters
			{
					{ "city_ids", cityIds.JoinNonEmpty() }
			};

			return _vk.Call(methodName: "database.getCitiesById", parameters: parameters, skipAuthorization: true)
					.ToReadOnlyCollectionOf<City>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список высших учебных заведений.
		/// </summary>
		/// <param name="countryId">
		/// Идентификатор страны, учебные заведения которой
		/// необходимо вернуть.
		/// </param>
		/// <param name="cityId">
		/// Идентификатор города, учебные заведения которого
		/// необходимо вернуть.
		/// </param>
		/// <param name="query"> Строка поискового запроса. Например, СПБ. </param>
		/// <param name="offset">
		/// Отступ, необходимый для получения определенного
		/// подмножества учебных заведений.
		/// </param>
		/// <param name="count"> Количество учебных заведений, которое необходимо вернуть. </param>
		/// <returns> Список высших учебных заведений, удовлетворяющих заданным условиям. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getUniversities
		/// </remarks>
		[Pure]
		public VkCollection<University> GetUniversities(int countryId, int cityId, string query = "", int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => countryId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => cityId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "q", query }
					, { "country_id", countryId }
					, { "city_id", cityId }
					, { "offset", offset }
					, { "count", count }
			};

			return _vk.Call(methodName: "database.getUniversities", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<University>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список школ.
		/// </summary>
		/// <param name="cityId"> Идентификатор города, школы которого необходимо вернуть. </param>
		/// <param name="query"> Строка поискового запроса. Например, гимназия. </param>
		/// <param name="offset">
		/// Отступ, необходимый для получения определенного
		/// подмножества школ.
		/// </param>
		/// <param name="count"> Количество школ, которое необходимо вернуть. </param>
		/// <returns> Cписок школ. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getSchools
		/// </remarks>
		[Pure]
		public VkCollection<School> GetSchools(int cityId, string query = "", int? offset = null, int? count = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => cityId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "q", query }
					, { "city_id", cityId }
					, { "offset", offset }
					, { "count", count }
			};

			return _vk.Call(methodName: "database.getSchools", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<School>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список факультетов.
		/// </summary>
		/// <param name="universityId">
		/// Идентификатор университета, факультеты которого
		/// необходимо получить.
		/// </param>
		/// <param name="count">
		/// Отступ, необходимый для получения определенного
		/// подмножества факультетов.
		/// </param>
		/// <param name="offset"> Количество факультетов которое необходимо получить. </param>
		/// <returns> Cписок факультетов. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getFaculties
		/// </remarks>
		[Pure]
		public VkCollection<Faculty> GetFaculties(long universityId, int? count = null, int? offset = null)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => universityId);
			VkErrors.ThrowIfNumberIsNegative(expr: () => count);
			VkErrors.ThrowIfNumberIsNegative(expr: () => offset);

			var parameters = new VkParameters
			{
					{ "university_id", universityId }
					, { "offset", offset }
					, { "count", count }
			};

			return _vk.Call(methodName: "database.getFaculties", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<Faculty>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список классов, характерных для школ определенной страны.
		/// </summary>
		/// <param name="countryId">
		/// Идентификатор страны, доступные классы в которой
		/// необходимо вернуть.
		/// </param>
		/// <returns>
		/// Возвращает массив, каждый элемент которого представляет собой пару:
		/// идентификатор и строковое обозначение
		/// класса.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getSchoolClasses
		/// </remarks>
		[Pure]
		public ReadOnlyCollection<SchoolClass> GetSchoolClasses(long countryId)
		{
			var parameters = new VkParameters
			{
					{ "country_id", countryId }
			};

			return _vk.Call(methodName: "database.getSchoolClasses", parameters: parameters, skipAuthorization: true)
					.ToReadOnlyCollectionOf<SchoolClass>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список кафедр университета по указанному факультету.
		/// </summary>
		/// <param name="facultyId">
		/// Идентификатор факультета, кафедры которого необходимо
		/// получить.
		/// </param>
		/// <param name="count"> Количество кафедр которое необходимо получить. </param>
		/// <param name="offset">
		/// Отступ, необходимый для получения определенного
		/// подмножества кафедр.
		/// </param>
		/// <returns>
		/// Возвращает массив, каждый элемент которого представляет собой пару:
		/// идентификатор и строковое обозначение класса.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getChairs
		/// </remarks>
		[Pure]
		public VkCollection<Chair> GetChairs(long facultyId, int? count = null, int? offset = null)
		{
			var parameters = new VkParameters
			{
					{ "faculty_id", facultyId }
					, { "offset", offset }
					, { "count", count }
			};

			return _vk.Call(methodName: "database.getChairs", parameters: parameters, skipAuthorization: true)
					.ToVkCollectionOf<Chair>(selector: x => x);
		}
	}
}