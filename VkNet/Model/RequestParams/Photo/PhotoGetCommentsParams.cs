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
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография. целое число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long owner_id
		{ get; set; }

		/// <summary>
		/// Идентификатор фотографии. целое число, обязательный параметр.
		/// </summary>
		public ulong photo_id
		{ get; set; }

		/// <summary>
		/// <c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается. флаг, может принимать значения <c>true</c> или <c>false</c>.
		/// </summary>
		public bool? need_likes
		{ get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности см. ниже). положительное число, доступен начиная с версии 5.33.
		/// </summary>
		public ulong? start_comment_id
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества комментариев. По умолчанию — 0. целое число.
		/// </summary>
		public ulong? offset
		{ get; set; }

		/// <summary>
		/// Количество комментариев, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 100.
		/// </summary>
		public ulong? count
		{ get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым) строка.
		/// </summary>
		public CommentsSort sort
		{ get; set; }

		/// <summary>
		/// Ключ доступа к фотографии. строка.
		/// </summary>
		public string access_key
		{ get; set; }

		/// <summary>
		/// <c>true</c> — комментарии в ответе будут возвращены в виде пронумерованных объектов, дополнительно будут возвращены списки объектов profiles, groups. флаг, может принимать значения <c>true</c> или <c>false</c>, доступен начиная с версии 5.<c>false</c>.
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