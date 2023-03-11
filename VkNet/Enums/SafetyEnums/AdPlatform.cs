using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Рекламные площадки, на которых будет показываться объявление. (если значение применимо к данному формату объявления)
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AdPlatform
{
	/// <summary>
	/// (если ad_format равен 1) ВКонтакте и сайты-партнёры.
	/// </summary>
	VkAndPartners,

	/// <summary>
	/// (если ad_format равен 1) Только ВКонтакте.
	/// </summary>
	VkOnly,

	/// <summary>
	/// (если ad_format равен 9) Все площадки.
	/// </summary>
	All,

	/// <summary>
	/// (если ad_format равен 9) Полная версия сайта.
	/// </summary>
	Desktop,

	/// <summary>
	/// (если ad_format равен 9) Мобильный сайт и приложения.
	/// </summary>
	Mobile
}