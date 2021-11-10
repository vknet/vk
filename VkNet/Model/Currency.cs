using System;
using Newtonsoft.Json;
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
		[JsonProperty("id")]
		public long? Id { get; set; }

		/// <summary>
		/// Буквенное обозначение валюты
		/// </summary>
		[Obsolete(ObsoleteText.ObsoleteCyrillicProperty)]
		[JsonProperty("currency")]
		public string Сurrency { get; set; }

		/// <summary>
		/// Буквенное обозначение валюты
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Currency FromJson(VkResponse response)
		{
			return new Currency
			{
				Id = response[key: "id"],
				Сurrency = response[key: "currency"],
				Name = response[key: "name"]
			};
		}
	}
}