using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class ShareTargetGroupTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void ShareTargetGroup()
	{
		Url = "https://api.vk.com/method/ads.shareTargetGroup";

		ReadCategoryJsonPath(nameof(Api.Ads.ShareTargetGroup));

		var result = Api.Ads.ShareTargetGroup(new()
		{
			AccountId = 1605245430,
			TargetGroupId = 1
		});

		result.Id.Should()
			.Be(1488);
	}
}