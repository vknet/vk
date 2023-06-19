using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Возможные значения параметра VideoCatalogType, задающего внешний вид окна
/// авторизации.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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