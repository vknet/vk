using System.Collections.Generic;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Элемент коллекции новостей.
	/// </summary>
	public class NewsItem
	{
		/// <summary>
		/// Тип списка новости, соответствующий одному из значений параметра filters.
		/// </summary>
		public NewsTypes type
		{ get; set; }

		/// <summary>
		/// Идентификатор источника новости (положительный — новость пользователя, отрицательный — новость группы).
		/// </summary>
		public long source_id
		{ get; set; }

		/// <summary>
		/// Время публикации новости в формате unixtime.
		/// </summary>
		public string date
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит идентификатор записи на стене владельца.
		/// </summary>
		public ulong post_id
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен, содержит тип новости (post или copy).
		/// </summary>
		public PostType post_type
		{ get; set; }

		/// <summary>
		/// Передается в случае, если этот пост сделан при удалении.
		/// </summary>
		/// <remarks>
		/// TODO: Установить настоящий тип данных
		/// </remarks>
		public ulong? final_post
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой стены, и содержит идентификатор владельца стены, у которого было скопировано сообщение.
		/// </summary>
		public long? copy_owner_id
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой стены, и содержит идентификатор скопированного сообщения на стене его владельца.
		/// </summary>
		public long? copy_post_id
		{ get; set; }

		/// <summary>
		/// Массив, содержащий историю репостов для записи. Возвращается только в том случае, если запись является репостом. Каждый из объектов массива, в свою очередь, является объектом-записью стандартного формата..
		/// </summary>
		/// <remarks>
		/// TODO: Установить настоящий тип данных
		/// </remarks>
		public ulong? copy_history
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен, если сообщение является копией сообщения с чужой стены, и содержит дату скопированного сообщения.
		/// </summary>
		public string copy_post_date
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит текст записи.
		/// </summary>
		public string text
		{ get; set; }

		/// <summary>
		/// Содержит <c>true</c>, если текущий пользователь может редактировать запись.
		/// </summary>
		public bool can_edit
		{ get; set; }

		/// <summary>
		/// Возвращается, если пользователь может удалить новость, всегда содержит <c>true</c>.
		/// </summary>
		public bool can_delete
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о комментариях к записи.
		/// </summary>
		public Comments comments
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которым понравилась данная запись.
		/// </summary>
		public Likes likes
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит информацию о числе людей, которые скопировали данную запись на свою страницу.
		/// </summary>
		public Reposts reposts
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен и содержит массив объектов, которые прикреплены к текущей новости (фотография, ссылка и т.п.). Более подробная информация представлена на странице Описание поля attachments..
		/// </summary>
		public IEnumerable<Attachment> attachments
		{ get; set; }

		/// <summary>
		/// Находится в записях со стен, в которых имеется информация о местоположении.
		/// </summary>
		public Geo geo
		{ get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных с данной новостью.
		/// </summary>
		public IEnumerable<Photo> photos
		{ get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных с данной новостью.
		/// </summary>
		public ulong? photo_tags
		{ get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных с данной новостью.
		/// </summary>
		public IEnumerable<Note> notes
		{ get; set; }

		/// <summary>
		/// Содержат информацию о количестве объектов и до 5 последних объектов, связанных с данной новостью..
		/// </summary>
		public IEnumerable<User> friends
		{ get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static NewsItem FromJson(VkResponse response)
		{
			var newsItem = new NewsItem
			{
				type = response["type"],
				source_id = response["source_id"],
				date = response["date"],
				post_id = response["post_id"],
				post_type = response["post_type"],
				final_post = response["final_post"],
				copy_owner_id = response["copy_owner_id"],
				copy_post_id = response["copy_post_id"],
				copy_history = response["copy_history"],
				copy_post_date = response["copy_post_date"],
				text = response["text"],
				can_edit = response["can_edit"],
				can_delete = response["can_delete"],
				comments = response["comments"],
				likes = response["likes"],
				reposts = response["reposts"],
				attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x),
				geo = response["geo"],
				photos = response["photos"].ToReadOnlyCollectionOf<Photo>(x => x),
				photo_tags = response["photo_tags"],
				notes = response["notes"].ToReadOnlyCollectionOf<Note>(x => x),
				friends = response["friends"].ToReadOnlyCollectionOf<User>(x => x)
			};

			return newsItem;
		}
	}
}
