using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Цена.
	/// </summary>
	[Serializable]
	public class Price
	{
		/// <summary>
		/// Целочисленное значение цены, умноженное на 100.
		/// </summary>
		[JsonProperty("amount")]
		public long? Amount { get; set; }

		/// <summary>
		/// Валюта.
		/// </summary>
		[JsonProperty("currency")]
		public Currency Currency { get; set; }

		/// <summary>
		/// Старая цена товара в сотых долях единицы валюты.
		/// </summary>
		[JsonProperty("old_amount")]
		public string OldAmount { get; set; }

		/// <summary>
		/// Текстовое представлением старой цены.
		/// </summary>
		[JsonProperty("old_amount_text ")]
		public string OldAmountText { get; set; }

		/// <summary>
		/// Строка с локализованной ценой и валютой.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Price FromJson(VkResponse response)
		{
			var price = new Price
			{
				Amount = response["amount"],
				Currency = response["currency"],
				OldAmount = response["old_amount"],
				Text = response["text"]
			};

			return price;
		}
	}
}