using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.createComment
	/// </summary>
	[Serializable]
	public class VideoCreateCommentParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись.
		/// Обратите внимание, идентификатор
		/// сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию
		/// идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи. целое число, обязательный параметр.
		/// </summary>
		public long VideoId { get; set; }

		/// <summary>
		/// Текст комментария (является обязательным, если не задан параметр attachments).
		/// строка.
		/// </summary>
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
		/// Параметр является обязательным, если не задан параметр message. список строк,
		/// разделенных через запятую.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Данный параметр учитывается, если oid &lt; 0 (комментарий к видеозаписи
		/// группы). 1 — комментарий будет опубликован
		/// от имени группы, 0 — комментарий будет опубликован от имени пользователя (по
		/// умолчанию). флаг, может принимать
		/// значения 1 или 0.
		/// </summary>
		public bool? FromGroup { get; set; }

		/// <summary>
		/// Положительное число.
		/// </summary>
		public long? ReplyToComment { get; set; }

		/// <summary>
		/// Положительное число.
		/// </summary>
		public long? StickerId { get; set; }

		/// <summary>
		/// </summary>
		[JsonProperty(propertyName: "guid")]
		public string Guid { get; set; }
	}
}