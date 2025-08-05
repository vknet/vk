

using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип продуктов
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum ProductType
{
	/// <summary>
	/// Стикеры
	/// </summary>
	Stickers,

	/// <summary>
	/// Голоса
	/// </summary>
	Votes
}