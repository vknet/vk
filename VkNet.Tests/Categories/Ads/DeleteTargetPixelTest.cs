using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class DeleteTargetPixelTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void DeleteTargetPixel()
	{
		Url = "https://api.vk.com/method/ads.deleteTargetPixel";

		ReadCategoryJsonPath(nameof(Api.Ads.DeleteTargetPixel));

		var result = Api.Ads.DeleteTargetPixel(new()
		{
			AccountId = 1605245430,
			TargetPixelId = 1
		});

		result.Should()
			.BeTrue();
	}
}