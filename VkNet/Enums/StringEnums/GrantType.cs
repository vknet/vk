using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип авторизации.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum GrantType
{
	/// <summary>
	/// Client Credentials Flow.
	/// </summary>
	ClientCredentials,

	/// <summary>
	/// Direct Auth Flow.
	/// </summary>
	Password
}