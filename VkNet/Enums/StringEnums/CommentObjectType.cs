using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип комментариев.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum CommentObjectType
{
	/// <summary>
	/// Запись на стене пользователя или группы.
	/// </summary>
	Post,

	/// <summary>
	/// Фотография.
	/// </summary>
	Photo,

	/// <summary>
	/// Видеозапись.
	/// </summary>
	Video,

	/// <summary>
	/// Обсуждение.
	/// </summary>
	Topic,

	/// <summary>
	/// Заметка.
	/// </summary>
	Note
}