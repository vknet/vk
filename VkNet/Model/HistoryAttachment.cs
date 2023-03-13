using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.Attachments;
using VkNet.Utils.JsonConverter;

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
	[JsonConverter(typeof(HistoryAttachmentJsonConverter))]
	public Attachment Attachment { get; set; }

	/// <summary>
	/// Тип плейлиста.
	/// </summary>
	[JsonProperty("forward_level")]
	public int ForwardLevel { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty("cmid")]
	public long Cmid { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty("from_id")]
	public long FromId { get; set; }

	/// <summary>
	/// Дата
	/// </summary>
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty("date")]
	public DateTime Date { get; set; }

}