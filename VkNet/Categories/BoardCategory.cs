using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы со темами группы.
	/// </summary>
	public partial class BoardCategory : IBoardCategory
	{
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public BoardCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список тем в обсуждениях указанной группы.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.getTopics" />.
		/// </remarks>
		public VkCollection<Topic> GetTopics(BoardGetTopicsParams @params, bool skipAuthorization = false)
		{
			return _vk.Call(methodName: "board.getTopics", new VkParameters
				{
					{ "group_id", @params.GroupId }
					, { "topic_ids", @params.TopicIds }
					, { "order", @params.Order }
					, { "offset", @params.Offset }
					, { "count", @params.Count }
					, { "extended", @params.Extended }
					, { "preview", @params.Preview }
					, { "preview_length", @params.PreviewLength }
				}, skipAuthorization: skipAuthorization)
					.ToVkCollectionOf<Topic>(selector: x => x);
		}

		/// <summary>
		/// Возвращает список сообщений в указанной теме.
		/// </summary>
		/// <param name="params"> Входные параметры выборки. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.getComments" />.
		/// </remarks>
		public TopicsFeed GetComments(BoardGetCommentsParams @params, bool skipAuthorization = false)
		{
			var response = _vk.Call(methodName: "board.getComments", new VkParameters
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
			}, skipAuthorization: skipAuthorization);

			var result = new TopicsFeed
			{
					Count = response[key: "count"]
					, Items = response[key: "items"].ToReadOnlyCollectionOf<CommentBoard>(selector: x => x)
					, Profiles = response[key: "profiles"].ToReadOnlyCollectionOf<User>(selector: x => x)
					, Groups = response[key: "groups"].ToReadOnlyCollectionOf<Group>(selector: x => x)
			};

			return result;
		}

		/// <summary>
		/// Создает новую тему в списке обсуждений группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.addTopic
		/// </remarks>
		public long AddTopic(BoardAddTopicParams @params)
		{
			return _vk.Call(methodName: "board.addTopic", new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "title", @params.Title },
				{ "text", @params.Text },
				{ "from_group", @params.FromGroup },
				{ "attachments", @params.Attachments }
			});
		}

		/// <summary>
		/// Удаляет тему в обсуждениях группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.deleteTopic
		/// </remarks>
		public bool DeleteTopic(BoardTopicParams @params)
		{
			return _vk.Call(methodName: "board.deleteTopic", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <summary>
		/// Закрывает тему в списке обсуждений группы (в такой теме невозможно оставлять
		/// новые сообщения).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.closeTopic
		/// </remarks>
		public bool CloseTopic(BoardTopicParams @params)
		{
			return _vk.Call(methodName: "board.closeTopic", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <summary>
		/// Открывает ранее закрытую тему (в ней станет возможно оставлять новые
		/// сообщения).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.openTopic
		/// </remarks>
		public bool OpenTopic(BoardTopicParams @params)
		{
			return _vk.Call(methodName: "board.openTopic", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <summary>
		/// Закрепляет тему в списке обсуждений группы (такая тема при любой сортировке
		/// выводится выше остальных).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.fixTopic
		/// </remarks>
		public bool FixTopic(BoardTopicParams @params)
		{
			return _vk.Call(methodName: "board.fixTopic", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <summary>
		/// Отменяет прикрепление темы в списке обсуждений группы (тема будет выводиться
		/// согласно выбранной сортировке).
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.unfixTopic
		/// </remarks>
		public bool UnFixTopic(BoardTopicParams @params)
		{
			return _vk.Call(methodName: "board.unfixTopic", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId }
			});
		}

		/// <summary>
		/// Изменяет заголовок темы в списке обсуждений группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.editTopic
		/// </remarks>
		public bool EditTopic(BoardEditTopicParams @params)
		{
			return _vk.Call(methodName: "board.editTopic", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "title", @params.Title }
			});
		}

		/// <summary>
		/// Добавляет новый комментарий в обсуждении.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.createComment" />.
		/// </remarks>
		public long CreateComment(BoardCreateCommentParams @params)
		{
			return _vk.Call(methodName: "board.createComment", parameters: new VkParameters
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

		/// <summary>
		/// Удаляет сообщение в обсуждениях сообщества.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте
		/// <see href="https://new.vk.com/dev/board.deleteComment" />.
		/// </remarks>
		public bool DeleteComment(BoardCommentParams @params)
		{
			return _vk.Call(methodName: "board.deleteComment", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "comment_id", @params.CommentId }
			});
		}

		/// <summary>
		/// Редактирует одно из сообщений в обсуждении сообщества..
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.editComment
		/// </remarks>
		public bool EditComment(BoardEditCommentParams @params)
		{
			return _vk.Call(methodName: "board.editComment", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "comment_id", @params.CommentId },
				{ "message", @params.Message },
				{ "attachments", @params.Attachments }
			});
		}

		/// <summary>
		/// Восстанавливает удаленное сообщение темы в обсуждениях группы.
		/// </summary>
		/// <param name="params"> Входные параметры. </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/board.restoreComment
		/// </remarks>
		public bool RestoreComment(BoardCommentParams @params)
		{
			return _vk.Call<bool>(methodName: "board.restoreComment", parameters: new VkParameters
			{
				{ "group_id", @params.GroupId },
				{ "topic_id", @params.TopicId },
				{ "comment_id", @params.CommentId }
			});
		}
	}
}