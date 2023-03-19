namespace VkNet.Enums;

/// <summary>
/// Статус заказа.
/// </summary>
public enum MarketOrderState
{
	New = 0,
	Matching = 1,
	Collecting = 2,
	Delivering = 3,
	Done = 4,
	Cancelled = 5,
	Refunded = 6
}