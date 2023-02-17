using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>

public enum AccessRole
{
	/// <summary>
	/// Главный администратор
	/// </summary>
	[EnumMember(Value = "admin")]
	Admin,

	/// <summary>
	/// Администратор
	/// </summary>
	[EnumMember(Value = "manager")]
	Manager,

	/// <summary>
	/// Наблюдатель
	/// </summary>
	[EnumMember(Value = "reports")]
	Reports
}