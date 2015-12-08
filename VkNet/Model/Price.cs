using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Цена.
	/// </summary>
	public class Price
	{
		/// <summary>
		/// Целочисленное значение цены, умноженное на 100.
		/// </summary>
		public long? Amount;

		/// <summary>
		/// Валюта.
		/// </summary>
		public Currency Currency;

		/// <summary>
		/// Строка с локализованной ценой и валютой.
		/// </summary>
		public string Text;

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Price FromJson(VkResponse response)
		{
			var price = new Price
			{
				Amount = response["amount"],
				Currency = response["currency"],
				Text = response["text"]
			};

			return price;
		}
	}
}