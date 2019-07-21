using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	// <inheritdoc />
	public partial class StatsCategory
	{
		/// <inheritdoc/>
		public Task<ReadOnlyCollection<StatsPeriod>> GetAsync(StatsGetParams getParams, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<ReadOnlyCollection<StatsPeriod>>("stats.get",
				new VkParameters
				{
					{ "interval", getParams.Interval },
					{ "filters", getParams.Filters },
					{ "stats_groups", getParams.StatsGroups },
					{ "group_id", getParams.GroupId },
					{ "app_id", getParams.AppId },
					{ "timestamp_from", getParams.TimestampFrom },
					{ "timestamp_to", getParams.TimestampTo },
					{ "intervals_count", getParams.IntervalsCount },
					{ "extended", getParams.Extended }
				},
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<bool> TrackVisitorAsync(CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<bool>("stats.trackVisitor",
				VkParameters.Empty,
				cancellationToken: cancellationToken);
		}

		/// <inheritdoc />
		public Task<PostReach> GetPostReachAsync(long ownerId, long postId, CancellationToken cancellationToken = default)
		{
			return _vk.CallAsync<PostReach>("stats.getPostReach",
				new VkParameters
				{
					{ "owner_id", ownerId },
					{ "post_id", postId }
				},
				cancellationToken: cancellationToken);
		}
	}
}