using AwesomeAssertions;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads;

public class GetClientsTest : CategoryBaseTest
{
	protected override string Folder => "Ads";

	[Test]
	[DisplayName("Get clients")]
	public void GetClients()
	{
		Url = "https://api.vk.ru/method/ads.getClients";

		ReadCategoryJsonPath(nameof(Api.Ads.GetClients));

		var result = Api.Ads.GetClients(123213);

		result[0]
			.Id.Should()
			.Be(123);
	}
}