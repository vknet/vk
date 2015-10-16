using VkNet.Enums.SafetyEnums;

namespace VkNet.Enums
{
	/// <summary>
	/// Рейтинг приложений
	/// </summary>
	public sealed class AppRatingType : SafetyEnum<AppRatingType>
	{
		/// <summary>
		/// Рейтинг по уровням
		/// </summary>
		public static readonly AppRatingType Level = RegisterPossibleValue("level");
		/// <summary>
		/// Рейтинг по очкам 
		/// </summary>
		public static readonly AppRatingType Points = RegisterPossibleValue("points");
	}
}