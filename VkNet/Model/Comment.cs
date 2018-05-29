using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Комментарий к записи.
	/// См. описание <see href="http://vk.com/devcomment_object" />.
	/// </summary>
	[DebuggerDisplay(value: "Id = {Id}, Text = {Text}, Date = {Date}")]
	[Serializable]
	public class Comment
	{
		/// <summary>
		/// Идентификатор комментария.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		public long FromId { get; set; }

		/// <summary>
		/// Дата и время создания комментария.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Идентификатор пользователя или сообщества, в ответ которому оставлен текущий
		/// комментарий (если применимо).
		/// </summary>
		public long? ReplyToUserId { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который оставлен текущий комментарий
		/// (если применимо).
		/// </summary>
		public long? ReplyToCommentId { get; set; }

		/// <summary>
		/// Объект, содержащий информацию о медиавложениях в комментарии. См. описание
		/// формата медиавложений.
		/// </summary>
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Первое приложение к комментарию.
		/// </summary>
		public Attachment Attachment => Attachments.FirstOrDefault();

	#region Поля, установленные экспериментально

		/// <summary>
		/// Информация о числе людей, которым понравился данный комментарий.
		/// </summary>
		public Likes Likes { get; set; }

	#endregion

	#region Методы

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Comment FromJson(VkResponse response)
		{
			var comment = new Comment
			{
					Id = response[key: "id"]
					, FromId = response[key: "from_id"]
					, Date = response[key: "date"]
					, Text = response[key: "text"]
					, ReplyToUserId = response[key: "reply_to_user"]
					, ReplyToCommentId = response[key: "reply_to_comment"]
					, Attachments = response[key: "attachments"].ToReadOnlyCollectionOf<Attachment>(selector: x => x)
					, Likes = response[key: "likes"] // установлено экcпериментальным путем
			};

			return comment;
		}

	#endregion
	}
}