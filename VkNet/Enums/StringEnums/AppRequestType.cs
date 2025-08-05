using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип запроса для приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum AppRequestType
{
	/// <summary>
	/// В случае если запрос отправляется пользователю, не установившему приложение
	/// </summary>
	Invite,

	/// <summary>
	/// В случае если пользователь уже установил приложение
	/// </summary>
	Request
}