using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Объект статистики истории.
	/// </summary>
	[Serializable]
    public class StoryStatsResult
    {
		/// <summary>
		/// Просмотры.
		/// </summary>
		[JsonProperty("views")]
		public StoryStatsObject Views { get; set; }
		/// <summary>
		/// Ответы на историю.
		/// </summary>
		[JsonProperty("replies")]
		public StoryStatsObject Replies { get; set; }
		/// <summary>
		/// Число. (?)
		/// </summary>
		[JsonProperty("answer")]
		public StoryStatsObject Answer { get; set; }
		/// <summary>
		/// Расшаривания истории.
		/// </summary>
		[JsonProperty("shares")]
		public StoryStatsObject Shares { get; set; }
		/// <summary>
		/// Новые подписчики.
		/// </summary>
		[JsonProperty("subscribers")]
		public StoryStatsObject Subscribers { get; set; }
		/// <summary>
		/// Скрытия истории.
		/// </summary>
		[JsonProperty("bans")]
		public StoryStatsObject Bans { get; set; }
		/// <summary>
		/// Переходы по ссылке.
		/// </summary>
		[JsonProperty("open_link")]
		public StoryStatsObject OpenLink { get; set; }
	}
}
