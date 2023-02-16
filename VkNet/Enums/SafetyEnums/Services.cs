using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Сервисы
/// </summary>
public sealed class Services : SafetyEnum<Services>
{
	/// <summary>
	/// The email
	/// </summary>
	[EnumMember(Value = "email")]
	public static readonly Services Email = RegisterPossibleValue(value: "email");

	/// <summary>
	/// The phone
	/// </summary>
	[EnumMember(Value = "phone")]
	public static readonly Services Phone = RegisterPossibleValue(value: "phone");

	/// <summary>
	/// The twitter
	/// </summary>
	[EnumMember(Value = "twitter")]
	public static readonly Services Twitter = RegisterPossibleValue(value: "twitter");

	/// <summary>
	/// The facebook
	/// </summary>
	[EnumMember(Value = "facebook")]
	public static readonly Services Facebook = RegisterPossibleValue(value: "facebook");

	/// <summary>
	/// The odnoklassniki
	/// </summary>
	[EnumMember(Value = "odnoklassniki")]
	public static readonly Services Odnoklassniki = RegisterPossibleValue(value: "odnoklassniki");

	/// <summary>
	/// The instagram
	/// </summary>
	[EnumMember(Value = "instagram")]
	public static readonly Services Instagram = RegisterPossibleValue(value: "instagram");

	/// <summary>
	/// The google
	/// </summary>
	[EnumMember(Value = "google")]
	public static readonly Services Google = RegisterPossibleValue(value: "google");
}