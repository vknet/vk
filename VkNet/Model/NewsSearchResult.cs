using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат поиска метода newsfeed.search
	/// </summary>
	[Serializable]
	public class NewsSearchResult
	{
		/// <summary>
		/// Список новостей
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<NewsSearchItem> Items { get; set; }

		/// <summary>
		/// Количество новостей
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Общее количество новостей
		/// </summary>
		[JsonProperty("total_count")]
		public long TotalCount { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Сообщества
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups { get; set; }

		/// <summary>
		/// Ключ для следующего поиска
		/// </summary>
		[JsonProperty("next_from")]
		public string NextFrom { get; set; }
	}
}