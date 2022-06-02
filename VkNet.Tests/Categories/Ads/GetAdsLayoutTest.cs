using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetAdsLayoutTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetAdsLayout()
		{
			Url = "https://api.vk.com/method/ads.getAdsLayout";

			ReadCategoryJsonPath(nameof(Api.Ads.GetAdsLayout));


			var result = Api.Ads.GetAdsLayout(new GetAdsLayoutParams
			{
				AccountId = 1
			});

			result[0].Id.Should().Be(1);
		}
	}
}