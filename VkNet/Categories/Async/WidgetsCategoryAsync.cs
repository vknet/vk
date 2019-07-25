using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class WidgetsCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<Comment>> GetCommentsAsync(GetCommentsParams getCommentsParams,
															CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<VkCollection<Comment>>("widgets.getComments",
				getCommentsParams,
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<VkCollection<WidgetPage>> GetPagesAsync(long? widgetApiId = null,
															string order = null,
															string period = null,
															ulong? offset = null,
															ulong? count = null,
															CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<VkCollection<WidgetPage>>("widgets.getPages",
				new VkParameters
				{
					{ "widget_api_id", widgetApiId },
					{ "order", order },
					{ "period", period },
					{ "offset", offset },
					{ "count", count }
				},
				cancellationToken: cancellationToken);
		}
	}
}