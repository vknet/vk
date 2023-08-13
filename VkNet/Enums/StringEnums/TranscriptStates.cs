using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Статус транскрипции голосового сообщения
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum TranscriptStates
{
	/// <summary>
	/// Транскрипция в обработке
	/// </summary>
	InProgress,

	/// <summary>
	/// Транскрипция завершена
	/// </summary>
	Done
}