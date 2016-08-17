using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	public struct BoardEditTopicParams
	{
		/// <summary>
		/// Параметры метода wall.addComment
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public BoardEditTopicParams(bool gag = true)
		{
            GroupId = 0;
            TopicId = 0;
            Title = null;
            CaptchaKey = null;
            CaptchaSid = null;
        }

        /// <summary>
        /// идентификатор сообщества, в котором находится обсуждение.положительное число, обязательный параметр
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// идентификатор сообщества, в котором находится обсуждение.положительное число, обязательный параметр
        /// </summary>
        public long TopicId { get; set; }

        /// <summary>
        /// новое название обсуждения. Обязательный параметр. 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Идентификатор капчи
        /// </summary>
        public long? CaptchaSid { get; set; }

        /// <summary>
        /// текст, который ввел пользователь
        /// </summary>
        public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(BoardEditTopicParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "topic_id", p.TopicId },
                { "title", p.Title },
                { "captcha_sid", p.CaptchaSid},
                { "captcha_key", p.CaptchaKey}
			};

			return parameters;
		}
	}
}