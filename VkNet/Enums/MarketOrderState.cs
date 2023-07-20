namespace VkNet.Enums;

/// <summary>
/// Статус заказа.
/// </summary>
public enum MarketOrderState
{
	/// <summary>
	/// Новый
	/// </summary>
	New = 0,

	/// <summary>
	/// Согласуется
	/// </summary>
	Matching = 1,

	/// <summary>
	/// Собирается
	/// </summary>
	Collecting = 2,

	/// <summary>
	/// Доставляется
	/// </summary>
	Delivering = 3,

	/// <summary>
	/// Выполнен
	/// </summary>
	Done = 4,

	/// <summary>
	/// Отменен
	/// </summary>
	Cancelled = 5,

	/// <summary>
	/// Возвращен
	/// </summary>
	Refunded = 6
}