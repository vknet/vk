using System;
using Newtonsoft.Json;
using VkNet.Utils.JsonConverter;

namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Тип каталога
	/// </summary>
	[Serializable]
	[JsonConverter(typeof(SafetyEnumJsonConverter))]
	public class AudioCatalogType  : SafetyEnum<AudioCatalogType>
	{
		/// <summary>
		/// AudiosSpecial - Специальные аудиозаписи.
		/// </summary>
		public static readonly AudioCatalogType AudiosSpecial = RegisterPossibleValue("audios_special");

		/// <summary>
		/// Audios - Аудиозаписи.
		/// </summary>
		public static readonly AudioCatalogType Audios = RegisterPossibleValue("audios");

		/// <summary>
		/// Playlists - Плейлисты.
		/// </summary>
		public static readonly AudioCatalogType Playlists = RegisterPossibleValue("playlists");

		/// <summary>
		/// TopAudios - Чарт Вконтакте.
		/// </summary>
		public static readonly AudioCatalogType TopAudios = RegisterPossibleValue("top_audios");

		/// <summary>
		/// CustomImageBig - Большое изображение сообщества.
		/// </summary>
		public static readonly AudioCatalogType CustomImageBig = RegisterPossibleValue("custom_image_big");
	}
}