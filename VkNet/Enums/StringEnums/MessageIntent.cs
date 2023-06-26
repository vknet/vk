using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип интента, который требует подписку
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum MessageIntent
{
	/// <summary>
	/// Промо новость
	/// </summary>
	PromoNewsletter,

	/// <summary>
	/// Не промо новость.
	/// </summary>
	NonPromoNewsletter,

	/// <summary>
	/// Подтвержденное уведомление
	/// </summary>
	ConfirmedNotification
}