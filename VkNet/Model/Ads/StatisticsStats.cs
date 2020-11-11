using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Cтатистика объекта за один временной период
	/// </summary>
	[Serializable]
	public class StatisticsStats
	{
		/// <summary>
		/// День в формате YYYY-MM-DD
		/// </summary>
		[JsonProperty("day")]
		public string Day { get; set; }

		/// <summary>
		/// Месяц в формате YYYY-MM
		/// </summary>
		[JsonProperty("month")]
		public string Month { get; set; }

		/// <summary>
		/// Если был запрос на статистику за все время, то значение 1
		/// </summary>
		[JsonProperty("overall")]
		public string OverAll { get; set; }

		/// <summary>
		/// Потраченные средства
		/// </summary>
		[JsonProperty("spent")]
		public string Spent { get; set; }

		/// <summary>
		/// Потраченные средства
		/// </summary>
		[JsonProperty("impressions")]
		public long Impressions { get; set; }

		/// <summary>
		/// Клики
		/// </summary>
		[JsonProperty("clicks")]
		public long Clicks { get; set; }

		/// <summary>
		/// Охват
		/// </summary>
		[JsonProperty("reach")]
		public long Reach { get; set; }

		/// <summary>
		/// Вступления в группу, событие, подписки на публичную страницу или
		/// установки приложения (только если в объявлении указана прямая ссылка
		/// на соответствующую страницу ВКонтакте)
		/// </summary>
		[JsonProperty("join_rate")]
		public long? JoinRate { get; set; }

		/// <summary>
		/// Количество уникальных просмотров
		/// </summary>
		[JsonProperty("uniq_views_count")]
		public long UniqViewsCount { get; set; }

		/// <summary>
		/// CTR
		/// </summary>
		[JsonProperty("ctr")]
		public string Ctr { get; set; }

		/// <summary>
		/// eCPC
		/// </summary>
		[JsonProperty("effective_cost_per_click")]
		public string EffectiveCostPerClick { get; set; }

		/// <summary>
		/// eCPM
		/// </summary>
		[JsonProperty("effective_cost_per_mille")]
		public string EffectiveCostPerMille { get; set; }

		/// <summary>
		/// eCPF
		/// </summary>
		[JsonProperty("effective_cpf")]
		public string EffectiveCpf { get; set; }

		/// <summary>
		/// Cтоимость сообщения
		/// </summary>
		[JsonProperty("effective_cost_per_message")]
		public string EffectiveCostPerMessage { get; set; }

		/// <summary>
		/// Количество сообщений
		/// </summary>
		[JsonProperty("message_sends_by_any_user")]
		public long? MessageSendsByAnyUser { get; set; }

		/// <summary>
		/// Cколько пользователей включили видео
		/// </summary>
		[JsonProperty("video_plays_unique_started")]
		public long? VideoPlaysUniqueStarted { get; set; }

		/// <summary>
		/// Cколько пользователей посмотрели 3 секунды видео
		/// </summary>
		[JsonProperty("video_plays_unique_3_seconds")]
		public long? VideoPlaysUnique3Seconds { get; set; }

		/// <summary>
		/// Cколько пользователей посмотрели 25% видео
		/// </summary>
		[JsonProperty("video_plays_unique_25_percents")]
		public long? VideoPlaysUnique25Percents { get; set; }

		/// <summary>
		/// Cколько пользователей посмотрели 50% видео
		/// </summary>
		[JsonProperty("video_plays_unique_50_percents")]
		public long? VideoPlaysUnique50Percents { get; set; }

		/// <summary>
		/// Cколько пользователей посмотрели 50% видео
		/// </summary>
		[JsonProperty("video_plays_unique_75_percents")]
		public long? VideoPlaysUnique75Percents { get; set; }

		/// <summary>
		/// Cколько пользователей посмотрели 50% видео
		/// </summary>
		[JsonProperty("video_plays_unique_100_percents")]
		public long? VideoPlaysUnique100Percents { get; set; }

		/// <summary>
		/// Конверсии
		/// </summary>
		[JsonProperty("conversion_count")]
		public long? ConversionCount { get; set; }

		/// <summary>
		/// Ценность конверсий
		/// </summary>
		[JsonProperty("conversion_sum")]
		public string ConversionSum { get; set; }

		/// <summary>
		/// Окупаемость затрат на рекламу
		/// </summary>
		[JsonProperty("conversion_roas")]
		public string ConversionRoas { get; set; }

		/// <summary>
		/// Коэффициент конверсии
		/// </summary>
		[JsonProperty("conversion_cr")]
		public string ConversionCr { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static StatisticsStats FromJson(VkResponse response)
		{
			return new StatisticsStats
			{
				Day = response["day"],
				Month = response["month"],
				OverAll = response["overall"],
				Spent = response["spent"],
				Impressions = response["impressions"],
				Clicks = response["clicks"],
				Reach = response["reach"],
				JoinRate = response["join_rate"],
				UniqViewsCount = response["uniq_views_count"],
				Ctr = response["ctr"],
				EffectiveCostPerClick = response["effective_cost_per_click"],
				EffectiveCostPerMille = response["effective_cost_per_mille"],
				EffectiveCpf = response["effective_cpf"],
				EffectiveCostPerMessage = response["effective_cost_per_message"],
				MessageSendsByAnyUser = response["message_sends_by_any_user"],
				VideoPlaysUniqueStarted = response["video_plays_unique_started"],
				VideoPlaysUnique3Seconds = response["video_plays_unique_3_seconds"],
				VideoPlaysUnique25Percents = response["video_plays_unique_25_percents"],
				VideoPlaysUnique50Percents = response["video_plays_unique_50_percents"],
				VideoPlaysUnique75Percents = response["video_plays_unique_75_percents"],
				VideoPlaysUnique100Percents = response["video_plays_unique_100_percents"],
				ConversionCount = response["conversion_count"],
				ConversionSum = response["conversion_sum"],
				ConversionRoas = response["conversion_roas"],
				ConversionCr = response["conversion_cr"]
			};
		}
	}
}