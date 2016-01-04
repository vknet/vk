using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "По популярности")]
        ByPopularity = 0,
        /// <summary>
        /// По дате регистрации
        /// </summary>
        [Display(Name = "По дате регистрации")]
        ByRegDate
	}
}