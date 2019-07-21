using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class WidgetsCategory : IWidgetsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		internal WidgetsCategory(IVkApiInvoke api = null)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public VkCollection<Comment> GetComments(GetCommentsParams getCommentsParams)
		{
			return GetCommentsAsync(getCommentsParams, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public VkCollection<WidgetPage> GetPages(long? widgetApiId = null,
												string order = null,
												string period = null,
												ulong? offset = null,
												ulong? count = null)
		{
			return GetPagesAsync(widgetApiId, order, period, offset, count, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}