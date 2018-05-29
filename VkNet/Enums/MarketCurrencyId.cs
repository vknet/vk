using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Идентификатор валюты магазина.
	/// </summary>
	public enum MarketCurrencyId
	{
		/// <summary>
		/// 643 — российский рубль;
		/// </summary>
		[DefaultValue]
		Rub = 643

		, /// <summary>
		/// 980 — украинская гривна;
		/// </summary>
		Uah = 980

		, /// <summary>
		/// 398 — казахстанский тенге;
		/// </summary>
		Kzt = 398

		, /// <summary>
		/// 978 — евро;
		/// </summary>
		Eur = 978

		, /// <summary>
		/// 840 — доллар США.
		/// </summary>
		Usd = 840
	}
}