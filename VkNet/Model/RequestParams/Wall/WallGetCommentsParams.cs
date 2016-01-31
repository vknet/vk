﻿using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.getComments
	/// </summary>
	public struct WallGetCommentsParams
	{
		/// <summary>
		/// Параметры метода wall.getComments
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public WallGetCommentsParams(bool gag = true)
		{
			OwnerId = null;
			PostId = 0;
			NeedLikes = null;
			StartCommentId = null;
			Offset = null;
			Count = null;
			Sort = null;
			PreviewLength = null;
			Extended = null;
		}


		/// <summary>
		/// Идентификатор владельца страницы (пользователь или сообщество). Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор записи на стене. положительное число, обязательный параметр.
		/// </summary>
		public long PostId { get; set; }

		/// <summary>
		/// 1 — возвращать информацию о лайках. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? NeedLikes { get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности см. ниже). положительное число, доступен начиная с версии 5.33.
		/// </summary>
		public long? StartCommentId { get; set; }

		/// <summary>
		/// Сдвиг, необходимый для получения конкретной выборки результатов. целое число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Число комментариев, которые необходимо получить. По умолчанию — 10, максимальное значение — 100. положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым) строка.
		/// </summary>
		public SortOrderBy? Sort { get; set; }

		/// <summary>
		/// Количество символов, по которому нужно обрезать текст комментария. Укажите 0, если Вы не хотите обрезатьтекст. положительное число.
		/// </summary>
		public long? PreviewLength { get; set; }

		/// <summary>
		/// 1 — комментарии в ответе будут возвращены в виде пронумерованных объектов, дополнительно будут возвращены списки объектов profiles, groups. флаг, может принимать значения 1 или 0, доступен начиная с версии 5.0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(WallGetCommentsParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "post_id", p.PostId },
				{ "need_likes", p.NeedLikes },
				{ "start_comment_id", p.StartCommentId },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "sort", p.Sort },
				{ "preview_length", p.PreviewLength },
				{ "extended", p.Extended }
			};

			return parameters;
		}
	}
}