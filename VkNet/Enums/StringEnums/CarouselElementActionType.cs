using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;


/// <summary>
/// Тип элемента карусели
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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