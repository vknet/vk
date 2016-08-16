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

		internal BoardCategory(VkApi vk)
		{
			_vk = vk;
		}

        /// <summary>
        /// Возвращает список тем в обсуждениях указанной группы.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.getTopics" />.
        /// </remarks>
        [ApiVersion("5.44")]
        public VkCollection<Topic> GetTopics(BoardGetTopicsParams @params)
        {
            return _vk.Call("board.getTopics", @params).ToVkCollectionOf<Topic>(x => x);
        }

        /// <summary>
        /// Возвращает список сообщений в указанной теме.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
        /// <returns>
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте <see href="https://new.vk.com/dev/board.getComments" />.
        /// </remarks>
        [ApiVersion("5.44")]
        public TopicsFeed GetComments(BoardGetCommentsParams @params)
        {
            var response = _vk.Call("board.getComments", @params);
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
        /// Возвращает список сообщений в указанной теме.
        /// </summary>
        /// <param name="params">Входные параметры выборки.</param>
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
        public long DeleteComment(BoardDeleteCommentParams @params)
        {
            return _vk.Call("board.deleteComment", @params);
        }

    }
    
}
