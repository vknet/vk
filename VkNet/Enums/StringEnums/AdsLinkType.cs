using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;


/// <summary>
/// Тип ссылки рекламы
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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