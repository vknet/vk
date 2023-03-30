using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PlacesCategory
{
	/// <inheritdoc />
	public Task<long> AddAsync(PlacesAddParams placesAddParams,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(placesAddParams));

	/// <inheritdoc />
	public Task<long> CheckinAsync(PlacesCheckinParams placesCheckinParams,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Checkin(placesCheckinParams));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Place>> GetByIdAsync(IEnumerable<ulong> places,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(places));

	/// <inheritdoc />
	public Task<VkCollection<Checkin>> GetCheckinsAsync(PlacesGetCheckinsParams placesGetCheckinsParams,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCheckins(placesGetCheckinsParams));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PlaceType>> GetTypesAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetTypes);

	/// <inheritdoc />
	public Task<VkCollection<Place>> SearchAsync(PlacesSearchParams placesSearchParams,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(placesSearchParams));
}