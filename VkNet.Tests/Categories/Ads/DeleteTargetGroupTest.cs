using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class DeleteTargetGroupTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void DeleteTargetGroup()
		{
			Url = "https://api.vk.com/method/ads.deleteTargetGroup";

			ReadCategoryJsonPath(nameof(Api.Ads.DeleteTargetGroup));

			var result = Api.Ads.DeleteTargetGroup(new DeleteTargetGroupParams
			{
				AccountId = 1605245430,
				TargetGroupId = 1
			});

			result.Should().BeTrue();
		}
	}
}