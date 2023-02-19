using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Статус транскрипции голосового сообщения
/// </summary>
public enum TranscriptStates
{
	/// <summary>
	/// Транскрипция в обработке
	/// </summary>
	[EnumMember(Value = "in_progress")]
	InProgress,

	/// <summary>
	/// Транскрипция завершена
	/// </summary>
	[EnumMember(Value = "done")]
	Done
}