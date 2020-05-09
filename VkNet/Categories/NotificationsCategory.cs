using System.Collections.Generic;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
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
		public NotificationsCategory(VkApi vk = null)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public IEnumerable<NotificationGetResult> Get(ulong? count = null
													, string startFrom = null
													, IEnumerable<string> filters = null
													, long? startTime = null
													, long? endTime = null)
		{
			return _vk.Call<IEnumerable<NotificationGetResult>>("notifications.get"
					, new VkParameters
					{
							{ "count", count }
							, { "start_from", startFrom }
							, { "filters", filters }
							, { "start_time", startTime }
							, { "end_time", endTime }
					});
		}

		/// <inheritdoc />
		public bool MarkAsViewed()
		{
			return _vk.Call<bool>("notifications.markAsViewed", VkParameters.Empty);
		}
	}
}