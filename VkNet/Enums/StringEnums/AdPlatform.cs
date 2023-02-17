using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Рекламные площадки, на которых будет показываться объявление. (если значение применимо к данному формату объявления)
/// </summary>
public enum AdPlatform
{
	/// <summary>
	/// (если ad_format равен 1) ВКонтакте и сайты-партнёры.
	/// </summary>
	[EnumMember(Value = "0")]
	VkAndPartners,

	/// <summary>
	/// (если ad_format равен 1) Только ВКонтакте.
	/// </summary>
	[EnumMember(Value = "1")]
	VkOnly,

	/// <summary>
	/// (если ad_format равен 9) Все площадки.
	/// </summary>
	[EnumMember(Value = "all")]
	All,

	/// <summary>
	/// (если ad_format равен 9) Полная версия сайта.
	/// </summary>
	[EnumMember(Value = "desktop")]
	Desktop,

	/// <summary>
	/// (если ad_format равен 9) Мобильный сайт и приложения.
	/// </summary>
	[EnumMember(Value = "mobile")]
	Mobile
}