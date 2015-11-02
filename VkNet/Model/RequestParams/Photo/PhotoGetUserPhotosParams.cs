using VkNet.Enums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.getUserPhotos
	/// </summary>
	public class PhotoGetUserPhotosParams
	{
		/// <summary>
		/// Идентификатор пользователя, список фотографий для которого нужно получить. положительное число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public ulong UserId
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — 0. положительное число.
		/// </summary>
		public ulong? Offset
		{ get; set; }

		/// <summary>
		/// Количество фотографий, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 1000.
		/// </summary>
		public ulong? Count
		{ get; set; }

		/// <summary>
		/// <c>true</c> — будут возвращены дополнительные поля likes, comments, tags, can_comment. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается. флаг, может принимать значения <c>true</c> или <c>false</c>.
		/// </summary>
		public bool? Extended
		{ get; set; }

		/// <summary>
		/// Сортировка результатов (0 — по дате добавления отметки в порядке убывания, 1 — по дате добавления отметки в порядке возрастания). строка.
		/// </summary>
		public SortOrderBy Sort
		{ get; set; }
	}
}
