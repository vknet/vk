using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IPodcastsCategory" />
public partial class PodcastsCategory : IPodcastsCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Методы для работы с опросами.
	/// </summary>
	/// <param name="vk"> API. </param>
	public PodcastsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	public bool ClearRecentSearches() => _vk.Call<bool>("podcasts.clearRecentSearches", VkParameters.Empty);

	/// <inheritdoc />
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	public ReadOnlyCollection<PodcastsGetPopularResult> GetPopular() =>
		_vk.Call<ReadOnlyCollection<PodcastsGetPopularResult>>("podcasts.getPopular", VkParameters.Empty);

	/// <inheritdoc />
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	public ReadOnlyCollection<string> GetRecentSearchRequests() =>
		_vk.Call<ReadOnlyCollection<string>>("podcasts.getRecentSearchRequests", VkParameters.Empty);

	/// <inheritdoc />
	public PodcastsSearchResult Search(PodcastsSearchParams @params) => _vk.Call<PodcastsSearchResult>("podcasts.search", new()
	{
		{
			"search_string", @params.SearchString
		},
		{
			"offset", @params.Offset
		},
		{
			"count", @params.Count
		}
	});
}