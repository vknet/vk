using System;
using System.Collections.Generic;

using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class WallRecord
    {
        public long? Id { get; set; }
        public long? ToId { get; set; }
        public long? FromId { get; set; }
        public DateTime? Date { get; set; }
        public string Text { get; set; }
        public Comments Comments { get; set; }
        public Like Likes { get; set; }
        public Reposts Reposts { get; set; }
        public Geo Geo { get; set; }
        public long? SignerId { get; set; }
        public long? CopyOwnerId { get; set; }
        public long? CopyPostId { get; set; }
        public string CopyText { get; set; }
        public bool Online { get; set; }
        public int? ReplyCount { get; set; }
        public PostSource PostSource { get; set; }
        public Attachment Attachment { get; set; }
        public List<Attachment> Attachments { get; set; }

        internal static WallRecord FromJson(VkResponse wall)
        {
            var result = new WallRecord();

            result.Id = wall["id"];
            result.FromId = wall["from_id"];
            result.ToId = wall["to_id"];
            result.Date = wall["date"];
            result.Text = wall["text"];
            result.CopyOwnerId = wall["copy_owner_id"];
            result.CopyPostId = wall["copy_post_id"];
            result.ReplyCount = wall["reply_count"];
            result.Online = wall["online"];
            result.PostSource = wall["post_source"];
            result.Comments = wall["comments"];
            result.Likes = wall["likes"];
            result.Reposts = wall["reposts"];
            result.Geo = wall["geo"];
            result.Attachment = wall["attachment"];
            result.Attachments = wall["attachments"];

            return result;
        }
    }
}