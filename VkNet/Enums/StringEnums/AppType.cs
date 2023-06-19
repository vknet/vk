using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип приложения.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AppType
{
	/// <summary>
	/// Социальное приложение;
	/// </summary>
	App,

	/// <summary>
	/// Игра;
	/// </summary>
	Game,

	/// <summary>
	/// Подключаемый сайт;
	/// </summary>
	Site,

	/// <summary>
	/// Отдельное приложение (для мобильного устройства).
	/// </summary>
	Standalone,

	/// <summary>
	/// VK App приложение
	/// </summary>
	VkApp,

	/// <summary>
	/// VK App приложение
	/// </summary>
	CommunityApp,

	/// <summary>
	/// HTML5 игра
	/// </summary>
	Html5Game
}