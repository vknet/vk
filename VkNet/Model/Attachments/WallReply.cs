using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Комментарий к записи на стене.
	/// </summary>
	[Serializable]
	public class WallReply : MediaAttachment
	{
		/// <summary>
		/// Комментарий к записи на стене.
		/// </summary>
		static WallReply()
		{
			RegisterType(type: typeof(WallReply), match: "wall_reply");
		}

		/// <summary>
		/// Идентификатор автора комментария.
		/// </summary>
		public long? FromId { get; set; }

		/// <summary>
		/// Дата создания комментария в формате unixtime.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// Текст комментария.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Информация о лайках к комментарию.
		/// </summary>
		public Likes Likes { get; set; }

		/// <summary>
		/// Идентификатор пользователя, в ответ которому был оставлен комментарий;
		/// </summary>
		public long? ReplyToUId { get; set; }

		/// <summary>
		/// Идентификатор комментария, в ответ на который был оставлен текущий.
		/// </summary>
		public long? ReplyToCId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static WallReply FromJson(VkResponse response)
		{
			var wallReply = new WallReply
			{
					Id = response[key: "comment_id"] ?? response[key: "cid"] ?? response[key: "id"]
					, FromId = response[key: "from_id"] ?? response[key: "user_id"] ?? response[key: "uid"]
					, Date = response[key: "date"]
					, Text = response[key: "text"]
					, Likes = response[key: "likes"]
					, ReplyToUId = response[key: "reply_to_uid"]
					, ReplyToCId = response[key: "reply_to_cid"]
			};

			return wallReply;
		}
	}
}