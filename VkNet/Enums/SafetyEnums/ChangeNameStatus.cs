using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Статус заявки на изменение имени
/// </summary>
public sealed class ChangeNameStatus : SafetyEnum<ChangeNameStatus>
{
	/// <summary>
	/// Заявка рассматривается
	/// </summary>
	[EnumMember(Value = "processing")]
	public static readonly ChangeNameStatus Processing = RegisterPossibleValue(value: "processing");

	/// <summary>
	/// Заявка отклонена
	/// </summary>
	[EnumMember(Value = "declined")]
	public static readonly ChangeNameStatus Declined = RegisterPossibleValue(value: "declined");

	/// <summary>
	/// Имя было успешно изменено
	/// </summary>
	[EnumMember(Value = "success")]
	public static readonly ChangeNameStatus Success = RegisterPossibleValue(value: "success");

	/// <summary>
	/// Недавно уже была одобрена заявка, повторную заявку можно подать не раньше даты,
	/// указанной в поле
	/// ChangeNameRequest.RepeatDate
	/// </summary>
	[EnumMember(Value = "was_accepted")]
	public static readonly ChangeNameStatus WasAccepted = RegisterPossibleValue(value: "was_accepted");

	/// <summary>
	/// Предыдущая заявка была отклонена, повторную заявку можно подать не раньше даты,
	/// указанной в поле
	/// ChangeNameRequest.RepeatDate
	/// </summary>
	[EnumMember(Value = "was_declined")]
	public static readonly ChangeNameStatus WasDeclined = RegisterPossibleValue(value: "was_declined");
}