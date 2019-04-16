namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Текст на кнопке товара.
	/// </summary>
	public class MarketItemButtonTitle : SafetyEnum<MarketItemButtonTitle>
	{
		/// <summary>
		/// Купить
		/// </summary>
		public static readonly MarketItemButtonTitle Buy = RegisterPossibleValue("Купить");

		/// <summary>
		/// Перейти в магазин
		/// </summary>
		public static readonly MarketItemButtonTitle GoToTheStore = RegisterPossibleValue("Перейти в магазин");

		/// <summary>
		/// Купить билет
		/// </summary>
		public static readonly MarketItemButtonTitle BuyATicket = RegisterPossibleValue("Купить билет");
	}
}