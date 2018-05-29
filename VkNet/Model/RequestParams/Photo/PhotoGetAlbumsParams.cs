using System;
using System.Collections.Generic;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.getAlbums
	/// </summary>
	[Serializable]
	public class PhotoGetAlbumsParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежат альбомы.
		/// Обратите внимание, идентификатор
		/// сообщества в параметре owner_id необходимо указывать со знаком "-" — например,
		/// owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API (club1).
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// Перечисленные через запятую ID альбомов.
		/// </summary>
		public IEnumerable<long> AlbumIds { get; set; }

		/// <summary>
		/// Cмещение, необходимое для выборки определенного подмножества альбомов.
		/// </summary>
		public uint? Offset { get; set; }

		/// <summary>
		/// Количество альбомов, которое нужно вернуть.
		/// </summary>
		public uint? Count { get; set; }

		/// <summary>
		/// <c> true </c> – будут возвращены системные альбомы, имеющие отрицательные
		/// идентификаторы.
		/// </summary>
		public bool? NeedSystem { get; set; }

		/// <summary>
		/// <c> true </c> — будет возвращено дополнительное поле thumb_src. По умолчанию
		/// поле thumb_src не возвращается.
		/// </summary>
		public bool? NeedCovers { get; set; }

		/// <summary>
		/// <c> true </c> — будут возвращены размеры фотографий в специальном формате.
		/// </summary>
		public bool? PhotoSizes { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(PhotoGetAlbumsParams p)
		{
			var parameters = new VkParameters
			{
					{ "owner_id", p.OwnerId }
					, { "album_ids", p.AlbumIds }
					, { "offset", p.Offset }
					, { "count", p.Count }
					, { "need_system", p.NeedSystem }
					, { "need_covers", p.NeedCovers }
					, { "photo_sizes", p.PhotoSizes }
			};

			return parameters;
		}
	}
}