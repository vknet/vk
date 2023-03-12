using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип событий
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum StreamingEventType
{
	/// <summary>
	/// Записи на стене;
	/// </summary>
	Post,

	/// <summary>
	/// Комментарии;
	/// </summary>
	Comment,

	/// <summary>
	/// Репосты;
	/// </summary>
	Share
}