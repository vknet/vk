using System.Diagnostics.CodeAnalysis;
using AwesomeAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.NewsFeed;

[SuppressMessage("ReSharper", "PublicMemgitbersMustHaveComments")]
public class NewsFeedCategoryTest : CategoryBaseTest
{
	/// <inheritdoc />
	protected override string Folder => "NewsFeed";

	[Fact(DisplayName = "Get")]
	public void Get()
	{
		Url = "https://api.vk.ru/method/newsfeed.get";

		ReadCategoryJsonPath(nameof(Get));

		var result = Api.NewsFeed.Get(new()
		{
			SourceIds = ["1234"]
		});

		result.Items.Should()
			.NotBeEmpty();
	}

	[Fact(DisplayName = "Get recommended")]
	public void GetRecommended()
	{
		Url = "https://api.vk.ru/method/newsfeed.getRecommended";

		ReadCategoryJsonPath(nameof(GetRecommended));

		var result = Api.NewsFeed.GetRecommended(new()
		{
			Count = 1
		});

		result.Items.Should()
			.NotBeEmpty();
	}
}