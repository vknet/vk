using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип источника каталога
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class AudioCatalogSourceType : SafetyEnum<AudioCatalogSourceType>
	{
		/// <summary>
		/// RecomsRecoms - Выводит рекомандации специально для Вас.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsRecoms = RegisterPossibleValue("recoms_recoms");

		/// <summary>
		/// RecomsNewAudios - Выводит новинки.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsNewAudios = RegisterPossibleValue("recoms_new_audios");

		/// <summary>
		/// RecomsNewAlbums - Выводит новые альбомы.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsNewAlbums = RegisterPossibleValue("recoms_new_albums");

		/// <summary>
		/// RecomsTopAudiosGlobal - Выводит чарт ВКонтакте.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsTopAudiosGlobal = RegisterPossibleValue("recoms_top_audios_global");

		/// <summary>
		/// GenreRap - Выводит жанры Рэп &amp; Хип-Хоп.
		/// </summary>
		public static readonly AudioCatalogSourceType GenreRap = RegisterPossibleValue("genre_rap");

		/// <summary>
		/// GenrePop - Выводит жанр Поп
		/// </summary>
		public static readonly AudioCatalogSourceType GenrePop = RegisterPossibleValue("genre_pop");

		/// <summary>
		/// GenreRock - Выводит жанр Рок.
		/// </summary>
		public static readonly AudioCatalogSourceType GenreRock = RegisterPossibleValue("genre_rock");

		/// <summary>
		/// RecomsRecentAudios - Выводит недавно прослушанные.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsRecentAudios = RegisterPossibleValue("recoms_recent_audios");

		/// <summary>
		/// RecomsMoodPlaylists - Выводит музыку под настроение.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsMoodPlaylists = RegisterPossibleValue("recoms_mood_playlists");

		/// <summary>
		/// EditorsPlaylists - Выводит выбор редакции.
		/// </summary>
		public static readonly AudioCatalogSourceType EditorsPlaylists = RegisterPossibleValue("editors_playlists");

		/// <summary>
		/// Collections - Выводит музыкальные подборки.
		/// </summary>
		public static readonly AudioCatalogSourceType Collections = RegisterPossibleValue("collections");

		/// <summary>
		/// AnyCasePlaylists - Выводит плейлисты на любой случай.
		/// </summary>
		public static readonly AudioCatalogSourceType AnyCasePlaylists = RegisterPossibleValue("any_case_playlists");

		/// <summary>
		/// RecomsNewArtists - Выводит новые имена.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsNewArtists = RegisterPossibleValue("recoms_new_artists");

		/// <summary>
		/// RecomsRecentRecommendation - Выводит похожее на прослушанное.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsRecentRecommendation = RegisterPossibleValue("recoms_recent_recommendation");

		/// <summary>
		/// RecomsCommunities - Выводит рекомендации сообществ.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsCommunities = RegisterPossibleValue("recoms_communities");

		/// <summary>
		/// RecomsFriends - Выводит музыку друзей.
		/// </summary>
		public static readonly AudioCatalogSourceType RecomsFriends = RegisterPossibleValue("recoms_friends");
	}
}