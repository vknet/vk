using VkToolkit.Utils;

namespace VkToolkit.Model
{
    /// <summary>
    /// Информация о числе людей, которым понравилась запись.
    /// </summary>
    public class Likes
    {
        /// <summary>
        /// Число людей которым понравилась запись.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Признак понравилась ли запись текущему пользователю.
        /// </summary>
        public bool UserLikes { get; set; }
        /// <summary>
        /// Признак может ли текущий пользователь добавить запись в список "Мне нравится".
        /// </summary>
        public bool CanLike { get; set; }
        /// <summary>
        /// Признак может ли текущий пользователь опубликовать у себя запись.
        /// </summary>
        public bool? CanPublish { get; set; }

        internal static Likes FromJson(VkResponse like)
        {
            var result = new Likes();

            result.Count = like["count"];
            result.UserLikes = like["user_likes"];
            result.CanLike = like["can_like"];
            result.CanPublish = like["can_publish"];

            return result;
        }
    }
}