using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams.Notifications;
using VkNet.Model.Results.Notifications;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NotificationsCategory
	{
		/// <inheritdoc />
		public Task<NotificationGetResult> GetAsync(ulong? count = null, string startFrom = null,
													IEnumerable<string> filters = null, long? startTime = null,
													long? endTime = null, CancellationToken token = default)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Get(count, startFrom, filters, startTime, endTime));
		}

		/// <param name="token"></param>
		/// <inheritdoc />
		public Task<bool> MarkAsViewedAsync(CancellationToken token)
		{
			return TypeHelper.TryInvokeMethodAsync(func: MarkAsViewed);
		}

		/// <inheritdoc/>
		public Task<IEnumerable<NotificationsSendMessageResult>> SendMessageAsync(NotificationsSendMessageParams sendMessageParams,
																				CancellationToken token)
		{
			return TypeHelper.TryInvokeMethodAsync(() => SendMessage(sendMessageParams));
		}
	}
}