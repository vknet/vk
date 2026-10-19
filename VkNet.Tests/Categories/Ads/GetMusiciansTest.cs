using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class GetMusiciansTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Get musicians")]
	public void GetMusicians()
	{
		Url = "https://api.vk.ru/method/ads.getMusicians";

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