using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Places.Add(placesAddParams: placesAddParams));
		}

		/// <inheritdoc />
		public Task<object> CheckinAsync(PlacesCheckinParams placesCheckinParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Places.Checkin(placesCheckinParams: placesCheckinParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<object>> GetByIdAsync(IEnumerable<ulong> places)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Places.GetById(places: places));
		}

		/// <inheritdoc />
		public Task<IEnumerable<object>> GetCheckinsAsync(PlacesGetCheckinsParams placesGetCheckinsParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
				_vk.Places.GetCheckins(placesGetCheckinsParams: placesGetCheckinsParams));
		}

		/// <inheritdoc />
		public Task<IEnumerable<object>> GetTypesAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Places.GetTypes());
		}

		/// <inheritdoc />
		public Task<Uri> SearchAsync(PlacesSearchParams placesSearchParams)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => _vk.Places.Search(placesSearchParams: placesSearchParams));
		}
	}
}