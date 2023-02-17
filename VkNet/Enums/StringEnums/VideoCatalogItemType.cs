using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Тип элемента каталога.
/// </summary>
public enum VideoCatalogItemType
{
	/// <summary>
	/// Видеоролик.
	/// </summary>
	[EnumMember(Value = "video")]
	Video,

	/// <summary>
	/// Альбом.
	/// </summary>
	[EnumMember(Value = "album")]
	Album
}