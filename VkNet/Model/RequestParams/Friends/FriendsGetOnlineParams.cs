using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.getOnline
	/// </summary>
	[Serializable]
	public class FriendsGetOnlineParams
	{
		/// <summary>
		/// Идентификатор пользователя, для которого необходимо получить список друзей
		/// онлайн. Если параметр не задан, то
		/// считается, что он равен идентификатору текущего пользователя. положительное
		/// число, по умолчанию идентификатор
		/// текущего пользователя.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор списка друзей. Если параметр не задан, возвращается информация
		/// обо всех друзьях, находящихся на
		/// сайте. положительное число.
		/// </summary>
		public long? ListId { get; set; }

		/// <summary>
		/// 1 — будет возвращено дополнительное поле online_mobile.
		/// По умолчанию — 0. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? OnlineMobile { get; set; }

		/// <summary>
		/// Порядок, в котором нужно вернуть список друзей, находящихся на сайте.
		/// Допустимые значения: random - возвращает
		/// друзей в случайном порядке, hints - сортировать по рейтингу, аналогично тому,
		/// как друзья сортируются в разделе Мои
		/// друзья (данный параметр доступен только для Desktop-приложений). строка.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public FriendsOrder Order { get; set; }

		/// <summary>
		/// Количество друзей онлайн, которое нужно вернуть. (по умолчанию – все друзья
		/// онлайн) положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества друзей онлайн.
		/// положительное число.
		/// </summary>
		public long? Offset { get; set; }
	}
}