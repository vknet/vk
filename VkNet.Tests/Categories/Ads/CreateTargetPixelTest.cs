using FluentAssertions;
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

			result.Id.Should().Be(462641);
			result.Pixel.Should().Be("code...");
		}
	}
}