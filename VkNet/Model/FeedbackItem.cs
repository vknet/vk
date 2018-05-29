using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using VkNet.Model.Attachments;

namespace VkNet.Model
{
	/// <summary>
	/// Feedback Item
	/// </summary>
	[Serializable]
	public class FeedbackItem
	{
		/// <summary>
		/// Идентификатор записи-ответа;
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public long? Id { get; set; }

		/// <summary>
		/// Идентификатор стены, на которой размещена запись;
		/// </summary>
		[JsonProperty(propertyName: "to_id ")]
		public long? ToId { get; set; }

		/// <summary>
		/// Идентификатор автора ответа;
		/// </summary>
		[JsonProperty(propertyName: "from_id")]
		public long FromId { get; set; }

		/// <summary>
		/// Текст ответа;
		/// </summary>
		[JsonProperty(propertyName: "text")]
		public string Text { get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которым
		/// понравилась данная запись
		/// </summary>
		[JsonProperty(propertyName: "likes")]
		public Likes Likes { get; set; }

		/// <summary>
		/// Содержит массив объектов, которые присоединены к текущей записи (фотографии,
		/// ссылки и т.п.)
		/// </summary>
		[JsonProperty(propertyName: "attachments")]
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении
		/// </summary>
		[JsonProperty(propertyName: "geo")]
		public Geo Geo { get; set; }
	}
}