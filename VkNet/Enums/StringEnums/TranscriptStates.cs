using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Статус транскрипции голосового сообщения
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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