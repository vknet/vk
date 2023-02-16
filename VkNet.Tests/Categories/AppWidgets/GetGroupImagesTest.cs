using System.Linq;
using FluentAssertions;
using VkNet.Enums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class GetGroupImagesTest : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact]
	public void GetGroupImages()
	{
		Url = "https://api.vk.com/method/appWidgets.getGroupImages";

		ReadCategoryJsonPath(nameof(GetGroupImages));

		var result = Api.AppWidgets.GetGroupImages(0, 10, AppWidgetImageType.FiftyOnFifty);

		result.Items.First()
			.Images.First()
			.Url.Should()
			.NotBeNull();
	}
}