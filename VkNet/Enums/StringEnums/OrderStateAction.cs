using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Действие статуса заказа.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum OrderStateAction
{
	/// <summary>
	/// cancel — отменить неподтверждённый заказ.
	/// </summary>
	Cancel,

	/// <summary>
	/// charge — подтвердить неподтверждённый заказ.
	/// Применяется только если не удалось обработать уведомление order_change_state.
	/// </summary>
	Charge,

	/// <summary>
	/// cancel — отменить неподтверждённый заказ.
	/// </summary>
	Refund
}