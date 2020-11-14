using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.Attachments;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Комментарий к записи.
	/// См. описание <see href="https://vk.com/dev/objects/comment" />.
	/// </summary>
	[DebuggerDisplay("Id = {Id}, Text = {Text}, Date = {Date}")]
	[Serializable]
	public class Comment
	{
		/// <summary>
		/// Идентификатор комментария.
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		[JsonProperty("from_id")]
		public long? FromId { get; set; }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		[JsonProperty("post_id")]
		public long? PostId { get; set; }

		/// <summary>
		/// Идентификатор фотографии.
		/// </summary>
		[JsonProperty("pid")]
		public long? PhotoId { get; set; }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		[JsonProperty("owner_id")]
		public long? OwnerId { get; set; }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		[JsonProperty("parents_stack")]
		public ReadOnlyCollection<long> ParentsStack { get; set; }

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		[JsonProperty("thread")]
		public CommentThread Thread { get; set; }

		/// <summary>
		/// Дата и время создания комментария.
		/// </summary>
		[JsonConverter(typeof(UnixDateTimeConverter))]
		[JsonProperty("date")]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		/// Информация о VK Donut.
		/// </summary>
		[JsonProperty("donut")]
		public CommentDonut Donut { get; set; }
		/// <summary>
		/// Идентификатор пользователя или сообщества, в ответ которому оставлен текущий
		/// комментарий (если применимо).
		/// </summary>
		[JsonProperty("reply_to_user")]
		public long? ReplyToUser { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который оставлен текущий комментарий
		/// (если применимо).
		/// </summary>
		[JsonProperty("reply_to_comment")]
		public long? ReplyToComment { get; set; }

		/// <summary>
		/// Объект, содержащий информацию о медиавложениях в комментарии. См. описание
		/// формата медиавложений.
		/// </summary>
		[JsonConverter(typeof(AttachmentJsonConverter))]
		[JsonProperty("attachments")]
		public ReadOnlyCollection<Attachment> Attachments { get; set; }

		/// <summary>
		/// Первое приложение к комментарию.
		/// </summary>
		public Attachment Attachment => Attachments.FirstOrDefault();

	#region Поля, установленные экспериментально

		/// <summary>
		/// Информация о числе людей, которым понравился данный комментарий.
		/// </summary>
		[JsonProperty("likes")]
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
			return new Comment
			{
				Id = response["id"],
				FromId = response["from_id"],
				Date = response["date"],
				Text = response["text"],
				Donut = response["donut"],
				ReplyToUser = response["reply_to_user"],
				ReplyToComment = response["reply_to_comment"],
				Attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x),
				Likes = response["likes"],
				PostId = response["post_id"],
				PhotoId = response["pid"],
				OwnerId = response["owner_id"],
				ParentsStack = response["parents_stack"].ToReadOnlyCollectionOf<long>(x => x),
				Thread = response["thread"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Comment" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Comment" /></returns>
		public static implicit operator Comment(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

	#endregion
	}
}