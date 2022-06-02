using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class GetFloodStatsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void GetFloodStats()
		{
			Url = "https://api.vk.com/method/ads.getFloodStats";

			ReadCategoryJsonPath(nameof(Api.Ads.GetFloodStats));

			var result = Api.Ads.GetFloodStats(123213);

			result.Left.Should().Be(4998);
		}
	}
}