using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Добавление участника или заявки на вступление в сообщество
/// </summary>
[Serializable]
public class DonutWithdraw : IGroupUpdate
{
	private string _reason;

	/// <summary>
	/// Произошла ли ошибка
	/// </summary>
	[JsonProperty("error")]
	public bool Error { get; set; }

		/// <summary>
	/// Cумма  в рублях
	/// </summary>
	[JsonProperty("amount")]
	public float? Amount { get; set; }

	/// <summary>
	/// Cумма  без комиссии (в рублях)
	/// </summary>
	[JsonProperty("amount_without_fee")]
	public float? AmountWithoutFee { get; set; }

	/// <summary>
	/// Причина ошибки
	/// </summary>
	[JsonProperty("reason")]
	public string Reason
	{
		get => _reason;

		set {
			_reason = value;
			Error = !string.IsNullOrEmpty(_reason);
		}
	}
}