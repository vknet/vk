using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип объекта (исп. в категории Likes)
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum LikeObjectType
{
	/// <summary>
	/// Запись на стене пользователя или группы
	/// </summary>
	Post,

	/// <summary>
	/// Комментарий к записи на стене
	/// </summary>
	Comment,

	/// <summary>
	/// Фотография
	/// </summary>
	Photo,

	/// <summary>
	/// Аудиозапись
	/// </summary>
	Audio,

	/// <summary>
	/// Видеозапись
	/// </summary>
	Video,

	/// <summary>
	/// Заметка
	/// </summary>
	Note,

	/// <summary>
	/// Комментарий к фотографии
	/// </summary>
	PhotoComment,

	/// <summary>
	/// Комментарий к видеозаписи
	/// </summary>
	VideoComment,

	/// <summary>
	/// Комментарий в обсуждении
	/// </summary>
	TopicComment,

	/// <summary>
	/// Страница сайта, на котором установлен виджет «Мне нравится»
	/// </summary>
	Sitepage,

	/// <summary>
	/// Товар
	/// </summary>
	Market,

	/// <summary>
	/// Комментарий к товару.
	/// </summary>
	MarketComment
}