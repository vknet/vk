using System;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model;

/// <summary>
/// Вложения материалов диалога или беседы
/// </summary>
[Serializable]
public class HistoryAttachment
{
	/// <summary>
	/// Идентификатор сообщения, в котором было отправлено вложение.
	/// </summary>
	[JsonProperty("message_id")]
	public int MessageId { get; set; }

	/// <summary>
	/// Информация о вложении.
	/// </summary>
	[JsonProperty("attachment")]
	public Attachment Attachment { get; set; }
}