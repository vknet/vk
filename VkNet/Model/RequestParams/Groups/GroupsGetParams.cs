﻿using System.Collections.Generic;
using VkNet.Enums.Filters;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.get
	/// </summary>
	public struct GroupsGetParams
	{
		/// <summary>
		/// Параметры метода groups.get
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public GroupsGetParams(bool gag = true)
		{
			UserId = null;
			Extended = null;
			Filter = null;
			Fields = null;
			Offset = null;
			Count = null;
		}


		/// <summary>
		/// Идентификатор пользователя, информацию о сообществах которого требуется получить. положительное число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Если указать в качестве этого параметра 1, то будет возвращена полная информация о группах пользователя. По умолчанию 0. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Список фильтров сообществ, которые необходимо вернуть, перечисленные через запятую. Доступны значения admin, editor, moder, groups, publics, events. По умолчанию возвращаются все сообщества пользователя. 
		/// При указании фильтра admin будут возвращены сообщества, в которых пользователь является администратором, editor — администратором или редактором, moder — администратором, редактором или модератором. список строк, разделенных через запятую.
		/// </summary>
		public GroupsFilters Filter { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть. Возможные значения: city, country, place, description, wiki_page, members_count, counters, start_date, finish_date, can_post, can_see_all_posts, activity, status, contacts, links, fixed_post, verified, site, can_create_topic. Подробнее см. описание полей объекта group. 
		/// Обратите внимание, этот параметр учитывается только при extended=1. список строк, разделенных через запятую.
		/// </summary>
		public GroupsFields Fields { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определённого подмножества сообществ. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество сообществ, информацию о которых нужно вернуть. положительное число, максимальное значение 1000.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(GroupsGetParams p)
		{
			var parameters = new VkParameters
			{
				{ "user_id", p.UserId },
				{ "extended", p.Extended },
				{ "filter", p.Filter },
				{ "fields", p.Fields },
				{ "offset", p.Offset },
				{ "count", p.Count }
			};

			return parameters;
		}
	}
}