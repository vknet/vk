using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Способ сортировки приложений
/// </summary>
[Serializable]
public sealed class PostTypeOrder : SafetyEnum<PostTypeOrder>
{
	/// <summary>
	/// Популярные за день (по умолчанию);
	/// </summary>
	[EnumMember(Value = "post")]
	public static readonly PostTypeOrder Post = RegisterPossibleValue(value: "post");

	/// <summary>
	/// По посещаемости
	/// </summary>
	[EnumMember(Value = "copy")]
	public static readonly PostTypeOrder Copy = RegisterPossibleValue(value: "copy");
}