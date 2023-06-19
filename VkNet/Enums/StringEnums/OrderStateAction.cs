using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Действие статуса заказа.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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