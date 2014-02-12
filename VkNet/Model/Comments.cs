namespace VkNet.Model
{
    using VkNet.Utils;

    /// <summary>
    /// Информация о количестве комментариев к записи.
    /// См. описание <see cref="http://vk.com/dev/post"/>. Раздел comments.
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

        #region Методы

        internal static Comments FromJson(VkResponse response)
        {
            var comments = new Comments();

            comments.Count = response["count"];
            comments.CanPost = response["can_post"];

            return comments;
        }

        #endregion
    }
}