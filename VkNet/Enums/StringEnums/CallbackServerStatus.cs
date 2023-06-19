using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Статус сервера
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CallbackServerStatus
{
	/// <summary>
	/// Адрес не задан;
	/// </summary>
	[VkNetDefaultValue]
	Unconfigured,

	/// <summary>
	/// Подтвердить адрес не удалось
	/// </summary>
	Fail,

	/// <summary>
	/// Адрес ожидает подтверждения
	/// </summary>
	Wait,

	/// <summary>
	/// Сервер подключен
	/// </summary>
	Ok
}