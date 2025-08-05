using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип канала новостей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum PhotoFeedType
{
	/// <summary>
	/// Фото.
	/// </summary>
	Photo,

	/// <summary>
	/// Тег фото.
	/// </summary>
	PhotoTag
}