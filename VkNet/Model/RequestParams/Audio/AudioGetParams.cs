using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры метода audio.get
	/// </summary>
	[Serializable]
	public class AudioGetParams
	{
		/// <summary>
		/// Идентификатор владельца аудиозаписей (пользователь или сообщество). Обратите
		/// внимание, идентификатор сообщества в параметре owner_id необходимо указывать
		/// со знаком "-" — например, owner_id=-1.
		/// По умолчанию идентификатор текущего пользователя.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор альбома с аудиозаписями.
		/// </summary>
		[Obsolete("Use PlaylistId property instead.")]
		public long? AlbumId { get; set; }

		/// <summary>
		/// Идентификатор плейлиста с аудиозаписями.
		/// </summary>
		public long? PlaylistId { get; set; }

		/// <summary>
		/// Идентификаторы аудиозаписей, информацию о которых необходимо вернуть.
		/// </summary>
		public IEnumerable<long> AudioIds { get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного количества аудиозаписей.
		/// По умолчанию — 0.
		/// </summary>
		public long? Offset { get; set; }

		/// <summary>
		/// Количество аудиозаписей, информацию о которых необходимо вернуть. Максимальное
		/// значение — 6000.
		/// </summary>
		public long? Count { get; set; }

		/// <summary>
		/// Токен доступа
		/// </summary>
		[JsonProperty("access_key")]
		public string AccessKey { get; set; }
	}
}