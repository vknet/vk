using System;

namespace VkToolkit.Model
{
    public class Audio
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public Uri Url { get; set; }
        public long? LyricsId { get; set; }
        public long? AlbumId { get; set; }
        public string Performer { get; set; }
    }
}
