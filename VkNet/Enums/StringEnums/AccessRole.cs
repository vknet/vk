using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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