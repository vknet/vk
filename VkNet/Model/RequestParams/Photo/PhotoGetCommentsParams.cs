﻿using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Список параметров для метода photos.getComments
	/// </summary>
	public struct PhotoGetCommentsParams
	{
		/// <summary>
		/// Идентификатор пользователя или сообщества, которому принадлежит фотография.
		/// </summary>
		public long? OwnerId
		{ get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		public ulong PhotoId
		{ get; set; }

		/// <summary>
		/// <c>true</c> — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается.
		/// </summary>
		public bool? NeedLikes
		{ get; set; }

		/// <summary>
		/// Идентификатор комментария, начиная с которого нужно вернуть список (подробности см. ниже).
		/// </summary>
		public ulong? StartCommentId
		{ get; set; }

		/// <summary>
		/// Смещение, необходимое для выборки определенного подмножества комментариев. По умолчанию — 0.
		/// </summary>
		public ulong? Offset
		{ get; set; }

		/// <summary>
		/// Количество комментариев, которое необходимо получить.
		/// </summary>
		public ulong? Count
		{ get; set; }

		/// <summary>
		/// Порядок сортировки комментариев (asc — от старых к новым, desc - от новых к старым) строка.
		/// </summary>
		public CommentsSort Sort
		{ get; set; }

		/// <summary>
		/// Ключ доступа к фотографии.
		/// </summary>
		public string AccessKey
		{ get; set; }

		/// <summary>
		/// <c>true</c> — комментарии в ответе будут возвращены в виде пронумерованных объектов, дополнительно будут возвращены списки объектов profiles, groups.
		/// </summary>
		public bool? Extended
		{ get; set; }

		/// <summary>
		///  Список строк, разделенных через запятую.
		/// </summary>
		public UsersFields Fields
		{ get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(PhotoGetCommentsParams p)
		{
			var parameters = new VkParameters
			{
				{ "owner_id", p.OwnerId },
				{ "photo_id", p.PhotoId },
				{ "need_likes", p.NeedLikes },
				{ "start_comment_id", p.StartCommentId },
				{ "offset", p.Offset },
				{ "count", p.Count },
				{ "sort", p.Sort },
				{ "access_key", p.AccessKey },
				{ "extended", p.Extended },
				{ "fields", p.Fields }
			};

			return parameters;
		}
	}
}