using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class SaveLookalikeRequestResultTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Save lookalike request result")]
	public void SaveLookalikeRequestResult()
	{
		Url = "https://api.vk.ru/method/ads.saveLookalikeRequestResult";

		ReadCategoryJsonPath(nameof(Api.Ads.SaveLookalikeRequestResult));

		var result = Api.Ads.SaveLookalikeRequestResult(new()
		{
			AccountId = 123,
			Level = 2,
			RequestId = 1488
		});

		result.AudienceCount.Should()
			.Be(38000);
	}
}