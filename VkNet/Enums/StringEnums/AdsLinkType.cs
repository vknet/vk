using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;


/// <summary>
///
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AdsLinkType
{
	/// <summary>
	/// Сообщество
	/// </summary>
	Community,

	/// <summary>
	/// Запись в сообществе;
	/// </summary>
	Post,

	/// <summary>
	/// Приложение ВКонтакте;
	/// </summary>
	Application,

	/// <summary>
	/// Видеозапись;
	/// </summary>
	Video,

	/// <summary>
	/// Внешний сайт.
	/// </summary>
	Site
}