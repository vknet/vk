using System;

namespace VkNet.Tests.Helper
{
	public static class DateHelper
	{
		public static DateTime TimeStampToDateTime(long timestamp)
		{
			var dt = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, millisecond: 0, kind: DateTimeKind.Utc);

			return dt.AddSeconds(value: timestamp);
		}
	}
}