using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	// <inheritdoc />
	public partial class StatsCategory
	{
		/// <inheritdoc />
		public Task<ReadOnlyCollection<StatsPeriod>> GetByGroupAsync(long groupId, DateTime dateFrom, DateTime? dateTo = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetByGroup(groupId: groupId, dateFrom: dateFrom, dateTo: dateTo));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<StatsPeriod>> GetByAppAsync(long appId, DateTime dateFrom, DateTime? dateTo = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetByApp(appId: appId, dateFrom: dateFrom, dateTo: dateTo));
		}

		/// <inheritdoc />
		public Task<bool> TrackVisitorAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: TrackVisitor);
		}

		/// <inheritdoc />
		public Task<PostReach> GetPostReachAsync(long ownerId, long postId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetPostReach(ownerId: ownerId, postId: postId));
		}
	}
}