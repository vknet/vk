using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип запроса для приложений
/// </summary>
public sealed class AppRequestType : SafetyEnum<AppRequestType>
{
	/// <summary>
	/// В случае если запрос отправляется пользователю, не установившему приложение
	/// </summary>
	[EnumMember(Value = "invite")]
	public static readonly AppRequestType Invite = RegisterPossibleValue(value: "invite");

	/// <summary>
	/// В случае если пользователь уже установил приложение
	/// </summary>
	[EnumMember(Value = "request")]
	public static readonly AppRequestType Request = RegisterPossibleValue(value: "request");
}