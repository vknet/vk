using System;

using VkToolkit.Utils;

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

        internal static Photo FromJson(VkResponse photo)
        {
            var result = new Photo();

            result.Id = photo["pid"];
            result.AlbumId = photo["aid"];
            result.OwnerId = photo["owner_id"];
            result.Text = photo["text"];
            result.Width = photo["width"];
            result.Height = photo["height"];
            result.AccessKey = photo["access_key"];
            result.Src = photo["src"];
            result.SrcSmall = photo["src_small"];
            result.SrcBig = photo["src_big"];
            result.Created = photo["created"];
            result.SrcXBig = photo["src_xbig"];
            result.SrcXxBig = photo["src_xxbig"];

            return result;
        }
    }
}