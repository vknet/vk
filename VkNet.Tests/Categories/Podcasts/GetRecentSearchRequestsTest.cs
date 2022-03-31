using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Podcasts
{
	[TestFixture]

	public class GetRecentSearchRequestsTest : CategoryBaseTest
	{
		protected override string Folder => "Podcasts";

		[Test]
		public void GetRecentSearchRequests()
		{
			Url = "https://api.vk.com/method/podcasts.getRecentSearchRequests";

			ReadCategoryJsonPath(nameof(Api.Podcasts.GetRecentSearchRequests));

			var result = Api.Podcasts.GetRecentSearchRequests();

			result.Should().NotBeNull();
			result.Should().HaveElementAt(0, "navi");
			result.Should().HaveElementAt(1, "ted");
		}
	}
}