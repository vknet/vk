using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.get
	/// </summary>
	[Serializable]
	public class FriendsGetParams
	{
		/// <summary>
		/// Идентификатор пользователя, для которого необходимо получить список друзей.
		/// Если параметр не задан, то считается, что он равен идентификатору текущего
		/// пользователя
		/// (справедливо для вызова с передачей access_token).
		/// целое число.
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Порядок, в котором нужно вернуть список друзей. Допустимые значения:
		/// hints - сортировать по рейтингу, аналогично тому, как друзья сортируются в
		/// разделе Мои друзья (данный параметр
		/// доступен только для Desktop-приложений).
		/// random - возвращает друзей в случайном порядке.
		/// mobile - возвращает выше тех друзей, у которых установлены мобильные
		/// приложения.
		/// name - сортировать по имени. Данный тип сортировки работает медленно, так как
		/// сервер будет получать всех друзей а
		/// не только указанное количество count. (работает только при переданном параметре
		/// fields)
		/// строка.
		/// </summary>
		[JsonProperty("order")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public FriendsOrder Order { get; set; }

		/// <summary>
		/// Идентификатор списка друзей, полученный методом friends.getLists, друзей из
		/// которого необходимо получить. Данный
		/// параметр учитывается, только когда параметр user_id равен идентификатору
		/// текущего пользователя.
		/// Данный параметр доступен только для Desktop-приложений. положительное число.
		/// </summary>
		[JsonProperty("list_id")]
		public long? ListId { get; set; }

		/// <summary>
		/// Количество друзей, которое нужно вернуть. (по умолчанию – все друзья)
		/// положительное число.
		/// </summary>
		[JsonProperty("count")]
		public long? Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества друзей.
		/// положительное число.
		/// </summary>
		[JsonProperty("offset")]
		public long? Offset { get; set; }

		/// <summary>
		/// Список дополнительных полей, которые необходимо вернуть.
		/// Доступные значения: nickname, domain, sex, bdate, city, country, timezone,
		/// photo_50, photo_100, photo_200_orig,
		/// has_mobile, contacts, education, online, relation, last_seen, status,
		/// can_write_private_message, can_see_all_posts,
		/// can_post, universities список строк, разделенных через запятую.
		/// </summary>
		[JsonProperty("fields")]
		public ProfileFields Fields { get; set; }

		/// <summary>
		/// Падеж для склонения имени и фамилии пользователя. Возможные значения:
		/// именительный – nom, родительный – gen,
		/// дательный – dat, винительный – acc, творительный – ins, предложный – abl. По
		/// умолчанию nom. строка.
		/// </summary>
		[JsonProperty("name_case")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NameCase NameCase { get; set; }

		/// <summary>
		/// Ссылка?
		/// </summary>
		[JsonProperty("ref")]
		public string Reference { get; set; }
	}
}