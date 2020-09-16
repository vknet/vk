using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetTargetPixelsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetTargetPixels()
		{
			Url = "https://api.vk.com/method/ads.getTargetPixels";

			ReadCategoryJsonPath(nameof(Api.Ads.GetTargetPixels));

			var result = Api.Ads.GetTargetPixels(123);
			Assert.That(result[0].Name, Is.EqualTo("фывыфвв"));
		}
	}
}