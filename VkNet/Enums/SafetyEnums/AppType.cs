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
		public static readonly AppType App = RegisterPossibleValue(value: "app");

		/// <summary>
		/// Игра;
		/// </summary>
		public static readonly AppType Game = RegisterPossibleValue(value: "game");

		/// <summary>
		/// Подключаемый сайт;
		/// </summary>
		public static readonly AppType Site = RegisterPossibleValue(value: "site");

		/// <summary>
		/// Отдельное приложение (для мобильного устройства).
		/// </summary>
		public static readonly AppType Standalone = RegisterPossibleValue(value: "standalone");
	}
}