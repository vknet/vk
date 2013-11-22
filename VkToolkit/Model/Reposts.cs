using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Reposts
    {
        public int Count { get; set; }
        public bool UserReposted { get; set; }

        internal static Reposts FromJson(VkResponse resposts)
        {
            var result = new Reposts();

            result.Count = resposts["count"];
            result.UserReposted = resposts["user_reposted"];

            return result;
        }
    }
}