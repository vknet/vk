using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
    /// Заметка пользователя.
    /// См. описание <see href="http://vk.com/dev/note"/>.
    /// </summary>
    public class Note : MediaAttachment
    {
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

        #region Методы

        internal static Note FromJson(VkResponse response)
		{
			// TODO: TEST IT!!!!!
			var note = new Note
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Title = response["title"],
				Text = response["text"],
				Date = response["date"],
				CommentsCount = response["comments"],
				ReadCommentsCount = response["read_comments"]
			};

			return note;
		}

		#endregion
	}
}