namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Рейтинг приложений
	/// </summary>
	public sealed class AppRatingType : SafetyEnum<AppRatingType>
	{
		/// <summary>
		/// Рейтинг по уровням
		/// </summary>
		public static readonly AppRatingType Level = RegisterPossibleValue(value: "level");

		/// <summary>
		/// Рейтинг по очкам
		/// </summary>
		public static readonly AppRatingType Points = RegisterPossibleValue(value: "points");
	}
}