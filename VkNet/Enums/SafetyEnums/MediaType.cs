using System.Runtime.Serialization;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип медиавложения.
/// </summary>
public sealed class MediaType : SafetyEnum<MediaType>
{
	/// <summary>
	/// Фотографии.
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly MediaType Photo = RegisterPossibleValue("photo");

	/// <summary>
	/// Видеозаписи.
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly MediaType Video = RegisterPossibleValue("video");

	/// <summary>
	/// Аудиозаписи.
	/// </summary>
	[EnumMember(Value = "audio")]
	public static readonly MediaType Audio = RegisterPossibleValue("audio");

	/// <summary>
	/// Аудио сообщение
	/// </summary>
	[EnumMember(Value = "audio_message")]
	public static readonly MediaType AudioMessage = RegisterPossibleValue("audio_message");

	/// <summary>
	/// Документы.
	/// </summary>
	[EnumMember(Value = "doc")]
	public static readonly MediaType Doc = RegisterPossibleValue("doc");

	/// <summary>
	/// Ссылки.
	/// </summary>
	[EnumMember(Value = "link")]
	public static readonly MediaType Link = RegisterPossibleValue("link");

	/// <summary>
	/// Товары.
	/// </summary>
	[EnumMember(Value = "market")]
	public static readonly MediaType Market = RegisterPossibleValue("market");

	/// <summary>
	/// Записи.
	/// </summary>
	[EnumMember(Value = "wall")]
	public static readonly MediaType Wall = RegisterPossibleValue("wall");

	/// <summary>
	/// Ссылки, товары и записи.
	/// </summary>
	[EnumMember(Value = "share")]
	public static readonly MediaType Share = RegisterPossibleValue("share");

	/// <summary>
	/// Граффити.
	/// </summary>
	[EnumMember(Value = "graffiti")]
	public static readonly MediaType Graffiti = RegisterPossibleValue("graffiti");
}