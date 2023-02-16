using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип записи post, copy, reply, postpone, suggest
/// </summary>
[Serializable]
public sealed class PostType : SafetyEnum<PostType>
{
	/// <summary>
	/// Запись на стене (по умолчанию);
	/// v5.6+ - репосты имею тип "post"
	/// </summary>
	[EnumMember(Value = "post")]
	public static readonly PostType Post = RegisterPossibleValue(value: "post");

	/// <summary>
	/// Репост до версии 5.6 (сейчас не описано)
	/// </summary>
	[EnumMember(Value = "copy")]
	public static readonly PostType Copy = RegisterPossibleValue(value: "copy");

	/// <summary>
	/// Ответ на запись с закрытыми комментариями (м.б. еще что-то)
	/// </summary>
	[EnumMember(Value = "reply")]
	public static readonly PostType Reply = RegisterPossibleValue(value: "reply");

	/// <summary>
	/// Закрепленная запись
	/// </summary>
	[EnumMember(Value = "postpone")]
	public static readonly PostType Postpone = RegisterPossibleValue(value: "postpone");

	/// <summary>
	/// Предложенная запись
	/// </summary>
	[EnumMember(Value = "suggest")]
	public static readonly PostType Suggest = RegisterPossibleValue(value: "suggest");
}