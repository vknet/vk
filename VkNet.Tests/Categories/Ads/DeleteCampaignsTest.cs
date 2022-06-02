using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class DeleteCampaignsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void DeleteCampaigns()
		{
			Url = "https://api.vk.com/method/ads.deleteCampaigns";

			ReadCategoryJsonPath(nameof(Api.Ads.DeleteCampaigns));

			var a = new[]
			{
				"1",
				"2"
			};

			var result = Api.Ads.DeleteCampaigns(new DeleteCampaignsParams
			{
				AccountId = 1605245430,
				Ids = a
			});

			result.Should().HaveElementAt(0, true);
			result.Should().HaveElementAt(1, true);
		}
	}
}