using System;

namespace VkNet.Model;

/// <summary>
/// Информация о медиавложении в записи.
/// См. описание http://vk.com/dev/attachments_w
/// </summary>
[Serializable]
public class Attachment
{
	/// <summary>
	/// Экземпляр самого прикрепления.
	/// </summary>
	public MediaAttachment Instance { get; set; }

	/// <summary>
	/// Информация о типе вложения.
	/// </summary>
	public Type Type { get; set; }
}