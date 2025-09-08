using AwesomeAssertions;
using VkNet.Enums.Filters;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.NewsFeed;

public class GetTest : CategoryBaseTest
{
	protected override string Folder => "NewsFeed";

	[Fact(DisplayName = "Get")]
	public void Get()
	{
		Url = "https://api.vk.ru/method/newsfeed.get";
		ReadCategoryJsonPath(nameof(Get));

		var result = Api.NewsFeed.Get(new()
		{
			Filters = NewsTypes.Post|NewsTypes.Photo|NewsTypes.WallPhoto|NewsTypes.Friend,
			SourceIds =
			[
				"-106879986",
				"-30022666"
			],
			Count = 100
		});

		result.Should()
			.NotBeNull();

		result.NextFrom.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Get2")]
	public void Get2()
	{
		Url = "https://api.vk.ru/method/newsfeed.get";
		ReadCategoryJsonPath(nameof(Get2));

		var result = Api.NewsFeed.Get(new()
		{
			Filters = NewsTypes.Post|NewsTypes.Photo|NewsTypes.WallPhoto|NewsTypes.Friend,
			SourceIds = ["361347484"],
			Count = 100
		});

		result.Should()
			.NotBeNull();

		result.NextFrom.Should()
			.NotBeEmpty();
	}
}