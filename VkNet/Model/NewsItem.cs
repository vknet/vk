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
	/// Элемент коллекции новостей.
	/// </summary>
	[Serializable]
	public class NewsItem
	{
		/// <summary>
		/// Тип списка новости, соответствующий одному из значений параметра filters.
		/// </summary>
		public NewsTypes Type { get; set; }

		/// <summary>
		/// Идентификатор источника новости (положительный — новость пользователя,
		/// отрицательный — новость группы).
		/// </summary>
		public long SourceId { get; set; }

		/// <summary>
		/// Время публикации новости в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит идентификатор записи на стене владельца.
		/// </summary>
		public ulong PostId { get; set; }

		/// <summary>
		/// Находится в записях со стен, содержит тип новости (post или copy).
		/// </summary>
		public PostTypeOrder PostType { get; set; }

		/// <summary>
		/// Передается в случае, если этот пост сделан при удалении.
		/// </summary>
		/// <remarks>
		/// TODO: Установить настоящий тип данных
		/// </remarks>
		public ulong? FinalPost { get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой
		/// стены, и содержит идентификатор
		/// владельца стены, у которого было скопировано сообщение.
		/// </summary>
		public long? CopyOwnerId { get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой
		/// стены, и содержит идентификатор
		/// скопированного сообщения на стене его владельца.
		/// </summary>
		public long? CopyPostId { get; set; }

		/// <summary>
		/// Массив, содержащий историю репостов для записи. Возвращается только в том
		/// случае, если запись является репостом.
		/// Каждый из объектов массива, в свою очередь, является объектом-записью
		/// стандартного формата.
		/// </summary>
		public IEnumerable<Post> CopyHistory { get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой
		/// стены, и содержит дату скопированного
		/// сообщения.
		/// </summary>
		public string CopyPostDate { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит текст записи.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Содержит <c> true </c>, если текущий пользователь может редактировать запись.
		/// </summary>
		public bool CanEdit { get; set; }

		/// <summary>
		/// Возвращается, если пользователь может удалить новость, всегда содержит
		/// <c> true </c>.
		/// </summary>
		public bool CanDelete { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о комментариях к записи.
		/// </summary>
		public Comments Comments { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которым
		/// понравилась данная запись.
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которые
		/// скопировали данную запись на свою
		/// страницу.
		/// </summary>
		public Reposts Reposts { get; set; }

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
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		public IEnumerable<Photo> Photos { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		public ulong? PhotoTags { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		public IEnumerable<Note> Notes { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		public IEnumerable<User> Friends { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static NewsItem FromJson(VkResponse response)
		{
			var newsItem = new NewsItem
			{
					Type = response[key: "type"]
					, SourceId = response[key: "source_id"]
					, Date = response[key: "date"]
					, PostId = response[key: "post_id"]
					, PostType = response[key: "post_type"]
					, FinalPost = response[key: "final_post"]
					, CopyOwnerId = response[key: "copy_owner_id"]
					, CopyPostId = response[key: "copy_post_id"]
					, CopyHistory = response[key: "copy_history"].ToReadOnlyCollectionOf<Post>(selector: o => o)
					, CopyPostDate = response[key: "copy_post_date"]
					, Text = response[key: "text"]
					, CanEdit = response[key: "can_edit"]
					, CanDelete = response[key: "can_delete"]
					, Comments = response[key: "comments"]
					, Likes = response[key: "likes"]
					, Reposts = response[key: "reposts"]
					, Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x)
					, Geo = response[key: "geo"]
					, Photos = response[key: "photos"].ToReadOnlyCollectionOf<Photo>(selector: x => x)
					, PhotoTags = response[key: "photo_tags"]
					, Notes = response[key: "notes"].ToReadOnlyCollectionOf<Note>(selector: x => x)
					, Friends = response[key: "friends"].ToReadOnlyCollectionOf<User>(selector: x => x)
			};

			return newsItem;
		}
	}
}