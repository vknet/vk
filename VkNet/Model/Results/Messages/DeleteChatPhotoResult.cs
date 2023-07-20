using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Messages.DeleteChatPhoto
/// </summary>
[Serializable]
public class DeleteChatPhotoResult
{
	/// <summary>
	/// Общее число результатов
	/// </summary>
	[JsonProperty("message_id")]
	public long MessageId { get; set; }

	/// <summary>
	/// Массив объектов бесед
	/// </summary>
	[JsonProperty("chat")]
	public Chat Chat { get; set; }
}