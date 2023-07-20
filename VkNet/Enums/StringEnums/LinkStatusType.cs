using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип статуса ссылки
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum LinkStatusType
{
	/// <summary>
	/// Ссылку допустимо использовать в рекламных объявлениях;
	/// </summary>
	Allowed,

	/// <summary>
	/// Ссылку допустимо использовать в рекламных объявлениях;
	/// </summary>
	Disallowed,

	/// <summary>
	/// Ссылку допустимо использовать в рекламных объявлениях;
	/// </summary>
	InProgress
}