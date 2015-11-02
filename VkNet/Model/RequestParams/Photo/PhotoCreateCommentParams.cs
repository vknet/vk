using System.Collections.Generic;
using VkNet.Model.Attachments;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.createComment
	/// </summary>
	public class PhotoCreateCommentParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография. целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// Идентификатор фотографии. целое число, обязательный параметр.
		/// </summary>
		public ulong PhotoId
		{ get; set; }

		/// <summary>
		/// Текст комментария (является обязательным, если не задан параметр <c>Attachments</c>). Максимальное количество символов: 2048. строка.
		/// </summary>
		public string Message
		{ get; set; }

		/// <summary>
		/// Список объектов, приложенных к комментарию и разделённых символом ",". Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<Attachment> Attachments
		{ get; set; }

		/// <summary>
		/// Данный параметр учитывается, если oid меньше 0 (комментарий к фотографии группы). 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет опубликован от имени пользователя (по умолчанию). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? FromGroup
		{ get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который нужно оставить текущий. целое число.
		/// </summary>
		public long? ReplyToComment
		{ get; set; }

		/// <summary>
		/// Идентификатор стикера, который нужно прикрепить к комментарию. положительное число.
		/// </summary>
		public ulong? StickerId
		{ get; set; }

		/// <summary>
		/// Ключ доступа. строка.
		/// </summary>
		public string AccessKey
		{ get; set; }

		/// <summary>
		/// Положительное число.
		/// </summary>
		public ulong? Guid
		{ get; set; }
	}
}