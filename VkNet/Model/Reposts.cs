namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Информация о репостах записи. 
    /// См. описание <see cref="http://vk.com/dev/post"/>. Раздел reposts.
    /// </summary>
    public class Reposts
    {
        /// <summary>
        /// Число пользователей, скопировавших запись.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Наличие репоста от текущего пользователя .
        /// </summary>
        public bool UserReposted { get; set; }

        #region Методы

        internal static Reposts FromJson(VkResponse response)
        {
            var reposts = new Reposts();

            reposts.Count = response["count"];
            reposts.UserReposted = response["user_reposted"];

            return reposts;
        }

        #endregion
    }
}