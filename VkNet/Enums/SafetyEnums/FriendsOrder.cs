using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Порядок, в котором необходимо вернуть список друзей.
/// </summary>
public sealed class FriendsOrder : SafetyEnum<FriendsOrder>
{
	/// <summary>
	/// Сортировать по имени (работает только при переданном параметре fields).
	/// </summary>
	[EnumMember(Value = "name")]
	public static readonly FriendsOrder Name = RegisterPossibleValue(value: "name");

	/// <summary>
	/// Сортировать по рейтингу, аналогично тому, как друзья сортируются в разделе "Мои
	/// друзья".
	/// </summary>
	[EnumMember(Value = "hints")]
	public static readonly FriendsOrder Hints = RegisterPossibleValue(value: "hints");

	/// <summary>
	/// Возвращает друзей в случайном порядке.
	/// </summary>
	[EnumMember(Value = "random")]
	public static readonly FriendsOrder Random = RegisterPossibleValue(value: "random");
}