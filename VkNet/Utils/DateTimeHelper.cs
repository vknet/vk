using System;

namespace VkNet.Utils
{
	/// <summary>
	/// Методы расширения для даты
	/// </summary>
	public static class DateTimeHelper
	{
		/// <summary>
		/// Приветси дату в строковый вид в формате "DD.MM.YYYY"
		/// </summary>
		/// <param name="dateTime"> Дата </param>
		/// <returns> Строковое представление даты в формате "DD.MM.YYYY" </returns>
		public static string ToShortDateString(this DateTime dateTime)
		{
			return dateTime.ToString(format: "DD.MM.YYYY");
		}
	}
}