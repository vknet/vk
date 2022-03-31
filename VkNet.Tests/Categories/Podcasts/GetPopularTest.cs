using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Podcasts
{
	[TestFixture]

	public class GetPopularTest : CategoryBaseTest
	{
		protected override string Folder => "Podcasts";

		[Test]
		public void GetPopular()
		{
			Url = "https://api.vk.com/method/podcasts.getPopular";

			ReadCategoryJsonPath(nameof(Api.Podcasts.GetPopular));

			var result = Api.Podcasts.GetPopular();

			result.Should().NotBeNull();
			result[0].OwnerId.Should().Be(-74962618);
			result[1].OwnerTitle.Should().Be("вДудь");
		}
	}
}