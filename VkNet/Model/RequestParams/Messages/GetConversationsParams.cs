using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса messages.GetConversations
	/// </summary>
	[Serializable]
	public class GetConversationsParams
	{
		/// <summary>
		/// Фильтр
		/// </summary>
		[JsonProperty("filter")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public GetConversationFilter Filter { get; set; }

		/// <summary>
		/// Список дополнительных полей для пользователей и сообществ.
		/// </summary>
		[JsonProperty("fields")]
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества результатов.
		/// </summary>
		[JsonProperty("offset")]
		public ulong? Offset { get; set; }

		/// <summary>
		/// Максимальное число результатов, которые нужно получить.
		/// </summary>
		[JsonProperty("count")]
		public ulong? Count { get; set; }

		/// <summary>
		/// 1 — возвращать дополнительные поля для пользователей и сообществ.
		/// </summary>
		[JsonProperty("extended")]
		public bool Extended { get; set; }

		/// <summary>
		/// Идентификатор сообщения, начиная с которого нужно возвращать беседы.
		/// </summary>
		[JsonProperty("start_message_id")]
		public ulong? StartMessageId { get; set; }

		/// <summary>
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя).
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }
	}
}