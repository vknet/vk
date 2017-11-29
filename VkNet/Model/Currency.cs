using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Валюта.
	/// </summary>
	[Serializable]
	public class Currency
	{
		/// <summary>
		/// Идентификатор валюты
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Буквенное обозначение валюты
		/// </summary>
		public string Сurrency { get; set; }

		/// <summary>
		/// Буквенное обозначение валюты
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static Currency FromJson(VkResponse response)
		{
			var currency = new Currency
			{
				Id = response["id"],
				Сurrency = response["currency"],
				Name = response["name"]
			};

			return currency;
		}
	}
}