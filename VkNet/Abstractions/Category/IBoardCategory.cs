using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IBoardCategoryAsync" />
	public interface IBoardCategory : IBoardCategoryAsync
	{
		/// <inheritdoc cref="IBoardCategoryAsync.GetTopicsAsync"/>
		VkCollection<Topic> GetTopics(BoardGetTopicsParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IBoardCategoryAsync.GetCommentsAsync"/>
		TopicsFeed GetComments(BoardGetCommentsParams @params, bool skipAuthorization = false);

		/// <inheritdoc cref="IBoardCategoryAsync.AddTopicAsync"/>
		long AddTopic(BoardAddTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.DeleteTopicAsync"/>
		bool DeleteTopic(BoardTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.CloseTopicAsync"/>
		bool CloseTopic(BoardTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.OpenTopicAsync"/>
		bool OpenTopic(BoardTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.FixTopicAsync"/>
		bool FixTopic(BoardTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.UnFixTopicAsync"/>
		bool UnFixTopic(BoardTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.EditTopicAsync"/>
		bool EditTopic(BoardEditTopicParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.CreateCommentAsync"/>
		long CreateComment(BoardCreateCommentParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.DeleteCommentAsync"/>
		bool DeleteComment(BoardCommentParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.EditCommentAsync"/>
		bool EditComment(BoardEditCommentParams @params);

		/// <inheritdoc cref="IBoardCategoryAsync.RestoreCommentAsync"/>
		bool RestoreComment(BoardCommentParams @params);
	}
}