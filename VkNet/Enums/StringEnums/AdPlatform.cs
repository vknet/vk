using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Рекламные площадки, на которых будет показываться объявление. (если значение применимо к данному формату объявления)
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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