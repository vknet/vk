using System;
using Newtonsoft.Json;
using VkNet.Enums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса places.search
	/// </summary>
	[Serializable]
	public class PlacesSearchParams
	{
		/// <summary>
		/// Строка поискового запроса.
		/// </summary>
		[JsonProperty(propertyName: "q")]
		public string Query { get; set; }

		/// <summary>
		/// Географическая широта точки, в радиусе которой необходимо производить поиск,
		/// заданная в градусах (от -90 до 90).
		/// </summary>
		[JsonProperty(propertyName: "latitude")]
		public decimal Latitude { get; set; }

		/// <summary>
		/// Географическая долгота точки, в радиусе которой необходимо производить поиск,
		/// заданная в градусах (от -180 до 180).
		/// </summary>
		[JsonProperty(propertyName: "longitude")]
		public decimal Longitude { get; set; }

		/// <summary>
		/// Идентификатор города.
		/// </summary>
		[JsonProperty(propertyName: "city")]
		public ulong City { get; set; }

		/// <summary>
		/// Тип радиуса зоны поиска (от 1 до 4)
		/// </summary>
		[JsonProperty(propertyName: "radius")]
		public Radius Radius { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества результатов
		/// поиска.
		/// </summary>
		[JsonProperty(propertyName: "offset")]
		public ulong Offset { get; set; }

		/// <summary>
		/// Количество мест, информацию о которых необходимо вернуть.
		/// </summary>
		[JsonProperty(propertyName: "count")]
		public ulong Count { get; set; }
	}
}