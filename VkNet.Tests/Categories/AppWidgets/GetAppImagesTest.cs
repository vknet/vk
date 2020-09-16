using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.AppWidgets
{
	[TestFixture]

	public class GetAppImagesTest : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Test]
		public void GetAppImages()
		{
			Url = "https://api.vk.com/method/appWidgets.getAppImages";

			ReadCategoryJsonPath(nameof(GetAppImages));

			var result = Api.AppWidgets.GetAppImages(0, 10, AppWidgetImageType.FiftyOnFifty);

			Assert.IsNotNull(result.Items.First().Images.First().Url);
		}
	}
}