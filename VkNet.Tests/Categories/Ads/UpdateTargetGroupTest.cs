using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class UpdateTargetGroupTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void UpdateTargetGroup()
		{
			Url = "https://api.vk.com/method/ads.updateTargetGroup";

			ReadCategoryJsonPath(nameof(Api.Ads.UpdateTargetGroup));


			var result = Api.Ads.UpdateTargetGroup(new UpdateTargetGroupParams
			{
				AccountId = 1605245430,
				Name = "123123",
				TargetGroupId = 1,
				TargetPixelId = 462641,
				Lifetime = 365
			});

			Assert.That(result, Is.EqualTo(true));
		}
	}
}