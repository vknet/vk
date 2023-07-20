using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип источника каталога
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AudioCatalogSourceType
{
	/// <summary>
	/// RecomsRecoms - Выводит рекомандации специально для Вас.
	/// </summary>
	RecomsRecoms,

	/// <summary>
	/// RecomsNewAudios - Выводит новинки.
	/// </summary>
	RecomsNewAudios,

	/// <summary>
	/// RecomsNewAlbums - Выводит новые альбомы.
	/// </summary>
	RecomsNewAlbums,

	/// <summary>
	/// RecomsTopAudiosGlobal - Выводит чарт ВКонтакте.
	/// </summary>
	RecomsTopAudiosGlobal,

	/// <summary>
	/// GenreRap - Выводит жанры Рэп &amp; Хип-Хоп.
	/// </summary>
	GenreRap,

	/// <summary>
	/// GenrePop - Выводит жанр Поп
	/// </summary>
	GenrePop,

	/// <summary>
	/// GenreRock - Выводит жанр Рок.
	/// </summary>
	GenreRock,

	/// <summary>
	/// RecomsRecentAudios - Выводит недавно прослушанные.
	/// </summary>
	RecomsRecentAudios,

	/// <summary>
	/// RecomsMoodPlaylists - Выводит музыку под настроение.
	/// </summary>
	RecomsMoodPlaylists,

	/// <summary>
	/// EditorsPlaylists - Выводит выбор редакции.
	/// </summary>
	EditorsPlaylists,

	/// <summary>
	/// Collections - Выводит музыкальные подборки.
	/// </summary>
	Collections,

	/// <summary>
	/// AnyCasePlaylists - Выводит плейлисты на любой случай.
	/// </summary>
	AnyCasePlaylists,

	/// <summary>
	/// RecomsNewArtists - Выводит новые имена.
	/// </summary>
	RecomsNewArtists,

	/// <summary>
	/// RecomsRecentRecommendation - Выводит похожее на прослушанное.
	/// </summary>
	RecomsRecentRecommendation,

	/// <summary>
	/// RecomsCommunities - Выводит рекомендации сообществ.
	/// </summary>
	RecomsCommunities,

	/// <summary>
	/// RecomsFriends - Выводит музыку друзей.
	/// </summary>
	RecomsFriends
}