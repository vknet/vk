using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.search
	/// </summary>
	[Serializable]
	public class PhotoSearchParams
	{
		/// <summary>
		/// Строка поискового запроса, например, "Nature".
		/// </summary>
		public string Query { get; set; }

		/// <summary>
		/// Географическая широта отметки, заданная в градусах (от -90 до 90).
		/// </summary>
		public double? Latitude { get; set; }

		/// <summary>
		/// Географическая долгота отметки, заданная в градусах (от -180 до 180).
		/// </summary>
		public double? Longitude { get; set; }

		/// <summary>
		/// Время в формате unixtime, не раньше которого должны были быть загружены
		/// найденные фотографии.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? StartTime { get; set; }

		/// <summary>
		/// Время в формате unixtime, не позже которого должны были быть загружены
		/// найденные фотографии.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? EndTime { get; set; }

		/// <summary>
		/// <c> true </c> – сортировать по количеству отметок «Мне нравится»,
		/// <c> false </c> – сортировать по дате добавления
		/// фотографии.
		/// </summary>
		public bool? Sort { get; set; }

		/// <summary>
		/// Смещение относительно первой найденной фотографии для выборки определенного
		/// подмножества.
		/// </summary>
		public ulong? Offset { get; set; }

		/// <summary>
		/// Количество возвращаемых фотографий. Положительное число, по умолчанию 100,
		/// максимальное значение 1000.
		/// </summary>
		public ulong? Count { get; set; }

		/// <summary>
		/// Радиус поиска в метрах. (Работает очень приближенно, поэтому реальное
		/// расстояние до цели может отличаться от
		/// заданного). Может принимать значения: 10, 100, 800, 6000, 50000 положительное
		/// число, по умолчанию 5000.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PhotoSearchRadius Radius { get; set; }
	}
}