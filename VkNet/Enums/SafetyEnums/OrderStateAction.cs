using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Действие статуса заказа.
/// </summary>
[Serializable]
public sealed class OrderStateAction : SafetyEnum<OrderStateAction>
{
	/// <summary>
	/// cancel — отменить неподтверждённый заказ.
	/// </summary>
	[EnumMember(Value = "cancel")]
	public static readonly OrderStateAction Cancel = RegisterPossibleValue("cancel");

	/// <summary>
	/// charge — подтвердить неподтверждённый заказ.
	/// Применяется только если не удалось обработать уведомление order_change_state.
	/// </summary>
	[EnumMember(Value = "charge")]
	public static readonly OrderStateAction Charge = RegisterPossibleValue("charge");

	/// <summary>
	/// cancel — отменить неподтверждённый заказ.
	/// </summary>
	[EnumMember(Value = "refund")]
	public static readonly OrderStateAction Refund = RegisterPossibleValue("refund");
}