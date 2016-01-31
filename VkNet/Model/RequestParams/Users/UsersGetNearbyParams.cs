﻿using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода users.getNearby
	/// </summary>
	public struct UsersGetNearbyParams
	{
		/// <summary>
		/// Параметры метода users.getNearby
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public UsersGetNearbyParams(bool gag = true)
		{
			Latitude = 0;
			Longitude = 0;
			Accuracy = null;
			Timeout = null;
			Radius = null;
			Fields = null;
			NameCase = null;
		}

		/// <summary>
		/// Географическая широта точки, в которой в данный момент находится пользователь, заданная в градусах (от -90 до 90). дробное число, обязательный параметр.
		/// </summary>
		public long Latitude { get; set; }

		/// <summary>
		/// Географическая долгота точки, в которой в данный момент находится пользователь, заданная в градусах (от -180 до 180). дробное число, обязательный параметр.
		/// </summary>
		public long Longitude { get; set; }

		/// <summary>
		/// Точность текущего местоположения пользователя в метрах. положительное число.
		/// </summary>
		public long? Accuracy { get; set; }

		/// <summary>
		/// Время в секундах через которое пользователь должен перестать находиться через поиск по местоположению. положительное число, по умолчанию 7200.
		/// </summary>
		public long? Timeout { get; set; }

		/// <summary>
		/// Тип радиуса зоны поиска (от 1 до 4) 
		/// 
		/// 1 — 300 метров; 
		/// 2 — 2400 метров; 
		/// 3 — 18 километров; 
		/// 4 — 150 километров. 
		/// положительное число, по умолчанию 1.
		/// </summary>
		public long? Radius { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей, которые необходимо вернуть. См. подробное описание. 
		/// Доступные значения: photo_id, verified, sex, bdate, city, country, home_town, has_photo, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, lists, domain, has_mobile, contacts, site, education, universities, schools, status, last_seen, followers_count, common_count, occupation, nickname, relatives, relation, personal, connections, exports, wall_comments, activities, interests, music, movies, tv, books, games, about, quotes, can_post, can_see_all_posts, can_see_audio, can_write_private_message, can_send_friend_request, is_favorite, is_hidden_from_feed, timezone, screen_name, maiden_name, crop_photo, is_friend, friend_status, career, military, blacklisted, blacklisted_by_me. список строк, разделенных через запятую.
		/// </summary>
		public ProfileFields Fields { get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения: именительный – nom, родительный – gen, дательный – dat, винительный – acc, творительный – ins, предложный – abl. По умолчанию nom. строка.
		/// </summary>
		public NameCase NameCase { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(UsersGetNearbyParams p)
		{
			var parameters = new VkParameters
			{
				{ "latitude", p.Latitude },
				{ "longitude", p.Longitude },
				{ "accuracy", p.Accuracy },
				{ "timeout", p.Timeout },
				{ "radius", p.Radius },
				{ "fields", p.Fields },
				{ "name_case", p.NameCase }
			};

			return parameters;
		}
	}

}