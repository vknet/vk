using VkNet.Model.Attachments;

namespace VkNet.Model
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Diagnostics;

    using Utils;

    /// <summary>
    /// Комментарий к записи.
    /// См. описание <see href="http://vk.com/devcomment_object"/>.
    /// </summary>
    [DebuggerDisplay("Id = {Id}, Text = {Text}, Date = {Date}")][Serializable]
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
        public DateTime? Date { get; set; }

        /// <summary>
        /// Текст комментария.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Идентификатор пользователя или сообщества, в ответ которому оставлен текущий комментарий (если применимо).
        /// </summary>     
        public long? ReplyToUserId { get; set; }

        /// <summary>
        /// Идентификатор комментария, в ответ на который оставлен текущий комментарий (если применимо).
        /// </summary>
        public long? ReplyToCommentId { get; set; }

        /// <summary>
        /// Объект, содержащий информацию о медиавложениях в комментарии. См. описание формата медиавложений. 
        /// </summary>
        public Collection<Attachment> Attachments { get; set; }

        /// <summary>
        /// Первое приложение к комментарию.
        /// </summary>
        public Attachment Attachment
        {
            get { return Attachments.FirstOrDefault(); }
        }

        #region Поля, установленные экспериментально

        /// <summary>
        /// Информация о числе людей, которым понравился данный комментарий.
        /// </summary>
        public Likes Likes { get; set; }

        #endregion

        #region Методы

        internal static Comment FromJson(VkResponse response)
        {
            var comment = new Comment();

            comment.Id = response["id"];
            comment.FromId = response["from_id"];
            comment.Date = response["date"];
            comment.Text = response["text"];
            comment.ReplyToUserId = response["reply_to_user"];
            comment.ReplyToCommentId = response["reply_to_comment"];
            comment.Attachments = response["attachments"];

            comment.Likes = response["likes"]; // установлено экcпериментальным путем

            return comment;
        }

        #endregion
    }
}