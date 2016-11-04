using System;
using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Заметка пользователя.
	/// См. описание <see href="http://vk.com/dev/note"/>.
	/// </summary>
	[DataContract]
	public class Note : MediaAttachment
    {
		/// <summary>
		/// Заметка пользователя.
		/// </summary>
		static Note()
		{
			RegisterType(typeof (Note), "note");
		}

		/// <summary>
        /// Заголовок заметки.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата создания заметки.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Количество комментариев к заметке.
        /// </summary>
        public int? CommentsCount { get; set; }

        /// <summary>
        /// Количество прочитанных комментариев (только при запросе информации о заметке текущего пользователя).
        /// </summary>
        public int? ReadCommentsCount { get; set; }

		/// <summary>
		/// Адрес страницы для отображения заметки.
		/// </summary>
		public Uri ViewUrl { get; set; }
		#region Методы

		internal static Note FromJson(VkResponse response)
		{
			var note = new Note
			{
				Id = response["id"],
				OwnerId = response["user_id"],
				Title = response["title"],
				Text = response["text"],
				Date = response["date"],
				CommentsCount = response["comments"],
				ReadCommentsCount = response["read_comments"],
				ViewUrl = response["view_url"]
			};

			return note;
		}

		#endregion
	}
}