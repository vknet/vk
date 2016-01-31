﻿using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода friends.getRequests
	/// </summary>
	public struct FriendsGetRequestsParams
	{
		/// <summary>
		/// Параметры метода friends.getRequests
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public FriendsGetRequestsParams(bool gag = true)
		{
			Offset = null;
			Count = null;
			Extended = null;
			NeedMutual = null;
			Out = null;
			Sort = null;
			Suggested = null;
		}


		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества заявок на добавление в друзья. положительное число.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Максимальное количество заявок на добавление в друзья, которые необходимо получить (не более'''1000). 
		/// По умолчанию —  100''. положительное число.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Определяет, требуется ли возвращать в ответе сообщения от пользователей, подавших заявку на добавление в друзья. И отправителя рекомендации при suggested=1. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Определяет, требуется ли возвращать в ответе список общих друзей, если они есть. Обратите внимание, что при использовании need_mutual будет возвращено не более 20 заявок. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? NeedMutual { get; set; }

		/// <summary>
		/// 0 — возвращать полученные заявки в друзья (по умолчанию), 1 — возвращать отправленные пользователем заявки. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Out { get; set; }

		/// <summary>
		/// 0 — сортировать по дате добавления, 1 — сортировать по количеству общих друзей. (Если out = 1, данный параметр не учитывается). положительное число.
		/// </summary>
		public bool? Sort { get; set; }

		/// <summary>
		/// 1 — возвращать рекомендованных другими пользователями друзей, 0 — возвращать заявки в друзья (по умолчанию). флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? Suggested { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(FriendsGetRequestsParams p)
		{
			var parameters = new VkParameters
			{
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "extended", p.Extended },
				{ "need_mutual", p.NeedMutual },
				{ "out", p.Out },
				{ "sort", p.Sort },
				{ "suggested", p.Suggested }
			};

			return parameters;
		}
	}
}