using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class CreateTargetPixelTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CreateTargetPixel()
		{
			Url = "https://api.vk.com/method/ads.createTargetPixel";

			ReadCategoryJsonPath(nameof(Api.Ads.CreateTargetPixel));

			var result = Api.Ads.CreateTargetPixel(new CreateTargetPixelParams
			{
				AccountId = 1605245430,
				CategoryId = 1
			});

			Assert.That(result.Id, Is.EqualTo(462641));
			Assert.That(result.Pixel, Is.EqualTo("code..."));
		}
	}
}