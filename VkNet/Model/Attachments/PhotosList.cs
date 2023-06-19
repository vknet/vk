using System;

namespace VkNet.Model;

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