using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Способ сортировки приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum PostTypeOrder
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	Post,

	/// <summary>
	/// По посещаемости
	/// </summary>
	Copy
}