using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Model.Keyboard;
using VkNet.Model.Template;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса Messages.Edit
	/// </summary>
	[Serializable]
	public class MessageEditParams
	{
		/// <summary>
		/// Идентификатор назначения.
		/// </summary>
		[JsonProperty("peer_id")]
		public long PeerId { get; set; }

		/// <summary>
		/// Текст сообщения. Обязательный параметр, если не задан параметр attachment.
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		/// Идентификатор сообщения.
		/// </summary>
		[JsonProperty("message_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? MessageId { get; set; }

		/// <summary>
		/// Географическая широта (от -90 до 90).
		/// </summary>
		[JsonProperty("lat")]
		public double Latitude { get; set; }

		/// <summary>
		/// Географическая долгота (от -180 до 180).
		/// </summary>
		[JsonProperty("long")]
		public double Longitude { get; set; }

		/// <summary>
		/// медиавложения к личному сообщению, перечисленные через запятую.
		/// </summary>
		[JsonProperty("attachment")]
		public IEnumerable<MediaAttachment> Attachments { get; set; }

		/// <summary>
		/// 1, чтобы сохранить прикреплённые пересланные сообщения
		/// </summary>
		[JsonProperty("keep_forward_messages")]
		public bool? KeepForwardMessages { get; set; }

		/// <summary>
		/// 1, чтобы сохранить прикреплённые внешние ссылки (сниппеты).
		/// </summary>
		[JsonProperty("keep_snippets")]
		public bool? KeepSnippets { get; set; }

		/// <summary>
		/// Идентификатор сообщества (для сообщений сообщества с ключом доступа пользователя). положительное число
		/// </summary>
		[JsonProperty("group_id")]
		public ulong GroupId { get; set; }

		/// <summary>
		/// 1 — не создавать сниппет ссылки из сообщения флаг, может принимать значения 1 или 0, по умолчанию
		/// </summary>
		[JsonProperty("dont_parse_links")]
		public bool DontParseLinks { get; set; }

		/// <summary>
		/// идентификатор сообщения в беседе
		/// </summary>
		[JsonProperty("conversation_message_id", NullValueHandling = NullValueHandling.Ignore)]
		public long? ConversationMessageId { get; set; }

		/// <summary>
		/// Шаблон сообщений
		/// </summary>
		/// <remarks>
		/// Рекомендуется для построения использовать <see cref="ITemplateBuilder" />
		/// </remarks>
		[JsonProperty("template")]
		public MessageTemplate Template { get; set; }

		/// <summary>
		/// Клавиатура бота
		/// </summary>
		/// <remarks>
		/// Рекомендуется для построения использовать <see cref="IKeyboardBuilder" />
		/// </remarks>
		[JsonProperty("keyboard")]
		public MessageKeyboard Keyboard { get; set; }
	}
}