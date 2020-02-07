using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetAppImageUploadServerTest : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Test]
		public void GetAppImageUploadServer()
		{
			Url = "https://api.vk.com/method/appWidgets.getAppImageUploadServer";

			ReadCategoryJsonPath(nameof(GetAppImageUploadServer));

			var result = Api.AppWidgets.GetAppImageUploadServer(AppWidgetImageType.FiftyOnFifty);

			Assert.IsNotNull(result.UploadUrl);
		}
	}
}