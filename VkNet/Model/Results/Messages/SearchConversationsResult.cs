using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса messages.searchConversations
	/// </summary>
	[Serializable]
	public class SearchConversationsResult
	{
		/// <summary>
		/// Число результатов
		/// </summary>
		[JsonProperty("count")]
		public long Count { get; set; }

		/// <summary>
		/// Массив объектов диалогов
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<Conversation> Items { get; set; }

		/// <summary>
		/// Массив объектов пользователей.
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }
	}
}