using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип интента, который требует подписку
/// </summary>
[Serializable]
[JsonConverter(converterType: typeof(SafetyEnumJsonConverter))]
public class MessageIntent : SafetyEnum<MessageIntent>
{
	/// <summary>
	/// Промо новость
	/// </summary>
	[EnumMember(Value = "promo_newsletter")]
	public static readonly MessageIntent PromoNewsletter = RegisterPossibleValue("promo_newsletter");

	/// <summary>
	/// Не промо новость.
	/// </summary>
	[EnumMember(Value = "non_promo_newsletter")]
	public static readonly MessageIntent NonPromoNewsletter = RegisterPossibleValue("non_promo_newsletter");

	/// <summary>
	/// Подтвержденное уведомление
	/// </summary>
	[EnumMember(Value = "confirmed_notification")]
	public static readonly MessageIntent ConfirmedNotification = RegisterPossibleValue("confirmed_notification");
}