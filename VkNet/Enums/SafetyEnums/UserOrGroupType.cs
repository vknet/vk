namespace VkNet.Enums.SafetyEnums
{

	/// <summary>
	/// Пользователь или сообщество.
	/// </summary>
	public class UserOrGroupType : SafetyEnum<UserOrGroupType>
	{
		/// <summary>
		/// Пользователь.
		/// </summary>
		public static readonly UserOrGroupType User = RegisterPossibleValue("user");

		/// <summary>
		/// Сообщество.
		/// </summary>
		public static readonly UserOrGroupType Group = RegisterPossibleValue("group");
	}
}