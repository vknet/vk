using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class GetGroupImageUploadServerTest : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact]
	public void GetGroupImageUploadServer()
	{
		Url = "https://api.vk.com/method/appWidgets.getGroupImageUploadServer";

		ReadCategoryJsonPath(nameof(GetGroupImageUploadServer));

		var result = Api.AppWidgets.GetGroupImageUploadServer(AppWidgetImageType.FiftyOnFifty);

		result.UploadUrl.Should()
			.NotBeNull();
	}
}