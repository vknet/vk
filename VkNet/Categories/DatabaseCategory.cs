using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using VkNet.Abstractions;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IDatabaseCategory" />
public partial class DatabaseCategory : IDatabaseCategory
{
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="DatabaseCategory" />
	/// </summary>
	public DatabaseCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	[Pure]
	public VkCollection<Country> GetCountries(bool? needAll = null, IEnumerable<Iso3166> codes = null, int? count = null,
											int? offset = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => offset);
		VkErrors.ThrowIfNumberIsNegative(() => count);

		var parameters = new VkParameters
		{
			{
				"code", codes
			},
			{
				"offset", offset
			},
			{
				"count", count
			},
			{
				"need_all", needAll
			}
		};

		return _vk.Call<VkCollection<Country>>("database.getCountries", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<Region> GetRegions(int countryId, string query = "", int? count = null, int? offset = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => countryId);
		VkErrors.ThrowIfNumberIsNegative(() => offset);
		VkErrors.ThrowIfNumberIsNegative(() => count);

		var parameters = new VkParameters
		{
			{
				"country_id", countryId
			},
			{
				"q", query
			},
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<VkCollection<Region>>("database.getRegions", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public ReadOnlyCollection<Street> GetStreetsById(params int[] streetIds)
	{
		var parameters = new VkParameters
		{
			{
				"street_ids", streetIds.JoinNonEmpty()
			}
		};

		return _vk.Call<ReadOnlyCollection<Street>>("database.getStreetsById", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public ReadOnlyCollection<Country> GetCountriesById(params int[] countryIds)
	{
		var parameters = new VkParameters
		{
			{
				"country_ids", countryIds.JoinNonEmpty()
			}
		};

		return _vk.Call<ReadOnlyCollection<Country>>("database.getCountriesById", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<City> GetCities(GetCitiesParams getCitiesParams)
	{
		VkErrors.ThrowIfNumberIsNegative(() => getCitiesParams.CountryId);
		VkErrors.ThrowIfNumberIsNegative(() => getCitiesParams.RegionId);

		return _vk.Call<VkCollection<City>>("database.getCities", new()
			{
				{
					"country_id", getCitiesParams.CountryId
				},
				{
					"region_id", getCitiesParams.RegionId
				},
				{
					"q", getCitiesParams.Query
				},
				{
					"need_all", getCitiesParams.NeedAll
				},
				{
					"count", getCitiesParams.Count
				},
				{
					"offset", getCitiesParams.Offset
				}
			}, true);
	}

	/// <inheritdoc />
	[Pure]
	public ReadOnlyCollection<City> GetCitiesById(params int[] cityIds)
	{
		var parameters = new VkParameters
		{
			{
				"city_ids", cityIds.JoinNonEmpty()
			}
		};

		return _vk.Call<ReadOnlyCollection<City>>("database.getCitiesById", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<University> GetUniversities(int countryId, int cityId, string query = "", int? count = null, int? offset = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => countryId);
		VkErrors.ThrowIfNumberIsNegative(() => cityId);
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"q", query
			},
			{
				"country_id", countryId
			},
			{
				"city_id", cityId
			},
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<VkCollection<University>>("database.getUniversities", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<School> GetSchools(int cityId, string query = "", int? offset = null, int? count = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => cityId);
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"q", query
			},
			{
				"city_id", cityId
			},
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<VkCollection<School>>("database.getSchools", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<Faculty> GetFaculties(long universityId, int? count = null, int? offset = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => universityId);
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"university_id", universityId
			},
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<VkCollection<Faculty>>("database.getFaculties", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public ReadOnlyCollection<SchoolClass> GetSchoolClasses(long countryId)
	{
		var parameters = new VkParameters
		{
			{
				"country_id", countryId
			}
		};

		return _vk.Call<ReadOnlyCollection<SchoolClass>>("database.getSchoolClasses", parameters, true);
	}

	/// <inheritdoc />
	[Pure]
	public VkCollection<Chair> GetChairs(long facultyId, int? count = null, int? offset = null)
	{
		var parameters = new VkParameters
		{
			{
				"faculty_id", facultyId
			},
			{
				"offset", offset
			},
			{
				"count", count
			}
		};

		return _vk.Call<VkCollection<Chair>>("database.getChairs", parameters, true);
	}

	/// <inheritdoc />
	public ReadOnlyCollection<MetroStation> GetMetroStationsById(IEnumerable<ulong> stationIds) =>
		_vk.Call<ReadOnlyCollection<MetroStation>>("database.getMetroStationsById",
			new()
			{
				{
					"station_ids", stationIds
				}
			});

	/// <inheritdoc />
	public VkCollection<MetroStation> GetMetroStations(ulong cityId, int? offset = null, int? count = null, bool extended = false) =>
		_vk.Call<VkCollection<MetroStation>>("database.getMetroStations",
			new()
			{
				{
					"city_id", cityId
				},
				{
					"offset", offset
				},
				{
					"count", count
				},
				{
					"extended", extended
				}
			});
}