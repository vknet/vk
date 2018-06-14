using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	///  Комментарий к заметке
	/// </summary>
	[Serializable]
	public class CommentNote
	{
		/// <summary>
		/// идентификатор комментария
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public long? Id { get; set; }

		/// <summary>
		/// идентификатор автора комментария
		/// </summary>
		[JsonProperty(propertyName: "uid")]
		public long? UserId { get; set; }

		/// <summary>
		/// идентификатор заметки
		/// </summary>
		[JsonProperty(propertyName: "nid")]
		public long? NoteId { get; set; }

		/// <summary>
		/// идентификатор владельца заметки
		/// </summary>
		[JsonProperty(propertyName: "oid")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Дата добавления комментария в формате unixtime
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		[JsonProperty(propertyName: "date")]
		public DateTime? Date { get; set; }

		/// <summary>
		/// текст комментария
		/// </summary>
		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }

		/// <summary>
		/// идентификатор пользователя, в ответ на комментарий которого
		/// был оставлен текущий комментарий (если доступно). 
		/// </summary>
		[JsonProperty(propertyName: "reply_to")]
		public long? ReplyTo { get; set; }

		#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера. </param>
		/// <returns>Результат преобразования.</returns>
		public static CommentNote FromJson(VkResponse response)
		{
			return new CommentNote
			{
				Id = response[key: "id"],
				UserId = response[key: "uid "],
				NoteId = response[key: "nid "],
				OwnerId = response[key: "oid"],
				Date = response[key: "date "],
				Message = response[key: "message"],
				ReplyTo = response[key: "reply_to"]
			};
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CommentNote(VkResponse response)
		{
			return !response.HasToken()
					? null
					: FromJson(response: response);
		}
		#endregion
	}
}
