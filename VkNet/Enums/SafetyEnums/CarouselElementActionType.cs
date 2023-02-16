using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <inheritdoc />
public class CarouselElementActionType : SafetyEnum<CarouselElementActionType>
{
	/// <summary>
	/// Открывает указанную ссылку.
	/// </summary>
	[EnumMember(Value = "open_link")]
	public static readonly CarouselElementActionType OpenLink = RegisterPossibleValue("open_link");

	/// <summary>
	/// Открывает фото текущего элемента карусели.
	/// </summary>
	[EnumMember(Value = "open_photo")]
	public static readonly CarouselElementActionType OpenPhoto = RegisterPossibleValue("open_photo");
}