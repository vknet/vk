using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model;

/// <summary>
/// Перевод денег
/// </summary>
[Serializable]
public class MoneyTransfer : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "money_transfer";

	/// <summary>
	/// Идентификатор отправителя
	/// </summary>
	[JsonProperty("from_id")]
	public long FromId { get; set; }

	/// <summary>
	/// Идентификатор получателя
	/// </summary>
	[JsonProperty("to_id")]
	public long ToId { get; set; }

	/// <summary>
	/// Состояние
	/// </summary>
	[JsonProperty("status")]
	public long Status { get; set; }

	/// <summary>
	/// Дата
	/// </summary>
	[JsonProperty("date")]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime Date { get; set; }

	/// <summary>
	/// Количество
	/// </summary>
	[JsonProperty("amount")]
	public AmountObject Amount { get; set; }

	/// <summary>
	/// Комментарий
	/// </summary>
	[JsonProperty("comment")]
	public string Comment { get; set; }
}