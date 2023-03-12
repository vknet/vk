using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип медиавложения.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum MediaType
{
	/// <summary>
	/// Фотографии.
	/// </summary>
	Photo,

	/// <summary>
	/// Видеозаписи.
	/// </summary>
	Video,

	/// <summary>
	/// Аудиозаписи.
	/// </summary>
	Audio,

	/// <summary>
	/// Аудио сообщение
	/// </summary>
	AudioMessage,

	/// <summary>
	/// Документы.
	/// </summary>
	Doc,

	/// <summary>
	/// Ссылки.
	/// </summary>
	Link,

	/// <summary>
	/// Товары.
	/// </summary>
	Market,

	/// <summary>
	/// Записи.
	/// </summary>
	Wall,

	/// <summary>
	/// Ссылки, товары и записи.
	/// </summary>
	Share,

	/// <summary>
	/// Граффити.
	/// </summary>
	Graffiti
}