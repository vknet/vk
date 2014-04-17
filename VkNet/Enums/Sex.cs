using VkNet.Utils;

namespace VkNet.Enums
{
    /// <summary>
    /// Пол.
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// Не указан.
        /// </summary>
		[DefaultValue]
		Unknown = 0,

        /// <summary>
        /// Женский.
        /// </summary>
        Female = 1,

        /// <summary>
        /// Мужской.
        /// </summary>
        Male = 2
    }
}