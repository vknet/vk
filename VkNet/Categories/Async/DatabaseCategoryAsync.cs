using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Database;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class DatabaseCategory
	{
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
		public async Task<VkCollection<Country>> GetCountriesAsync(bool? needAll = null
																	, IEnumerable<Iso3166> codes = null
																	, int? count = null
																	, int? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetCountries(needAll: needAll, codes: codes, count: count, offset: offset));
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
		public async Task<VkCollection<Region>> GetRegionsAsync(int countryId, string query = "", int? count = null, int? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetRegions(countryId: countryId, query: query, count: count, offset: offset));
		}

		/// <summary>
		/// Возвращает информацию об улицах по их идентификаторам.
		/// </summary>
		/// <param name="streetIds"> Идентификаторы улиц. </param>
		/// <returns> Информация об улицах. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getStreetsById
		/// </remarks>
		public async Task<ReadOnlyCollection<Street>> GetStreetsByIdAsync(params int[] streetIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Database.GetStreetsById(streetIds: streetIds));
		}

		/// <summary>
		/// Возвращает информацию о странах по их идентификаторам.
		/// </summary>
		/// <param name="countryIds"> Идентификаторы стран. </param>
		/// <returns> Информация о странах. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/database.getCountriesById
		/// </remarks>
		public async Task<ReadOnlyCollection<Country>> GetCountriesByIdAsync(params int[] countryIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Database.GetCountriesById(countryIds: countryIds));
		}

		/// <summary>
		/// Возвращает список городов.
		/// </summary>
		/// <param name="getCitiesParams"> Параметры запроса database.getCities </param>
		/// <returns> Cписок городов </returns>
		/// <remarks>
		/// Возвращает коллекцию городов, каждый из которых содержит поля City.Id
		/// При наличии информации о регионе и/или области, в которых находится данный
		/// город, в объекте могут дополнительно
		/// включаться поля City.Area
		/// Если не задан параметр <paramref name="getCitiesParams.query" />, то будет
		/// возвращен список самых крупных городов в
		/// заданной стране.
		/// Если задан параметр <paramref name="getCitiesParams.query" />, то будет
		/// возвращен список городов, которые
		/// релевантны поисковому запросу.
		/// Страница документации ВКонтакте http://vk.com/dev/database.getCities
		/// </remarks>
		public async Task<VkCollection<City>> GetCitiesAsync(GetCitiesParams getCitiesParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Database.GetCities(parameters: getCitiesParams));
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
		public async Task<ReadOnlyCollection<City>> GetCitiesByIdAsync(params int[] cityIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Database.GetCitiesById(cityIds: cityIds));
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
		public async Task<VkCollection<University>> GetUniversitiesAsync(int countryId
																		, int cityId
																		, string query = ""
																		, int? count = null
																		, int? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetUniversities(countryId: countryId, cityId: cityId, query: query, count: count, offset: offset));
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
		public async Task<VkCollection<School>> GetSchoolsAsync(int cityId, string query = "", int? offset = null, int? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetSchools(cityId: cityId, query: query, offset: offset, count: count));
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
		public async Task<VkCollection<Faculty>> GetFacultiesAsync(long universityId, int? count = null, int? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetFaculties(universityId: universityId, count: count, offset: offset));
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
		public async Task<ReadOnlyCollection<SchoolClass>> GetSchoolClassesAsync(long countryId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetSchoolClasses(countryId: countryId));
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
		public async Task<VkCollection<Chair>> GetChairsAsync(long facultyId, int? count = null, int? offset = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Database.GetChairs(facultyId: facultyId, count: count, offset: offset));
		}
	}
}