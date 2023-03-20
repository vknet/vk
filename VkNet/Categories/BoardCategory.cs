using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class BoardCategory : IBoardCategory
{
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Api vk.com
	/// </summary>
	/// <param name="vk"> </param>
	public BoardCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public VkCollection<Topic> GetTopics(BoardGetTopicsParams @params, bool skipAuthorization = false) => _vk.Call<VkCollection<Topic>>("board.getTopics", new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"topic_ids", @params.TopicIds
			},
			{
				"order", @params.Order
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			},
			{
				"extended", @params.Extended
			},
			{
				"preview", @params.Preview
			},
			{
				"preview_length", @params.PreviewLength
			}
		}, skipAuthorization);

	/// <inheritdoc />
	public TopicsFeed GetComments(BoardGetCommentsParams @params, bool skipAuthorization = false)
	{
		return _vk.Call<TopicsFeed>("board.getComments", new()
		{
			{
				"group_id", @params.GroupId
			},
			{
				"topic_id", @params.TopicId
			},
			{
				"need_likes", @params.NeedLikes
			},
			{
				"start_comment_id", @params.StartCommentId
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			},
			{
				"sort", @params.Sort
			},
			{
				"preview_length", @params.PreviewLength
			},
			{
				"extended", @params.Extended
			}
		}, skipAuthorization);
	}

	/// <inheritdoc />
	public long AddTopic(BoardAddTopicParams @params) => _vk.Call<long>("board.addTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"title", @params.Title
		},
		{
			"text", @params.Text
		},
		{
			"from_group", @params.FromGroup
		},
		{
			"attachments", @params.Attachments
		}
	});

	/// <inheritdoc />
	public bool DeleteTopic(BoardTopicParams @params) => _vk.Call<bool>("board.deleteTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		}
	});

	/// <inheritdoc />
	public bool CloseTopic(BoardTopicParams @params) => _vk.Call<bool>("board.closeTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		}
	});

	/// <inheritdoc />
	public bool OpenTopic(BoardTopicParams @params) => _vk.Call<bool>("board.openTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		}
	});

	/// <inheritdoc />
	public bool FixTopic(BoardTopicParams @params) => _vk.Call<bool>("board.fixTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		}
	});

	/// <inheritdoc />
	public bool UnFixTopic(BoardTopicParams @params) => _vk.Call<bool>("board.unfixTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		}
	});

	/// <inheritdoc />
	public bool EditTopic(BoardEditTopicParams @params) => _vk.Call<bool>("board.editTopic", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		},
		{
			"title", @params.Title
		}
	});

	/// <inheritdoc />
	public long CreateComment(BoardCreateCommentParams @params) => _vk.Call<long>("board.createComment", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		},
		{
			"from_group", @params.FromGroup
		},
		{
			"message", @params.Message
		},
		{
			"attachments", @params.Attachments
		},
		{
			"sticker_id", @params.StickerId
		},
		{
			"guid", @params.Guid
		}
	});

	/// <inheritdoc />
	public bool DeleteComment(BoardCommentParams @params) => _vk.Call<bool>("board.deleteComment", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		},
		{
			"comment_id", @params.CommentId
		}
	});

	/// <inheritdoc />
	public bool EditComment(BoardEditCommentParams @params) => _vk.Call<bool>("board.editComment", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		},
		{
			"comment_id", @params.CommentId
		},
		{
			"message", @params.Message
		},
		{
			"attachments", @params.Attachments
		}
	});

	/// <inheritdoc />
	public bool RestoreComment(BoardCommentParams @params) => _vk.Call<bool>("board.restoreComment", new()
	{
		{
			"group_id", @params.GroupId
		},
		{
			"topic_id", @params.TopicId
		},
		{
			"comment_id", @params.CommentId
		}
	});
}