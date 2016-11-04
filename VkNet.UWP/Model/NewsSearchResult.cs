using System;
using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат поиска метода newsfeed.search
	/// </summary>
	public class NewsSearchResult
	{
		/// <summary>
		/// Локальный идентификатор записи (для конкретного владельца).
		/// </summary>
		public long Id
		{ get; set; }

		/// <summary>
		/// Идентификатор владельца стены, на которой размещена запись. Если стена принадлежит сообществу, то данный параметр равен -gid (идентификатор сообщества со знаком минус).
		/// </summary>
		public long OwnerId
		{ get; set; }

		/// <summary>
		/// Идентификатор автора записи;.
		/// </summary>
		public long FromId
		{ get; set; }

		/// <summary>
		/// Время публикации записи в формате unixtime.
		/// </summary>
		public DateTime? Date
		{ get; set; }

		/// <summary>
		/// Текст записи.
		/// </summary>
		public string Text
		{ get; set; }

		/// <summary>
		/// Содержит информацию о количестве комментариев к записи.
		/// </summary>
		public Comments Comments
		{ get; set; }

		/// <summary>
		/// Содержит информацию о числе людей, которым понравилась данная запись.
		/// </summary>
		public Likes Likes
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит массив объектов, которые прикреплены к текущей новости (фотография, ссылка и т.п.). Более подробная информация представлена на странице Описание поля attachments.
		/// </summary>
		public IEnumerable<Attachment> Attachments
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		public Geo Geo
		{ get; set; }

        /// <summary>
        /// Идентификатор владельца записи.
        /// </summary>
	    public long? SignerId { get; set; }

        /// <summary>
        /// Тип записи
        /// </summary>
	    public PostType PostType { get; set; }
	    
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static NewsSearchResult FromJson(VkResponse response)
		{
			var newsSearchResult = new NewsSearchResult
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				FromId = response["from_id"],
				Date = response["date"],
				Text = response["text"],
				Comments = response["comments"],
				Likes = response["likes"],
				Attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x),
				Geo = response["geo"],
                SignerId = response["signer_id"],
                PostType = response["post_type"]
            };
			return newsSearchResult;
		}
	}
}
