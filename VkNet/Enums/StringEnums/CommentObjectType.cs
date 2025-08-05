using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип комментариев.
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
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