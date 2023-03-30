using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

// <inheritdoc />
public partial class StatsCategory
{
	/// <inheritdoc/>
	public Task<ReadOnlyCollection<StatsPeriod>> GetAsync(StatsGetParams getParams,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(getParams));

	/// <inheritdoc />
	public Task<bool> TrackVisitorAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(TrackVisitor);

	/// <inheritdoc />
	public Task<PostReach> GetPostReachAsync(long ownerId,
											long postId,
											CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPostReach(ownerId, postId));
}