using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Subscription
/// </summary>
[Serializable]
public class Subscription
{
	/// <summary>
	/// Идентификатор сообщества, доном которого является пользователь.
	/// </summary>
	[JsonProperty("owner_id")]
	public long OwnerId { get; set; }

	/// <summary>
	/// Дата следующего платежа в формате "unixtime".
	/// </summary>
	[JsonProperty("next_payment_date")]
	public long NextPaymentDate { get; set; }

	/// <summary>
	/// Стоимость подписки.
	/// </summary>
	[JsonProperty("amount")]
	public long Amount { get; set; }

	/// <summary>
	/// Статус подписки.
	/// </summary>
	[JsonProperty("status")]
	public string Status { get; set; }
}