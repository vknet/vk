using System;

using VkToolkit.Utils;

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

        internal static Audio FromJson(VkResponse audio)
        {
            // TODO: case when album id is not null
            var result = new Audio();

            result.Id = audio["aid"];
            result.OwnerId = audio["owner_id"];
            result.Artist = audio["artist"];
            result.Title = audio["title"];
            result.Duration = audio["duration"];
            result.Performer = audio["performer"];
            result.Url = audio["url"];
            result.LyricsId = audio["lyrics_id"];
            result.AlbumId = audio["album"];

            return result;
        }
    }
}
