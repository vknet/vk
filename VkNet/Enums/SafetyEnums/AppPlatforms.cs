using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Платформа для которой необходимо вернуть приложения.
/// </summary>
/// <remarks>
/// По умолчанию используется web.
/// </remarks>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AppPlatforms
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	Ios,

	/// <summary>
	/// По посещаемости
	/// </summary>
	Android,

	/// <summary>
	/// По дате создания приложения
	/// </summary>
	Winphone,

	/// <summary>
	/// По скорости роста
	/// </summary>
	Web
}