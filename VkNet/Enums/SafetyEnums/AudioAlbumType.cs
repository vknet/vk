using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип источника альбома каталога
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class AudioAlbumType  : SafetyEnum<AudioAlbumType>
	{
		/// <summary>
		/// Collection.
		/// </summary>
		public static readonly AudioAlbumType Collection = RegisterPossibleValue("collection");

		/// <summary>
		/// MainOnly.
		/// </summary>
		public static readonly AudioAlbumType MainOnly = RegisterPossibleValue("main_only");

		/// <summary>
		/// MainFeat.
		/// </summary>
		public static readonly AudioAlbumType MainFeat = RegisterPossibleValue("main_feat");

		/// <summary>
		/// Playlist.
		/// </summary>
		public static readonly AudioAlbumType Playlist = RegisterPossibleValue("playlist");
	}
}