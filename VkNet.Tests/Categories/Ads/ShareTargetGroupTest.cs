using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class ShareTargetGroupTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void ShareTargetGroup()
		{
			Url = "https://api.vk.com/method/ads.shareTargetGroup";

			ReadCategoryJsonPath(nameof(Api.Ads.ShareTargetGroup));

			var result = Api.Ads.ShareTargetGroup(new ShareTargetGroupParams
			{
				AccountId = 1605245430,
				TargetGroupId = 1
			});

			Assert.That(result.Id, Is.EqualTo(1488));
		}
	}
}