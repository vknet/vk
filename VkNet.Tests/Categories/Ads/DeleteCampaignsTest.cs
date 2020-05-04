using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class DeleteCampaignsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void DeleteCampaigns()
		{
			Url = "https://api.vk.com/method/ads.deleteCampaigns";

			ReadCategoryJsonPath(nameof(Api.Ads.DeleteCampaigns));

			string[] a = new[]
			{
				"1",
				"2"
			};

			var result = Api.Ads.DeleteCampaigns(new DeleteCampaignsParams
			{
				AccountId = 1605245430,
				Ids = a
			});

			Assert.That(result[0], Is.EqualTo(true));
			Assert.That(result[1], Is.EqualTo(true));
		}
	}
}