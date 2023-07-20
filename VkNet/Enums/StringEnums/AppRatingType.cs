using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Рейтинг приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AppRatingType
{
	/// <summary>
	/// Рейтинг по уровням
	/// </summary>
	Level,

	/// <summary>
	/// Рейтинг по очкам
	/// </summary>
	Points
}