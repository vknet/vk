using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IPodcastsCategoryAsync"/>
	public interface IPodcastsCategory : IPodcastsCategoryAsync
	{
		/// <inheritdoc cref="IPodcastsCategoryAsync.ClearRecentSearchesAsync"/>
		bool ClearRecentSearches();

		/// <inheritdoc cref="IPodcastsCategoryAsync.GetPopularAsync"/>
		ReadOnlyCollection<PodcastsGetPopularResult> GetPopular();

		/// <inheritdoc cref="IPodcastsCategoryAsync.GetRecentSearchRequestsAsync"/>
		ReadOnlyCollection<string> GetRecentSearchRequests();

		/// <inheritdoc cref="IPodcastsCategoryAsync.SearchAsync"/>
		PodcastsSearchResult Search(PodcastsSearchParams @params);
	}
}