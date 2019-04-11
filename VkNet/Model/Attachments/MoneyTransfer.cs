using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Денежный перевод.
	/// </summary>
	[Serializable]
	public class MoneyTransfer : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => "money_transfer";

		/// <summary>
		/// Сумма денежнего перевода.
		/// </summary>
		[JsonProperty("amount")]
		public TransferAmount Amount { get; set; }

		/// <summary>
		/// Идентификатор отправителя перевода.
		/// </summary>
		[JsonProperty("from_id")]
		public long? FromId { get; set; }

		/// <summary>
		/// Идентификатор получателя перевода.
		/// </summary>
		[JsonProperty("to_id")]
		public long? ToId { get; set; }

		[JsonProperty("status")]
		public int? Status { get; set; }

		/// <summary>
		/// Дата перевода.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Комментарий к переводу.
		/// </summary>
		[JsonProperty("comment")]
		public string Comment { get; set; }

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MoneyTransfer FromJson(VkResponse response)
		{
			return new MoneyTransfer()
			{
				Id = response["id"],
				FromId = response["from_id"],
				Date = response["date"],
				Amount = response["amount"],
				Status = response["status"]
			};
		}

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
	#endregion
}

