using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class SearchCategory
{
	/// <inheritdoc />
	public Task<VkCollection<SearchHintsItem>> GetHintsAsync(SearchGetHintsParams @params,
															CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetHints(@params));
}