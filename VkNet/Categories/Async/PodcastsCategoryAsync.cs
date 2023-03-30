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
	public Task<bool> ClearRecentSearchesAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(ClearRecentSearches, token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetPopular, token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetRecentSearchRequests, token);

	/// <inheritdoc />
	public Task<PodcastsSearchResult> SearchAsync(PodcastsSearchParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Search(@params), token);
}