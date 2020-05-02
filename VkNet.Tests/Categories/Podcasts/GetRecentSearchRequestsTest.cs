using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Podcasts
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetRecentSearchRequestsTest : CategoryBaseTest
	{
		protected override string Folder => "Podcasts";

		[Test]
		public void GetRecentSearchRequests()
		{
			Url = "https://api.vk.com/method/podcasts.getRecentSearchRequests";

			ReadCategoryJsonPath(nameof(Api.Podcasts.GetRecentSearchRequests));

			var result = Api.Podcasts.GetRecentSearchRequests();

			Assert.NotNull(result);
			Assert.AreEqual(result[0], "kukluxklan");
			Assert.AreEqual(result[1], "ted");
		}
	}
}