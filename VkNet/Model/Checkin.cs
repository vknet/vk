using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Отметка пользователя
	/// </summary>
	[Serializable]
	public class Checkin
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// Идентификатор отметившегося пользователя
		/// </summary>
		[JsonProperty("user_id")]
		public long UserId { get; set; }

		/// <summary>
		/// Дата добавления отметки в формате unixtime;
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Географическая широта, заданная в градусах (от -90 до 90);
		/// </summary>
		[JsonProperty("latitude")]
		public decimal Latitude { get; set; }

		/// <summary>
		/// Географическая долгота, заданная в градусах (от -180 до 180);
		/// </summary>
		[JsonProperty("longitude")]
		public decimal Longitude { get; set; }

		/// <summary>
		/// Идентификатор места
		/// </summary>
		[JsonProperty("place_id")]
		public long PlaceId { get; set; }

		/// <summary>
		/// Текст сопроводительного сообщения;
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Расстояние от места до заданной точки.
		/// </summary>
		[JsonProperty("distance")]
		public long Distance { get; set; }

		/// <summary>
		/// Наименование места
		/// </summary>
		[JsonProperty("place_title")]
		public string PlaceTitle { get; set; }

		/// <summary>
		/// Идентификатор страны
		/// </summary>
		[JsonProperty("place_country")]
		public long PlaceCountry { get; set; }

		/// <summary>
		/// Идентификатор города
		/// </summary>
		[JsonProperty("place_city")]
		public long PlaceCity { get; set; }

		/// <summary>
		/// Адрес
		/// </summary>
		[JsonProperty("place_address")]
		public string PlaceAddress { get; set; }

		/// <summary>
		/// Тип места;
		/// </summary>
		[JsonProperty("place_type")]
		public long PlaceType { get; set; }

		/// <summary>
		/// URL адрес к иконке
		/// </summary>
		[JsonProperty("icon")]
		public Uri Icon { get; set; }
	}
}