using System;
using VkNet.Enums;
using VkNet.Enums.Filters;

namespace VkNet.Model.RequestParams.Market
{
	/// <summary>
	/// Параметры запроса market.getComments
	/// </summary>
	[Serializable]
	public class MarketGetCommentsParams
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
		/// 1 — возвращать информацию о лайках. флаг, может принимать значения 1 или 0
		/// (флаг, может принимать значения 1 или
		/// 0).
		/// </summary>
		public bool? NeedLikes { get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности
		/// см. ниже). положительное число
		/// (положительное число).
		/// </summary>
		public long? StartCommentId { get; set; }

		/// <summary>
		/// Сдвиг, необходимый для получения конкретной выборки результатов. положительное
		/// число, по умолчанию 0 (положительное
		/// число, по умолчанию 0).
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Число комментариев, которые необходимо получить. положительное число, по
		/// умолчанию 20, максимальное значение 100
		/// (положительное число, по умолчанию 20, максимальное значение 100).
		/// </summary>
		/// <value>
		/// The count.
		/// </value>
		public long? Count { get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к
		/// старым) строка, по умолчанию asc
		/// (строка, по умолчанию asc).
		/// </summary>
		public SortOrderBy? Sort { get; set; }

		/// <summary>
		/// 1 — комментарии в ответе будут возвращены в виде пронумерованных объектов,
		/// дополнительно будут возвращены списки
		/// объектов profiles, groups. флаг, может принимать значения 1 или 0 (флаг, может
		/// принимать значения 1 или 0).
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное
		/// описание. Доступные значения: sex,
		/// bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200,
		/// photo_400_orig, photo_max, photo_max_orig,
		/// photo_id, online, online_mobile, domain, has_mobile, contacts, connections,
		/// site, education, universities, schools,
		/// can_post, can_see_all_posts, can_see_audio, can_write_private_message, status,
		/// last_seen, common_count, relation,
		/// relatives, counters, screen_name, maiden_name, timezone, occupation,activities,
		/// interests, music, movies, tv,
		/// books, games, about, quotes, personal, friend_status, military, career список
		/// строк, разделенных через запятую
		/// (список строк, разделенных через запятую).
		/// </summary>
		public UsersFields Fields { get; set; }
	}
}