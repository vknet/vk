using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса о получении беседы
	/// </summary>
	[Serializable]
	public class ConversationResult
	{
		/// <summary>
		/// Общее число результатов
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов бесед
		/// </summary>
		[JsonProperty("items")]
		public IEnumerable<Conversation> Items { get; set; }

		/// <summary>
		/// Профили
		/// </summary>
		[JsonProperty("profiles")]
		public IEnumerable<User> Profiles { get; set; }

		/// <summary>
		/// Группы
		/// </summary>
		[JsonProperty("groups")]
		public IEnumerable<Group> Groups { get; set; }
	}
}