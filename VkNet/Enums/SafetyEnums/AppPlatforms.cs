namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Платформа для которой необходимо вернуть приложения.
	/// </summary>
	/// <remarks>
	/// По умолчанию используется web.
	/// </remarks>
	public sealed class AppPlatforms : SafetyEnum<AppPlatforms>
	{
		/// <summary>
		/// Популярные за день (по умолчанию);
		/// </summary>
		public static readonly AppPlatforms Ios = RegisterPossibleValue(value: "ios");

		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly AppPlatforms Android = RegisterPossibleValue(value: "android");

		/// <summary>
		/// По дате создания приложения
		/// </summary>
		public static readonly AppPlatforms WinPhone = RegisterPossibleValue(value: "winphone");

		/// <summary>
		/// По скорости роста
		/// </summary>
		public static readonly AppPlatforms Web = RegisterPossibleValue(value: "web");
	}
}