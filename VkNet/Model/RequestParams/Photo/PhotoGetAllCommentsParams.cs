﻿using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.getAllComments
	/// </summary>
	public struct PhotoGetAllCommentsParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежат фотографии.
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// Идентификатор альбома. Если параметр не задан, то считается, что необходимо получить комментарии ко всем альбомам пользователя или сообщества.
		/// </summary>
		public ulong AlbumId
		{ get; set; }

		/// <summary>
		/// <c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается.
		/// </summary>
		public bool? NeedLikes
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества комментариев. Если параметр не задан, то считается, что он равен 0.
		/// </summary>
		public ulong? Offset
		{ get; set; }

		/// <summary>
		/// Количество комментариев, которое необходимо получить. Если параметр не задан, то считается что он равен 20. Максимальное значение параметра 100. Обратите внимание, даже при использовании параметра offset для получения доступны только первые 10000 комментариев.
		/// </summary>
		public ulong? Count
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(PhotoGetAllCommentsParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "album_id", p.AlbumId },
				{ "need_likes", p.NeedLikes },
				{ "offset", p.Offset },
				{ "count", p.Count }
			};

			return parameters;
		}
	}
}