using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums;

/// <summary>
/// Тип источника альбома каталога
/// </summary>
[Serializable]
[JsonConverter(typeof(SafetyEnumJsonConverter))]
public class AudioAlbumType : SafetyEnum<AudioAlbumType>
{
	/// <summary>
	/// Collection.
	/// </summary>
	[EnumMember(Value = "collection")]
	public static readonly AudioAlbumType Collection = RegisterPossibleValue("collection");

	/// <summary>
	/// MainOnly.
	/// </summary>
	[EnumMember(Value = "main_only")]
	public static readonly AudioAlbumType MainOnly = RegisterPossibleValue("main_only");

	/// <summary>
	/// MainFeat.
	/// </summary>
	[EnumMember(Value = "main_feat")]
	public static readonly AudioAlbumType MainFeat = RegisterPossibleValue("main_feat");

	/// <summary>
	/// Playlist.
	/// </summary>
	[EnumMember(Value = "playlist")]
	public static readonly AudioAlbumType Playlist = RegisterPossibleValue("playlist");
}