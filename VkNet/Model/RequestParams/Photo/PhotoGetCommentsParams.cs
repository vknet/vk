using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.getComments
	/// </summary>
	public class PhotoGetCommentsParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
		/// </summary>
		public long? owner_id
		{ get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong photo_id
		{ get; set; }

		/// <summary>
		/// <c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается.
		/// </summary>
		public bool? need_likes
		{ get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности см. ниже).
		/// </summary>
		public ulong? start_comment_id
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества комментариев. По умолчанию — 0.
		/// </summary>
		public ulong? offset
		{ get; set; }

		/// <summary>
		/// Количество комментариев, которое необходимо получить.
		/// </summary>
		public ulong? count
		{ get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым) строка.
		/// </summary>
		public CommentsSort sort
		{ get; set; }

		/// <summary>
		/// Ключ доступа к фотографии.
		/// </summary>
		public string access_key
		{ get; set; }

		/// <summary>
		/// <c>true</c> — комментарии в ответе будут возвращены в виде пронумерованных объектов, дополнительно будут возвращены списки объектов profiles, groups.
		/// </summary>
		public bool? extended
		{ get; set; }

		/// <summary>
		///  Список строк, разделенных через запятую.
		/// </summary>
		public IEnumerable<string> fields
		{ get; set; }
	}
}