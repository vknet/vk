using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	[Serializable]
	public class WallCreateCommentParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, на чьей стене находится запись, к
		/// которой необходимо добавить
		/// комментарий. Обратите внимание, идентификатор сообщества в параметре owner_id
		/// необходимо указывать со знаком "-" —
		/// например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, по умолчанию
		/// идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор записи на стене пользователя или сообщества. положительное число,
		/// обязательный параметр.
		/// </summary>
		public long PostId { get; set; }

		/// <summary>
		/// Идентификатор сообщества, от имени которого публикуется комментарий. По
		/// умолчанию: 0.
		/// </summary>
		public long FromGroup { get; set; }

		/// <summary>
		/// Текст комментария. Обязательный параметр, если не передан параметр attachments
		/// </summary>
		[CanBeNull]
		public string Message { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который должен быть добавлен новый
		/// комментарий. целое число.
		/// </summary>
		public long? ReplyToComment { get; set; }

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
		[CanBeNull]
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Идентификатор стикера. положительное число.
		/// </summary>
		public long? StickerId { get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки
		/// одинакового комментария. .
		/// </summary>
		[CanBeNull]
		public string Guid { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public long? CaptchaSid { get; set; }

		/// <summary>
		/// текст, который ввел пользователь
		/// </summary>
		[CanBeNull]
		[Obsolete(ObsoleteText.CaptchaNeeded, true)]
		public string CaptchaKey { get; set; }
	}
}