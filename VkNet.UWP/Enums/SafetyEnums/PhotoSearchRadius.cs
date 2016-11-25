namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Радиус поиска в метрах.
	/// </summary>
	public sealed class PhotoSearchRadius : SafetyEnum<PhotoSearchRadius>
	{
		/// <summary>
		/// 10.
		/// </summary>
		public static readonly PhotoSearchRadius Ten = RegisterPossibleValue("10");

		/// <summary>
		/// 100.
		/// </summary>
		public static readonly PhotoSearchRadius OneHundred = RegisterPossibleValue("100");

		/// <summary>
		/// 800.
		/// </summary>
		public static readonly PhotoSearchRadius Eighty = RegisterPossibleValue("800");

		/// <summary>
		/// 6000.
		/// </summary>
		public static readonly PhotoSearchRadius SixThousand = RegisterPossibleValue("6000");

		/// <summary>
		/// 50000.
		/// </summary>
		public static readonly PhotoSearchRadius FiftyThousand = RegisterPossibleValue("50000");

	}
}