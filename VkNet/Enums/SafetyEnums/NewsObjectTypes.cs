using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Названия списков новостей, которые необходимо получить.
/// </summary>
public sealed class NewsObjectTypes : SafetyEnum<NewsObjectTypes>
{
	/// <summary>
	/// Запись на стене.
	/// </summary>
	[EnumMember(Value = "wall")]
	public static readonly NewsObjectTypes Wall = RegisterPossibleValue(value: "wall");

	/// <summary>
	/// Отметка на фотографии.
	/// </summary>
	[EnumMember(Value = "tag")]
	public static readonly NewsObjectTypes Tag = RegisterPossibleValue(value: "tag");

	/// <summary>
	/// Фотография профиля.
	/// </summary>
	[EnumMember(Value = "profilephoto")]
	public static readonly NewsObjectTypes ProfilePhoto = RegisterPossibleValue(value: "profilephoto");

	/// <summary>
	/// Видеозапись.
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly NewsObjectTypes Video = RegisterPossibleValue(value: "video");

	/// <summary>
	/// Фотография.
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly NewsObjectTypes Photo = RegisterPossibleValue(value: "photo");

	/// <summary>
	/// Аудиозапись.
	/// </summary>
	[EnumMember(Value = "audio")]
	public static readonly NewsObjectTypes Audio = RegisterPossibleValue(value: "audio");
}