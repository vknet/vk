using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Статус сервера
/// </summary>
public class CallbackServerStatus : SafetyEnum<CallbackServerStatus>
{
	/// <summary>
	/// Адрес не задан;
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "unconfigured")]
	public static readonly CallbackServerStatus Unconfigured = RegisterPossibleValue(value: "unconfigured");

	/// <summary>
	/// Подтвердить адрес не удалось
	/// </summary>
	[EnumMember(Value = "fail")]
	public static readonly CallbackServerStatus Fail = RegisterPossibleValue(value: "fail");

	/// <summary>
	/// Адрес ожидает подтверждения
	/// </summary>
	[EnumMember(Value = "wait")]
	public static readonly CallbackServerStatus Wait = RegisterPossibleValue(value: "wait");

	/// <summary>
	/// Сервер подключен
	/// </summary>
	[EnumMember(Value = "ok")]
	public static readonly CallbackServerStatus Ok = RegisterPossibleValue(value: "ok");
}