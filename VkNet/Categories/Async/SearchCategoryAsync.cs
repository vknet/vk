using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="ISearchCategory" />
public partial class SearchCategory
{
	/// <inheritdoc />
	public Task<VkCollection<SearchHintsItem>> GetHintsAsync(SearchGetHintsParams @params,
															CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetHints(@params), token);
}