using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ на методы stories
	/// </summary>
	[Serializable]
	public class StoryResult<T>
	{
		/// <summary>
		/// Число подборок
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив данных
		/// </summary>
		[JsonProperty("items")]
		public IEnumerable<T> Items { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public IEnumerable<User> Profiles { get; set; }

		/// <summary>
		/// Сообщества
		/// </summary>
		[JsonProperty("groups")]
		public IEnumerable<Group> Groups { get; set; }
	}
}