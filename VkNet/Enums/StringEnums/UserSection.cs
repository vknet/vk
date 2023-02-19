using System.Runtime.Serialization;

namespace VkNet.Enums;

/// <summary>
/// Разделы среди которых нужно осуществить поиск, перечисленные через запятую:
/// friends – искать среди друзей
/// subscriptions – искать среди друзей и подписок пользователя список строк,
/// разделенных через запятую.
/// </summary>
public enum UserSection
{
	/// <summary>
	/// Искать среди друзей.
	/// </summary>
	[EnumMember(Value = "friends")]
	Friends,

	/// <summary>
	/// Искать среди друзей и подписок пользователя список строк, разделенных через
	/// запятую.
	/// </summary>
	[EnumMember(Value = "subscriptions")]
	Subscriptions
}