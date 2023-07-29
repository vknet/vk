using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;


/// <summary>
/// Тип элемента карусели
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CarouselElementActionType
{
	/// <summary>
	/// Открывает указанную ссылку.
	/// </summary>
	OpenLink,

	/// <summary>
	/// Открывает фото текущего элемента карусели.
	/// </summary>
	OpenPhoto
}