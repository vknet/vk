using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Podcasts;

public class ClearRecentSearchesTest : CategoryBaseTest
{
	protected override string Folder => "Podcasts";

	[Fact]
	public void ClearRecentSearches()
	{
		Url = "https://api.vk.com/method/podcasts.clearRecentSearches";

		ReadCategoryJsonPath(nameof(Api.Podcasts.ClearRecentSearches));

		var result = Api.Podcasts.ClearRecentSearches();

		result.Should()
			.BeTrue();
	}
}