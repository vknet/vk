using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок сортировки членов группы.
/// </summary>
public sealed class GroupsMemberFilters : SafetyEnum<GroupsMemberFilters>
{
	/// <summary>
	/// Friends — будут возвращены только друзья в этом сообществе.
	/// </summary>
	[EnumMember(Value = "friends")]
	public static readonly GroupsMemberFilters Friends = RegisterPossibleValue(value: "friends");

	/// <summary>
	/// unsure — будут возвращены пользователи, которые выбрали «Возможно пойду» (если
	/// сообщество относится к
	/// мероприятиям).
	/// </summary>
	[EnumMember(Value = "unsure")]
	public static readonly GroupsMemberFilters Unsure = RegisterPossibleValue(value: "unsure");

	/// <summary>
	/// managers — будут возвращены только руководители сообщества (доступно при
	/// запросе с передачей access_token от имени
	/// администратора сообщества).
	/// строка.
	/// </summary>
	[EnumMember(Value = "managers")]
	public static readonly GroupsMemberFilters Managers = RegisterPossibleValue(value: "managers");

	/// <summary>
	/// donuts — будут возвращены доны
	/// строка.
	/// </summary>
	[EnumMember(Value = "donut")]
	public static readonly GroupsMemberFilters Donut = RegisterPossibleValue(value: "donut");
}