using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип элемента каталога.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum VideoCatalogItemType
{
	/// <summary>
	/// Видеоролик.
	/// </summary>
	Video,

	/// <summary>
	/// Альбом.
	/// </summary>
	Album
}