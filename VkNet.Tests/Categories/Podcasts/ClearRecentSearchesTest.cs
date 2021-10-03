using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Podcasts
{
	[TestFixture]

	public class ClearRecentSearchesTest : CategoryBaseTest
	{
		protected override string Folder => "Podcasts";

		[Test]
		public void ClearRecentSearches()
		{
			Url = "https://api.vk.com/method/podcasts.clearRecentSearches";

			ReadCategoryJsonPath(nameof(Api.Podcasts.ClearRecentSearches));

			var result = Api.Podcasts.ClearRecentSearches();

			Assert.AreEqual(result, true);
		}
	}
}