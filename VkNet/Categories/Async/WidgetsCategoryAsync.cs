using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class WidgetsCategory
	{
		/// <inheritdoc/>
		public async Task<VkCollection<Comment>> GetCommentsAsync(GetCommentsParams getComments)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Widgets.GetComments(getComments));
		}

		/// <inheritdoc/>
		public async Task<Uri> GetPagesAsync(long? widgetApiId = null, string order = null, string period = null, ulong? offset = null, ulong? count = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Widgets.GetPages(widgetApiId, order, period, offset, count));
		}
	}
}