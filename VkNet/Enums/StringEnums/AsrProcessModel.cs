using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Модель распознавания речи, которую нужно использовать
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum AsrProcessModel
{
	/// <summary>
	/// Распознавание разборчивой речи, как в интервью или телешоу.
	/// </summary>
	Neutral,

	/// <summary>
	/// Распознавание речи со сленгом и ненормативной лексикой.
	/// </summary>
	Spontaneous
}