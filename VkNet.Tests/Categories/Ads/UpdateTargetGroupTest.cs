using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class UpdateTargetGroupTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void UpdateTargetGroup()
	{
		Url = "https://api.vk.com/method/ads.updateTargetGroup";

		ReadCategoryJsonPath(nameof(Api.Ads.UpdateTargetGroup));

		var result = Api.Ads.UpdateTargetGroup(new()
		{
			AccountId = 1605245430,
			Name = "123123",
			TargetGroupId = 1,
			TargetPixelId = 462641,
			Lifetime = 365
		});

		result.Should()
			.BeTrue();
	}
}