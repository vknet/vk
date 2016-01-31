using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода video.createComment
	/// </summary>
	public struct VideoCreateCommentParams
	{
		/// <summary>
		/// Параметры метода video.createComment
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public VideoCreateCommentParams(bool gag = true)
		{
			OwnerId = null;
			VideoId = 0;
			Message = null;
			Attachments = null;
			FromGroup = null;
			ReplyToComment = null;
			StickerId = null;
		}


		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит видеозапись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор видеозаписи. целое число, обязательный параметр.
		/// </summary>
		public long VideoId { get; set; }

		/// <summary>
		/// Текст комментария (является обязательным, если не задан параметр attachments). строка.
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
		/// Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<string> Attachments { get; set; }

		/// <summary>
		/// Данный параметр учитывается, если oid &lt; 0 (комментарий к видеозаписи группы). 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет опубликован от имени пользователя (по умолчанию). флаг, может принимать значения 1 или 0.
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
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(VideoCreateCommentParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "video_id", p.VideoId },
				{ "message", p.Message },
				{ "attachments", p.Attachments },
				{ "from_group", p.FromGroup },
				{ "reply_to_comment", p.ReplyToComment },
				{ "sticker_id", p.StickerId }
			};

			return parameters;
		}
	}
}