using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class SearchCategory : ISearchCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		public SearchCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params)
		{
			return _vk.Call<VkCollection<SearchHintsItem>>(methodName: "search.getHints", new VkParameters
			{
				{ "q", @params.Query }
				, { "offset", @params.Offset }
				, { "limit", @params.Limit }
				, { "filters", @params.Filters }
				, { "fields", @params.ProfileFields }
				, { "search_global", @params.SearchGlobal }
			});
		}
	}
}