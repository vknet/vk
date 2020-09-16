using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Podcasts
{
	[TestFixture]

	public class SearchTest : CategoryBaseTest
	{
		protected override string Folder => "Podcasts";

		[Test]
		public void Search()
		{
			Url = "https://api.vk.com/method/podcasts.search";

			ReadCategoryJsonPath(nameof(Api.Podcasts.Search));

			var result = Api.Podcasts.Search(new PodcastsSearchParams
			{
				SearchString = "дудь",
				Offset = 0,
				Count = 100
			});

			Assert.NotNull(result);
			Assert.AreEqual(result.Podcasts[0].OwnerId, -189167851);
			Assert.AreEqual(result.Episodes[0].Id, 456239643);
			Assert.AreEqual(result.Groups[0].Id, 189167851);
		}
	}
}