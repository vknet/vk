using System;
using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.addComment
	/// </summary>
	[Serializable]
	public class WallAddCommentParams
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
		/// Данный параметр учитывается, если owner_id &lt; 0 (комментарий публикуется на
		/// стене группы). 1 — комментарий будет
		/// опубликован от имени группы, 0 — комментарий будет опубликован от имени
		/// пользователя (по умолчанию). флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? FromGroup { get; set; }

		/// <summary>
		/// Текст комментария к записи. строка.
		/// </summary>
		public string Text { get; set; }

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
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// Идентификатор стикера. положительное число.
		/// </summary>
		public long? StickerId { get; set; }

		/// <summary>
		/// Строка.
		/// </summary>
		public string Ref { get; set; }

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
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(WallAddCommentParams p)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "post_id", p.PostId }
					, { "from_group", p.FromGroup }
					, { "text", p.Text }
					, { "reply_to_comment", p.ReplyToComment }
					, { "attachments", p.Attachments }
					, { "sticker_id", p.StickerId }
					, { "ref", p.Ref }
					, { "captcha_sid", p.CaptchaSid }
					, { "captcha_key", p.CaptchaKey }
			};

			return parameters;
		}
	}
}