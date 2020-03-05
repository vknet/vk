using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetAdsTargetingTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetAdsTargeting()
		{
			Url = "https://api.vk.com/method/ads.getAdsTargeting";

			ReadCategoryJsonPath(nameof(Api.Ads.GetAdsTargeting));


			var result = Api.Ads.GetAdsTargeting(new GetAdsTargetingParams
			{
				AccountId = 1605245430,
				AdIds = "123",
				CampaignIds = "123",
				ClientId = 123,
				IncludeDeleted = true,
				Limit = 100,
				Offset = 0
			});

			Assert.That(result[0].Id, Is.EqualTo("11021348"));
		}
	}
}