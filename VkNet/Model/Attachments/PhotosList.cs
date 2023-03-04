using System;
using VkNet.Model.Attachments;

namespace VkNet.UWP.Model.Attachments;

/// <inheritdoc />
/// <summary>
/// Список фото
/// </summary>
[Obsolete("Для версии API ниже 5.0")]
[Serializable]
public class PhotosList : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "photos_list";
}