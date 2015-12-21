using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Валюта.
	/// </summary>
	public class Currency
	{
		/// <summary>
		/// Идентификатор валюты;.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Буквенное обозначение валюты;.
		/// </summary>
		public string Сurrency { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Currency FromJson(VkResponse response)
		{
			var currency = new Currency
			{
				Id = response["id"],
				Сurrency = response["currency"]
			};

			return currency;
		}
	}
}