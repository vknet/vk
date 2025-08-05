using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Результат таргетированной рекламы
/// </summary>
[Serializable]
public class AdsTargetingResult
{
	/// <summary>
	/// Идентификатор кампании.
	/// </summary>
	[JsonProperty("id")]
	public string Id { get; set; }

	/// <summary>
	/// Формат объявления
	/// </summary>
	[JsonProperty("campaign_id")]
	public string CampaignId { get; set; }

	/// <summary>
	/// Автоматическое управление ценой
	/// </summary>
	[JsonProperty("country")]
	public string Country { get; set; }

	/// <summary>
	/// Тип оплаты
	/// </summary>
	[JsonProperty("cities")]
	public string Cities { get; set; }

	/// <summary>
	/// Тип оплаты
	/// </summary>
	[JsonProperty("cities_not")]
	public string CitiesNot { get; set; }

	/// <summary>
	/// Тип оплаты
	/// </summary>
	[JsonProperty("count")]
	public string Count { get; set; }

	/// <summary>
	/// Тип оплаты
	/// </summary>
	[JsonProperty("statuses")]
	public string Statuses { get; set; }
}