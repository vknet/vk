using System;

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
        public bool? Online { get; set; }
        public int? ReplyCount { get; set; }
        public PostSource PostSource { get; set; }
    }
}