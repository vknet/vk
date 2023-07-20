using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип объекта, добавленного в закладки.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum FaveType
{
	/// <summary>
	/// Запись на стене.
	/// </summary>
	Post,

	/// <summary>
	/// Видеозапись.
	/// </summary>
	Video,

	/// <summary>
	/// Товар.
	/// </summary>
	Product,

	/// <summary>
	/// Статья.
	/// </summary>
	Article,

	/// <summary>
	/// Ссылки.
	/// </summary>
	Link,

	/// <summary>
	/// Подкаст.
	/// </summary>
	Podcast
}