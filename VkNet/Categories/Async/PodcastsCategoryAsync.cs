using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PodcastsCategory
{
	/// <inheritdoc />
	public Task<bool> ClearRecentSearchesAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(ClearRecentSearches);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetPopular);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetRecentSearchRequests);

	/// <inheritdoc />
	public Task<PodcastsSearchResult> SearchAsync(PodcastsSearchParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params));
}