using System.Linq;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.AppWidgets;

public class GetImagesByIdTest : CategoryBaseTest
{
	protected override string Folder => "AppWidgets";

	[Fact(DisplayName = "Get images by id")]
	public void GetImagesById()
	{
		Url = "https://api.vk.ru/method/appWidgets.getImagesById";

		ReadCategoryJsonPath(nameof(GetImagesById));

		var result = Api.AppWidgets.GetImagesById("7309583_1192027");

		result.Should()
			.NotBeNull();

		result.First()
			.Id.Should()
			.Be("7309583_1192027");
	}
}