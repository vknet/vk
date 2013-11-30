using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Информация о числе людей, которые скопировали запись на свою страницу. 
    /// </summary>
    public class Reposts
    {
        /// <summary>
        /// Число людей, которые скопировали запись на свою страницу.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Признак опубликовал ли текущий пользователь запись на своей странице.
        /// </summary>
        public bool UserReposted { get; set; }

        internal static Reposts FromJson(VkResponse response)
        {
            var reposts = new Reposts();

            reposts.Count = response["count"];
            reposts.UserReposted = response["user_reposted"];

            return reposts;
        }
    }
}