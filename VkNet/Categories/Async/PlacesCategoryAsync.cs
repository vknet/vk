using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PlacesCategory
	{
		/// <inheritdoc />
		public Task<long> AddAsync(PlacesAddParams placesAddParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Add(placesAddParams: placesAddParams));
		}

		/// <inheritdoc />
		public Task<long> CheckinAsync(PlacesCheckinParams placesCheckinParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Checkin(placesCheckinParams: placesCheckinParams));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<Place>> GetByIdAsync(IEnumerable<ulong> places)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetById(places: places));
		}

		/// <inheritdoc />
		public Task<VkCollection<Checkin>> GetCheckinsAsync(PlacesGetCheckinsParams placesGetCheckinsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				GetCheckins(placesGetCheckinsParams: placesGetCheckinsParams));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<PlaceType>> GetTypesAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: GetTypes);
		}

		/// <inheritdoc />
		public Task<VkCollection<Place>> SearchAsync(PlacesSearchParams placesSearchParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Search(placesSearchParams: placesSearchParams));
		}
	}
}