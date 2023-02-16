using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Статус транскрипции голосового сообщения
/// </summary>
public sealed class TranscriptStates : SafetyEnum<TranscriptStates>
{
	/// <summary>
	/// Транскрипция в обработке
	/// </summary>
	[EnumMember(Value = "in_progress")]
	public static readonly TranscriptStates InProgress = RegisterPossibleValue(value: "in_progress");

	/// <summary>
	/// Транскрипция завершена
	/// </summary>
	[EnumMember(Value = "done")]
	public static readonly TranscriptStates Done = RegisterPossibleValue(value: "done");
}