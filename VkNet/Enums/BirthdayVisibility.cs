using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Видимость даты рождения
	/// </summary>
	public enum BirthdayVisibility
	{
		/// <summary>
		/// Не показывать дату рождения.
		/// </summary>
		[DefaultValue]
		Invisible = 0,

		/// <summary>
		/// Показывать дату рождения.
		/// </summary>
		Full = 1,

		/// <summary>
		/// Показывать только месяц и день.
		/// </summary>
		OnlyDayAndMonth = 2
	}
}