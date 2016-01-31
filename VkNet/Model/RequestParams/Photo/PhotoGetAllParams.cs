﻿using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.getAll
	/// </summary>
	public struct PhotoGetAllParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, фотографии которого нужно получить.
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// <c>true</c> — возвращать расширенную информацию о фотографиях.
		/// </summary>
		public bool? Extended
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества фотографий. По умолчанию — <c>false</c>.
		/// </summary>
		public ulong? Offset
		{ get; set; }

		/// <summary>
		/// Число фотографий, информацию о которых необходимо получить.
		/// </summary>
		public ulong? Count
		{ get; set; }

		/// <summary>
		/// <c>true</c> — будут возвращены размеры фотографий в специальном формате.
		/// </summary>
		public bool? PhotoSizes
		{ get; set; }

		/// <summary>
		/// <c>false</c> — вернуть все фотографии, включая находящиеся в сервисных альбомах, таких как "Фотографии на моей стене" (по умолчанию).
		/// </summary>
		public bool? NoServiceAlbums
		{ get; set; }

		/// <summary>
		/// <c>true</c> — возвращает информацию от том, скрыта ли фотография из блока над стеной пользователя.
		/// </summary>
		public bool? NeedHidden
		{ get; set; }

		/// <summary>
		/// <c>true</c> — не возвращать фотографии, скрытые из блока над стеной пользователя (параметр учитывается только при owner_id > <c>false</c>, параметр no_service_albums игнорируется).
		/// </summary>
		public bool? SkipHidden
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(PhotoGetAllParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "extended", p.Extended },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "photo_sizes", p.PhotoSizes },
				{ "no_service_albums", p.NoServiceAlbums },
				{ "need_hidden", p.NeedHidden },
				{ "skip_hidden", p.SkipHidden }
			};

			return parameters;
		}
	}
}
