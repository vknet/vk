using VkNet.Utils;

namespace VkNet.Model.Attachments
{
    public class Gift : MediaAttachment
    {
        static Gift()
        {
            RegisterType(typeof(Gift), "gift");
        }

        public string Thumb48 { get; set; }

        public string Thumb96 { get; set; }

        public string Thumb256 { get; set; }

        internal static Gift FromJson(VkResponse response)
        {
            var gift = new Gift();

            gift.Id = response["id"];
            gift.Thumb48 = response["thumb_48"];
            gift.Thumb96 = response["thumb_96"];
            gift.Thumb256 = response["thumb_256"];

            return gift;
        }
    }
}
