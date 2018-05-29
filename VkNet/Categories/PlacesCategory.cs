using System;
using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PlacesCategory : IPlacesCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		public PlacesCategory(VkApi api)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public object Add(PlacesAddParams placesAddParams)
		{
			return _vk.Call<object>(methodName: "places.add"
					, parameters: new VkParameters
					{
							{ "title", placesAddParams.Title }
							, { "latitude", placesAddParams.Latitude }
							, { "longitude", placesAddParams.Longitude }
							, { "address", placesAddParams.Address }
							, { "type", placesAddParams.Type }
							, { "country", placesAddParams.Country }
							, { "city", placesAddParams.City }
					});
		}

		/// <inheritdoc />
		public object Checkin(PlacesCheckinParams placesCheckinParams)
		{
			return _vk.Call<object>(methodName: "places.checkin"
					, parameters: new VkParameters
					{
							{ "text", placesCheckinParams.Text }
							, { "services", placesCheckinParams.Services }
							, { "place_id", placesCheckinParams.PlaceId }
							, { "latitude", placesCheckinParams.Latitude }
							, { "longitude", placesCheckinParams.Longitude }
							, { "friends_only", placesCheckinParams.FriendsOnly }
					});
		}

		/// <inheritdoc />
		public IEnumerable<object> GetById(IEnumerable<ulong> places)
		{
			return _vk.Call<IEnumerable<object>>(methodName: "places.getById", parameters: new VkParameters { { "places", places } });
		}

		/// <inheritdoc />
		public IEnumerable<object> GetCheckins(PlacesGetCheckinsParams placesGetCheckinsParams)
		{
			return _vk.Call<IEnumerable<object>>(methodName: "places.getCheckins"
					, parameters: new VkParameters
					{
							{ "latitude", placesGetCheckinsParams.Latitude }
							, { "longitude", placesGetCheckinsParams.Longitude }
							, { "place", placesGetCheckinsParams.Place }
							, { "user_id", placesGetCheckinsParams.UserId }
							, { "offset", placesGetCheckinsParams.Offset }
							, { "count", placesGetCheckinsParams.Count }
							, { "timestamp", placesGetCheckinsParams.Timestamp }
							, { "friends_only", placesGetCheckinsParams.FriendsOnly }
							, { "need_places", placesGetCheckinsParams.NeedPlaces }
					});
		}

		/// <inheritdoc />
		public IEnumerable<object> GetTypes()
		{
			return _vk.Call<IEnumerable<object>>(methodName: "places.getTypes", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public Uri Search(PlacesSearchParams placesSearchParams)
		{
			return _vk.Call<Uri>(methodName: "places.search"
					, parameters: new VkParameters
					{
							{ "q", placesSearchParams.Query }
							, { "latitude", placesSearchParams.Latitude }
							, { "longitude", placesSearchParams.Longitude }
							, { "city", placesSearchParams.City }
							, { "radius", placesSearchParams.Radius }
							, { "offset", placesSearchParams.Offset }
							, { "count", placesSearchParams.Count }
					});
		}
	}
}