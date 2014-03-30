using VkNet.Utils;

namespace VkNet.Enums
{
    /// <summary>
    /// Cписок критериев, по которым требуется отфильтровать видео.
    /// </summary>
    public class VideoFilters : VkFilter
    {
        /// <summary>
        /// Возвращать видео в формате mp4 (воспроиводимое на iOS).
        /// </summary>
        public static readonly VideoFilters Mp4 = new VideoFilters(1 << 0, "mp4");

        /// <summary>
        /// Возвращать youtube видео.
        /// </summary>
        public static readonly VideoFilters Youtube = new VideoFilters(1 << 1, "youtube");

        /// <summary>
        /// Возвращать vimeo видео.
        /// </summary>
        public static readonly VideoFilters Vimeo = new VideoFilters(1 << 2, "vimeo");

        /// <summary>
        /// Возвращать короткие видеозаписи.
        /// </summary>
        public static readonly VideoFilters Short = new VideoFilters(1 << 3, "short");

        /// <summary>
        /// Возвращать длинные видеозаписи
        /// </summary>
        public static readonly VideoFilters Long = new VideoFilters(1 << 4, "long");

        /// <summary>
        /// Возвращать все доступные виды видео.
        /// </summary>
        public static readonly VideoFilters All = Mp4 | Youtube | Vimeo | Short | Long;

        private VideoFilters(int value, string name) : base(value, name)
        {
        }

        private VideoFilters(VkFilter left, VkFilter right) : base(left, right)
        {
        }

        /// <summary>
        /// Оператор объединения фильтров видео.
        /// </summary>
        /// <param name="left">Левое поле выражения объединения.</param>
        /// <param name="right">Правое поле выражения объединения.</param>
        /// <returns>Результат объединения.</returns>
        public static VideoFilters operator |(VideoFilters left, VideoFilters right)
        {
            return new VideoFilters(left, right);
        }
    }
}