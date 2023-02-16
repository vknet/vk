using System;
using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Является опциональным и содержит следующие данные в зависимости от значения
/// поля type:
/// </summary>
[Serializable]
public class PostSourceData : SafetyEnum<PostSourceData>
{
	/// <summary>
	/// Изменение статуса под именем пользователя.
	/// </summary>
	[EnumMember(Value = "profile_activity")]
	public static readonly PostSourceData ProfileActivity = RegisterPossibleValue(value: "profile_activity");

	/// <summary>
	/// Изменение профильной фотографии пользователя.
	/// </summary>
	[EnumMember(Value = "profile_photo")]
	public static readonly PostSourceData ProfilePhoto = RegisterPossibleValue(value: "profile_photo");

	/// <summary>
	/// Виджет комментариев.
	/// </summary>
	[EnumMember(Value = "comments")]
	public static readonly PostSourceData Comments = RegisterPossibleValue(value: "comments");

	/// <summary>
	/// Виджет «Мне нравится».
	/// </summary>
	[EnumMember(Value = "like")]
	public static readonly PostSourceData Like = RegisterPossibleValue(value: "like");

	/// <summary>
	/// Виджет опросов.
	/// </summary>
	[EnumMember(Value = "poll")]
	public static readonly PostSourceData Poll = RegisterPossibleValue(value: "poll");
}