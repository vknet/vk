using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Database;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class DatabaseCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<Country>> GetCountriesAsync(bool? needAll = null, IEnumerable<Iso3166> codes = null, int? count = null,
															int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetCountries(needAll, codes, count, offset));
		}

		/// <inheritdoc />
		public Task<VkCollection<Region>> GetRegionsAsync(int countryId, string query = "", int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetRegions(countryId, query, count, offset));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Street>> GetStreetsByIdAsync(params int[] streetIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetStreetsById(streetIds));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Country>> GetCountriesByIdAsync(params int[] countryIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCountriesById(countryIds));
		}

		/// <inheritdoc />
		public Task<VkCollection<City>> GetCitiesAsync(GetCitiesParams getCitiesParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCities(getCitiesParams));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<City>> GetCitiesByIdAsync(params int[] cityIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetCitiesById(cityIds));
		}

		/// <inheritdoc />
		public Task<VkCollection<University>> GetUniversitiesAsync(int countryId, int cityId, string query = "", int? count = null,
																	int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetUniversities(countryId, cityId, query, count, offset));
		}

		/// <inheritdoc />
		public Task<VkCollection<School>> GetSchoolsAsync(int cityId, string query = "", int? offset = null, int? count = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetSchools(cityId, query, offset, count));
		}

		/// <inheritdoc />
		public Task<VkCollection<Faculty>> GetFacultiesAsync(long universityId, int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetFaculties(universityId, count, offset));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<SchoolClass>> GetSchoolClassesAsync(long countryId)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetSchoolClasses(countryId));
		}

		/// <inheritdoc />
		public Task<VkCollection<Chair>> GetChairsAsync(long facultyId, int? count = null, int? offset = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() =>
				GetChairs(facultyId, count, offset));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<MetroStation>> GetMetroStationsByIdAsync(IEnumerable<ulong> stationIds)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMetroStationsById(stationIds));
		}

		/// <inheritdoc />
		public Task<VkCollection<MetroStation>> GetMetroStationsAsync(ulong cityId, int? offset = null, int? count = null,
																	bool extended = false)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetMetroStations(cityId, offset, count, extended));
		}
	}
}