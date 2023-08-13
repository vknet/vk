using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип элемента каталога.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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