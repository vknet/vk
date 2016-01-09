using System.ComponentModel.DataAnnotations;
using VkNet.Properties;
using VkNet.Utils;

namespace VkNet.Enums
{
    /// <summary>
    /// Пол.
    /// </summary>
    public enum Sex
    {
        /// <summary>
        /// Не указан
        /// </summary>
		[DefaultValue]
		[Display(ResourceType = typeof (Resources), Name = "Sex_Unknown")]
		Unknown = 0,

		/// <summary>
		/// Женский
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "Sex_Female")]
		Female = 1,

		/// <summary>
		/// Мужской
		/// </summary>
		[Display(ResourceType = typeof (Resources), Name = "Sex_Male")]
		Male = 2
    }
}