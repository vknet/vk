using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class UpdateTargetPixelTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void UpdateTargetPixel()
		{
			Url = "https://api.vk.com/method/ads.updateTargetPixel";

			ReadCategoryJsonPath(nameof(Api.Ads.UpdateTargetPixel));


			var result = Api.Ads.UpdateTargetPixel(new UpdateTargetPixelParams
			{
				AccountId = 1605245430,
				Name = "123123",
				CategoryId = 2,
				TargetPixelId = 462641
			});

			Assert.That(result, Is.EqualTo(true));
		}
	}
}