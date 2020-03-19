using System;
using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.createComment
	/// </summary>
	[Serializable]
	public class PhotoCreateCommentParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong PhotoId { get; set; }

		/// <summary>
		/// Текст комментария (является обязательным, если не задан параметр
		/// <c> Attachments </c>). Максимальное количество
		/// символов: 2048.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Список объектов, приложенных к комментарию и разделённых символом ",". Параметр
		/// является обязательным, если не
		/// задан параметр message.
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Данный параметр учитывается, если oid меньше 0 (комментарий к фотографии
		/// группы). <c> true </c> — комментарий будет
		/// опубликован от имени группы, <c> false </c> — комментарий будет опубликован от
		/// имени пользователя (по умолчанию).
		/// флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? FromGroup { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который нужно оставить текущий.
		/// </summary>
		public long? ReplyToComment { get; set; }

		/// <summary>
		/// Идентификатор стикера, который нужно прикрепить к комментарию.
		/// </summary>
		public ulong? StickerId { get; set; }

		/// <summary>
		/// Ключ доступа.
		/// </summary>
		public string AccessKey { get; set; }

		/// <summary>
		/// Положительное число.
		/// </summary>
		public ulong? Guid { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }
	}
}