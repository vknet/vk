using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class AdsTargetingResult
	{
		/// <summary>
		/// Идентификатор кампании.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		/// Формат объявления
		/// </summary>
		[JsonProperty("campaign_id")]
		public string CampaignId { get; set; }

		/// <summary>
		/// Автоматическое управление ценой
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		/// Тип оплаты
		/// </summary>
		[JsonProperty("cities")]
		public string Cities { get; set; }

		/// <summary>
		/// Тип оплаты
		/// </summary>
		[JsonProperty("cities_not")]
		public string CitiesNot { get; set; }

		/// <summary>
		/// Тип оплаты
		/// </summary>
		[JsonProperty("count")]
		public string Count { get; set; }

		/// <summary>
		/// Тип оплаты
		/// </summary>
		[JsonProperty("statuses")]
		public string Statuses { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static AdsTargetingResult FromJson(VkResponse response)
		{
			return new AdsTargetingResult
			{
				CampaignId = response["campaign_id"],
				Id = response["id"],
				Country= response["country"],
				Cities =  response["cities"],
				CitiesNot = response["cities_not"],
				Count = response["count"],
				Statuses = response["statuses"]
			};
		}

	}
}