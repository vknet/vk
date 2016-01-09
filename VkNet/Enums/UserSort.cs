using System.ComponentModel.DataAnnotations;
using VkNet.Properties;

namespace VkNet.Enums
{
	/// <summary>
	/// Сортировка результатов: 1 - по дате регистрации, 0 - по популярности целое число.
	/// </summary>
	public enum UserSort
	{
        /// <summary>
        /// По популярности
        /// </summary>        
		[Display(ResourceType = typeof(Resources), Name = "UserSort_ByPopularity")]
		ByPopularity = 0,
        /// <summary>
        /// По дате регистрации
        /// </summary>
        [Display(ResourceType = typeof (Resources), Name = "UserSort_ByRegDate")]
        ByRegDate
	}
}