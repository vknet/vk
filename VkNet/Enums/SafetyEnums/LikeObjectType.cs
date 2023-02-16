using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип объекта (исп. в категории Likes)
/// </summary>
public class LikeObjectType : SafetyEnum<LikeObjectType>
{
	/// <summary>
	/// Запись на стене пользователя или группы
	/// </summary>
	[EnumMember(Value = "post")]
	public static readonly LikeObjectType Post = RegisterPossibleValue(value: "post");

	/// <summary>
	/// Комментарий к записи на стене
	/// </summary>
	[EnumMember(Value = "comment")]
	public static readonly LikeObjectType Comment = RegisterPossibleValue(value: "comment");

	/// <summary>
	/// Фотография
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly LikeObjectType Photo = RegisterPossibleValue(value: "photo");

	/// <summary>
	/// Аудиозапись
	/// </summary>
	[EnumMember(Value = "audio")]
	public static readonly LikeObjectType Audio = RegisterPossibleValue(value: "audio");

	/// <summary>
	/// Видеозапись
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly LikeObjectType Video = RegisterPossibleValue(value: "video");

	/// <summary>
	/// Заметка
	/// </summary>
	[EnumMember(Value = "note")]
	public static readonly LikeObjectType Note = RegisterPossibleValue(value: "note");

	/// <summary>
	/// Комментарий к фотографии
	/// </summary>
	[EnumMember(Value = "photo_comment")]
	public static readonly LikeObjectType PhotoComment = RegisterPossibleValue(value: "photo_comment");

	/// <summary>
	/// Комментарий к видеозаписи
	/// </summary>
	[EnumMember(Value = "video_comment")]
	public static readonly LikeObjectType VideoComment = RegisterPossibleValue(value: "video_comment");

	/// <summary>
	/// Комментарий в обсуждении
	/// </summary>
	[EnumMember(Value = "topic_comment")]
	public static readonly LikeObjectType TopicComment = RegisterPossibleValue(value: "topic_comment");

	/// <summary>
	/// Страница сайта, на котором установлен виджет «Мне нравится»
	/// </summary>
	[EnumMember(Value = "sitepage")]
	public static readonly LikeObjectType SitePage = RegisterPossibleValue(value: "sitepage");

	/// <summary>
	/// Товар
	/// </summary>
	[EnumMember(Value = "market")]
	public static readonly LikeObjectType Market = RegisterPossibleValue(value: "market");

	/// <summary>
	/// Комментарий к товару.
	/// </summary>
	[EnumMember(Value = "market_comment")]
	public static readonly LikeObjectType MarketComment = RegisterPossibleValue(value: "market_comment");
}