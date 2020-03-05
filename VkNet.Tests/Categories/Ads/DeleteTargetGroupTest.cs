using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class DeleteTargetGroupTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void DeleteTargetGroup()
		{
			Url = "https://api.vk.com/method/ads.deleteTargetGroup";

			ReadCategoryJsonPath(nameof(Api.Ads.DeleteTargetGroup));

			var result = Api.Ads.DeleteTargetGroup(new DeleteTargetGroupParams
			{
				AccountId = 1605245430,
				TargetGroupId = 1
			});

			Assert.That(result, Is.EqualTo(true));
		}
	}
}