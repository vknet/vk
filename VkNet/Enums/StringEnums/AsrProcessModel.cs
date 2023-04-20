using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Модель распознавания речи, которую нужно использовать
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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