using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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