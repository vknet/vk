namespace VkNet.Enums.SafetyEnums
{
    /// <summary>
    /// Тип объекта (исп. в категории Likes)
    /// </summary>
    public sealed class LikeObjectType : SafetyEnum<LikeObjectType>
    {
        /// <summary>
        /// Запись на стене пользователя или группы
        /// </summary>
        public static LikeObjectType Post = RegisterPossibleValue("post");

        /// <summary>
        /// Комментарий к записи на стене
        /// </summary>
        public static LikeObjectType Comment = RegisterPossibleValue("comment");

        /// <summary>
        /// Фотография
        /// </summary>
        public static LikeObjectType Photo = RegisterPossibleValue("photo");

        /// <summary>
        /// Аудиозапись
        /// </summary>
        public static LikeObjectType Audio = RegisterPossibleValue("audio");

        /// <summary>
        /// Видеозапись
        /// </summary>
        public static LikeObjectType Video = RegisterPossibleValue("video");

        /// <summary>
        /// Заметка
        /// </summary>
        public static LikeObjectType Note = RegisterPossibleValue("note");

        /// <summary>
        /// Комментарий к фотографии
        /// </summary>
        public static LikeObjectType PhotoComment = RegisterPossibleValue("photo_comment");

        /// <summary>
        /// Комментарий к видеозаписи
        /// </summary>
        public static LikeObjectType VideoComment = RegisterPossibleValue("video_comment");

        /// <summary>
        /// Комментарий в обсуждении
        /// </summary>
        public static LikeObjectType TopicComment = RegisterPossibleValue("topic_comment");

        /// <summary>
        /// Страница сайта, на котором установлен виджет «Мне нравится»
        /// </summary>
        public static LikeObjectType SitePage = RegisterPossibleValue("sitepage");
    }
}