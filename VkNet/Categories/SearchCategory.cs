using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="ISearchCategory" />
public partial class SearchCategory : ISearchCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	public SearchCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params) => _vk.Call<VkCollection<SearchHintsItem>>(
		"search.getHints", new()
		{
			{
				"q", @params.Query
			},
			{
				"offset", @params.Offset
			},
			{
				"limit", @params.Limit
			},
			{
				"filters", @params.Filters
			},
			{
				"fields", @params.ProfileFields
			},
			{
				"search_global", @params.SearchGlobal
			}
		});
}