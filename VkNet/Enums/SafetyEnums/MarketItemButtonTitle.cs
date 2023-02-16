using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Текст на кнопке товара.
/// </summary>
public class MarketItemButtonTitle : SafetyEnum<MarketItemButtonTitle>
{
	/// <summary>
	/// Купить
	/// </summary>
	[EnumMember(Value = "Купить")]
	public static readonly MarketItemButtonTitle Buy = RegisterPossibleValue("Купить");

	/// <summary>
	/// Перейти в магазин
	/// </summary>
	[EnumMember(Value = "Перейти в магазин")]
	public static readonly MarketItemButtonTitle GoToTheStore = RegisterPossibleValue("Перейти в магазин");

	/// <summary>
	/// Купить билет
	/// </summary>
	[EnumMember(Value = "Купить билет")]
	public static readonly MarketItemButtonTitle BuyATicket = RegisterPossibleValue("Купить билет");
}