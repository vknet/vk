﻿using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.getOnline
	/// </summary>
	public struct FriendsGetOnlineParams
	{
		/// <summary>
		/// Параметры метода friends.getOnline
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public FriendsGetOnlineParams(bool gag = true)
		{
			UserId = null;
			ListId = null;
			OnlineMobile = null;
			Order = null;
			Count = null;
			Offset = null;
		}


		/// <summary>
		/// Идентификатор пользователя, для которого необходимо получить список друзей онлайн. Если параметр не задан, то считается, что он равен идентификатору текущего пользователя. положительное число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор списка друзей. Если параметр не задан, возвращается информация обо всех друзьях, находящихся на сайте. положительное число.
		/// </summary>
		public long? ListId { get; set; }

		/// <summary>
		/// 1 — будет возвращено дополнительное поле online_mobile. 
		/// По умолчанию — 0. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? OnlineMobile { get; set; }

		/// <summary>
		/// Порядок, в котором нужно вернуть список друзей, находящихся на сайте. Допустимые значения: random - возвращает друзей в случайном порядке, hints - сортировать по рейтингу, аналогично тому, как друзья сортируются в разделе Мои друзья (данный параметр доступен только для Desktop-приложений). строка.
		/// </summary>
		public FriendsOrder Order { get; set; }

		/// <summary>
		/// Количество друзей онлайн, которое нужно вернуть. (по умолчанию – все друзья онлайн) положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества друзей онлайн. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(FriendsGetOnlineParams p)
		{
			var parameters = new VkParameters
			{
				{ "user_id", p.UserId },
				{ "list_id", p.ListId },
				{ "online_mobile", p.OnlineMobile },
				{ "order", p.Order },
				{ "count", p.Count },
				{ "offset", p.Offset }
			};

			return parameters;
		}
	}
}