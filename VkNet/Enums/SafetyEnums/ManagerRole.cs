namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Уровень полномочий пользователя в сообществе (Используется для задания
	/// полномочий пользователя в методе
	/// EditManager).
	/// </summary>
	public sealed class ManagerRole : SafetyEnum<ManagerRole>
	{
		/// <summary>
		/// Пользователь является модератором собщества.
		/// </summary>
		public static readonly ManagerRole Moderator = RegisterPossibleValue(value: "moderator");

		/// <summary>
		/// Пользователь является редактором сообщества.
		/// </summary>
		public static readonly ManagerRole Editor = RegisterPossibleValue(value: "editor");

		/// <summary>
		/// Пользователь является администратором сообщества.
		/// </summary>
		public static readonly ManagerRole Administrator = RegisterPossibleValue(value: "administrator");
	}
}