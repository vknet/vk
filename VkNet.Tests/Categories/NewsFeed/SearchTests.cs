using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.NewsFeed
{
	[TestFixture]

	public class SearchTests : CategoryBaseTest
	{
		protected override string Folder => "NewsFeed";

		[Test]
		public void Search_NextFrom_NotNull()
		{
			Url = "https://api.vk.com/method/newsfeed.search";
			ReadCategoryJsonPath(nameof(Search_NextFrom_NotNull));

			var result = Api.NewsFeed.Search(new NewsFeedSearchParams());

			Assert.NotNull(result);
			Assert.IsNotEmpty(result.NextFrom);
		}

		[Test]
		public void Search_Coordinates_Exception()
		{
			Url = "https://api.vk.com/method/newsfeed.search";
			ReadCategoryJsonPath(nameof(Search_Coordinates_Exception));

			var result = Api.NewsFeed.Search(new NewsFeedSearchParams{
				Query = "word",
				Extended = false,
				Count = 20
			});

			Assert.NotNull(result);
			Assert.IsNotEmpty(result.NextFrom);
		}
	}
}