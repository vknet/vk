using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams.Database;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IDatabaseCategoryAsync" />
	public interface IDatabaseCategory : IDatabaseCategoryAsync
	{
		/// <inheritdoc cref="IDatabaseCategoryAsync.GetCountriesAsync"/>
		VkCollection<Country> GetCountries(bool? needAll = null, IEnumerable<Iso3166> codes = null, int? count = null, int? offset = null);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetRegionsAsync"/>
		VkCollection<Region> GetRegions(int countryId, string query = "", int? count = null, int? offset = null);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetStreetsByIdAsync"/>
		ReadOnlyCollection<Street> GetStreetsById(params int[] streetIds);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetCountriesByIdAsync"/>
		ReadOnlyCollection<Country> GetCountriesById(params int[] countryIds);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetCitiesAsync" />
		VkCollection<City> GetCities(GetCitiesParams getCitiesParams);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetCitiesByIdAsync"/>
		ReadOnlyCollection<City> GetCitiesById(params int[] cityIds);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetUniversitiesAsync"/>
		VkCollection<University> GetUniversities(int countryId, int cityId, string query = "", int? count = null, int? offset = null);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetSchoolsAsync"/>
		VkCollection<School> GetSchools(int cityId, string query = "", int? offset = null, int? count = null);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetFacultiesAsync"/>
		VkCollection<Faculty> GetFaculties(long universityId, int? count = null, int? offset = null);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetSchoolClassesAsync"/>
		ReadOnlyCollection<SchoolClass> GetSchoolClasses(long countryId);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetChairsAsync"/>
		VkCollection<Chair> GetChairs(long facultyId, int? count = null, int? offset = null);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetMetroStationsByIdAsync"/>
		ReadOnlyCollection<MetroStation> GetMetroStationsById(IEnumerable<ulong> stationIds);

		/// <inheritdoc cref="IDatabaseCategoryAsync.GetMetroStationsAsync"/>
		VkCollection<MetroStation> GetMetroStations(ulong cityId, int? offset = null, int? count = null, bool extended = false);
	}
}