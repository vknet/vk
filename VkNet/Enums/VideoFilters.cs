using VkNet.Utils;

namespace VkNet.Enums
{
    /// <summary>
    /// Cписок критериев, по которым требуется отфильтровать видео
    /// </summary>
    public class VideoFilters : VkFilter
    {
        /// <summary>
        /// todo not implemented
        /// </summary>
        public static readonly VideoFilters Mp4 = new VideoFilters(1 << 0, "mp4");

        /// <summary>
        /// todo not implemented
        /// </summary>
        public static readonly VideoFilters Youtube = new VideoFilters(1 << 1, "youtube");

        /// <summary>
        /// todo not implemented
        /// </summary>
        public static readonly VideoFilters Vimeo = new VideoFilters(1 << 2, "vimeo");

        /// <summary>
        /// todo not implemented
        /// </summary>
        public static readonly VideoFilters Short = new VideoFilters(1 << 3, "short");

        /// <summary>
        /// todo not implemented
        /// </summary>
        public static readonly VideoFilters Long = new VideoFilters(1 << 4, "long");

        /// <summary>
        /// todo not implemented
        /// </summary>
        public static readonly VideoFilters All = Mp4 | Youtube | Vimeo | Short | Long;

        private VideoFilters(int value, string name) : base(value, name)
        {
        }

        private VideoFilters(VkFilter f1, VkFilter f2) : base(f1, f2)
        {
        }

        public static VideoFilters operator |(VideoFilters f1, VideoFilters f2)
        {
            return new VideoFilters(f1, f2);
        }
    }
}