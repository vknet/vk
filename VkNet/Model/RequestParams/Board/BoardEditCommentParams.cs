using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	public struct BoardEditCommentParams
	{
		/// <summary>
		/// Параметры метода wall.addComment
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public BoardEditCommentParams(bool gag = true)
		{
            GroupId = null;
            TopicId = 0;
            CommentId = 0;
            Message = null;
            Attachments = null;
		    CaptchaKey = null;
		    CaptchaSid = null;
		}

        /// <summary>
        /// идентификатор сообщества, в котором находится обсуждение.положительное число, обязательный параметр
        /// </summary>
        public long? GroupId { get; set; }

        /// <summary>
        /// Идентификатор темы, в которой необходимо оставить комментарий.положительное число, обязательный параметр
        /// </summary>
        public long TopicId { get; set; }

        /// <summary>
        /// идентификатор комментария в обсуждении.положительное число, обязательный параметр.
        /// </summary>
        public long CommentId { get; set; }

        /// <summary>
        /// новый текст комментария (является обязательным, если не задан параметр attachments). 
        /// </summary>
        public string Message { get; set; }

		/// <summary>
		/// Список объектов, приложенных к комментарию и разделённых символом ",". Поле attachments представляется в формате:
		/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;
		/// &lt;type&gt; — тип медиа-вложения:
		/// photo — фотография 
		/// video — видеозапись 
		/// audio — аудиозапись 
		/// doc — документ
		/// &lt;owner_id&gt; — идентификатор владельца медиа-вложения 
		/// &lt;media_id&gt; — идентификатор медиа-вложения. 
		/// 
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		/// Параметр является обязательным, если не задан параметр text. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }
   
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
		internal static VkParameters ToVkParameters(BoardEditCommentParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "topic_id", p.TopicId },
                { "comment_id", p.CommentId },
                { "message", p.Message },
				{ "attachments", p.Attachments },
                { "captcha_sid", p.CaptchaSid},
                { "captcha_key", p.CaptchaKey}
			};

			return parameters;
		}
	}
}