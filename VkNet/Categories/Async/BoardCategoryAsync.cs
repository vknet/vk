using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class BoardCategory
{
	/// <inheritdoc />
	public Task<VkCollection<Topic>> GetTopicsAsync(BoardGetTopicsParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			GetTopics(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<TopicsFeed> GetCommentsAsync(BoardGetCommentsParams @params, bool skipAuthorization = false) =>
		TypeHelper.TryInvokeMethodAsync(func: () =>
			GetComments(@params, skipAuthorization));

	/// <inheritdoc />
	public Task<long> AddTopicAsync(BoardAddTopicParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => AddTopic(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteTopicAsync(BoardTopicParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteTopic(@params: @params));

	/// <inheritdoc />
	public Task<bool> CloseTopicAsync(BoardTopicParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CloseTopic(@params: @params));

	/// <inheritdoc />
	public Task<bool> OpenTopicAsync(BoardTopicParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => OpenTopic(@params: @params));

	/// <inheritdoc />
	public Task<bool> FixTopicAsync(BoardTopicParams @params) => TypeHelper.TryInvokeMethodAsync(func: () => FixTopic(@params: @params));

	/// <inheritdoc />
	public Task<bool> UnFixTopicAsync(BoardTopicParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => UnFixTopic(@params: @params));

	/// <inheritdoc />
	public Task<bool> EditTopicAsync(BoardEditTopicParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => EditTopic(@params: @params));

	/// <inheritdoc />
	public Task<long> CreateCommentAsync(BoardCreateCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => CreateComment(@params: @params));

	/// <inheritdoc />
	public Task<bool> DeleteCommentAsync(BoardCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => DeleteComment(@params: @params));

	/// <inheritdoc />
	public Task<bool> EditCommentAsync(BoardEditCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => EditComment(@params: @params));

	/// <inheritdoc />
	public Task<bool> RestoreCommentAsync(BoardCommentParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => RestoreComment(@params: @params));
}