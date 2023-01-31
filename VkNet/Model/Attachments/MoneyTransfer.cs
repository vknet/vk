using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments;

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

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static MoneyTransfer FromJson(VkResponse response) => new()
	{
		Id = response["id"],
		FromId = response["from_id"],
		Date = response["date"],
		Amount = JsonConvert.DeserializeObject<AmountObject>(response["amount"].ToString()),
		Status = response["status"]
	};

	/// <summary>
	/// Преобразование класса <see cref="MoneyTransfer" /> в <see cref="VkParameters" />
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns>Результат преобразования в <see cref="MoneyTransfer" /></returns>
	public static implicit operator MoneyTransfer(VkResponse response)
	{
		if (response == null)
		{
			return null;
		}

		return response.HasToken()
			? FromJson(response)
			: null;
	}
}