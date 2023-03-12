using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Источник контента.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum MessageContentSourceType
{
	/// <summary>
	/// Сообщение
	/// </summary>
	Message,

	/// <summary>
	/// Ссылка
	/// </summary>
	Url
}