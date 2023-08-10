using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Podcasts;

public class SearchPodcastTest : CategoryBaseTest
{
	protected override string Folder => "Podcasts";

	[Fact]
	public void SearchPodcast()
	{
		Url = "https://api.vk.com/method/podcasts.searchPodcast";

		ReadCategoryJsonPath(nameof(Api.Podcasts.SearchPodcast));

		var result = Api.Podcasts.SearchPodcast(new()
		{
			SearchString = "дудь",
			Offset = 0,
			Count = 100
		});

		result.Should()
			.NotBeNull();

		result.Podcasts[0]
			.OwnerId.Should()
			.Be(-189167851);

		result.Episodes[0]
			.Id.Should()
			.Be(456239643);

		result.Groups[0]
			.Id.Should()
			.Be(189167851);
	}
}