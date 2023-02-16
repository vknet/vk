using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип статуса ссылки
/// </summary>
public class LinkStatusType : SafetyEnum<LinkStatusType>
{
	/// <summary>
	/// Ссылку допустимо использовать в рекламных объявлениях;
	/// </summary>
	[EnumMember(Value = "allowed")]
	public static readonly LinkStatusType Allowed = RegisterPossibleValue(value: "allowed");

	/// <summary>
	/// Ссылку допустимо использовать в рекламных объявлениях;
	/// </summary>
	[EnumMember(Value = "disallowed")]
	public static readonly LinkStatusType Disallowed = RegisterPossibleValue(value: "disallowed");

	/// <summary>
	/// Ссылку допустимо использовать в рекламных объявлениях;
	/// </summary>
	[EnumMember(Value = "in_progress")]
	public static readonly LinkStatusType InProgress = RegisterPossibleValue(value: "in_progress");
}