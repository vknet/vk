using VkNet.Model.Attachments;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// Комментарий к записи.
    /// См. описание <see href="http://vk.com/devcomment_object"/>.
    /// </summary>
    [DebuggerDisplay("Id = {Id}, Text = {Text}, Date = {Date}")]
    [Serializable]
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
        public ReadOnlyCollection<Attachment> Attachments { get; set; }

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

        /// <summary>
        /// Разобрать из json.
        /// </summary>
        /// <param name="response">Ответ сервера.</param>
        /// <returns></returns>
        public static Comment FromJson(VkResponse response)
        {
            var comment = new Comment
            {
                Id = response["id"],
                FromId = response["from_id"],
                Date = response["date"],
                Text = response["text"],
                ReplyToUserId = response["reply_to_user"],
                ReplyToCommentId = response["reply_to_comment"],
                Attachments = response["attachments"].ToReadOnlyCollectionOf<Attachment>(x => x),

                Likes = response["likes"] // установлено экcпериментальным путем
            };

            return comment;
        }

        #endregion
    }
}