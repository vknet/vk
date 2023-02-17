using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Тип рекламного кабинета.
/// </summary>
public enum AccountType
{
	/// <summary>
	/// Обычный
	/// </summary>
	[EnumMember(Value = "general")]
	General,

	/// <summary>
	/// Обычный
	/// </summary>
	[EnumMember(Value = "agency")]
	Agency
}