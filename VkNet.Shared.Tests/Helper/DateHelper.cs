using System;

namespace VkNet.Tests
{
	public static class DateHelper
	{
		public static DateTime TimeStampToDateTime(long timestamp)
		{
			var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return dt.AddSeconds(timestamp).ToLocalTime();
		}
	}
}