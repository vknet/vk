using System;
using VkToolkit.Utils;

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

        internal static Note FromJson(VkResponse note)
        {
            // TODO: TEST IT!!!!!
            var result = new Note();

            result.Id = note["nid"];
            result.UserId = note["uid"];
            result.Title = note["title"];
            result.Text = note["text"];
            result.Date = note["date"];
            result.CommentsCount = note["ncom"];
            result.ReadCommentsCount = note["read_ncom"];

            return result;
        }
    }
}