using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IPlacesCategoryAsync"/>
	public interface IPlacesCategory : IPlacesCategoryAsync
	{
		/// <inheritdoc cref="IPlacesCategoryAsync.AddAsync"/>
		long Add(PlacesAddParams placesAddParams);

		/// <inheritdoc cref="IPlacesCategoryAsync.CheckinAsync"/>
		long Checkin(PlacesCheckinParams placesCheckinParams);

		/// <inheritdoc cref="IPlacesCategoryAsync.GetByIdAsync"/>
		ReadOnlyCollection<Place> GetById(IEnumerable<ulong> places);

		/// <inheritdoc cref="IPlacesCategoryAsync.GetCheckinsAsync"/>
		VkCollection<Checkin> GetCheckins(PlacesGetCheckinsParams placesGetCheckinsParams);

		/// <inheritdoc cref="IPlacesCategoryAsync.GetTypesAsync"/>
		ReadOnlyCollection<PlaceType> GetTypes();

		/// <inheritdoc cref="IPlacesCategoryAsync.SearchAsync"/>
		VkCollection<Place> Search(PlacesSearchParams placesSearchParams);
	}
}