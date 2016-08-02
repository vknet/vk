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

    }
    
}
