using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetStatisticsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetStatistics()
		{
			Url = "https://api.vk.com/method/ads.getStatistics";

			ReadCategoryJsonPath(nameof(Api.Ads.GetStatistics));

			var result = Api.Ads.GetStatistics(new GetStatisticsParams
			{
				AccountId = 123,
				DateFrom = "123",
				DateTo = "123",
				Ids = "123",
				IdsType = IdsType.Campaign,
				Period = "123"
			});
			Assert.That(result[0].Id, Is.EqualTo(1012219949));
		}
	}
}