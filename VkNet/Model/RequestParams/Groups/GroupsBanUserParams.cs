using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода groups.banUser
	/// </summary>
	[Serializable]
	public class GroupsBanUserParams
	{
		/// <summary>
		/// Идентификатор группы. положительное число, обязательный параметр.
		/// </summary>
		public long GroupId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, которого нужно добавить в черный список.
		/// положительное число, обязательный параметр.
		/// Использовать <see cref="OwnerId"/> для более новых версий API
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Идентификатор пользователя или сообщества,  которое будет добавлено в черный список.
		/// обязательный параметр.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Дата завершения срока действия бана в формате unixtime. Максимальный возможный
		/// срок окончания бана, который можно
		/// указать, — один год с его начала. Если параметр не указан, пользователь будет
		/// заблокирован навсегда. положительное
		/// число.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Причина бана:
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
		/// 0 – текст комментария не доступен пользователю. (по умолчанию) флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? CommentVisible { get; set; }
	}
}