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

		/// <inheritdoc />
		public SearchCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params)
		{
			return _vk.Call<VkCollection<SearchHintsItem>>(methodName: "search.getHints", parameters: @params);
		}
	}
}