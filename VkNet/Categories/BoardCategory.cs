using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class BoardCategory : IBoardCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Api vk.com
		/// </summary>
		/// <param name="vk"> </param>
		public BoardCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public VkCollection<Topic> GetTopics(BoardGetTopicsParams @params, bool skipAuthorization = false)
		{
			return _vk.Call("board.getTopics", new VkParameters
				{
					{ "group_id", @params.GroupId }
					, { "topic_ids", @params.TopicIds }
					, { "order", @params.Order }
					, { "offset", @params.Offset }
					, { "count", @params.Count }
					, { "extended", @params.Extended }
					, { "preview", @params.Preview }
					, { "preview_length", @params.PreviewLength }
				}, skipAuthorization)
					.ToVkCollectionOf<Topic>(selector: x => x);
		}

		/// <inheritdoc />
		public TopicsFeed GetComments(BoardGetCommentsParams @params, bool skipAuthorization = false)
		{
			var response = _vk.Call("board.getComments", new VkParameters
			{
				{ "group_id", @params.GroupId }
				, { "topic_id", @params.TopicId }
				, { "need_likes", @params.NeedLikes }
				, { "start_comment_id", @params.StartCommentId }
				, { "offset", @params.Offset }
				, { "count", @params.Count }
				, { "sort", @params.Sort }
				, { "preview_length", @params.PreviewLength }
				, { "extended", @params.Extended }
			}, skipAuthorization);

			var result = new TopicsFeed
			{
					Count = response[key: "count"]
					, Items = response[key: "items"].ToReadOnlyCollectionOf<CommentBoard>(selector: x => x)
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
			};

			return result;
		}

		/// <inheritdoc />
		public long AddTopic(BoardAddTopicParams @params)
		{
			return _vk.Call("board.addTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "title", @params.Title },
				{ "text", @params.Text },
				{ "from_group", @params.FromGroup },
				{ "attachments", @params.Attachments }
			});
		}

		/// <inheritdoc />
		public bool DeleteTopic(BoardTopicParams @params)
		{
			return _vk.Call("board.deleteTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <inheritdoc />
		public bool CloseTopic(BoardTopicParams @params)
		{
			return _vk.Call("board.closeTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <inheritdoc />
		public bool OpenTopic(BoardTopicParams @params)
		{
			return _vk.Call("board.openTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <inheritdoc />
		public bool FixTopic(BoardTopicParams @params)
		{
			return _vk.Call("board.fixTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <inheritdoc />
		public bool UnFixTopic(BoardTopicParams @params)
		{
			return _vk.Call("board.unfixTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <inheritdoc />
		public bool EditTopic(BoardEditTopicParams @params)
		{
			return _vk.Call("board.editTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "title", @params.Title }
			});
		}

		/// <inheritdoc />
		public long CreateComment(BoardCreateCommentParams @params)
		{
			return _vk.Call("board.createComment", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "from_group", @params.FromGroup },
				{ "message", @params.Message },
				{ "attachments", @params.Attachments },
				{ "sticker_id", @params.StickerId },
				{ "guid", @params.Guid }
			});
		}

		/// <inheritdoc />
		public bool DeleteComment(BoardCommentParams @params)
		{
			return _vk.Call("board.deleteComment", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "comment_id", @params.CommentId }
			});
		}

		/// <inheritdoc />
		public bool EditComment(BoardEditCommentParams @params)
		{
			return _vk.Call("board.editComment", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "comment_id", @params.CommentId },
				{ "message", @params.Message },
				{ "attachments", @params.Attachments }
			});
		}

		/// <inheritdoc />
		public bool RestoreComment(BoardCommentParams @params)
		{
			return _vk.Call<bool>("board.restoreComment", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "comment_id", @params.CommentId }
			});
		}
	}
}