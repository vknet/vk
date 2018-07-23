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
		public Task<IEnumerable<NotificationGetResult>> GetAsync(ulong? count = null
																		, string startFrom = null
																		, IEnumerable<string> filters = null
																		, long? startTime = null
																		, long? endTime = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					Get(count: count, startFrom: startFrom, filters: filters, startTime: startTime, endTime: endTime));
		}

		/// <inheritdoc />
		public Task<bool> MarkAsViewedAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>MarkAsViewed());
		}
	}
}