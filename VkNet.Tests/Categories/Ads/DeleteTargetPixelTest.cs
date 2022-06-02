using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class DeleteTargetPixelTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void DeleteTargetPixel()
		{
			Url = "https://api.vk.com/method/ads.deleteTargetPixel";

			ReadCategoryJsonPath(nameof(Api.Ads.DeleteTargetPixel));

			var result = Api.Ads.DeleteTargetPixel(new DeleteTargetPixelParams
			{
				AccountId = 1605245430,
				TargetPixelId = 1
			});

			result.Should().Be(true);
		}
	}
}