using System;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.RequestParams.Photo
{
	/// <summary>
	/// Список параметров для метода photos.search
	/// </summary>
	public class PhotoSearchParams
	{
		/// <summary>
		/// Строка поискового запроса, например, "Nature". строка.
		/// </summary>
		public string Query
		{ get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90). дробное число.
		/// </summary>
		public double? Latitude
		{ get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180). дробное число.
		/// </summary>
		public double? Longitude
		{ get; set; }

		/// <summary>
		/// время в формате unixtime, не раньше которого должны были быть загружены найденные фотографии. положительное число.
		/// </summary>
		public DateTime? StartTime
		{ get; set; }

		/// <summary>
		/// время в формате unixtime, не позже которого должны были быть загружены найденные фотографии. положительное число.
		/// </summary>
		public DateTime? EndTime
		{ get; set; }

		/// <summary>
		/// 1 – сортировать по количеству отметок «Мне нравится», 0 – сортировать по дате добавления фотографии. положительное число.
		/// </summary>
		public bool? Sort
		{ get; set; }

		/// <summary>
		/// смещение относительно первой найденной фотографии для выборки определенного подмножества. положительное число.
		/// </summary>
		public ulong? Offset
		{ get; set; }

		/// <summary>
		/// количество возвращаемых фотографий. положительное число, по умолчанию 100, максимальное значение 1000.
		/// </summary>
		public ulong? Count
		{ get; set; }

		/// <summary>
		/// радиус поиска в метрах. (работает очень приближенно, поэтому реальное расстояние до цели может отличаться от заданного). Может принимать значения: 10, 100, 800, 6000, 50000 положительное число, по умолчанию 5000.
		/// </summary>
		public PhotoSearchRadius Radius
		{ get; set; }

	}
}
