using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.banUser
	/// </summary>
	public struct GroupsBanUserParams
	{
		/// <summary>
		/// Параметры метода groups.banUser
		/// </summary>
		/// <param name="gag">Заглушка для конструктора.</param>
		public GroupsBanUserParams(bool gag = true)
		{
			GroupId = 0;
			UserId = 0;
			EndDate = null;
			Reason = null;
			Comment = null;
			CommentVisible = null;
		}


		/// <summary>
		/// Идентификатор группы. положительное число, обязательный параметр.
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, которого нужно добавить в черный список. положительное число, обязательный параметр.
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// Дата завершения срока действия бана в формате unixtime. Максимальный возможный срок окончания бана, который можно указать, — один год с его начала. Если параметр не указан, пользователь будет заблокирован навсегда. положительное число.
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Причина бана: 
		/// 
		/// 0 — другое (по умолчанию); 
		/// 1 — спам; 
		/// 2 — оскорбление участников; 
		/// 3 — нецензурные выражения; 
		/// 4 — сообщения не по теме. 
		/// положительное число.
		/// </summary>
		public BanReason? Reason { get; set; }

		/// <summary>
		/// Текст комментария к бану. строка.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// 1 – текст комментария будет отображаться пользователю. 
		/// 0 – текст комментария не доступен пользователю. (по умолчанию) флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? CommentVisible { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(GroupsBanUserParams p)
		{
			var parameters = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "user_id", p.UserId },
				{ "end_date", p.EndDate },
				{ "reason", p.Reason },
				{ "comment", p.Comment },
				{ "comment_visible", p.CommentVisible }
			};

			return parameters;
		}
	}
}