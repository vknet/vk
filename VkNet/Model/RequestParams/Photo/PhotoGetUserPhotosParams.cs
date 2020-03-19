using System;
using VkNet.Enums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.getUserPhotos
	/// </summary>
	[Serializable]
	public class PhotoGetUserPhotosParams
	{
		/// <summary>
		/// Идентификатор пользователя, список фотографий для которого нужно получить.
		/// </summary>
		public ulong? UserId { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества фотографий.
		/// </summary>
		public ulong? Offset { get; set; }

		/// <summary>
		/// Количество фотографий, которое необходимо получить.
		/// </summary>
		public ulong? Count { get; set; }

		/// <summary>
		/// <c> true </c> — будут возвращены дополнительные поля likes, comments, tags,
		/// can_comment. Поля comments и tags
		/// содержат только количество объектов. По умолчанию данные поля не возвращается.
		/// </summary>
		public bool? Extended { get; set; }

		/// <summary>
		/// Сортировка результатов (0 — по дате добавления отметки в порядке убывания, 1 —
		/// по дате добавления отметки в порядке
		/// возрастания).
		/// </summary>
		public SortOrderBy Sort { get; set; }
	}
}