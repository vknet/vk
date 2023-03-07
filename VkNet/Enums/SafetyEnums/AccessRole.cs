namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
[StringEnum]
public enum AccessRole
{
	/// <summary>
	/// Главный администратор
	/// </summary>
	Admin,

	/// <summary>
	/// Администратор
	/// </summary>
	Manager,

	/// <summary>
	/// Наблюдатель
	/// </summary>
	Reports
}