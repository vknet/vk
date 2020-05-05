using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.AppWidgets
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class Update : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Test]
		public void EnableOnline()
		{
			Url = "https://api.vk.com/method/appWidgets.update";

			ReadJsonFile(JsonPaths.True);

			var result = Api.AppWidgets.Update("string", AppWidgetType.Donation);

			Assert.IsTrue(result);
		}
	}
}