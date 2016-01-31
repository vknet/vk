﻿using System.Collections.Generic;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода wall.search
	/// </summary>
	public struct WallSearchParams
	{
		/// <summary>
		/// Параметры метода wall.search
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public WallSearchParams(bool gag = true)
		{
			OwnerId = null;
			Domain = null;
			Query = null;
			OwnersOnly = null;
			Count = null;
			Offset = null;
			Extended = null;
			Fields = null;
		}


		/// <summary>
		/// Идентификатор пользователя или сообщества. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Короткий адрес пользователя или сообщества. строка.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Поисковой запрос. строка.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// 1 — возвращать только записи от имени владельца стены. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? OwnersOnly { get; set; }

		/// <summary>
		/// Количество записей, которые необходимо вернуть. положительное число, по умолчанию 20, максимальное значение 100.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение. положительное число, по умолчанию 0.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Возвращать ли расширенную информацию о записях. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Список дополнительных полей для групп, которые необходимо вернуть. Возможные значения: city, country, place, description, wiki_page, members_count, counters, start_date, finish_date, can_post, can_see_all_posts, activity, status, contacts, links, fixed_post, verified, site, can_create_topic. 
		/// Обратите внимание, этот параметр учитывается только при extended=1. список строк, разделенных через запятую.
		/// </summary>
		public GroupsFields Fields { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(WallSearchParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "domain", p.Domain },
				{ "query", p.Query },
				{ "owners_only", p.OwnersOnly },
				{ "count", p.Count },
				{ "offset", p.Offset },
				{ "extended", p.Extended },
				{ "fields", p.Fields }
			};

			return parameters;
		}
	}
}