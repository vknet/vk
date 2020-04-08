namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Уровень полномочий пользователя в сообществе (Используется для задания
	/// полномочий пользователя в методе
	/// EditManager).
	/// </summary>
	public class ManagerRole : SafetyEnum<ManagerRole>
	{
		/// <summary>
		/// Создатель сообщества
		/// </summary>
		public static readonly ManagerRole Creator = RegisterPossibleValue(value: "creator");

		/// <summary>
		/// Пользователь является администратором сообщества.
		/// </summary>
		public static readonly ManagerRole Administrator = RegisterPossibleValue(value: "administrator");

		/// <summary>
		/// Пользователь является модератором собщества.
		/// </summary>
		public static readonly ManagerRole Moderator = RegisterPossibleValue(value: "moderator");

		/// <summary>
		/// Пользователь является редактором сообщества.
		/// </summary>
		public static readonly ManagerRole Editor = RegisterPossibleValue(value: "editor");
	}
}