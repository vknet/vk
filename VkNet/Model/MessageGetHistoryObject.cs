using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Объект ответа на message.getHistory
	/// </summary>
	[Serializable]
	public class MessageGetHistoryObject
	{
		/// <summary>
		/// Общее число результатов
		/// </summary>
		[JsonProperty("count")]
		public uint TotalCount { get; set; }

		/// <summary>
		/// Массив объектов <see cref="Message"/>
		/// </summary>
		[JsonProperty("items")]
		public IEnumerable<Message> Messages { get; set; }

		/// <summary>
		/// Массив объектов <see cref="Conversation"/>
		/// <remarks>Возвращается, если был передан параметр Extended=<c>true</c></remarks>
		/// </summary>
		[JsonProperty("conversations")]
		public IEnumerable<Conversation> Conversations { get; set; }

		/// <summary>
		/// Массив объектов <see cref="User"/>
		/// <remarks>Возвращается, если был передан параметр Extended=<c>true</c></remarks>
		/// </summary>
		[JsonProperty("profiles")]
		public IEnumerable<User> Users { get; set; }

		/// <summary>
		/// Массив объектов <see cref="Group"/>
		/// <remarks>Возвращается, если был передан параметр Extended=<c>true</c></remarks>
		/// </summary>
		[JsonProperty("groups")]
		public IEnumerable<Group> Groups { get; set; }
	}
}