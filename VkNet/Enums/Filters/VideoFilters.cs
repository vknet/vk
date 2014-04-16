using VkNet.Utils;

namespace VkNet.Enums.Filters
{
    /// <summary>
    /// Cписок критериев, по которым требуется отфильтровать видео.
    /// </summary>
    public class VideoFilters : Filter<VideoFilters>
    {
        /// <summary>
        /// Возвращать видео в формате mp4 (воспроиводимое на iOS).
        /// </summary>
		public static readonly VideoFilters Mp4 = RegisterPossibleValue(1 << 0, "mp4");

        /// <summary>
        /// Возвращать youtube видео.
        /// </summary>
		public static readonly VideoFilters Youtube = RegisterPossibleValue(1 << 1, "youtube");

        /// <summary>
        /// Возвращать vimeo видео.
        /// </summary>
		public static readonly VideoFilters Vimeo = RegisterPossibleValue(1 << 2, "vimeo");

        /// <summary>
        /// Возвращать короткие видеозаписи.
        /// </summary>
		public static readonly VideoFilters Short = RegisterPossibleValue(1 << 3, "short");

        /// <summary>
        /// Возвращать длинные видеозаписи
        /// </summary>
		public static readonly VideoFilters Long = RegisterPossibleValue(1 << 4, "long");

        /// <summary>
        /// Возвращать все доступные виды видео.
        /// </summary>
        public static readonly VideoFilters All = Mp4 | Youtube | Vimeo | Short | Long;
    }
}