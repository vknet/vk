using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class SearchCategory : ISearchCategory
	{
		/// <inheritdoc />
		public SearchCategory(VkApi vk)
		{
			Vk = vk;
		}

		private VkApi Vk { get; }

		/// <inheritdoc />
		public VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params)
		{
			return Vk.Call<VkCollection<SearchHintsItem>>(methodName: "search.getHints", parameters: @params);
		}
	}
}