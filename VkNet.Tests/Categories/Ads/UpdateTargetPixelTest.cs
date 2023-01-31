using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class UpdateTargetPixelTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void UpdateTargetPixel()
	{
		Url = "https://api.vk.com/method/ads.updateTargetPixel";

		ReadCategoryJsonPath(nameof(Api.Ads.UpdateTargetPixel));

		var result = Api.Ads.UpdateTargetPixel(new()
		{
			AccountId = 1605245430,
			Name = "123123",
			CategoryId = 2,
			TargetPixelId = 462641
		});

		result.Should()
			.BeTrue();
	}
}