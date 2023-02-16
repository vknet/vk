using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип объекта поиска
/// </summary>
[Serializable]
public class SearchResultType : SafetyEnum<SearchResultType>
{
	/// <summary>
	/// Сообщество
	/// </summary>
	[EnumMember(Value = "group")]
	public static readonly SearchResultType Group = RegisterPossibleValue(value: "group");

	/// <summary>
	/// Профиль
	/// </summary>
	[EnumMember(Value = "profile")]
	public static readonly SearchResultType Profile = RegisterPossibleValue(value: "profile");
}