using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Указывает, следует ли вернуть всех пользователей, добавивших объект в список
/// "Мне нравится" или только тех, которые
/// рассказали о нем друзьям
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum LikesFilter
{
	/// <summary>
	/// Возвращать информацию обо всех пользователях
	/// </summary>
	Likes,

	/// <summary>
	/// Возвращать информацию только о пользователях, рассказавших об объекте друзьям.
	/// </summary>
	Copies
}