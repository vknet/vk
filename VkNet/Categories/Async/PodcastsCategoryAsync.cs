using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PodcastsCategory
	{

		/// <inheritdoc />
		public Task<bool> ClearRecentSearchesAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: ClearRecentSearches);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: GetPopular);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: GetRecentSearchRequests);
		}

		/// <inheritdoc />
		public Task<PodcastsSearchResult> SearchAsync(PodcastsSearchParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Search(@params: @params));
		}
	}
}