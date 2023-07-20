using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление участника или заявки на вступление в сообщество
/// </summary>
[Serializable]
public class DonutNew : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Цена в рублях
	/// </summary>
	[JsonProperty("amount")]
	public decimal? Amount { get; set; }

	/// <summary>
	/// Цена без комиссии (в рублях)
	/// </summary>
	[JsonProperty("amount_without_fee")]
	public decimal? AmountWithoutFee { get; set; }
}