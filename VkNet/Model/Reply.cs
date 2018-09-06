using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Описание поля reply
	/// </summary>
	[Serializable]
	public class Reply
	{
		/// <summary>
		/// Идентификатор комментария
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public long Id { get; set; }

		/// <summary>
		/// Время публикации комментария в формате unixtime
		/// </summary>
		[JsonProperty(propertyName: "date")]
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime Date { get; set; }

		/// <summary>
		/// Текст комментария
		/// </summary>
		[JsonProperty(propertyName: "text")]
		public string Text { get; set; }
	}
}