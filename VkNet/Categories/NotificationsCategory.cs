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
		private readonly VkApi _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		public NotificationsCategory(VkApi api = null)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public IEnumerable<NotificationGetResult> Get(ulong? count = null
													, string startFrom = null
													, IEnumerable<string> filters = null
													, long? startTime = null
													, long? endTime = null)
		{
			return _vk.Call<IEnumerable<NotificationGetResult>>(methodName: "notifications.get"
					, parameters: new VkParameters
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
			return _vk.Call<bool>(methodName: "notifications.markAsViewed", parameters: VkParameters.Empty);
		}
	}
}