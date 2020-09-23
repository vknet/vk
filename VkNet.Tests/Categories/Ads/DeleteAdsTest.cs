using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class DeleteAdsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void DeleteAds()
		{
			Url = "https://api.vk.com/method/ads.deleteAds";

			ReadCategoryJsonPath(nameof(Api.Ads.DeleteAds));

			string[] a = new[]
			{
				"1",
				"2"
			};

			var result = Api.Ads.DeleteAds(new DeleteAdsParams
			{
				AccountId = 1605245430,
				Ids = a
			});

			Assert.That(result[0], Is.EqualTo(true));
			Assert.That(result[1], Is.EqualTo(true));
		}
	}
}