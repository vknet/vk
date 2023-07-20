using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип канала новостей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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