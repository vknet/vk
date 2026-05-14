using System;
using System.Diagnostics;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Информация об адресе сообщества.
/// </summary>
[DebuggerDisplay(value: "[{Id}] {Title}")]
[Serializable]
public class Address
{
	/// <summary>
	/// Идентификатор адреса.
	/// </summary>
	[JsonProperty(propertyName: "id")]
	public long? Id { get; set; }

	/// <summary>
	/// Улица и дом
	/// </summary>
	[JsonProperty(propertyName: "address")]
	public string Residence { get; set; }

	/// <summary>
	/// Город адреса.
	/// </summary>
	[JsonProperty(propertyName: "city")]
	public AddressCity City { get; set; }

	/// <summary>
	/// Станция метро.
	/// </summary>
	[JsonProperty(propertyName: "metro_station")]
	public AddressMetroStation MetroStation { get; set; }

	/// <summary>
	/// Страна адреса.
	/// </summary>
	[JsonProperty(propertyName: "country")]
	public AddressCountry Country { get; set; }

	/// <summary>
	/// Название или описание адреса.
	/// </summary>
	[JsonProperty(propertyName: "title")]
	public string Title { get; set; }

	/// <summary>
	/// Статус работы (расписание) по данному адресу.
	/// </summary>
	[JsonProperty(propertyName: "work_info_status")]
	ScheduleWorkInfoStatus? WorkInfoStatus { get; set; }
}
