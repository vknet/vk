using System.Collections.Generic;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class NotificationsCategory : INotificationsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <inheritdoc />
		/// <param name="api">
		/// Api vk.com
		/// </param>
		public NotificationsCategory(VkApi api = null)
		{
			_vk = api;
		}

		/// <inheritdoc />
		public IEnumerable<NotificationGetResult> Get(ulong? count = null,
													string startFrom = null,
													IEnumerable<string> filters = null,
													long? startTime = null,
													long? endTime = null)
		{
			return GetAsync(count, startFrom, filters, startTime, endTime, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool MarkAsViewed()
		{
			return MarkAsViewedAsync(CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}