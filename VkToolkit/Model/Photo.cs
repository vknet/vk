using System;

namespace VkToolkit.Model
{
    public class Photo
    {
        public long? Id { get; set; }
        public long? AlbumId { get; set; }
        public long? OwnerId { get; set; }
        public Uri Src { get; set; }
        public Uri SrcSmall { get; set; }
        public Uri SrcBig { get; set; }
        public string Text { get; set; }
        public DateTime? Created { get; set; }

        public Uri SrcXBig { get; set; }
        public Uri SrcXxBig { get; set; }

        public int? Width { get; set; }
        public int? Height { get; set; }

        public string AccessKey { get; set; }
    }
}