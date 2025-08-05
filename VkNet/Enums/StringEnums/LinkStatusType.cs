using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип статуса ссылки
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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