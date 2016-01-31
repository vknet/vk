﻿using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.search
	/// </summary>
	public struct FriendsSearchParams
	{
		/// <summary>
		/// Параметры метода friends.search
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public FriendsSearchParams(bool gag = true)
		{
			UserId = 0;
			Query = null;
			Fields = null;
			NameCase = null;
			Offset = null;
			Count = null;
		}


		/// <summary>
		/// Идентификатор пользователя, по списку друзей которого необходимо произвести поиск. положительное число, по умолчанию идентификатор текущего пользователя, обязательный параметр.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Строка запроса. строка.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть. 
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities, domain список строк, разделенных через запятую.
		/// </summary>
		public ProfileFields Fields { get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка, по умолчанию Nom.
		/// </summary>
		public NameCase NameCase { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества друзей. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество друзей, которое нужно вернуть. положительное число, по умолчанию 20, максимальное значение 1000.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(FriendsSearchParams p)
		{
			var parameters = new VkParameters
			{
				{ "user_id", p.UserId },
				{ "q", p.Query },
				{ "fields", p.Fields },
				{ "name_case", p.NameCase },
				{ "offset", p.Offset },
				{ "count", p.Count }
			};

			return parameters;
		}
	}
}