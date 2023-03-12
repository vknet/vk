using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Метка, которая обозначает приблизительное содержание сообщения от сообщества
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum Intent
{
	/// <summary>
	/// Для рекламной рассылки от ботов.
	/// </summary>
	PromoNewsletter,

	/// <summary>
	/// Рекламный API / монетизация.
	/// </summary>
	BotAdInvite,

	/// <summary>
	/// Рекламный API / монетизация.
	/// </summary>
	BotAdPromo,

	/// <summary>
	/// Информационные рассылки.
	/// </summary>
	NonPromoNewsLetter,

	/// <summary>
	/// Любые уведомления о событиях или действиях, на которые пользователь дал согласие.
	/// </summary>
	ConfirmedNotification,

	/// <summary>
	/// Обновления/уведомления о покупке, сделанной пользователем.
	/// </summary>
	PurchaseUpdate,

	/// <summary>
	/// Нерегулярные обновления /уведомления, связанные с аккаунтом или приложением.
	/// </summary>
	AccountUpdate,

	/// <summary>
	/// Уведомления от игр; ретеншен-сообщения; уведомления, связанные с дейтингом, и т. д.
	/// </summary>
	GameNotification,

	/// <summary>
	/// Ответы сотрудников поддержки сервиса на запросы пользователя.
	/// </summary>
	CustomerSupport,

	/// <summary>
	/// Стандартный интент, подставляется автоматически если не указан другой.
	/// </summary>
	Default
}