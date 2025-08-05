using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип каталога
/// </summary>
[StringEnum]
[JsonConverter(typeof(TolerantStringEnumConverter))]
public enum AudioCatalogType
{
	/// <summary>
	/// AudiosSpecial - Специальные аудиозаписи.
	/// </summary>
	AudiosSpecial,

	/// <summary>
	/// Audios - Аудиозаписи.
	/// </summary>
	Audios,

	/// <summary>
	/// Playlists - Плейлисты.
	/// </summary>
	Playlists,

	/// <summary>
	/// TopAudios - Чарт Вконтакте.
	/// </summary>
	TopAudios,

	/// <summary>
	/// CustomImageBig - Большое изображение сообщества.
	/// </summary>
	CustomImageBig
}