using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetPostsReachTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetPostsReach()
		{
			Url = "https://api.vk.com/method/ads.getPostsReach";

			ReadCategoryJsonPath(nameof(Api.Ads.GetPostsReach));

			var result = Api.Ads.GetPostsReach(123,IdsType.Campaign, "123");
			Assert.That(result[0].Id, Is.EqualTo(1012219949));
		}
	}
}