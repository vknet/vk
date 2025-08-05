using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="INotificationsCategory" />
public partial class NotificationsCategory : INotificationsCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk">
	/// Api vk.com
	/// </param>
	public NotificationsCategory(VkApi vk = null) => _vk = vk;

	/// <inheritdoc />
	public NotificationGetResult Get(ulong? count = null
									, string startFrom = null
									, IEnumerable<string> filters = null
									, long? startTime = null
									, long? endTime = null) => _vk.Call<NotificationGetResult>("notifications.get",
		new()
		{
			{
				"count", count
			},
			{
				"start_from", startFrom
			},
			{
				"filters", filters
			},
			{
				"start_time", startTime
			},
			{
				"end_time", endTime
			}
		});

	/// <inheritdoc />
	public bool MarkAsViewed() => _vk.Call<bool>("notifications.markAsViewed", VkParameters.Empty);

	/// <inheritdoc />
	public IEnumerable<NotificationsSendMessageResult> SendMessage(NotificationsSendMessageParams sendMessageParams) =>
		_vk.Call<IEnumerable<NotificationsSendMessageResult>>("notifications.sendMessage",
			new()
			{
				{
					"user_ids", sendMessageParams.UserIds
				},
				{
					"message", sendMessageParams.Message
				},
				{
					"fragment", sendMessageParams.Fragment
				},
				{
					"sending_mode", sendMessageParams.SendingMode
				},
				{
					"group_id", sendMessageParams.GroupId
				},
				{
					"random_id", sendMessageParams.RandomId
				}
			});
}