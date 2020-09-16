using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetDemographicsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetDemographics()
		{
			Url = "https://api.vk.com/method/ads.getDemographics";

			ReadCategoryJsonPath(nameof(Api.Ads.GetDemographics));

			var result = Api.Ads.GetDemographics(new GetDemographicsParams
			{
				AccountId = 123,
				DateFrom = "123",
				DateTo = "123",
				Ids = "123,123",
				IdsType = IdsType.Ad,
				Period = "123"
			});

			Assert.That(result[0].Id, Is.EqualTo(1012219949));
		}
	}
}