using VkNet.Enums;

namespace VkNet.Model.RequestParams.Wall
{
	/// <summary>
	/// Список параметров для метода photos.createAlbum
	/// </summary>
	public class WallGetParams
	{
		/// <summary>
		/// идентификатор пользователя или сообщества, со стены которого необходимо получить записи (по умолчанию — текущий пользователь). целое число.
		/// </summary>
		public long? owner_id
		{ get; set; }

		/// <summary>
		/// короткий адрес пользователя или сообщества. строка.
		/// </summary>
		public string domain
		{ get; set; }

		/// <summary>
		/// смещение, необходимое для выборки определенного подмножества записей. положительное число.
		/// </summary>
		public ulong? offset
		{ get; set; }

		/// <summary>
		/// количество записей, которое необходимо получить (но не более 100). положительное число.
		/// </summary>
		public ulong? count
		{ get; set; }

		/// <summary>
		/// определяет, какие типы записей на стене необходимо получить. Возможны следующие значения параметра: Если параметр не задан, то считается, что он равен all. строка.
		/// </summary>
		public WallFilter filter
		{ get; set; }

		/// <summary>
		/// 1 — будут возвращены три массива wall, profiles и groups. По умолчанию дополнительные поля не возвращаются. флаг, может принимать значения 1 или 0.
		/// </summary>
		public bool? extended
		{ get; set; }

		/// <summary>
		/// список дополнительных полей для профилей и групп, которые необходимо вернуть. См. описание полей объекта user и описание полей объекта group. Обратите внимание, этот параметр учитывается только при extended=1. список строк, разделенных через запятую.
		/// </summary>
		public object fields
		{ get; set; }
	}
}