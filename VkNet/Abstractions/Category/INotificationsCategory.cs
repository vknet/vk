using System.Collections.Generic;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <inheritdoc />
	public interface INotificationsCategory : INotificationsCategoryAsync
	{
		/// <inheritdoc cref="INotificationsCategoryAsync.GetAsync" />
		IEnumerable<NotificationGetResult> Get(ulong? count = null,
												string startFrom = null,
												IEnumerable<string> filters = null,
												long? startTime = null,
												long? endTime = null);

		/// <inheritdoc cref="INotificationsCategoryAsync.MarkAsViewedAsync" />
		bool MarkAsViewed();
	}
}