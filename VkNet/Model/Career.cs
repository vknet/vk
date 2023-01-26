using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Информация о карьере пользователя.
/// </summary>
[Serializable]
public class Career
{
	/// <summary>
	/// Идентификатор сообщества (если доступно, иначе company).
	/// </summary>
	[JsonProperty("group_id")]
	public long? GroupId { get; set; }

	/// <summary>
	/// Название организации (если доступно, иначе group_id).
	/// </summary>
	[JsonProperty("company")]
	public string Company { get; set; }

	/// <summary>
	/// Идентификатор страны.
	/// </summary>
	[JsonProperty("country_id")]
	public long? CountryId { get; set; }

	/// <summary>
	/// Идентификатор города (если доступно, иначе city_name).
	/// </summary>
	[JsonProperty("city_id")]
	public long? CityId { get; set; }

	/// <summary>
	/// Название города (если доступно, иначе city_id).
	/// </summary>
	[JsonProperty("city_name")]
	public string CityName { get; set; }

	/// <summary>
	/// Год начала работы.
	/// </summary>
	[JsonProperty("from")]
	public int? From { get; set; }

	/// <summary>
	/// Год окончания работы.
	/// </summary>
	[JsonProperty("until")]
	public ulong? Until { get; set; }

	/// <summary>
	/// Должность.
	/// </summary>
	[JsonProperty("position")]
	public string Position { get; set; }
}