using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип канала новостей.
/// </summary>
public sealed class PhotoFeedType : SafetyEnum<PhotoFeedType>
{
	/// <summary>
	/// Фото.
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly PhotoFeedType Photo = RegisterPossibleValue(value: "photo");

	/// <summary>
	/// Тег фото.
	/// </summary>
	[EnumMember(Value = "photo_tag")]
	public static readonly PhotoFeedType PhotoTag = RegisterPossibleValue(value: "photo_tag");
}