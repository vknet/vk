using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class BoardCategory
	{
		/// <inheritdoc />
		public Task<VkCollection<Topic>> GetTopicsAsync(BoardGetTopicsParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetTopics(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<TopicsFeed> GetCommentsAsync(BoardGetCommentsParams @params, bool skipAuthorization = false)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					GetComments(@params: @params, skipAuthorization: skipAuthorization));
		}

		/// <inheritdoc />
		public Task<long> AddTopicAsync(BoardAddTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>AddTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteTopicAsync(BoardTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> CloseTopicAsync(BoardTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>CloseTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> OpenTopicAsync(BoardTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>OpenTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> FixTopicAsync(BoardTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>FixTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> UnFixTopicAsync(BoardTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>UnFixTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditTopicAsync(BoardEditTopicParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditTopic(@params: @params));
		}

		/// <inheritdoc />
		public Task<long> CreateCommentAsync(BoardCreateCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>CreateComment(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteCommentAsync(BoardCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteComment(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditCommentAsync(BoardEditCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>EditComment(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> RestoreCommentAsync(BoardCommentParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>RestoreComment(@params: @params));
		}
	}
}