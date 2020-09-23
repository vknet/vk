using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.AppWidgets
{
	[TestFixture]

	public class SaveAppImageTest : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Test]
		public void SaveAppImage()
		{
			Url = "https://api.vk.com/method/appWidgets.saveAppImage";

			ReadCategoryJsonPath(nameof(SaveAppImage));

			var result = Api.AppWidgets.SaveAppImage(
				"0f009dbdd6154c88b8",
				"eyJvaWQiOjczMDk1ODMsInR5cGUiOjUsInBob3RvIjp7InBob3RvIjoiMjRkNmQwOWU1ZXgiLCJzaXplcyI6W1siYSIsMjA2NzIwNTg5LCI1YmYxOCIsInJ2a3JxRWRsR0tVIiw1MCw1MF0sWyJiIiwyMDY3MjA1ODksIjViZjE5IiwiYnE2VXhhakJaUFEiLDEwMCwxMDBdLFsiYyIsMjA2NzIwNTg5LCI1YmYxYSIsImI5eTlEalUtTVR3IiwxNTAsMTUwXV0sImtpZCI6IjhlMDkzZjYxOGQyY2M5MzJiMDU5YmRlYTViNjVhYmNhIiwiZGVidWciOiJ4Y2MiLCJ1cmxzIjpbInYyMDY3MjA1ODlcLzViZjE4XC9ydmtycUVkbEdLVS5qcGciLCJ2MjA2NzIwNTg5XC81YmYxOVwvYnE2VXhhakJaUFEuanBnIiwidjIwNjcyMDU4OVwvNWJmMWFcL2I5eTlEalUtTVR3LmpwZyJdfSwiYndhY3QiOiJhcHBfd2lkZ2V0X2ltYWdlIiwic2VydmVyIjoyMDY3MjAsIm1pZCI6MCwiX3NpZyI6ImNhMjI3ZWZlY2MxMjhjMzgxNTYzZjBjOGQ4YTM4ZTJlIn0");

			Assert.IsNotNull(result.Images.First().Url);
		}
	}
}