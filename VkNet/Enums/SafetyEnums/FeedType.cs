using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
public sealed class FeedType : SafetyEnum<FeedType>
{
	/// <summary>
	/// По возрастанию численных значений идентификаторов.
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly FeedType Photo = RegisterPossibleValue(value: "photo");

	/// <summary>
	/// По убыванию численных значений идентификаторов.
	/// </summary>
	[EnumMember(Value = "photo_tag")]
	public static readonly FeedType PhotoTag = RegisterPossibleValue(value: "photo_tag");
}