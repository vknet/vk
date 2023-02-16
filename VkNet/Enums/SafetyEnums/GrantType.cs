using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип авторизации.
/// </summary>
public sealed class GrantType : SafetyEnum<GrantType>
{
	/// <summary>
	/// Client Credentials Flow.
	/// </summary>
	[EnumMember(Value = "client_credentials")]
	public static readonly GrantType ClientCredentials = RegisterPossibleValue("client_credentials");

	/// <summary>
	/// Direct Auth Flow.
	/// </summary>
	[EnumMember(Value = "password")]
	public static readonly GrantType Password = RegisterPossibleValue("password");
}