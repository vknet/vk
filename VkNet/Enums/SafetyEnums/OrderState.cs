using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Статус заказа.
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public sealed class OrderState : SafetyEnum<OrderState>
	{
		/// <summary>
		/// chargeable — неподтверждённый заказ. В это состояние заказы попадают в случае, если магазин не обрабатывает уведомления.
		/// </summary>
		public static readonly OrderState Chargeable = RegisterPossibleValue("chargeable");

		/// <summary>
		/// Отменённый заказ на этапе получения информации о товаре, например, была получена ошибка 20, "Товара не существует".
		/// В это состояние заказ может попасть из состояния chargeable.
		/// </summary>
		public static readonly OrderState Declined = RegisterPossibleValue("declined");

		/// <summary>
		/// cancelled — отменённый заказ. В это состояние заказ может попасть из состояния chargeable.
		/// </summary>
		public static readonly OrderState Cancelled = RegisterPossibleValue("cancelled");

		/// <summary>
		/// charged — оплаченный заказ. В это состояние заказ может попасть из состояния chargeable, либо сразу после оплаты, если приложение обрабатывает уведомления.
		/// </summary>
		public static readonly OrderState Charged = RegisterPossibleValue("charged");

		/// <summary>
		/// refunded — отменённый после оплаты заказ, голоса возвращены пользователю.
		/// </summary>
		public static readonly OrderState Refunded = RegisterPossibleValue("refunded");
	}
}