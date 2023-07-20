using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PlacesCategory : IPlacesCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk">
	/// Api vk.com
	/// </param>
	public PlacesCategory(VkApi vk) => _vk = vk;

	/// <inheritdoc />
	public long Add(PlacesAddParams placesAddParams) => _vk.Call("places.add",
		new()
		{
			{
				"title", placesAddParams.Title
			},
			{
				"latitude", placesAddParams.Latitude
			},
			{
				"longitude", placesAddParams.Longitude
			},
			{
				"address", placesAddParams.Address
			},
			{
				"type", placesAddParams.Type
			},
			{
				"country", placesAddParams.Country
			},
			{
				"city", placesAddParams.City
			}
		})["id"];

	/// <inheritdoc />
	public long Checkin(PlacesCheckinParams placesCheckinParams) => _vk.Call<long>("places.checkin",
		new()
		{
			{
				"text", placesCheckinParams.Text
			},
			{
				"services", placesCheckinParams.Services
			},
			{
				"place_id", placesCheckinParams.PlaceId
			},
			{
				"latitude", placesCheckinParams.Latitude
			},
			{
				"longitude", placesCheckinParams.Longitude
			},
			{
				"friends_only", placesCheckinParams.FriendsOnly
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<Place> GetById(IEnumerable<ulong> places) => _vk.Call<ReadOnlyCollection<Place>>("places.getById", new()
	{
		{
			"places", places
		}
	});

	/// <inheritdoc />
	public VkCollection<Checkin> GetCheckins(PlacesGetCheckinsParams placesGetCheckinsParams) => _vk.Call<VkCollection<Checkin>>(
		"places.getCheckins",
		new()
		{
			{
				"latitude", placesGetCheckinsParams.Latitude
			},
			{
				"longitude", placesGetCheckinsParams.Longitude
			},
			{
				"place", placesGetCheckinsParams.Place
			},
			{
				"user_id", placesGetCheckinsParams.UserId
			},
			{
				"offset", placesGetCheckinsParams.Offset
			},
			{
				"count", placesGetCheckinsParams.Count
			},
			{
				"timestamp", placesGetCheckinsParams.Timestamp
			},
			{
				"friends_only", placesGetCheckinsParams.FriendsOnly
			},
			{
				"need_places", placesGetCheckinsParams.NeedPlaces
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<PlaceType> GetTypes() => _vk.Call<ReadOnlyCollection<PlaceType>>("places.getTypes", VkParameters.Empty);

	/// <inheritdoc />
	public VkCollection<Place> Search(PlacesSearchParams placesSearchParams) => _vk.Call<VkCollection<Place>>("places.search",
		new()
		{
			{
				"q", placesSearchParams.Query
			},
			{
				"latitude", placesSearchParams.Latitude
			},
			{
				"longitude", placesSearchParams.Longitude
			},
			{
				"city", placesSearchParams.City
			},
			{
				"radius", placesSearchParams.Radius
			},
			{
				"offset", placesSearchParams.Offset
			},
			{
				"count", placesSearchParams.Count
			}
		});
}