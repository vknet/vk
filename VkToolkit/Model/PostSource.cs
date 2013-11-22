using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class PostSource
    {
        public string Type { get; set; }

        internal static PostSource FromJson(VkResponse postSource)
        {
            var result = new PostSource();

            result.Type = postSource["type"];

            return result;
        }
    }
}