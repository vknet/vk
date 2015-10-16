using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Упоминание.
	/// </summary>
	public class Mention
	{
		/// <summary>
		/// идентификатор записи на стене пользователя;.
		/// </summary>
		public ulong Id
		{ get; set; }

		/// <summary>
		/// идентификатор пользователя, написавшего запись;.
		/// </summary>
		public ulong FromId
		{ get; set; }

		/// <summary>
		/// время публикаии записи в формате unixtime;.
		/// </summary>
		public string Date
		{ get; set; }

		/// <summary>
		/// текст записи;.
		/// </summary>
		public string Text
		{ get; set; }

		/// <summary>
		/// содержит информацию о числе людей, которым понравилась данная запись, и понравилась ли она текущему пользователю;.
		/// </summary>
		public Likes Likes
		{ get; set; }

		/// <summary>
		/// содержит информацию о количестве комментариев к записи и возможности текущего пользователя оставлять комментарии к ней;.
		/// </summary>
		public Comments Comments
		{ get; set; }

		/// <summary>
		/// содержит объект, который присоединен к текущей новости ( фотография, ссылка и т.п.). Более подробная информация представлена на странице Описание поля attachment;.
		/// </summary>
		public Attachment Attachment
		{ get; set; }

		/// <summary>
		/// находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		public Geo Geo
		{ get; set; }

		/// <summary>
		/// если запись является копией записи с чужой стены, то в поле содержится идентификатор владельца стены у которого была скопирована запись;.
		/// </summary>
		public ulong? CopyOwnerId
		{ get; set; }

		/// <summary>
		/// если запись является копией записи с чужой стены, то в поле содержится идентфикатор скопированной записи на стене ее владельца..
		/// </summary>
		public ulong? CopyPostId
		{ get; set; }

		
		/// <summary>
		/// Идентификатор сообщества где было сделано упоминание.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public long? ToId
		{ get; set; }

		/// <summary>
		/// Идентификатор поста.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public ulong? PostId
		{ get; set; }
		/// <summary>
		/// Тип поста.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public string PostType
		{ get; set; }

		/// <summary>
		/// Репосты.
		/// </summary>
		/// <remarks>
		/// Выведено экспериментально.
		/// </remarks>
		public Reposts Reposts
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Mention FromJson(VkResponse response)
		{
			var mention = new Mention();
			mention.Id = response["id"];
			mention.FromId = response["from_id"];
			mention.Date = response["date"];
			mention.Text = response["text"];
			mention.Likes = response["likes"];
			mention.Comments = response["comments"];
			mention.Attachment = response["attachment"];
			mention.Geo = response["geo"];
			mention.CopyOwnerId = response["copy_owner_id"];
			mention.CopyPostId = response["copy_post_id"];
			mention.ToId = response["to_id"];
			mention.PostId = response["post_id"];
			mention.PostType = response["post_type"];
			mention.Reposts = response["reposts"];

			return mention;
		}
	}
}
