using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Возможные значения параметра VideoCatalogType, задающего внешний вид окна
/// авторизации.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum VideoCatalogType
{
	/// <summary>
	/// Видеозаписи сообщества.
	/// </summary>
	[VkNetDefaultValue]
	Channel,

	/// <summary>
	/// Подборки видеозаписей.
	/// </summary>
	Category
}