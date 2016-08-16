using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	public struct BoardDeleteCommentParams
	{
		/// <summary>
		/// Параметры метода wall.addComment
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public BoardDeleteCommentParams(bool gag = true)
		{
            GroupId = 0;
            TopicId = 0;
            CommentId = 0;
            CaptchaKey = null;
		    CaptchaSid = null;
		}

        /// <summary>
        /// идентификатор сообщества, в котором находится обсуждение.положительное число, обязательный параметр
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// Идентификатор темы, в которой необходимо оставить комментарий.положительное число, обязательный параметр
        /// </summary>
        public long TopicId { get; set; }

        /// <summary>
        /// Идентификатор комментария в обсуждении, обязательный параметр. 
        /// </summary>
        public long CommentId { get; set; }

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
		internal static VkParameters ToVkParameters(BoardDeleteCommentParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "topic_id", p.TopicId },
                { "comment_id", p.CommentId },
                { "captcha_sid", p.CaptchaSid},
                { "captcha_key", p.CaptchaKey},
			};

			return parameters;
		}
	}
}