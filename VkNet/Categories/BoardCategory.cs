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
		private readonly VkApi _vk;

		/// <summary>
		/// </summary>
		/// <param name="vk"> </param>
		public BoardCategory(VkApi vk)
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
			return _vk.Call(methodName: "board.getTopics", parameters: @params, skipAuthorization: skipAuthorization)
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
			var response = _vk.Call(methodName: "board.getComments", parameters: @params, skipAuthorization: skipAuthorization);

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
			return _vk.Call(methodName: "board.addTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.deleteTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.closeTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.openTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.fixTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.unfixTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.editTopic", parameters: @params);
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
			return _vk.Call(methodName: "board.createComment", parameters: @params);
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
			return _vk.Call(methodName: "board.deleteComment", parameters: @params);
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
			return _vk.Call(methodName: "board.editComment", parameters: @params);
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
			return _vk.Call(methodName: "board.restoreComment", parameters: @params);
		}
	}
}