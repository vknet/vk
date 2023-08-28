using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Параметры проверки ссылки
/// </summary>
[Serializable]
public class CheckLinkParams
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty(propertyName: "account_id")]
	public long AccountId { get; set; }

	/// <summary>
	/// Тип ссылки рекламы
	/// </summary>
	[JsonProperty(propertyName: "link_type")]
	public AdsLinkType? LinkType { get; set; }

	/// <summary>
	/// Ссылка
	/// </summary>
	[JsonProperty(propertyName: "link_url")]
	public Uri LinkUrl { get; set; }

	/// <summary>
	/// Идентификатор кампании
	/// </summary>
	[JsonProperty(propertyName: "campaign_id")]
	public long? CampaignId { get; set; }
}