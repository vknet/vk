using System.Collections.Generic;
using VkNet.Model;
using VkNet.Model.RequestParams.Notifications;
using VkNet.Model.Results.Notifications;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="INotificationsCategoryAsync"/>
	public interface INotificationsCategory : INotificationsCategoryAsync
	{
		/// <inheritdoc cref="INotificationsCategoryAsync.GetAsync"/>
		NotificationGetResult Get(ulong? count = null, string startFrom = null, IEnumerable<string> filters = null,
								long? startTime = null, long? endTime = null);

		/// <inheritdoc cref="INotificationsCategoryAsync.MarkAsViewedAsync"/>
		bool MarkAsViewed();

		/// <inheritdoc cref = "INotificationsCategoryAsync.SendMessageAsync"/>
		IEnumerable<NotificationsSendMessageResult> SendMessage(NotificationsSendMessageParams sendMessageParams);
	}
}