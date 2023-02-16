using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Пользователь или сообщество.
/// </summary>
public class UserOrGroupType : SafetyEnum<UserOrGroupType>
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	[EnumMember(Value = "user")]
	public static readonly UserOrGroupType User = RegisterPossibleValue("user");

	/// <summary>
	/// Сообщество.
	/// </summary>
	[EnumMember(Value = "group")]
	public static readonly UserOrGroupType Group = RegisterPossibleValue("group");
}