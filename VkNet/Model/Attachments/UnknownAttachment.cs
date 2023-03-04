using System;

namespace VkNet.Model.Attachments;

/// <summary>
/// Неизвестное вложение
/// </summary>
[Serializable]
public class UnknownAttachment : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => nameof(UnknownAttachment);
}