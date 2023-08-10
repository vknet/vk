using System;
using System.Collections.ObjectModel;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <inheritdoc cref="IPodcastsCategoryAsync"/>
public interface IPodcastsCategory : IPodcastsCategoryAsync
{
	/// <inheritdoc cref="IPodcastsCategoryAsync.ClearRecentSearchesAsync"/>
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	bool ClearRecentSearches();

	/// <inheritdoc cref="IPodcastsCategoryAsync.GetPopularAsync"/>
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	ReadOnlyCollection<PodcastsGetPopularResult> GetPopular();

	/// <inheritdoc cref="IPodcastsCategoryAsync.GetRecentSearchRequestsAsync"/>
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	ReadOnlyCollection<string> GetRecentSearchRequests();

	/// <inheritdoc cref="IPodcastsCategoryAsync.SearchPodcastAsync"/>
	PodcastsSearchResult SearchPodcast(PodcastsSearchParams @params);
}