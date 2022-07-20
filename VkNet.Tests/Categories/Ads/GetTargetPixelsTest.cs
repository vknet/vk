using FluentAssertions;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class GetTargetPixelsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void GetTargetPixels()
		{
			Url = "https://api.vk.com/method/ads.getTargetPixels";

			ReadCategoryJsonPath(nameof(Api.Ads.GetTargetPixels));

			var result = Api.Ads.GetTargetPixels(123);
			result[0].Name.Should().Be("фывыфвв");
		}
	}
}