﻿using System.Collections.Generic;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.get
	/// </summary>
	public struct FriendsGetParams
	{
		/// <summary>
		/// Параметры метода friends.get
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public FriendsGetParams(bool gag = true)
		{
			UserId = null;
			Order = null;
			ListId = null;
			Count = null;
			Offset = null;
			Fields = null;
			NameCase = null;
		}


		/// <summary>
		/// Идентификатор пользователя, для которого необходимо получить список друзей. Если параметр не задан, то считается, что он равен идентификатору текущего пользователя (справедливо для вызова с передачей access_token). целое число.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Порядок, в котором нужно вернуть список друзей. Допустимые значения: 
		/// 
		/// hints - сортировать по рейтингу, аналогично тому, как друзья сортируются в разделе Мои друзья (данный параметр доступен только для Desktop-приложений). 
		/// random - возвращает друзей в случайном порядке. 
		/// mobile - возвращает выше тех друзей, у которых установлены мобильные приложения. 
		/// name - сортировать по имени. Данный тип сортировки работает медленно, так как сервер будет получать всех друзей а не только указанное количество count. (работает только при переданном параметре fields) 
		/// строка.
		/// </summary>
		public FriendsOrder Order { get; set; }

		/// <summary>
		/// Идентификатор списка друзей, полученный методом friends.getLists, друзей из которого необходимо получить. Данный параметр учитывается, только когда параметр user_id равен идентификатору текущего пользователя.
		/// 
		/// Данный параметр доступен только для Desktop-приложений. положительное число.
		/// </summary>
		public long? ListId { get; set; }

		/// <summary>
		/// Количество друзей, которое нужно вернуть. (по умолчанию – все друзья) положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества друзей. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть. 
		/// Доступные значения: nickname, domain, sex, bdate, city, country, timezone, photo_50, photo_100, photo_200_orig, has_mobile, contacts, education, online, relation, last_seen, status, can_write_private_message, can_see_all_posts, can_post, universities список строк, разделенных через запятую.
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
		internal static VkParameters ToVkParameters(FriendsGetParams p)
		{
			var parameters = new VkParameters
			{
				{ "user_id", p.UserId },
				{ "order", p.Order },
				{ "list_id", p.ListId },
				{ "count", p.Count },
				{ "offset", p.Offset },
				{ "fields", p.Fields },
				{ "name_case", p.NameCase }
			};

			return parameters;
		}
	}
}