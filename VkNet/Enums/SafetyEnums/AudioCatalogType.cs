using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип каталога
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class AudioCatalogType : SafetyEnum<AudioCatalogType>
{
	/// <summary>
	/// AudiosSpecial - Специальные аудиозаписи.
	/// </summary>
	[EnumMember(Value = "audios_special")]
	public static readonly AudioCatalogType AudiosSpecial = RegisterPossibleValue("audios_special");

	/// <summary>
	/// Audios - Аудиозаписи.
	/// </summary>
	[EnumMember(Value = "audios")]
	public static readonly AudioCatalogType Audios = RegisterPossibleValue("audios");

	/// <summary>
	/// Playlists - Плейлисты.
	/// </summary>
	[EnumMember(Value = "playlists")]
	public static readonly AudioCatalogType Playlists = RegisterPossibleValue("playlists");

	/// <summary>
	/// TopAudios - Чарт Вконтакте.
	/// </summary>
	[EnumMember(Value = "top_audios")]
	public static readonly AudioCatalogType TopAudios = RegisterPossibleValue("top_audios");

	/// <summary>
	/// CustomImageBig - Большое изображение сообщества.
	/// </summary>
	[EnumMember(Value = "custom_image_big")]
	public static readonly AudioCatalogType CustomImageBig = RegisterPossibleValue("custom_image_big");
}