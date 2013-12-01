namespace VkToolkit.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using VkToolkit.Utils;

    /// <summary>
    /// Комментарий к записи.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Идентификатор комментария к записи.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя, оставившего комментарий.
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Дата и время, когда был оставлен комментарий.
        /// </summary>
        public DateTime ?Date { get; set; }
        /// <summary>
        /// Текст комментария.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Информация о числе людей, которым понравился данный комментарий.
        /// </summary>
        public Likes Likes { get; set; }

        /// <summary>
        /// Если комментарий является ответом на другой комментарий, то в этом поле содержится идентификатор пользователя, которому оставлен ответ.
        /// </summary>     
        public long? ReplyToUserId { get; set; }
        /// <summary>
        /// Если комментарий является ответом на другой комментарий, то в этом поле содержится идентификатор комментария, на который оставлен ответ.
        /// </summary>
        public long? ReplyToCommentId { get; set; }
        /// <summary>
        /// Приложения к комментарию.
        /// </summary>
        public List<Attachment> Attachments { get; set; }
        /// <summary>
        /// Первое приложение к комментарию.
        /// </summary>
        public Attachment Attachment { get { return Attachments.FirstOrDefault(); } }

        internal static Comment FromJson(VkResponse response)
        {
            var comment = new Comment();

            comment.Id = response["cid"];
            comment.UserId = response["uid"];
            comment.Date = response["date"];
            comment.Text = response["text"];
            comment.Likes = response["likes"];
            comment.ReplyToUserId = response["reply_to_uid"];
            comment.ReplyToCommentId = response["reply_to_cid"];
            comment.Attachments = response["attachments"];

            return comment;
        }
    }
}