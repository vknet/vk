namespace VkNet.Categories
{
    using Model;
	using Model.RequestParams;
	using Utils;

    /// <summary>
	/// Методы для работы со темами группы.
	/// </summary>
	public class BoardCategory
	{
		private readonly VkApi _vk;

		public BoardCategory(VkApi vk)
		{
			_vk = vk;
		}

        /// <summary>
        /// Возвращает список тем в обсуждениях указанной группы.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.getTopics" />.
        /// </remarks>
        [ApiVersion("5.44")]
        public VkCollection<Topic> GetTopics(BoardGetTopicsParams @params, bool skipAuthorization = false)
        {
            return _vk.Call("board.getTopics", @params, skipAuthorization).ToVkCollectionOf<Topic>(x => x);
        }

        /// <summary>
        /// Возвращает список сообщений в указанной теме.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <param name="skipAuthorization">Если <c>true</c> то пропустить авторизацию.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.getComments" />.
        /// </remarks>
        [ApiVersion("5.44")]
        public TopicsFeed GetComments(BoardGetCommentsParams @params, bool skipAuthorization = false)
        {
            var response = _vk.Call("board.getComments", @params, skipAuthorization);
            var result = new TopicsFeed
            {
                Count = response["count"],
                Items = response["items"].ToReadOnlyCollectionOf<Comment>(x => x),
                Profiles = response["profiles"].ToReadOnlyCollectionOf<User>(x => x),
                Groups = response["groups"].ToReadOnlyCollectionOf<Group>(x => x)
            };
            return result;
        }

        /// <summary>
        /// Создает новую тему в списке обсуждений группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.addTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long AddTopic(BoardAddTopicParams @params)
        {
            return _vk.Call("board.addTopic", @params);
        }

        /// <summary>
        /// Удаляет тему в обсуждениях группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.deleteTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long DeleteTopic(BoardTopicParams @params)
        {
            return _vk.Call("board.deleteTopic", @params);
        }

        /// <summary>
        /// Закрывает тему в списке обсуждений группы (в такой теме невозможно оставлять новые сообщения).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.closeTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long CloseTopic(BoardTopicParams @params)
        {
            return _vk.Call("board.closeTopic", @params);
        }

        /// <summary>
        /// Открывает ранее закрытую тему (в ней станет возможно оставлять новые сообщения).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.openTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long OpenTopic(BoardTopicParams @params)
        {
            return _vk.Call("board.openTopic", @params);
        }

        /// <summary>
        /// Закрепляет тему в списке обсуждений группы (такая тема при любой сортировке выводится выше остальных).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.fixTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long FixTopic(BoardTopicParams @params)
        {
            return _vk.Call("board.fixTopic", @params);
        }

        /// <summary>
        /// Отменяет прикрепление темы в списке обсуждений группы (тема будет выводиться согласно выбранной сортировке).
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.unfixTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long UnFixTopic(BoardTopicParams @params)
        {
            return _vk.Call("board.unfixTopic", @params);
        }


        /// <summary>
        /// Изменяет заголовок темы в списке обсуждений группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.editTopic" />.
        /// </remarks>
        [ApiVersion("5.53")]
        public long EditTopic(BoardEditTopicParams @params)
        {
            return _vk.Call("board.editTopic", @params);
        }

        /// <summary>
        /// Добавляет новый комментарий в обсуждении.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.createComment" />.
        /// </remarks>
        [ApiVersion("5.44")]
        public long СreateComment(BoardCreateCommentParams @params)
        {
            return _vk.Call("board.createComment", @params);
        }

        /// <summary>
        /// Удаляет сообщение в обсуждениях сообщества.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.deleteComment" />.
        /// </remarks>
        [ApiVersion("5.44")]
        public long DeleteComment(BoardCommentParams @params)
        {
            return _vk.Call("board.deleteComment", @params);
        }

        /// <summary>
        /// Редактирует одно из сообщений в обсуждении сообщества..
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.editComment" />.
        /// </remarks>
        public long EditComment(BoardEditCommentParams @params)
        {
            return _vk.Call("board.editComment", @params);
        }

        /// <summary>
        /// Восстанавливает удаленное сообщение темы в обсуждениях группы.
        /// </summary>
        /// <param name="params">Входные параметры.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://vk.com/dev/board.restoreComment" />.
        /// </remarks>
        public long RestoreComment(BoardCommentParams @params)
        {
            return _vk.Call("board.restoreComment", @params);
        }

    }
    
}
