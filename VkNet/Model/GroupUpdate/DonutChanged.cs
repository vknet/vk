using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление участника или заявки на вступление в сообщество
/// </summary>
[Serializable]
public class DonutChanged : IGroupUpdate
{
	/// <summary>
	/// Идентификатор пользователя
	/// </summary>
	[JsonProperty("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Старая цена в рублях
	/// </summary>
	[JsonProperty("amount_old")]
	public int? AmountOld { get; set; }

	/// <summary>
	/// Новая цена в рублях
	/// </summary>
	[JsonProperty("amount_new")]
	public int? AmountNew { get; set; }

	/// <summary>
	/// Сумма доплаты в рублях
	/// </summary>
	[JsonProperty("amount_diff")]
	public float? AmountDiff { get; set; }

	/// <summary>
	/// Cумма доплаты без комиссии (в рублях)
	/// </summary>
	[JsonProperty("amount_diff_without_fee")]
	public float? AmountDiffWithoutFee { get; set; }
}