using System;

namespace VkNet.Enums.SafetyEnums
{
	[Serializable]
	public sealed class OrderStateAction: SafetyEnum<OrderStateAction>
	{
		/// <summary>
		/// cancel — отменить неподтверждённый заказ.
		/// </summary>
		public static readonly OrderStateAction Cancel  = RegisterPossibleValue("cancel");
		/// <summary>
		/// charge — подтвердить неподтверждённый заказ.
		/// Применяется только если не удалось обработать уведомление order_change_state.
		/// </summary>
		public static readonly OrderStateAction Charge  = RegisterPossibleValue("charge");
		/// <summary>
		/// cancel — отменить неподтверждённый заказ.
		/// </summary>
		public static readonly OrderStateAction Refund  = RegisterPossibleValue("refund");
	}
}