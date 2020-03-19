using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.search
	/// </summary>
	[Serializable]
	public class FriendsSearchParams
	{
		/// <summary>
		/// Идентификатор пользователя, по списку друзей которого необходимо произвести
		/// поиск. положительное число, по
		/// умолчанию идентификатор текущего пользователя, обязательный параметр.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Строка запроса. строка.
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: nickname, screen_name, sex, bdate, city, country, timezone,
		/// photo_50, photo_100,
		/// photo_200_orig, has_mobile, contacts, education, online, relation, last_seen,
		/// status, can_write_private_message,
		/// can_see_all_posts, can_post, universities, domain список строк, разделенных
		/// через запятую.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public ProfileFields Fields { get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom, родительный – gen,
		/// дательный – dat, винительный – acc, творительный – ins, предложный – abl. По
		/// умолчанию nom. строка, по умолчанию
		/// Nom.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NameCase NameCase { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества друзей.
		/// положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество друзей, которое нужно вернуть. положительное число, по умолчанию 20,
		/// максимальное значение 1000.
		/// </summary>
		public long? Count { get; set; }
	}
}