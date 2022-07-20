using System;

namespace VkNet.Tests.Helper
{

	public static class DateHelper
	{
		public static DateTime TimeStampToDateTime(long timestamp)
		{
			var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

			return dt.AddSeconds(timestamp);
		}

		/// <summary>
		/// Приветси дату в строковый вид в формате "DD.MM.YYYY"
		/// </summary>
		/// <param name="dateTime"> Дата </param>
		/// <returns> Строковое представление даты в формате "DD.MM.YYYY" </returns>
		public static string ToShortDateString(this DateTime dateTime)
		{
			return dateTime.ToString("DD.MM.YYYY");
		}
	}
}