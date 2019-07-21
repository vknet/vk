using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NotificationsCategory
	{
		/// <inheritdoc />
		public Task<IEnumerable<NotificationGetResult>> GetAsync(ulong? count = null,
																string startFrom = null,
																IEnumerable<string> filters = null,
																long? startTime = null,
																long? endTime = null,
																CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<IEnumerable<NotificationGetResult>>("notifications.get",
				new VkParameters
				{
					{ "count", count },
					{ "start_from", startFrom },
					{ "filters", filters },
					{ "start_time", startTime },
					{ "end_time", endTime }
				},
				cancellationToken: cancellationToken);
		}

		/// <param name="cancellationToken"></param>
		/// <inheritdoc />
		public Task<bool> MarkAsViewedAsync(CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("notifications.markAsViewed", VkParameters.Empty, cancellationToken: cancellationToken);
		}
	}
}