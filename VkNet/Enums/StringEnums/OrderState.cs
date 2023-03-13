using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Статус заказа.
/// </summary>
[StringEnum]
[JsonConverter(typeof(OrderStateJsonConverter))]
public enum OrderState
{
	/// <summary>
	/// chargeable — неподтверждённый заказ. В это состояние заказы попадают в случае, если магазин не обрабатывает уведомления.
	/// </summary>
	Chargeable,

	/// <summary>
	/// Отменённый заказ на этапе получения информации о товаре, например, была получена ошибка 20, "Товара не существует".
	/// В это состояние заказ может попасть из состояния chargeable.
	/// </summary>
	Declined,

	/// <summary>
	/// cancelled — отменённый заказ. В это состояние заказ может попасть из состояния chargeable.
	/// </summary>
	Cancelled,

	/// <summary>
	/// charged — оплаченный заказ. В это состояние заказ может попасть из состояния chargeable, либо сразу после оплаты, если приложение обрабатывает уведомления.
	/// </summary>
	Charged,

	/// <summary>
	/// refunded — отменённый после оплаты заказ, голоса возвращены пользователю.
	/// </summary>
	Refunded
}