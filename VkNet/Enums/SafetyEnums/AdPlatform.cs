namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Рекламные площадки, на которых будет показываться объявление. (если значение применимо к данному формату объявления)
	/// </summary>
	public sealed class AdPlatform : SafetyEnum<AdPlatform>
	{
		/// <summary>
		/// (если ad_format равен 1) ВКонтакте и сайты-партнёры.
		/// </summary>
		public static readonly AdPlatform VkAndPartners = RegisterPossibleValue("0");

		/// <summary>
		/// (если ad_format равен 1) Только ВКонтакте.
		/// </summary>
		public static readonly AdPlatform VkOnly = RegisterPossibleValue("1");

		/// <summary>
		/// (если ad_format равен 9) Все площадки.
		/// </summary>
		public static readonly AdPlatform All = RegisterPossibleValue("all");

		/// <summary>
		/// (если ad_format равен 9) Полная версия сайта.
		/// </summary>
		public static readonly AdPlatform Desktop = RegisterPossibleValue("desktop");

		/// <summary>
		/// (если ad_format равен 9) Мобильный сайт и приложения.
		/// </summary>
		public static readonly AdPlatform Mobile = RegisterPossibleValue("mobile");
	}
}