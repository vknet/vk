using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

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

			result.Id.Should().Be(1488);
		}
	}
}