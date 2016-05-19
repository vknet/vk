﻿using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.getMembers
	/// </summary>
	public struct GroupsGetMembersParams
	{
		/// <summary>
		/// Параметры метода groups.getMembers
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public GroupsGetMembersParams(bool gag = true)
		{
			GroupId = null;
			Sort = null;
			Offset = null;
			Count = null;
			Fields = null;
			Filter = null;
		}

		/// <summary>
		/// Идентификатор или короткое имя сообщества. строка.
		/// </summary>
		public string GroupId { get; set; }

		/// <summary>
		/// Сортировка, с которой необходимо вернуть список участников. Может принимать значения: 
		/// 
		/// id_asc — в порядке возрастания id; 
		/// id_desc — в порядке убывания id; 
		/// time_asc — в хронологическом порядке по вступлению в сообщество; 
		/// time_desc — в антихронологическом порядке по вступлению в сообщество. 
		/// Сортировка по time_asc и time_desc возможна только при вызове от модератора сообщества. строка, по умолчанию id_asc.
		/// </summary>
		public GroupsSort Sort { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества участников. По умолчанию 0. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество участников сообщества, информацию о которых необходимо получить. положительное число, по умолчанию 1000, максимальное значение 1000.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть. 
		/// Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, lists, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters список строк, разделенных через запятую.
		/// </summary>
		public UsersFields Fields { get; set; }

		/// <summary>
		/// Friends — будут возвращены только друзья в этом сообществе. 
		/// unsure — будут возвращены пользователи, которые выбрали «Возможно пойду» (если сообщество относится к мероприятиям). 
		/// managers — будут возвращены только руководители сообщества (доступно при запросе с передачей access_token от имени администратора сообщества). 
		/// строка.
		/// </summary>
		public GroupsFilters Filter { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(GroupsGetMembersParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "sort", p.Sort },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "fields", p.Fields },
				{ "filter", p.Filter }
			};

			return parameters;
		}
	}
}