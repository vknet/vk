using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Информация о месте, в котором была сделана запись.
/// См. описание <see href="http://vk.com/pages?oid=-1&amp;p=Описание_поля_geo" />
/// и http://vk.com/dev/fields_groups
/// </summary>
[Serializable]
public class Place
{
	/// <summary>
	/// Идентификатор места.
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Название места.
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	/// Географическая широта, заданная в градусах (от -90 до 90).
	/// </summary>
	[JsonProperty("latitude")]
	public double? Latitude { get; set; }

	/// <summary>
	/// Географическая долгота, заданная в градусах (от -90 до 90).
	/// </summary>
	[JsonProperty("longitude")]
	public double? Longitude { get; set; }


	/// <summary>
	/// Идентификатор страны, название которой можно получить с помощью метода
	/// DatabaseCategory.GetCountriesById
	/// </summary>
	[JsonProperty("country_id")]
	public long? CountryId { get; set; }

	/// <summary>
	/// Идентификатор города, название которого можно получить с помощью метода
	/// DatabaseCategory.GetCitiesById
	/// </summary>
	[JsonProperty("city_id")]
	public long? CityId { get; set; }

	/// <summary>
	/// Строка с указанием адреса места в городе.
	/// </summary>
	[JsonProperty("address")]
	public string Address { get; set; }

	/// <summary>
	/// Данный параметр указывается, если местоположение является прикреплённой картой.
	/// </summary>
	[JsonProperty("shop_map")]
	public bool? ShowMap { get; set; }

	/// <summary>
	/// Регистрации
	/// </summary>
	[JsonProperty("checkins")]
	public long? Checkins { get; set; }

	/// <summary>
	/// Дата создания
	/// </summary>
	[JsonProperty("created")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Created { get; set; }

	/// <summary>
	/// Дата и время последнего обновления
	/// </summary>
	[JsonProperty("updated")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? Updated { get; set; }

	/// <summary>
	/// Тип
	/// </summary>
	[JsonProperty("type")]
	public long? Type { get; set; }

	/// <summary>
	/// Иконка
	/// </summary>
	[JsonProperty("icon")]
	public Uri Icon { get; set; }

	/// <summary>
	/// Страна, в которой находится место.
	/// </summary>
	[JsonProperty("country")]
	public string Country { get; set; }

	/// <summary>
	/// Город, в котором находится место.
	/// </summary>
	[JsonProperty("city")]
	public string City { get; set; }

	/// <summary>
	/// Расстояние от исходной точки
	/// </summary>
	[JsonProperty("distance")]
	public long? Distance { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty("group_id")]
	public long? GroupId { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty("group_photo")]
	public Uri GroupPhoto { get; set; }

	[JsonProperty("place_id")]
	private long? PlaceId
	{
		get => Id;
		set => Id = value;
	}
}