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
		Invisible = 0,
		/// <summary>
		/// ПОказывать дату рождения.
		/// </summary>
		Full = 1,
		/// <summary>
		/// Показывать только месяц и день.
		/// </summary>
		OnlyDayAndMonth = 2
	}
}