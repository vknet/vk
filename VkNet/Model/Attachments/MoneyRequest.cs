using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Выставление счета
/// </summary>
[Serializable]
public class MoneyRequest : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "money_request";

	/// <summary>
	/// Идентификатор инициатора
	/// </summary>
	[JsonProperty("from_id")]
	public long FromId { get; set; }

	/// <summary>
	/// Идентификатор получателя
	/// </summary>
	[JsonProperty("to_id")]
	public long ToId { get; set; }

	/// <summary>
	/// Статус обработанности
	/// </summary>
	[JsonProperty("processed")]
	public bool Processed { get; set; }

	/// <summary>
	/// Количество
	/// </summary>
	[JsonProperty("amount")]
	public AmountObject Amount { get; set; }

	/// <summary>
	/// Ссылка на выставленный счет
	/// </summary>
	[JsonProperty("init_url")]
	public Uri InitUrl { get; set; }
}