using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

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
		[JsonProperty("type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public NewsTypes Type { get; set; }

		/// <summary>
		/// Идентификатор источника новости (положительный — новость пользователя,
		/// отрицательный — новость группы).
		/// </summary>
		[JsonProperty("source_id")]
		public long SourceId { get; set; }

		/// <summary>
		/// Время публикации новости в формате unixtime.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит идентификатор записи на стене владельца.
		/// </summary>
		[JsonProperty("post_id")]
		public ulong? PostId { get; set; }

		/// <summary>
		/// Находится в записях со стен, содержит тип новости (post или copy).
		/// </summary>
		[JsonProperty("post_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PostTypeOrder PostType { get; set; }

		/// <summary>
		/// Передается в случае, если этот пост сделан при удалении.
		/// </summary>
		/// <remarks>
		/// TODO: Установить настоящий тип данных
		/// </remarks>
		[JsonProperty("final_post")]
		public ulong? FinalPost { get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой
		/// стены, и содержит идентификатор
		/// владельца стены, у которого было скопировано сообщение.
		/// </summary>
		[JsonProperty("copy_owner_id")]
		public long? CopyOwnerId { get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой
		/// стены, и содержит идентификатор
		/// скопированного сообщения на стене его владельца.
		/// </summary>
		[JsonProperty("copy_post_id")]
		public long? CopyPostId { get; set; }

		/// <summary>
		/// Массив, содержащий историю репостов для записи. Возвращается только в том
		/// случае, если запись является репостом.
		/// Каждый из объектов массива, в свою очередь, является объектом-записью
		/// стандартного формата.
		/// </summary>
		[JsonProperty("copy_history")]
		public IEnumerable<Post> CopyHistory { get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой
		/// стены, и содержит дату скопированного
		/// сообщения.
		/// </summary>
		[JsonProperty("copy_post_date")]
		public string CopyPostDate { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит текст записи.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Содержит <c> true </c>, если текущий пользователь может редактировать запись.
		/// </summary>
		[JsonProperty("can_edit")]
		public bool? CanEdit { get; set; }

		/// <summary>
		/// Возвращается, если пользователь может удалить новость, всегда содержит
		/// <c> true </c>.
		/// </summary>
		[JsonProperty("can_delete")]
		public bool? CanDelete { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о комментариях к записи.
		/// </summary>
		[JsonProperty("comments")]
		public Comments Comments { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которым
		/// понравилась данная запись.
		/// </summary>
		[JsonProperty("likes")]
		public Likes Likes { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которые
		/// скопировали данную запись на свою
		/// страницу.
		/// </summary>
		[JsonProperty("reposts")]
		public Reposts Reposts { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит массив объектов, которые прикреплены к
		/// текущей новости (фотография, ссылка и
		/// т.п.). Более подробная информация представлена на странице Описание поля
		/// attachments.
		/// </summary>
		[JsonProperty("attachments")]
		[JsonConverter(typeof(AttachmentJsonConverter))]
		public IEnumerable<Attachment> Attachments { get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		[JsonProperty("geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		[JsonProperty("photos")]
		public VkCollection<Photo> Photos { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		[JsonProperty("photo_tags")]
		public VkCollection<Photo> PhotoTags { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		[JsonProperty("notes")]
		public VkCollection<Note> Notes { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		[JsonProperty("friends")]
		public VkCollection<User> Friends { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		[JsonProperty("audio")]
		public VkCollection<Audio> Audios { get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных
		/// с данной новостью.
		/// </summary>
		[JsonProperty("video")]
		public VkCollection<Video> Videos { get; set; }
	}
}