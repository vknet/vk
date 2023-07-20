using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PlacesCategory
{
	/// <inheritdoc />
	public Task<long> AddAsync(PlacesAddParams placesAddParams,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Add(placesAddParams), token);

	/// <inheritdoc />
	public Task<long> CheckinAsync(PlacesCheckinParams placesCheckinParams,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Checkin(placesCheckinParams), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<Place>> GetByIdAsync(IEnumerable<ulong> places,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(places), token);

	/// <inheritdoc />
	public Task<VkCollection<Checkin>> GetCheckinsAsync(PlacesGetCheckinsParams placesGetCheckinsParams,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetCheckins(placesGetCheckinsParams), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PlaceType>> GetTypesAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetTypes, token);

	/// <inheritdoc />
	public Task<VkCollection<Place>> SearchAsync(PlacesSearchParams placesSearchParams,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(placesSearchParams), token);
}