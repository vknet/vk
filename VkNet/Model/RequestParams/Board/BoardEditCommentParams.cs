using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	[Serializable]
	public class BoardEditCommentParams
	{
		/// <summary>
		/// Идентификатор сообщества, в котором находится обсуждение.положительное число,
		/// обязательный параметр
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public long? GroupId { get; set; }

		/// <summary>
		/// Идентификатор темы, в которой необходимо оставить комментарий.положительное
		/// число, обязательный параметр
		/// </summary>
		[JsonProperty(propertyName: "topic_id")]
		public long TopicId { get; set; }

		/// <summary>
		/// Идентификатор комментария в обсуждении.положительное число, обязательный
		/// параметр.
		/// </summary>
		[JsonProperty(propertyName: "comment_id")]
		public long CommentId { get; set; }

		/// <summary>
		/// Текст комментария. Обязательный параметр, если не передано значение
		/// attachments.
		/// </summary>
		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }

		/// <summary>
		/// Список объектов, приложенных к комментарию и разделённых символом ",". Поле
		/// attachments представляется в формате:
		/// &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;
		/// media_id&gt;
		/// &lt;type&gt; — тип медиа-вложения:
		/// photo — фотография
		/// video — видеозапись
		/// audio — аудиозапись
		/// doc — документ
		/// &lt;owner_id&gt; — идентификатор владельца медиа-вложения
		/// &lt;media_id&gt; — идентификатор медиа-вложения.
		/// Например:
		/// photo100172_166443618,photo66748_265827614
		/// Параметр является обязательным, если не задан параметр text. список строк,
		/// разделенных через запятую.
		/// </summary>
		[JsonProperty(propertyName: "attachments")]
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[JsonProperty(propertyName: "captcha_sid")]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// Текст, который ввел пользователь
		/// </summary>
		[JsonProperty(propertyName: "captcha_key")]
		public string CaptchaKey { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(BoardEditCommentParams p)
		{
			var parameters = new VkParameters
			{
					{ "group_id", p.GroupId }
					, { "topic_id", p.TopicId }
					, { "comment_id", p.CommentId }
					, { "message", p.Message }
					, { "attachments", p.Attachments }
					, { "captcha_sid", p.CaptchaSid }
					, { "captcha_key", p.CaptchaKey }
			};

			return parameters;
		}
	}
}