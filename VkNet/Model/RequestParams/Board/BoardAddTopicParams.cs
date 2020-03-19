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
	public class BoardAddTopicParams
	{
		/// <summary>
		/// идентификатор сообщества, в котором находится обсуждение.положительное число,
		/// обязательный параметр
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public long GroupId { get; set; }

		/// <summary>
		/// название обсуждения. Обязательный параметр.
		/// </summary>
		[JsonProperty(propertyName: "title")]
		public string Title { get; set; }

		/// <summary>
		/// текст первого сообщения в обсуждении.
		/// </summary>
		[JsonProperty(propertyName: "text")]
		public string Text { get; set; }

		/// <summary>
		/// 1 — сообщение будет опубликовано от имени группы, 0 — сообщение будет
		/// опубликовано от имени пользователя (по
		/// умолчанию).
		/// </summary>
		[JsonProperty(propertyName: "from_group")]
		public bool? FromGroup { get; set; }

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
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[JsonProperty(propertyName: "captcha_key")]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }
	}
}