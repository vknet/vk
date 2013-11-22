using VkToolkit.Utils;

namespace VkToolkit.Model
{
    public class Like
    {
        public int Count { get; set; }
        public bool UserLikes { get; set; }
        public bool CanLike { get; set; }
        public bool CanPublish { get; set; }

        internal static Like FromJson(VkResponse like)
        {
            var result = new Like();

            result.Count = like["count"];
            result.UserLikes = like["user_likes"];
            result.CanLike = like["can_like"];
            result.CanPublish = like["can_publish"];

            return result;
        }
    }
}