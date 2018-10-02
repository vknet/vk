namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип приложения.
	/// </summary>
	public class AppType : SafetyEnum<AppType>
	{
		/// <summary>
		/// Социальное приложение;
		/// </summary>
		public static readonly AppType App = RegisterPossibleValue("app");

		/// <summary>
		/// Игра;
		/// </summary>
		public static readonly AppType Game = RegisterPossibleValue("game");

		/// <summary>
		/// Подключаемый сайт;
		/// </summary>
		public static readonly AppType Site = RegisterPossibleValue("site");

		/// <summary>
		/// Отдельное приложение (для мобильного устройства).
		/// </summary>
		public static readonly AppType Standalone = RegisterPossibleValue("standalone");

		/// <summary>
		/// VK App приложение
		/// </summary>
		public static readonly AppType VkApp = RegisterPossibleValue("vk_app");

		/// <summary>
		/// VK App приложение
		/// </summary>
		public static readonly AppType CommunityApp = RegisterPossibleValue("community_app");

		/// <summary>
		/// HTML5 игра
		/// </summary>
		public static readonly AppType Html5Game = RegisterPossibleValue("html5_game");
	}
}