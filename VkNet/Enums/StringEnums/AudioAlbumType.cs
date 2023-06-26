using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип источника альбома каталога
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AudioAlbumType
{
	/// <summary>
	/// Collection.
	/// </summary>
	Collection,

	/// <summary>
	/// MainOnly.
	/// </summary>
	MainOnly,

	/// <summary>
	/// MainFeat.
	/// </summary>
	MainFeat,

	/// <summary>
	/// Playlist.
	/// </summary>
	Playlist
}