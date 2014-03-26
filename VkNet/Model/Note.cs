namespace VkNet.Model
{
    using System;

    using VkNet.Utils;

    /// <summary>
    /// Заметка пользователя.
    /// См. описание <see href="http://vk.com/dev/note"/>.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Идентификатор заметки.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Идентификатор владельца заметки.
        /// </summary>
        public long? UserId { get; set; }

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
            var note = new Note();

            note.Id = response["id"];
            note.UserId = response["user_id"];
            note.Title = response["title"];
            note.Text = response["text"];
            note.Date = response["date"];
            note.CommentsCount = response["comments"];
            note.ReadCommentsCount = response["read_comments"];

            return note;
        }

        #endregion
    }
}