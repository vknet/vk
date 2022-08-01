using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class GetImagesByIdTest : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact]
	public void GetAppImages()
	{
		Url = "https://api.vk.com/method/appWidgets.getImagesById";

		ReadCategoryJsonPath(nameof(GetAppImages));

		var result = Api.AppWidgets.GetImagesById("7309583_1192027");

		result.Should()
			.NotBeNull();

		result.First()
			.Id.Should()
			.Be("7309583_1192027");
	}
}