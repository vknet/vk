using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с поиском.
/// </summary>
public interface ISearchCategory : ISearchCategoryAsync
{
	/// <inheritdoc cref="ISearchCategoryAsync.GetHintsAsync"/>
	VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params);
}