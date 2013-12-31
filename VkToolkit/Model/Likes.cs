namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о лайках к записи.
    /// См. описание <see cref="http://vk.com/dev/post"/>. Раздел likes.
    /// </summary>
    public class Likes
    {
        /// <summary>
        /// Число пользователей, которым понравилась запись.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Признак понравилась ли запись текущему пользователю.
        /// </summary>
        public bool UserLikes { get; set; }

        /// <summary>
        /// Признак может ли текущий пользователь поставить отметку "Мне нравится".
        /// </summary>
        public bool CanLike { get; set; }

        /// <summary>
        /// Признак может ли текущий пользователь сделать репост записи (опубликовать у себя запись).
        /// </summary>
        public bool? CanPublish { get; set; }

        #region Методы

        internal static Likes FromJson(VkResponse response)
        {
            var likes = new Likes();

            likes.Count = response["count"];
            likes.UserLikes = response["user_likes"];
            likes.CanLike = response["can_like"];
            likes.CanPublish = response["can_publish"];

            return likes;
        }

        #endregion
    }
}