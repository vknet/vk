using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model;

/// <summary>
/// Массив объектов CampaignSpecification
/// </summary>
[Serializable]
public class CampaignSpecification
{
	/// <summary>
	/// Идентификатор кампании.
	/// </summary>
	[JsonProperty("client_id")]
	public long ClientId { get; set; }

	/// <summary>
	/// Формат объявления
	/// </summary>
	[JsonProperty("type")]
	public CampaignType Type { get; set; }

	/// <summary>
	/// Название рекламной кампании.
	/// </summary>
	[JsonProperty("name")]
	public string Name { get; set; }

	/// <summary>
	/// Тип оплаты
	/// </summary>
	[JsonProperty("status")]
	public AdStatus Status { get; set; }

	/// <summary>
	/// Общий лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("all_limit")]
	public long AllLimit { get; set; }

	/// <summary>
	/// Дневной лимит объявления в рублях. 0 — лимит не задан.
	/// </summary>
	[JsonProperty("day_limit")]
	public long DayLimit { get; set; }

	/// <summary>
	/// Время создания объявления
	/// </summary>
	[JsonProperty(propertyName: "start_time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? StartTime { get; set; }

	/// <summary>
	/// Время последнего изменения объявления
	/// </summary>
	[JsonProperty(propertyName: "stop_time")]
	[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
	public DateTime? StopTime { get; set; }
}