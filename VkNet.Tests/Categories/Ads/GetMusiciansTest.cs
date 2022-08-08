using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads;

public class GetMusiciansTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Fact]
	public void GetMusicians()
	{
		Url = "https://api.vk.com/method/ads.getMusicians";

		ReadCategoryJsonPath(nameof(Api.Ads.GetMusicians));

		var result = Api.Ads.GetMusicians("Alan Walker");

		result[0]
			.Name.Should()
			.Be("Alan Walker");

		result[0]
			.Id.Should()
			.Be(32697);
	}
}