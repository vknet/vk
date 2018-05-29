using System;
using System.Collections.Generic;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса market.createComment
	/// </summary>
	[Serializable]
	public class MarketCreateCommentParams
	{
		/// <summary>
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id необходимо
		/// указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору
		/// сообщества ВКонтакте API (club1)
		/// целое число, обязательный параметр (целое число, обязательный параметр).
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор товара. положительное число, обязательный параметр (положительное
		/// число, обязательный параметр).
		/// </summary>
		public long ItemId { get; set; }

		/// <summary>
		/// Текст комментария (является обязательным, если не задан параметр attachments).
		/// строка (строка).
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Список объектов, приложенных к комментарию и разделённых символом ",".
		/// </summary>
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// 1 — комментарий будет опубликован от имени группы, 0 — комментарий будет
		/// опубликован от имени пользователя (по
		/// умолчанию). флаг, может принимать значения 1 или 0 (флаг, может принимать
		/// значения 1 или 0).
		/// </summary>
		public bool? FromGroup { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который должен быть добавлен новый
		/// комментарий. положительное число
		/// (положительное число).
		/// </summary>
		public long? ReplyToComment { get; set; }

		/// <summary>
		/// Идентификатор стикера. положительное число (положительное число).
		/// </summary>
		public long? StickerId { get; set; }

		/// <summary>
		/// Уникальный идентификатор, предназначенный для предотвращения повторной отправки
		/// одинакового комментария.
		/// </summary>
		public string Guid { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(MarketCreateCommentParams p)
		{
			return new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "item_id", p.ItemId }
					, { "message", p.Message }
					, { "attachments", p.Attachments }
					, { "from_group", p.FromGroup }
					, { "reply_to_comment", p.ReplyToComment }
					, { "sticker_id", p.StickerId }
					, { "guid", p.Guid }
			};
		}
	}
}