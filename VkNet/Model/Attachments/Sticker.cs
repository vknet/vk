using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    public class Sticker : MediaAttachment
    {
        static Sticker()
        {
            RegisterType(typeof(Sticker), "sticker");
        }

        public long? ProductId { get; set; }

        public string Photo64 { get; set; }

        public string Photo128 { get; set; }

        public string Photo256 { get; set; }

        public long? Width { get; set; }

        public long? Height { get; set; }

        internal static Sticker FromJson(VkResponse response)
		{
			var sticker = new Sticker
			{
				Id = response["id"],
				ProductId = response["product_id"],
				Photo64 = response["photo_64"],
				Photo128 = response["photo_128"],
				Photo256 = response["photo_256"],
				Width = response["width"],
				Height = response["height"]
			};

			return sticker;
		}
	}
}