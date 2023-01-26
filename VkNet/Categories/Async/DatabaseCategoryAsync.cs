using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Database;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class DatabaseCategory
{
	/// <inheritdoc />
	public Task<ReadOnlyCollection<Country>> GetCountriesAsync(bool? needAll = null, IEnumerable<Iso3166> codes = null, int? count = null,
													int? offset = null) => TypeHelper.TryInvokeMethodAsync(() =>
		GetCountries(needAll, codes, count, offset));

	/// <inheritdoc />
	public Task<VkCollection<Region>> GetRegionsAsync(int countryId, string query = "", int? count = null, int? offset = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetRegions(countryId, query, count, offset));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Street>> GetStreetsByIdAsync(params int[] streetIds) =>
		TypeHelper.TryInvokeMethodAsync(() => GetStreetsById(streetIds));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Country>> GetCountriesByIdAsync(params int[] countryIds) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCountriesById(countryIds));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<City>> GetCitiesAsync(GetCitiesParams getCitiesParams) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCities(getCitiesParams));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<City>> GetCitiesByIdAsync(params int[] cityIds) =>
		TypeHelper.TryInvokeMethodAsync(() => GetCitiesById(cityIds));

	/// <inheritdoc />
	public Task<VkCollection<University>> GetUniversitiesAsync(int countryId, int cityId, string query = "", int? count = null,
																int? offset = null) => TypeHelper.TryInvokeMethodAsync(() =>
		GetUniversities(countryId, cityId, query, count, offset));

	/// <inheritdoc />
	public Task<VkCollection<School>> GetSchoolsAsync(int cityId, string query = "", int? offset = null, int? count = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetSchools(cityId, query, offset, count));

	/// <inheritdoc />
	public Task<VkCollection<Faculty>> GetFacultiesAsync(long universityId, int? count = null, int? offset = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetFaculties(universityId, count, offset));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<SchoolClass>> GetSchoolClassesAsync(long countryId) => TypeHelper.TryInvokeMethodAsync(() =>
		GetSchoolClasses(countryId));

	/// <inheritdoc />
	public Task<VkCollection<Chair>> GetChairsAsync(long facultyId, int? count = null, int? offset = null) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetChairs(facultyId, count, offset));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<MetroStation>> GetMetroStationsByIdAsync(IEnumerable<ulong> stationIds) =>
		TypeHelper.TryInvokeMethodAsync(() => GetMetroStationsById(stationIds));

	/// <inheritdoc />
	public Task<VkCollection<MetroStation>> GetMetroStationsAsync(ulong cityId, int? offset = null, int? count = null,
																bool extended = false) => TypeHelper.TryInvokeMethodAsync(() =>
		GetMetroStations(cityId, offset, count, extended));
}