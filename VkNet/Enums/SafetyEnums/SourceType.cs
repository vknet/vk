using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип источника исходной аудитории.
/// </summary>
public sealed class SourceType : SafetyEnum<SourceType>
{
	/// <summary>
	/// Аудитория ретаргетинга
	/// </summary>
	[EnumMember(Value = "retargeting_group")]
	public static readonly SourceType RetargetingGroup = RegisterPossibleValue(value: "retargeting_group");
}