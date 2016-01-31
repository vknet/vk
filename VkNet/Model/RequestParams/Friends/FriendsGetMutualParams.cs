﻿using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.getMutual
	/// </summary>
	public struct FriendsGetMutualParams
	{
		/// <summary>
		/// Параметры метода friends.getMutual
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public FriendsGetMutualParams(bool gag = true)
		{
			SourceUid = null;
			TargetUid = null;
			TargetUids = null;
			Order = null;
			Count = null;
			Offset = null;
		}

		/// <summary>
		/// Идентификатор пользователя, чьи друзья пересекаются с друзьями пользователя с идентификатором target_uid. Если параметр не задан, то считается, что source_uid равен идентификатору текущего пользователя. положительное число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? SourceUid { get; set; }

		/// <summary>
		/// Идентификатор пользователя, с которым необходимо искать общих друзей. положительное число.
		/// </summary>
		public long? TargetUid { get; set; }

		/// <summary>
		/// Список идентификаторов пользователей, с которыми необходимо искать общих друзей. список положительных чисел, разделенных запятыми.
		/// </summary>
		public IEnumerable<string> TargetUids { get; set; }

		/// <summary>
		/// Порядок, в котором нужно вернуть список общих друзей. Допустимые значения: random - возвращает друзей в случайном порядке. строка.
		/// </summary>
		public FriendsOrder Order { get; set; }

		/// <summary>
		/// Количество общих друзей, которое нужно вернуть. (по умолчанию – все общие друзья) положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества общих друзей. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(FriendsGetMutualParams p)
		{
			var parameters = new VkParameters
			{
				{ "source_uid", p.SourceUid },
				{ "target_uid", p.TargetUid },
				{ "target_uids", p.TargetUids },
				{ "order", p.Order },
				{ "count", p.Count },
				{ "offset", p.Offset }
			};

			return parameters;
		}
	}
}