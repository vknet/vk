using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PodcastsCategory
{
	/// <inheritdoc />
	public Task<bool> ClearRecentSearchesAsync() => TypeHelper.TryInvokeMethodAsync(func: ClearRecentSearches);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync() => TypeHelper.TryInvokeMethodAsync(func: GetPopular);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync() =>
		TypeHelper.TryInvokeMethodAsync(func: GetRecentSearchRequests);

	/// <inheritdoc />
	public Task<PodcastsSearchResult> SearchAsync(PodcastsSearchParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Search(@params: @params));
}