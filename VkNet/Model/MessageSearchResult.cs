using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода messages.search
	/// </summary>
	[Serializable]
	public class MessageSearchResult
	{
		/// <summary>
		/// Количество найденных сообщений
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }

		/// <summary>
		/// Личные сообщения
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<Message> Items { get; set; }

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
		/// Беседы
		/// </summary>
		[JsonProperty("conversations")]
		public IEnumerable<Conversation> Conversations { get; set; }
	}
}