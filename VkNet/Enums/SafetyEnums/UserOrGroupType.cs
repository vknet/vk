using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Пользователь или сообщество.
/// </summary>
public enum UserOrGroupType
{
	/// <summary>
	/// Пользователь.
	/// </summary>
	[EnumMember(Value = "user")]
	User,

	/// <summary>
	/// Сообщество.
	/// </summary>
	[EnumMember(Value = "group")]
	Group
}