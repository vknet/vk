using System;
using Newtonsoft.Json;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Параметры метода groups.toggleMarket
/// </summary>
[Serializable]
public class GroupToggleMarketParams
{
	/// <summary>
	/// идентификатор сообщества.
	/// положительное число, обязательный параметр
	/// </summary>
	[JsonProperty("group_id")]
	public ulong GroupId { get; set; }

	/// <summary>
	/// Значение переключателя
	/// </summary>
	[JsonProperty("state")]
	public ToggleMarketState? State { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("ref")]
	public string Ref { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("utm_source")]
	public string UtmSource { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("utm_medium")]
	public string UtmMedium { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("utm_campaign")]
	public string UtmCampaign { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("utm_content")]
	public string UtmContent { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("utm_term")]
	public string UtmTerm { get; set; }

	/// <summary>
	/// Эксперементально
	/// </summary>
	[JsonProperty("promocode")]
	public string Promocode { get; set; }
}