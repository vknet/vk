using FluentAssertions;
using VkNet.Enums.StringEnums;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class AdsCheckLinkTests : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void CheckLink()
	{
		Url = "https://api.vk.com/method/ads.checkLink";

		ReadCategoryJsonPath(nameof(Api.Ads.CheckLink));

		var link = Api.Ads.CheckLink(new()
		{
			AccountId = 123,
			LinkType = AdsLinkType.Application,
			LinkUrl = new(Url)
		});

		link.Should()
			.NotBeNull();

		link.Description.Should()
			.NotBeEmpty();

		link.Status.Should()
			.Be(LinkStatusType.Disallowed);
	}
}