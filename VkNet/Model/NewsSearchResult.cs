using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Результат поиска метода newsfeed.search
	/// </summary>
	[Serializable]
	public class NewsSearchResult
	{
		/// <summary>
		/// Локальный идентификатор записи (для конкретного владельца).
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца стены, на которой размещена запись. Если стена
		/// принадлежит сообществу, то данный параметр
		/// равен -gid (идентификатор сообщества со знаком минус).
		/// </summary>
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор автора записи;.
		/// </summary>
		public long FromId { get; set; }

		/// <summary>
		/// Время публикации записи в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст записи.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Содержит информацию о количестве комментариев к записи.
		/// </summary>
		public Comments Comments { get; set; }

		/// <summary>
		/// Содержит информацию о числе людей, которым понравилась данная запись.
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит массив объектов, которые прикреплены к
		/// текущей новости (фотография, ссылка и
		/// т.п.). Более подробная информация представлена на странице Описание поля
		/// attachments.
		/// </summary>
		public IEnumerable<Attachment> Attachments { get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		public Geo Geo { get; set; }

		/// <summary>
		/// Идентификатор владельца записи.
		/// </summary>
		public long? SignerId { get; set; }

		/// <summary>
		/// Тип записи
		/// </summary>
		///

		


		public PostType PostType { get; set; }

		/// <summary>
		///  Идентификатор записи при PostType == reply
		/// </summary>

		public int? PostId { get; set; } //Будет иметь значение null, кроме случаев при "post_type": "reply" 

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static NewsSearchResult FromJson(VkResponse response)
		{
			var newsSearchResult = new NewsSearchResult
			{
					Id = response[key: "id"]
					, OwnerId = response[key: "owner_id"]
					, FromId = response[key: "from_id"]
					, Date = response[key: "date"]
					, Text = response[key: "text"]
					, Comments = response[key: "comments"]
					, Likes = response[key: "likes"]
					, Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x)
					, Geo = response[key: "geo"]
					, SignerId = response[key: "signer_id"]
					, PostType = response[key: "post_type"]
					, PostId = response[key: "post_id"]   //
			};

			return newsSearchResult;
		}
	}
}
