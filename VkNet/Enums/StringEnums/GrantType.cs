using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип авторизации.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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