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
			SearchString = "наука",
			Offset = 0,
			Count = 100
		});

		result.Should().
			NotBeNull();

		result.ResultsTotal.
			Should().
			Be(32);

		result.Podcasts[0].
			OwnerUrl.
			Should().
			Be("https://vk.com/science_in_palm");

		result.Podcasts[0].
			Title.
			Should().
			Be("Наука в Ладошке");

		result.Podcasts[0].
			Covers.
			Sizes[0].
			Width.
			Should().
			Be(640);

		result.Podcasts[0].
			Covers.
			Sizes[0].
			Type.
			Should().
			Be("a");

		result.Podcasts[4].
			Title.
			Should().
			Be("Noosphere Studio | Наука");

		result.Podcasts[4].
			OwnerUrl.
			Should()
			.Be("https://vk.com/noosphere_studio");

		result.Podcasts[4].
			Covers.
			Sizes[1].
			Type.
			Should()
			.Be("c");

		result.Podcasts[4].
			Covers.
			Sizes[2].
			Height.
			Should().
			Be(160);
	}
}