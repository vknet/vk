using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
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

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static MoneyRequest FromJson(VkResponse response)
		{
			return new MoneyRequest
			{
				Id = response["id"],
				FromId = response["from_id"],
				ToId = response["to_id"],
				Amount = response["amount"],
				Processed = response["processed"],
				InitUrl = response["init_url"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="MoneyTransfer" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="MoneyTransfer" /></returns>
		public static implicit operator MoneyRequest(VkResponse response)
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
}