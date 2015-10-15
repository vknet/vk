using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums
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
		public static readonly AppPlatforms Ios = RegisterPossibleValue("ios");
		/// <summary>
		/// По посещаемости
		/// </summary>
		public static readonly AppPlatforms Android = RegisterPossibleValue("android");
		/// <summary>
		/// По дате создания приложения
		/// </summary>
		public static readonly AppPlatforms WinPhone = RegisterPossibleValue("winphone");
		/// <summary>
		/// По скорости роста
		/// </summary>
		public static readonly AppPlatforms Web = RegisterPossibleValue("web");
	}
}