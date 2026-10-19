using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class ShareTargetGroupTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Share target group")]
	public void ShareTargetGroup()
	{
		Url = "https://api.vk.ru/method/ads.shareTargetGroup";

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