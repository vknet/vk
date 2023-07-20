using System.Linq;
using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.NewsFeed;

public class SearchTests : CategoryBaseTest
{
	protected override string Folder => "NewsFeed";

	[Fact]
	public void Search_NextFrom_NotNull()
	{
		Url = "https://api.vk.com/method/newsfeed.search";
		ReadCategoryJsonPath(nameof(Search_NextFrom_NotNull));

		var result = Api.NewsFeed.Search(new());

		result.Should()
			.NotBeNull();

		result.NextFrom.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void Search_Coordinates_Exception()
	{
		Url = "https://api.vk.com/method/newsfeed.search";
		ReadCategoryJsonPath(nameof(Search_Coordinates_Exception));

		var result = Api.NewsFeed.Search(new()
		{
			Query = "word",
			Extended = false,
			Count = 20
		});

		result.Should()
			.NotBeNull();

		result.NextFrom.Should()
			.NotBeEmpty();
	}

	[Fact]
	public void Search_PostSourceData_Parsing()
	{
		Url = "https://api.vk.com/method/newsfeed.search";
		ReadCategoryJsonPath(nameof(Search_PostSourceData_Parsing));

		var result = Api.NewsFeed.Search(new()
		{
			Query = "word",
			Extended = false,
			Count = 20
		});

		result.Should()
			.NotBeNull();

		var first = result.Items.First();

		first.PostSource.Data.Should().NotBe(null);

		var second = result.Items.Last();

		second.PostSource.Data.Should()
			.NotBe(null);
	}
}