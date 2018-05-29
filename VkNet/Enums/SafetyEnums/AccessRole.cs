namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Права пользователя в рекламном кабинете.
	/// </summary>
	public sealed class AccessRole : SafetyEnum<AccessRole>
	{
		/// <summary>
		/// Главный администратор
		/// </summary>
		public static readonly AccessRole Admin = RegisterPossibleValue(value: "admin");

		/// <summary>
		/// Администратор
		/// </summary>
		public static readonly AccessRole Manager = RegisterPossibleValue(value: "manager");

		/// <summary>
		/// Наблюдатель
		/// </summary>
		public static readonly AccessRole Reports = RegisterPossibleValue(value: "reports");
	}
}