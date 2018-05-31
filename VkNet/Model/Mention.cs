using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Упоминание.
	/// </summary>
	[Serializable]
	public class Mention
	{
		/// <summary>
		/// Идентификатор записи на стене пользователя.
		/// </summary>
		public ulong Id { get; set; }

		/// <summary>
		/// Идентификатор пользователя, написавшего запись.
		/// </summary>
		public ulong FromId { get; set; }

		/// <summary>
		/// Время публикаии записи в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст записи.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Содержит информацию о числе людей, которым понравилась данная запись, и
		/// понравилась ли она текущему пользователю.
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Содержит информацию о количестве комментариев к записи и возможности текущего
		/// пользователя оставлять комментарии к
		/// ней.
		/// </summary>
		public Comments Comments { get; set; }

		/// <summary>
		/// Содержит объект, который присоединен к текущей новости ( фотография, ссылка и
		/// т.п.). Более подробная информация
		/// представлена на странице Описание поля attachment.
		/// </summary>
		public Attachment Attachment { get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		public Geo Geo { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в поле содержится
		/// идентификатор владельца стены у которого
		/// была скопирована запись.
		/// </summary>
		public ulong? CopyOwnerId { get; set; }

		/// <summary>
		/// Если запись является копией записи с чужой стены, то в поле содержится
		/// идентфикатор скопированной записи на стене
		/// ее владельца.
		/// </summary>
		public ulong? CopyPostId { get; set; }

		/// <summary>
		/// Идентификатор сообщества где было сделано упоминание.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public long? ToId { get; set; }

		/// <summary>
		/// Идентификатор поста.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public ulong? PostId { get; set; }

		/// <summary>
		/// Тип поста.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public string PostType { get; set; }

		/// <summary>
		/// Репосты.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public Reposts Reposts { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Mention FromJson(VkResponse response)
		{
			var mention = new Mention
			{
					Id = response[key: "id"]
					, FromId = response[key: "from_id"]
					, Date = response[key: "date"]
					, Text = response[key: "text"]
					, Likes = response[key: "likes"]
					, Comments = response[key: "comments"]
					, Attachment = response[key: "attachment"]
					, Geo = response[key: "geo"]
					, CopyOwnerId = response[key: "copy_owner_id"]
					, CopyPostId = response[key: "copy_post_id"]
					, ToId = response[key: "to_id"]
					, PostId = response[key: "post_id"]
					, PostType = response[key: "post_type"]
					, Reposts = response[key: "reposts"]
			};

			return mention;
		}
	}
}