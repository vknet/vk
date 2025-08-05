using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат получения адреса
/// </summary>
[Serializable]
public class AddressResult
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	[JsonProperty("id")]
	public ulong Id { get; set; }

	/// <summary>
	/// Дополнительный адрес
	/// </summary>
	[JsonProperty("additional_address")]
	public string AdditionalAddress { get; set; }

	/// <summary>
	/// Основной адрес
	/// </summary>
	[JsonProperty("address")]
	public string Address { get; set; }

	/// <summary>
	/// Идентификатор города
	/// </summary>
	[JsonProperty("city_id")]
	public long? CityId { get; set; }

	/// <summary>
	/// Идентификатор страны
	/// </summary>
	[JsonProperty("country_id")]
	public long? CountryId { get; set; }

	/// <summary>
	/// Широта
	/// </summary>
	[JsonProperty("latitude")]
	public double? Latitude { get; set; }

	/// <summary>
	/// Долгота
	/// </summary>
	[JsonProperty("longitude")]
	public double? Longitude { get; set; }

	/// <summary>
	/// Идентификатор станции метро
	/// </summary>
	[JsonProperty("metro_station_id")]
	public long? MetroStationId { get; set; }

	/// <summary>
	/// Телефон
	/// </summary>
	[JsonProperty("phone")]
	public string Phone { get; set; }

	/// <summary>
	/// Сдвиг по времени
	/// </summary>
	[JsonProperty("time_offset")]
	public long? TimeOffset { get; set; }

	/// <summary>
	/// Расписание
	/// </summary>
	[JsonProperty("timetable")]
	public Timetable Timetable { get; set; }

	/// <summary>
	/// Заголовок
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Информация о статусе работы
	/// </summary>
	[JsonProperty("work_info_status")]
	public string WorkInfoStatus { get; set; }
}