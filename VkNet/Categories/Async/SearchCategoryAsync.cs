using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class SearchCategory
	{
		/// <inheritdoc />
		public async Task<VkCollection<SearchHintsItem>> GetHintsAsync(SearchGetHintsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => Vk.Search.GetHints(@params: @params));
		}
	}
}