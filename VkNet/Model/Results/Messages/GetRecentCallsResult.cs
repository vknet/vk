using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат запроса messages.GetRecentCalls
	/// </summary>
	[Serializable]
	public class GetRecentCallsResult
	{
		/// <summary>
		/// Число результатов.
		/// </summary>
		[JsonProperty("count")]
		public ulong Count { get; set; }
		/// <summary>
		/// Сообщения
		/// </summary>
		[JsonProperty("items")]
		public ReadOnlyCollection<Message> Messages { get; set; }

		/// <summary>
		/// Профили пользователей
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// Массив объектов сообществ.
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups { get; set; }
	}
}