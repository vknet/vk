using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Статус сервера
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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