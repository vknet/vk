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
    }
}