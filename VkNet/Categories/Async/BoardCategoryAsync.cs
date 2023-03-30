using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class BoardCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Topic>> GetTopicsAsync(BoardGetTopicsParams @params,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetTopics(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<TopicsFeed> GetCommentsAsync(BoardGetCommentsParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() => GetComments(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<long> AddTopicAsync(BoardAddTopicParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => AddTopic(@params));

	/// <inheritdoc />
	public Task<bool> DeleteTopicAsync(BoardTopicParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteTopic(@params));

	/// <inheritdoc />
	public Task<bool> CloseTopicAsync(BoardTopicParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CloseTopic(@params));

	/// <inheritdoc />
	public Task<bool> OpenTopicAsync(BoardTopicParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => OpenTopic(@params));

	/// <inheritdoc />
	public Task<bool> FixTopicAsync(BoardTopicParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => FixTopic(@params));

	/// <inheritdoc />
	public Task<bool> UnFixTopicAsync(BoardTopicParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => UnFixTopic(@params));

	/// <inheritdoc />
	public Task<bool> EditTopicAsync(BoardEditTopicParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => EditTopic(@params));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(BoardCreateCommentParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => CreateComment(@params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(BoardCommentParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => DeleteComment(@params));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(BoardEditCommentParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => EditComment(@params));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(BoardCommentParams @params,
										CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() => RestoreComment(@params));
}