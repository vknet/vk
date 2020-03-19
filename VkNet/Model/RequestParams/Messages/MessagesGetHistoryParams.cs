using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода Message.GetHistory
	/// http://vk.com/dev/messages.getHistory
	/// </summary>
	[Serializable]
	public class MessagesGetHistoryParams
	{
		/// <summary>
		/// Идентификатор пользователя, историю переписки с которым необходимо вернуть.
		/// </summary>
		[JsonProperty("user_id")]
		public long? UserId { get; set; }

		/// <summary>
		/// Список дополнительных полей профилей и сообществ, которые необходимо вернуть.
		/// </summary>
		[JsonProperty("fields")]
		public IEnumerable<string> Fields { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества сообщений,
		/// должен быть 0 или положительным, если не передан параметр start_message_id, и
		/// должен быть 0 или отрицательным, если
		/// передан.
		/// </summary>
		[JsonProperty("offset")]
		public long? Offset { get; set; }

		/// <summary>
		/// Количество сообщений, которое необходимо получить (но не более 200)
		/// </summary>
		[JsonProperty("count")]
		public long? Count { get; set; }

		/// <summary>
		/// Идентификатор назначения.
		/// </summary>
		[JsonProperty("peer_id")]
		public long? PeerId { get; set; }

		/// <summary>
		/// Если значение > 0, то это идентификатор сообщения, начиная с которого нужно
		/// вернуть историю переписки,
		/// если же передано значение -1, то к значению параметра offset прибавляется
		/// количество входящих непрочитанных сообщений в конце диалога
		/// </summary>
		[JsonProperty("start_message_id")]
		public long? StartMessageId { get; set; }

		/// <summary>
		/// Возвращать сообщения в хронологическом порядке или обратном (по умолчанию в
		/// обратном). Недоступен при переданном start_message_id.
		/// </summary>
		[JsonProperty("rev")]
		public bool? Reversed { get; set; }

		/// <summary>
		/// Если указать в качестве этого параметра <c>true</c>,
		/// то будет возвращена информация о пользователях и сообществах, являющихся авторами сообщений.
		/// <remarks>По умолчанию <c>false</c>.</remarks>
		/// </summary>
		[JsonProperty("extended")]
		public bool? Extended { get; set; }

		/// <summary>
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя).
		/// </summary>
		[JsonProperty("group_id")]
		public ulong? GroupId { get; set; }
	}
}