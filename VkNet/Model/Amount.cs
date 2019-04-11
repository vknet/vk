using Newtonsoft.Json;
using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Сумма денежнего перевода
	/// </summary>
	[Serializable]
	public class TransferAmount
	{
		/// <summary>
		/// Сумма перевода.
		/// </summary>
		[JsonProperty("amount")]
		public long? Amount { get; set; }

		/// <summary>
		/// Сумма и валюта перевода.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Валюта перевода
		/// </summary>
		[JsonProperty("currency")]
		public Currency Currency { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static TransferAmount FromJson(VkResponse response)
		{
			return new TransferAmount()
			{
				Text = response["text"],
				Amount = response["amount"],
				Currency = response["currency"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Model.TransferAmount" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Model.TransferAmount" /></returns>
		public static implicit operator TransferAmount(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
		#endregion
	}
}
