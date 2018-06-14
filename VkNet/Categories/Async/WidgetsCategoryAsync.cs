using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class WidgetsCategory
	{
		/// <inheritdoc />
		public async Task<VkCollection<Comment>> GetCommentsAsync(GetCommentsParams getComments)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Widgets.GetComments(getCommentsParams: getComments));
		}

		/// <inheritdoc />
		public async Task<VkCollection<WidgetPage>> GetPagesAsync(long? widgetApiId = null
																, string order = null
																, string period = null
																, ulong? offset = null
																, ulong? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Widgets.GetPages(widgetApiId: widgetApiId, order: order, period: period, offset: offset, count: count));
		}
	}
}