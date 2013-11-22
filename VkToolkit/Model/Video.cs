using System;

using VkToolkit.Utils;

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

        internal static Video FromJson(VkResponse video)
        {
            var result = new Video();

            result.Id = video["vid"];
            result.OwnerId = video["owner_id"];
            result.Title = video["title"];
            result.Description = video["description"];
            result.Duration = video["duration"];
            result.Link = video["video-4363_136089719"];
            result.Image = video["image"];
            result.Date = video["date"];
            result.Player = video["player"];

            return result;           
        }
    }
}