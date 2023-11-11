using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IBoardCategory" />
internal partial class BoardCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Topic>> GetTopicsAsync(BoardGetTopicsParams @params,
													bool skipAuthorization = false,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetTopics(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<TopicsFeed> GetCommentsAsync(BoardGetCommentsParams @params,
											bool skipAuthorization = false,
											CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetComments(@params, skipAuthorization), token);

	/// <inheritdoc />
	public Task<long> AddTopicAsync(BoardAddTopicParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddTopic(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteTopicAsync(BoardTopicParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteTopic(@params), token);

	/// <inheritdoc />
	public Task<bool> CloseTopicAsync(BoardTopicParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CloseTopic(@params), token);

	/// <inheritdoc />
	public Task<bool> OpenTopicAsync(BoardTopicParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			OpenTopic(@params), token);

	/// <inheritdoc />
	public Task<bool> FixTopicAsync(BoardTopicParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			FixTopic(@params), token);

	/// <inheritdoc />
	public Task<bool> UnFixTopicAsync(BoardTopicParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			UnFixTopic(@params), token);

	/// <inheritdoc />
	public Task<bool> EditTopicAsync(BoardEditTopicParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditTopic(@params), token);

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(BoardCreateCommentParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CreateComment(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(BoardCommentParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteComment(@params), token);

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(BoardEditCommentParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			EditComment(@params), token);

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(BoardCommentParams @params,
										CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			RestoreComment(@params), token);
}