using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Информация о текущем роде занятия пользователя.
/// </summary>
[Serializable]
public class OnlineStatusType : SafetyEnum<OnlineStatusType>
{
	/// <summary>
	/// Сообщество не онлайн
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "none")]
	public static readonly OnlineStatusType None = RegisterPossibleValue("none");

	/// <summary>
	/// Сообщество онлайн (отвечает мгновенно)
	/// </summary>
	[EnumMember(Value = "online")]
	public static readonly OnlineStatusType Online = RegisterPossibleValue("online");

	/// <summary>
	/// Сообщество отвечает быстро.
	/// </summary>
	[EnumMember(Value = "answer_mark")]
	public static readonly OnlineStatusType AnswerMark = RegisterPossibleValue("answer_mark");
}