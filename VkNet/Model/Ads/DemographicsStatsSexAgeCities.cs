using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class DemographicsStatsSexAgeCities
	{
		/// <summary>
		/// Идентификатор рекламного кабинета. обязательный параметр, целое число
		/// </summary>
		[JsonProperty("impressions_rate")]
		public long ImpressionsRate { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("clicks_rate")]
		public long ClicksRate { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// обязательный параметр, строка
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static DemographicsStatsSexAgeCities FromJson(VkResponse response)
		{
			return new DemographicsStatsSexAgeCities
			{
				Name = response["name"],
				Value = response["value"],
				ImpressionsRate = response["impressions_rate"],
				ClicksRate = response["clicks_rate"]
			};
		}
	}
}