using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Единица времени для подсчета статистики.
/// </summary>
public class LinkStatInterval : SafetyEnum<LinkStatInterval>
{
	/// <summary>
	/// Час
	/// </summary>
	[EnumMember(Value = "hour")]
	public static readonly LinkStatInterval Hour = RegisterPossibleValue(value: "hour");

	/// <summary>
	/// День
	/// </summary>
	[DefaultValue]
	[EnumMember(Value = "day")]
	public static readonly LinkStatInterval Day = RegisterPossibleValue(value: "day");

	/// <summary>
	/// Неделя
	/// </summary>
	[EnumMember(Value = "week")]
	public static readonly LinkStatInterval Week = RegisterPossibleValue(value: "week");

	/// <summary>
	/// Месяц
	/// </summary>
	[EnumMember(Value = "month")]
	public static readonly LinkStatInterval Month = RegisterPossibleValue(value: "month");

	/// <summary>
	/// Все время с момента создания ссылки
	/// </summary>
	[EnumMember(Value = "forever")]
	public static readonly LinkStatInterval Forever = RegisterPossibleValue(value: "forever");
}