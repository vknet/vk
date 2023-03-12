using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип запроса для приложений
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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