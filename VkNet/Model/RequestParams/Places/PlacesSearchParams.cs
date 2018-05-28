using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса places.search
	/// </summary>
	public class PlacesSearchParams
	{
		/// <summary>
		/// Строка поискового запроса. 
		/// </summary>
		[JsonProperty("q")]
		public string Query { get; set; }

		/// <summary>
		/// Географическая широта точки, в радиусе которой необходимо производить поиск, заданная в градусах (от -90 до 90). 
		/// </summary>
		[JsonProperty("latitude")]
		public decimal Latitude { get; set; }

		/// <summary>
		/// Географическая долгота точки, в радиусе которой необходимо производить поиск, заданная в градусах (от -180 до 180). 
		/// </summary>
		[JsonProperty("longitude")]
		public decimal Longitude { get; set; }

		/// <summary>
		/// Идентификатор города.
		/// </summary>
		[JsonProperty("city")]
		public ulong City { get; set; }

		/// <summary>
		/// Тип радиуса зоны поиска (от 1 до 4)
		/// </summary>
		[JsonProperty("radius")]
		public Radius Radius { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества результатов поиска. 
		/// </summary>
		[JsonProperty("offset")]
		public ulong Offset { get; set; }

		/// <summary>
		/// Количество мест, информацию о которых необходимо вернуть. 
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }
	}
}