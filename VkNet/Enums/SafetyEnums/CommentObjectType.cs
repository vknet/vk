using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип комментариев.
/// </summary>
public sealed class CommentObjectType : SafetyEnum<CommentObjectType>
{
	/// <summary>
	/// Запись на стене пользователя или группы.
	/// </summary>
	[EnumMember(Value = "post")]
	public static readonly CommentObjectType Post = RegisterPossibleValue(value: "post");

	/// <summary>
	/// Фотография.
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly CommentObjectType Photo = RegisterPossibleValue(value: "photo");

	/// <summary>
	/// Видеозапись.
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly CommentObjectType Video = RegisterPossibleValue(value: "video");

	/// <summary>
	/// Обсуждение.
	/// </summary>
	[EnumMember(Value = "topic")]
	public static readonly CommentObjectType Topic = RegisterPossibleValue(value: "topic");

	/// <summary>
	/// Заметка.
	/// </summary>
	[EnumMember(Value = "note")]
	public static readonly CommentObjectType Note = RegisterPossibleValue(value: "note");
}