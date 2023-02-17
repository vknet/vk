using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums;

/// <summary>
/// Возможные значения параметра VideoCatalogType, задающего внешний вид окна
/// авторизации.
/// </summary>
public enum VideoCatalogType
{
	/// <summary>
	/// Видеозаписи сообщества.
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "channel")]
	Channel,

	/// <summary>
	/// Подборки видеозаписей.
	/// </summary>
	[EnumMember(Value = "category")]
	Category
}