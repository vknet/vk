using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;


public partial class StatsCategory
{
	/// <inheritdoc/>
	public Task<ReadOnlyCollection<StatsPeriod>> GetAsync(StatsGetParams getParams,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(getParams), token);

	/// <inheritdoc />
	public Task<bool> TrackVisitorAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(TrackVisitor, token);

	/// <inheritdoc />
	public Task<PostReach> GetPostReachAsync(long ownerId,
											long postId,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPostReach(ownerId, postId), token);
}