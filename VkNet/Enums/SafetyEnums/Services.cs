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
		public static readonly Services Email = RegisterPossibleValue(value: "email");

		/// <summary>
		/// The phone
		/// </summary>
		public static readonly Services Phone = RegisterPossibleValue(value: "phone");

		/// <summary>
		/// The twitter
		/// </summary>
		public static readonly Services Twitter = RegisterPossibleValue(value: "twitter");

		/// <summary>
		/// The facebook
		/// </summary>
		public static readonly Services Facebook = RegisterPossibleValue(value: "facebook");

		/// <summary>
		/// The odnoklassniki
		/// </summary>
		public static readonly Services Odnoklassniki = RegisterPossibleValue(value: "odnoklassniki");

		/// <summary>
		/// The instagram
		/// </summary>
		public static readonly Services Instagram = RegisterPossibleValue(value: "instagram");

		/// <summary>
		/// The google
		/// </summary>
		public static readonly Services Google = RegisterPossibleValue(value: "google");
	}
}