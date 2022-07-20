using FluentAssertions;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.NewsFeed
{

	public class GetTest : CategoryBaseTest
	{
		protected override string Folder => "NewsFeed";

		[Fact]
		public void Get()
		{
			Url = "https://api.vk.com/method/newsfeed.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.NewsFeed.Get(new NewsFeedGetParams
			{
				Filters = NewsTypes.Post|NewsTypes.Photo|NewsTypes.WallPhoto|NewsTypes.Friend,
				SourceIds = new[]
				{
					"-106879986",
					"-30022666"
				},
				Count = 100
			});

			result.Should().NotBeNull();
			result.NextFrom.Should().NotBeEmpty();
		}

		[Fact]
		public void Get2()
		{
			Url = "https://api.vk.com/method/newsfeed.get";
			ReadCategoryJsonPath(nameof(Get2));

			var result = Api.NewsFeed.Get(new NewsFeedGetParams
			{
				Filters = NewsTypes.Post|NewsTypes.Photo|NewsTypes.WallPhoto|NewsTypes.Friend,
				SourceIds = new[]
				{
					"361347484"
				},
				Count = 100
			});

			result.Should().NotBeNull();
			result.NextFrom.Should().NotBeEmpty();
		}
	}
}