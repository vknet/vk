using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NotificationsCategory
	{
		/// <inheritdoc />
		public async Task<IEnumerable<NotificationGetResult>> GetAsync(ulong? count = null
																		, string startFrom = null
																		, IEnumerable<string> filters = null
																		, long? startTime = null
																		, long? endTime = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Notifications.Get(count: count, startFrom: startFrom, filters: filters, startTime: startTime, endTime: endTime));
		}

		/// <inheritdoc />
		public async Task<bool> MarkAsViewedAsync()
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Notifications.MarkAsViewed());
		}
	}
}