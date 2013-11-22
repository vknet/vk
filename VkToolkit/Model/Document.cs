using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Document
    {
        public long? Id { get; set; }
        public long? OwnerId { get; set; }
        public string Title { get; set; }
        public long? Size { get; set; }
        public string Ext { get; set; }
        public string Url { get; set; }

        internal static Document FromJson(VkResponse document)
        {
            var result = new Document();

            result.Id = document["did"];
            result.OwnerId = document["owner_id"];
            result.Title = document["title"];
            result.Size = document["size"];
            result.Ext = document["ext"];
            result.Url = document["url"];

            return result;
        }
    }
}