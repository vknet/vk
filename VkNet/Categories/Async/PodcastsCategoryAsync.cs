using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IPodcastsCategory" />
public partial class PodcastsCategory
{
	/// <inheritdoc />
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	public Task<bool> ClearRecentSearchesAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(ClearRecentSearches, token);

	/// <inheritdoc />
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	public Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetPopular, token);

	/// <inheritdoc />
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	public Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetRecentSearchRequests, token);

	/// <inheritdoc />
	public Task<PodcastsSearchResult> SearchPodcastAsync(PodcastsSearchParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SearchPodcast(@params), token);
}