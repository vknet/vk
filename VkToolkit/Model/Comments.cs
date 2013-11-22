using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Comments
    {
        public int Count { get; set; }
        public bool CanPost { get; set; }

        internal static Comments FromJson(VkResponse comments)
        {
            var result = new Comments();

            result.Count = comments["count"];
            result.CanPost = comments["can_post"];

            return result;
        }
    }
}