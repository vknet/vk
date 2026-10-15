using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class GetLookalikeRequestsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Get lookalike requests")]
	public void GetLookalikeRequests()
	{
		Url = "https://api.vk.ru/method/ads.getLookalikeRequests";

		ReadCategoryJsonPath(nameof(Api.Ads.GetLookalikeRequests));

		var result = Api.Ads.GetLookalikeRequests(new()
		{
			AccountId = 1605245430
		});

		result.Count.Should()
			.Be(1);

		result.Items[0]
			.Id.Should()
			.Be(37564);
	}
}