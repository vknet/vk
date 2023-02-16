using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип жалобы.
/// </summary>
public sealed class ReportType : SafetyEnum<ReportType>
{
	/// <summary>
	/// Порнография.
	/// </summary>
	[EnumMember(Value = "porn")]
	public static readonly ReportType Porn = RegisterPossibleValue(value: "porn");

	/// <summary>
	/// Рассылка спама.
	/// </summary>
	[EnumMember(Value = "spam")]
	public static readonly ReportType Spam = RegisterPossibleValue(value: "spam");

	/// <summary>
	/// Оскорбительное поведение.
	/// </summary>
	[EnumMember(Value = "insult")]
	public static readonly ReportType Insult = RegisterPossibleValue(value: "insult");

	/// <summary>
	/// Рекламная страница, засоряющая поиск.
	/// </summary>
	[EnumMember(Value = "advertisment")]
	public static readonly ReportType Advertisment = RegisterPossibleValue(value: "advertisment");
}