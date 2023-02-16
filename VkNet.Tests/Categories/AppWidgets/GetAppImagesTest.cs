using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class GetAppImagesTest : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact]
	public void GetAppImages()
	{
		Url = "https://api.vk.com/method/appWidgets.getAppImages";

		ReadCategoryJsonPath(nameof(GetAppImages));

		var result = Api.AppWidgets.GetAppImages(0, 10, AppWidgetImageType.FiftyOnFifty);

		result.Items.First()
			.Images.First()
			.Url.Should()
			.NotBeNull();
	}
}