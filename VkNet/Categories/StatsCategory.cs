using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class StatsCategory : IStatsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name="vk"> API. </param>
		public StatsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<StatsPeriod> Get(StatsGetParams getParams)
		{
			return _vk.Call<ReadOnlyCollection<StatsPeriod>>("stats.get",
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
				});
		}

		/// <inheritdoc />
		public bool TrackVisitor()
		{
			return _vk.Call(methodName: "stats.trackVisitor", parameters: VkParameters.Empty);
		}

		/// <inheritdoc />
		public PostReach GetPostReach(long ownerId, long postId)
		{
			VkErrors.ThrowIfNumberIsNegative(expr: () => postId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "post_id", postId }
			};

			return _vk.Call(methodName: "stats.getPostReach", parameters: parameters);
		}
	}
}