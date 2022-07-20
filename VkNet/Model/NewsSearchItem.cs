using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Новость
	/// </summary>
	[Serializable]
	public class NewsSearchItem
	{
		/// <summary>
		/// Локальный идентификатор записи (для конкретного владельца).
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца стены, на которой размещена запись. Если стена
		/// принадлежит сообществу, то данный параметр
		/// равен -gid (идентификатор сообщества со знаком минус).
		/// </summary>
		[JsonProperty("owner_id")]
		public long OwnerId { get; set; }

		/// <summary>
		/// Идентификатор автора записи;.
		/// </summary>
		[JsonProperty("from_id")]
		public long FromId { get; set; }

		/// <summary>
		/// Время публикации записи в формате unixtime.
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст записи.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Содержит информацию о количестве комментариев к записи.
		/// </summary>
		[JsonProperty("comments")]
		public Comments Comments { get; set; }

		/// <summary>
		/// Содержит информацию о числе людей, которым понравилась данная запись.
		/// </summary>
		[JsonProperty("likes")]
		public Likes Likes { get; set; }

		/// <summary>
		/// Содержит информацию о количестве репостов записи.
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
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		[JsonProperty("geo")]
		public Geo Geo { get; set; }

		/// <summary>
		/// Идентификатор владельца записи.
		/// </summary>
		[JsonProperty("signer_id")]
		public long? SignerId { get; set; }

		/// <summary>
		/// Тип записи
		/// </summary>
		[JsonProperty("post_type")]
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public PostType PostType { get; set; }

		/// <summary>
		/// Идентификатор записи при PostType == reply
		/// </summary>
		[JsonProperty("post_id")]
		public int? PostId { get; set; } //Будет иметь значение null, кроме случаев при "post_type": "reply"

		/// <summary>
		/// </summary>
		[JsonProperty("next_from")]
		public string NextFrom { get; set; }

		/// <summary>
		/// массив profiles
		/// </summary>
		[JsonProperty("profiles")]
		public ReadOnlyCollection<User> Profiles { get; set; }

		/// <summary>
		/// массив groups
		/// </summary>
		[JsonProperty("groups")]
		public ReadOnlyCollection<Group> Groups { get; set; }

		/// <summary>
		/// Информация информацию о том, каким образом (через интерфейс сайта, виджет и
		/// т.п.) была создана запись на стене.
		/// </summary>
		[JsonProperty("post_source")]
		public PostSource PostSource { get; set; }

		/// <summary>
		/// В закладках
		/// </summary>
		[JsonProperty("is_favorite")]
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Помечено как реклама
		/// </summary>
		[JsonProperty("marked_as_ads", NullValueHandling = NullValueHandling.Ignore)]
		public long? MarkedAsAds { get; set; }

		/// <summary>
		/// Просмотры
		/// </summary>
		[JsonProperty("views", NullValueHandling = NullValueHandling.Ignore)]
		public Views Views { get; set; }
	}
}