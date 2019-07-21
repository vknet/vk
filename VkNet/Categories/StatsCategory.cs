using System.Collections.ObjectModel;
using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;

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
		/// Методы для работы со статистикой.
		/// </summary>
		/// <param name="vk"> API. </param>
		public StatsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<StatsPeriod> Get(StatsGetParams getParams)
		{
			return GetAsync(getParams, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public bool TrackVisitor()
		{
			return TrackVisitorAsync(CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public PostReach GetPostReach(long ownerId, long postId)
		{
			return GetPostReachAsync(ownerId, postId, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}