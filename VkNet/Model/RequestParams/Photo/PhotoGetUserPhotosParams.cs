using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// 
	/// </summary>
	public class PhotoGetUserPhotosParams
	{
		/// <summary>
		/// идентификатор пользователя, список фотографий для которого нужно получить. положительное число, по умолчанию идентификатор текущего пользователя.
		/// </summary>
		public Type user_id
		{ get; set; }

		/// <summary>
		/// смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — 0. положительное число.
		/// </summary>
		public Type offset
		{ get; set; }

		/// <summary>
		/// количество фотографий, которое необходимо получить. положительное число, по умолчанию 20, максимальное значение 1000.
		/// </summary>
		public Type count
		{ get; set; }

		/// <summary>
		/// 1 — будут возвращены дополнительные поля likes, comments, tags, can_comment. Поля comments и tags содержат только количество объектов. По умолчанию данные поля не возвращается. флаг, может принимать значения 1 или 0.
		/// </summary>
		public Type extended
		{ get; set; }

		/// <summary>
		/// сортировка результатов (0 — по дате добавления отметки в порядке убывания, 1 — по дате добавления отметки в порядке возрастания). строка.
		/// </summary>
		public Type sort
		{ get; set; }
	}
}
