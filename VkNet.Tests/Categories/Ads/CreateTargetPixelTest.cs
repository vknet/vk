using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class CreateTargetPixelTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void CreateTargetPixel()
	{
		Url = "https://api.vk.com/method/ads.createTargetPixel";

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