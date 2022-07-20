using System;
using Newtonsoft.Json;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.getComments
	/// </summary>
	[Serializable]
	public class PhotoGetCommentsParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong PhotoId { get; set; }

		/// <summary>
		/// <c> true </c> — будет возвращено дополнительное поле likes. По умолчанию поле
		/// likes не возвращается.
		/// </summary>
		public bool? NeedLikes { get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности
		/// см. ниже).
		/// </summary>
		public ulong? StartCommentId { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества комментариев. По
		/// умолчанию — 0.
		/// </summary>
		public ulong? Offset { get; set; }

		/// <summary>
		/// Количество комментариев, которое необходимо получить.
		/// </summary>
		public ulong? Count { get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к
		/// старым) строка.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public CommentsSort Sort { get; set; }

		/// <summary>
		/// Ключ доступа к фотографии.
		/// </summary>
		public string AccessKey { get; set; }

		/// <summary>
		/// <c> true </c> — комментарии в ответе будут возвращены в виде пронумерованных
		/// объектов, дополнительно будут возвращены
		/// списки объектов profiles, groups.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Список строк, разделенных через запятую.
		/// </summary>
		public UsersFields Fields { get; set; }
	}
}