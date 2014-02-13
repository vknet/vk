namespace VkNet.Model
{
    using System;
    using System.Linq;
    using System.Collections.ObjectModel;

    using Utils;

    /// <summary>
    /// Запись со стены пользователя или сообщества.
    /// См. описание <see cref="http://vk.com/dev/post"/>.
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Идентификатор записи на стене.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор владельца стены, на которой размещена запись.
        /// </summary>
        public long? ToId { get; set; }

        /// <summary>
        /// Идентификатор автора записи.
        /// </summary>
        public long? FromId { get; set; }

        /// <summary>
        /// Время публикации записи.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Текст записи.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Идентификатор владельца записи, в ответ на которую была оставлена текущая.
        /// </summary>
        public long? ReplyOwnerId { get; set; }

        /// <summary>
        /// Идентификатор записи, в ответ на которую была оставлена текущая.
        /// </summary>
        public long? ReplyPostId { get; set; }

        /// <summary>
        /// true, если запись была создана с опцией «Только для друзей», false в противном случае.
        /// </summary>
        public bool FriendsOnly { get; set; }

        /// <summary>
        /// Информация о комментариях к записи.
        /// </summary>
        public Comments Comments { get; set; }

        /// <summary>
        /// Информация о лайках к записи.
        /// </summary>
        public Likes Likes { get; set; }

        /// <summary>
        /// Информация о репостах записи («Рассказать друзьям»). 
        /// </summary>
        public Reposts Reposts { get; set; }

        /// <summary>
        /// Тип записи (post, copy, reply, postpone, suggest). Если PostType равен "copy", то запись является копией записи с чужой стены.
        /// </summary>
        public string PostType { get; set; }

        /// <summary>
        /// Информация о способе размещения записи .
        /// </summary>
        public PostSource PostSource { get; set; }

        /// <summary>
        /// Информация о вложениях записи (фотографии ссылки и т.п.).
        /// </summary>
        public Collection<Attachment> Attachments { get; set; }

        /// <summary>
        /// Первое вложение.
        /// </summary>
        public Attachment Attachment
        {
            get { return Attachments.FirstOrDefault(); }
        }

        /// <summary>
        /// Информация о местоположении.
        /// </summary>
        public Geo Geo { get; set; }

        /// <summary>
        /// Идентификатор автора, если запись была опубликована от имени сообщества и подписана пользователем.
        /// </summary>
        public long? SignerId { get; set; }

        /// <summary>
        /// Время публикации записи-оригинала (если запись является копией записи с чужой стены).
        /// </summary>
        public DateTime? CopyPostDate { get; set; }

        /// <summary>
        /// Тип записи-оригинала (если запись является копией записи с чужой стены).
        /// </summary>
        public string CopyPostType { get; set; }

        /// <summary>
        /// Идентификатор владельца стены, у которого была скопирована запись (если запись является копией записи с чужой стены).
        /// </summary>
        public long? CopyOwnerId { get; set; }

        /// <summary>
        /// Идентификатор скопированной записи на стене ее владельца (если запись является копией записи с чужой стены).
        /// </summary>
        public long? CopyPostId { get; set; }

        /// <summary>
        /// Текст комментария, добавленного при копировании (если запись является копией записи с чужой стены).
        /// </summary>
        public string CopyText { get; set; }

        /// <summary>
        /// Массив, содержащий историю репостов для записи. Возвращается только в том случае, если запись является репостом. 
        /// </summary>
        public Collection<Post> CopyHistory { get; set; }

        #region Поля, установленные экспериментально

        /// <summary>
        /// Если запись является копией записи с чужой стены, то в этом поле содержится идентификатор коментатора записи.
        /// </summary>
        public long? CopyCommenterId { get; set; }

        /// <summary>
        /// Если запись является копией записи с чужой стены, то в этом поле содержится идентификатор коментария.
        /// </summary>
        public long? CopyCommentId { get; set; }

        /// <summary>
        /// Признак может ли текущий пользователь удалить эту запись.
        /// </summary>
        public bool CanDelete { get; set; }

        #endregion

        #region Методы

        internal static Post FromJson(VkResponse response)
        {
            var post = new Post();

            post.Id = response["id"];
            post.ToId = response["to_id"];
            post.FromId = response["from_id"];
            post.Date = Utilities.FromUnixTime(response["date"]);
            post.Text = response["text"];
            post.ReplyOwnerId = response["reply_owner_id"];
            post.ReplyPostId = response["reply_post_id"];
            post.FriendsOnly = response["friends_only"];
            post.Comments = response["comments"];
            post.Likes = response["likes"];
            post.Reposts = response["reposts"];
            post.PostType = response["post_type"];
            post.PostSource = response["post_source"];
            post.Attachments = response["attachments"];
            post.Geo = response["geo"];
            post.SignerId = response["signer_id"];
            post.CopyPostDate = response["copy_post_date"];
            post.CopyPostType = response["copy_post_type"];
            post.CopyOwnerId = response["copy_owner_id"];
            post.CopyPostId = response["copy_post_id"];
            post.CopyText = response["copy_text"];
            post.CopyHistory = response["copy_history"];

            // далее идут поля, установленные экcпериментальным путем
            post.CopyCommenterId = response["copy_commenter_id"];
            post.CopyCommentId = response["copy_comment_id"];
            post.CanDelete = response["can_delete"];

            return post;
        }

        #endregion
    }
}