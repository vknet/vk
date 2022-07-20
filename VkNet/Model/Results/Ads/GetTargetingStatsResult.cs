using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class GetTargetingStatsResult
	{
		/// <summary>
		/// Количество оставшихся методов;
		/// </summary>
		[JsonProperty("audience_count")]
		public long AudienceCount { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpc")]
		public string RecommendedCpc { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpm")]
		public string RecommendedCpm { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpc_50")]
		public string RecommendedCpc50 { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpm_50")]
		public string RecommendedCpm50 { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpc_70")]
		public string RecommendedCpc70 { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpm_70")]
		public string RecommendedCpm70 { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpc_90")]
		public string RecommendedCpc90 { get; set; }

		/// <summary>
		/// Время до следующего обновления в секундах.
		/// </summary>
		[JsonProperty("recommended_cpm_90")]
		public string RecommendedCpm90 { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static GetTargetingStatsResult FromJson(VkResponse response)
		{
			return new GetTargetingStatsResult
			{
				AudienceCount = response["audience_count"],
				RecommendedCpc = response["recommended_cpc"],
				RecommendedCpm = response["recommended_cpm"],
				RecommendedCpc50 = response["recommended_cpc_50"],
				RecommendedCpm50 = response["recommended_cpm_50"],
				RecommendedCpc70 = response["recommended_cpc_70"],
				RecommendedCpm70 = response["recommended_cpm_70"],
				RecommendedCpc90 = response["recommended_cpc_90"],
				RecommendedCpm90 = response["recommended_cpm_90"]
			};
		}
	}
}