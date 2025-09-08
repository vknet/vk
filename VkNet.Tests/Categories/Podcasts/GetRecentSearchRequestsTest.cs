using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Podcasts;

public class GetRecentSearchRequestsTest : CategoryBaseTest
{
	protected override string Folder => "Podcasts";

	[Fact(DisplayName = "Get recent search requests")]
	public void GetRecentSearchRequests()
	{
		Url = "https://api.vk.ru/method/podcasts.getRecentSearchRequests";

		ReadCategoryJsonPath(nameof(Api.Podcasts.GetRecentSearchRequests));

		var result = Api.Podcasts.GetRecentSearchRequests();

		result.Should()
			.NotBeNull();

		result.Should()
			.HaveElementAt(0, "navi");

		result.Should()
			.HaveElementAt(1, "ted");
	}
}