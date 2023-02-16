using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип страницы.
/// </summary>
public class FavePageType : SafetyEnum<FavePageType>
{
	/// <summary>
	/// Пользователи.
	/// </summary>
	[EnumMember(Value = "users")]
	public static readonly FavePageType Users = RegisterPossibleValue("users");

	/// <summary>
	/// Сообщества.
	/// </summary>
	[EnumMember(Value = "groups")]
	public static readonly FavePageType Videos = RegisterPossibleValue("groups");

	/// <summary>
	/// Топ сообществ и пользователей.
	/// </summary>
	[EnumMember(Value = "hints")]
	public static readonly FavePageType Hints = RegisterPossibleValue("hints");
}