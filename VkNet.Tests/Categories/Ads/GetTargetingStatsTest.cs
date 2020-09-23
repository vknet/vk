using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetTargetingStatsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetTargetingStats()
		{
			Url = "https://api.vk.com/method/ads.getTargetingStats";

			ReadCategoryJsonPath(nameof(Api.Ads.GetTargetingStats));

			var result = Api.Ads.GetTargetingStats(new GetTargetingStatsParams
			{
				AccountId = 123,

			});
			Assert.That(result.AudienceCount, Is.EqualTo(79189000));
		}
	}
}