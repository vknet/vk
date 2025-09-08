using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class CreateTargetPixelTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact(DisplayName = "Create target pixel")]
	public void CreateTargetPixel()
	{
		Url = "https://api.vk.ru/method/ads.createTargetPixel";

		ReadCategoryJsonPath(nameof(Api.Ads.CreateTargetPixel));

		var result = Api.Ads.CreateTargetPixel(new()
		{
			AccountId = 1605245430,
			CategoryId = 1
		});

		result.Id.Should()
			.Be(462641);

		result.Pixel.Should()
			.Be("code...");
	}
}