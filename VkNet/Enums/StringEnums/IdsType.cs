using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum IdsType
{
	/// <summary>
	/// Объявление.
	/// </summary>
	Ad,

	/// <summary>
	/// Кампания.
	/// </summary>
	Campaign
}