using System;

namespace VkToolkit.Model
{
    public class Video
    {
        public long? Id { get; set; }
        public long? OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Duration { get; set; }
        public string Link { get; set; }
        public Uri Image { get; set; }
        public DateTime? Date { get; set; }
        public Uri Player { get; set; }
    }
}