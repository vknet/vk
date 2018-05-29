using System;
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
		public long? Amount { get; set; }

		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency { get; set; }

		/// <summary>
		/// Строка с локализованной ценой и валютой.
		/// </summary>
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
					Amount = response[key: "amount"]
					, Currency = response[key: "currency"]
					, Text = response[key: "text"]
			};

			return price;
		}
	}
}