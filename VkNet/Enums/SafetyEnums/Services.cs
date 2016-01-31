namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Сервисы
	/// </summary>
	public sealed class Services : SafetyEnum<Services>
	{
		/// <summary>
		/// The email
		/// </summary>
		public static readonly Services Email = RegisterPossibleValue("email");

		/// <summary>
		/// The phone
		/// </summary>
		public static readonly Services Phone = RegisterPossibleValue("phone");

		/// <summary>
		/// The twitter
		/// </summary>
		public static readonly Services Twitter = RegisterPossibleValue("twitter");

		/// <summary>
		/// The facebook
		/// </summary>
		public static readonly Services Facebook = RegisterPossibleValue("facebook");

		/// <summary>
		/// The odnoklassniki
		/// </summary>
		public static readonly Services Odnoklassniki = RegisterPossibleValue("odnoklassniki");

		/// <summary>
		/// The instagram
		/// </summary>
		public static readonly Services Instagram = RegisterPossibleValue("instagram");

		/// <summary>
		/// The google
		/// </summary>
		public static readonly Services Google = RegisterPossibleValue("google");
	}
}