using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	public struct BoardAddTopicParams
	{
		/// <summary>
		/// Параметры метода wall.addComment
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public BoardAddTopicParams(bool gag = true)
		{
            GroupId = 0;
            Title = null;
            Text = null;
            FromGroup = null;
            Attachments = null;
            CaptchaKey = null;
            CaptchaSid = null;
        }

        /// <summary>
        /// идентификатор сообщества, в котором находится обсуждение.положительное число, обязательный параметр
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// название обсуждения. Обязательный параметр. 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// текст первого сообщения в обсуждении. 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 1 — сообщение будет опубликовано от имени группы, 0 — сообщение будет опубликовано от имени пользователя (по умолчанию).
        /// </summary>
        public bool? FromGroup { get; set; }

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
		internal static VkParameters ToVkParameters(BoardAddTopicParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "title", p.Title },
                { "text", p.Text },
                { "from_group", p.FromGroup },
				{ "attachments", p.Attachments },
                { "captcha_sid", p.CaptchaSid},
                { "captcha_key", p.CaptchaKey}
			};

			return parameters;
		}
	}
}