using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип интента, который требует подписку
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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