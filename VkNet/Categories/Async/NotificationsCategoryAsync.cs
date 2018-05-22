using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class NotificationsCategory
	{
		/// <inheritdoc/>
		public async Task<IEnumerable<object>> GetAsync(ulong? count = null, string startFrom = null, IEnumerable<string> filters = null, long? startTime = null, long? endTime = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Notifications.Get(count, startFrom, filters, startTime, endTime));
		}

		/// <inheritdoc/>
		public async Task<bool> MarkAsViewedAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(() => _vk.Notifications.MarkAsViewed());
		}
	}
}