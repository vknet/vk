using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="ISearchCategoryAsync"/>
	public interface ISearchCategory : ISearchCategoryAsync
	{
		/// <inheritdoc cref="ISearchCategoryAsync.GetHintsAsync"/>
		VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params);
	}
}