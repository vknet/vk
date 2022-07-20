using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets
{


	public class GetAppImageUploadServerTest : CategoryBaseTest
	{
		protected override string Folder => "AppWidgets";

		[Fact]
		public void GetAppImageUploadServer()
		{
			Url = "https://api.vk.com/method/appWidgets.getAppImageUploadServer";

			ReadCategoryJsonPath(nameof(GetAppImageUploadServer));

			var result = Api.AppWidgets.GetAppImageUploadServer(AppWidgetImageType.FiftyOnFifty);

			result.UploadUrl.Should().NotBeNull();
		}
	}
}