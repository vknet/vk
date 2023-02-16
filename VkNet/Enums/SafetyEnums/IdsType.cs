using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
public sealed class IdsType : SafetyEnum<IdsType>
{
	/// <summary>
	/// Объявление.
	/// </summary>
	[EnumMember(Value = "ad")]
	public static readonly IdsType Ad = RegisterPossibleValue(value: "ad");

	/// <summary>
	/// Кампания.
	/// </summary>
	[EnumMember(Value = "campaign")]
	public static readonly IdsType Campaign = RegisterPossibleValue(value: "campaign");
}