namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Радиус поиска в метрах.
	/// </summary>
	public sealed class PhotoSearchRadius : SafetyEnum<PhotoSearchRadius>
	{
		/// <summary>
		/// 10, 100, 800, 6000, 50000 .
		/// </summary>
		public static readonly PhotoSearchRadius Ten = RegisterPossibleValue("10");

		/// <summary>
		/// Родительный.
		/// </summary>
		public static readonly PhotoSearchRadius OneHundred = RegisterPossibleValue("100");

		/// <summary>
		/// Дательный.
		/// </summary>
		public static readonly PhotoSearchRadius Eighty = RegisterPossibleValue("800");

		/// <summary>
		/// Винительный.
		/// </summary>
		public static readonly PhotoSearchRadius SixThousand = RegisterPossibleValue("6000");

		/// <summary>
		/// Творительный.
		/// </summary>
		public static readonly PhotoSearchRadius FiftyThousand = RegisterPossibleValue("50000");

	}
}