using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип элемента каталога.
/// </summary>
public sealed class VideoCatalogItemType : SafetyEnum<VideoCatalogItemType>
{
	/// <summary>
	/// Видеоролик.
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly VideoCatalogItemType Video = RegisterPossibleValue(value: "video");

	/// <summary>
	/// Альбом.
	/// </summary>
	[EnumMember(Value = "album")]
	public static readonly VideoCatalogItemType Album = RegisterPossibleValue(value: "album");
}