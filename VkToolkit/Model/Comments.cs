using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Информация о количестве комментариев к записи.
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// Количество комментариев к записи.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Признак может ли текущий пользователь добавить комментарий к записи.
        /// </summary>
        public bool CanPost { get; set; }

        internal static Comments FromJson(VkResponse response)
        {
            var comments = new Comments();

            comments.Count = response["count"];
            comments.CanPost = response["can_post"];

            return comments;
        }
    }
}