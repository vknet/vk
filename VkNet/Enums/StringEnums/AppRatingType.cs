using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Рейтинг приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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