using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип ответа, который необходимо получить.
/// </summary>
public class ResponseType : SafetyEnum<ResponseType>
{
	/// <summary>
	/// Токен.
	/// </summary>
	[EnumMember(Value = "token")]
	public static readonly ResponseType Token = RegisterPossibleValue("token");

	/// <summary>
	/// Код.
	/// </summary>
	[EnumMember(Value = "code")]
	public static readonly ResponseType Сode = RegisterPossibleValue("code");
}