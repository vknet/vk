using System;
using System.Collections.Generic;

using VkToolkit.Utils;

namespace VkToolkit.Model
{
    using System.Linq;

    /// <summary>
    /// Запись со стены пользователя или группы.
    /// </summary>
    public class WallRecord
    {
        /// <summary>
        /// Идентификатор записи на стене.
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Идентификатор владельца записи.
        /// </summary>
        public long? ToId { get; set; }
        /// <summary>
        /// Идентификатор пользователя, создавшего запись.
        /// </summary>
        public long? FromId { get; set; }
        /// <summary>
        /// Время публикации записи.
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// Тип записи (post, copy и возможно другие). Если PostType равен "copy", то запись является копией записи с чужой стены.
        /// </summary>
        public string PostType { get; set; }
        /// <summary>
        /// Текст записи.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Информацию о количестве комментариев к записи.
        /// </summary>
        public Comments Comments { get; set; }
        /// <summary>
        /// Информация о числе людей, которым понравилась данная запись.
        /// </summary>
        public Likes Likes { get; set; }
        /// <summary>
        /// Информация о числе людей, которые скопировали данную запись на свою страницу. 
        /// </summary>
        public Reposts Reposts { get; set; }
        /// <summary>
        /// Массив объектов, присоединенных к данной записи (фотографии ссылки и т.п.).
        /// </summary>
        public List<Attachment> Attachments { get; set; }
        /// <summary>
        /// Первый прикрепленный объект.
        /// </summary>
        public Attachment Attachment { get { return Attachments.FirstOrDefault(); } }
        /// <summary>
        /// Если в записи содержится информация о местоположении, то она будет представлена в этом поле.
        /// </summary>
        public Geo Geo { get; set; }
        /// <summary>
        /// Если запись была опубликована от имени группы и подписана пользователем, то в этом поле содержится идентификатор её автора.
        /// </summary>
        public long? SignerId { get; set; }
        /// <summary>
        /// Если запись является копией записи с чужой стены, то в этом поле содержится идентификатор владельца стены у которого была скопирована запись.
        /// </summary>
        public long? CopyOwnerId { get; set; }
        /// <summary>
        /// Если запись является копией записи с чужой стены, то в этом поле содержится идентфикатор скопированной записи на стене ее владельца.
        /// </summary>
        public long? CopyPostId { get; set; }
        /// <summary>
        /// Если запись является копией записи с чужой стены, то в этом поле содержится тип записи (post, copy и возможно другие).
        /// </summary>
        public string CopyPostType { get; set; }
        /// <summary>
        /// Если запись является копией записи с чужой стены, то в этом поле содержится время публикации записи владельцем.
        /// </summary>
        public DateTime? CopyPostDate { get; set; }
        /// <summary>
        /// Если запись является копией записи с чужой стены и при её копировании был добавлен комментарий, его текст содержится в данном поле.
        /// </summary>
        public string CopyText { get; set; }
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

        internal static WallRecord FromJson(VkResponse wall)
        {
            var result = new WallRecord();

            result.Id = wall["id"];
            result.ToId = wall["to_id"];
            result.FromId = wall["from_id"];
            result.Date = wall["date"];
            result.Text = wall["text"];
            result.Comments = wall["comments"];
            result.Likes = wall["likes"];
            result.Reposts = wall["reposts"];
            result.Attachments = wall["attachments"];
            result.Geo = wall["geo"];
            result.SignerId = wall["signer_id"];
            result.CopyOwnerId = wall["copy_owner_id"];
            result.CopyPostType = wall["copy_post_type"];
            result.CopyPostId = wall["copy_post_id"];
            result.CopyPostDate = wall["copy_post_date"];
            result.CopyText = wall["copy_text"];
            result.CopyCommenterId = wall["copy_commenter_id"];
            result.CopyCommentId = wall["copy_comment_id"];
            result.CanDelete = wall["can_delete"];

            return result;
        }
    }
}