using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class PlacesCategory
	{
		/// <inheritdoc/>
		public async Task<object> AddAsync(PlacesAddParams placesAddParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Places.Add(placesAddParams));
		}

		/// <inheritdoc/>
		public async Task<object> CheckinAsync(PlacesCheckinParams placesCheckinParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Places.Checkin(placesCheckinParams));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetByIdAsync(IEnumerable<ulong> places)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Places.GetById(places));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetCheckinsAsync(PlacesGetCheckinsParams placesGetCheckinsParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Places.GetCheckins(placesGetCheckinsParams));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetTypesAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Places.GetTypes());
		}

		/// <inheritdoc/>
		public async Task<Uri> SearchAsync(PlacesSearchParams placesSearchParams)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Places.Search(placesSearchParams));
		}
	}
}