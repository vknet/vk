namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип страницы.
	/// </summary>
	public class FavePageType : SafetyEnum<FavePageType>
	{
		/// <summary>
		/// Пользователи.
		/// </summary>
		public static readonly FavePageType Users = RegisterPossibleValue("users");

		/// <summary>
		/// Сообщества.
		/// </summary>
		public static readonly FavePageType Videos = RegisterPossibleValue("groups");

		/// <summary>
		/// Топ сообществ и пользователей.
		/// </summary>
		public static readonly FavePageType Hints = RegisterPossibleValue("hints");
	}
}