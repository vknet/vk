using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="INotificationsCategory" />
public partial class NotificationsCategory
{
	/// <inheritdoc />
	public Task<NotificationGetResult> GetAsync(ulong? count = null,
												string startFrom = null,
												IEnumerable<string> filters = null,
												long? startTime = null,
												long? endTime = null,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(count, startFrom, filters, startTime, endTime), token);

	/// <inheritdoc />
	public Task<bool> MarkAsViewedAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(MarkAsViewed, token);

	/// <inheritdoc/>
	public Task<IEnumerable<NotificationsSendMessageResult>> SendMessageAsync(NotificationsSendMessageParams sendMessageParams,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SendMessage(sendMessageParams), token);
}