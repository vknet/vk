using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Разделы среди которых нужно осуществить поиск, перечисленные через запятую:
/// friends – искать среди друзей
/// subscriptions – искать среди друзей и подписок пользователя список строк,
/// разделенных через запятую.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum UserSection
{
	/// <summary>
	/// Искать среди друзей.
	/// </summary>
	Friends,

	/// <summary>
	/// Искать среди друзей и подписок пользователя список строк, разделенных через
	/// запятую.
	/// </summary>
	Subscriptions
}