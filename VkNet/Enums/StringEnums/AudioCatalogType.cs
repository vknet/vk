using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип каталога
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
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