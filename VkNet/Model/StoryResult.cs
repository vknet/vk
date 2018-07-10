using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Ответ stories.get
	/// </summary>
	[Serializable]
	public class StoryResult
	{
		/// <summary>
		/// Число подборок
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив подборок историй
		/// </summary>
		[JsonProperty("items")]
		public Story[][] Items { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public User Profiles { get; set; }

		/// <summary>
		/// Сообщества
		/// </summary>
		[JsonProperty("groups")]
		public Group Groups { get; set; }
	}
}