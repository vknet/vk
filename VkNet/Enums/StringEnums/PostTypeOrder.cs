using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Способ сортировки приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum PostTypeOrder
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	Post,

	/// <summary>
	/// По посещаемости
	/// </summary>
	Copy
}