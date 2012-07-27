using System;

namespace VkToolkit.Model
{
    public class Note
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime? Date { get; set; }
        public int? CommentsCount { get; set; }
        public int? ReadCommentsCount { get; set; }
    }
}