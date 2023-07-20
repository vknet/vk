using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetPostsReachTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetPostsReach()
	{
		Url = "https://api.vk.com/method/ads.getPostsReach";

		ReadCategoryJsonPath(nameof(Api.Ads.GetPostsReach));

		var result = Api.Ads.GetPostsReach(123, IdsType.Campaign, "123");

		result[0]
			.Id.Should()
			.Be(1012219949);
	}
}