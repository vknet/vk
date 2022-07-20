using FluentAssertions;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Ads
{


	public class SaveLookalikeRequestResultTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Fact]
		public void SaveLookalikeRequestResult()
		{
			Url = "https://api.vk.com/method/ads.saveLookalikeRequestResult";

			ReadCategoryJsonPath(nameof(Api.Ads.SaveLookalikeRequestResult));


			var result = Api.Ads.SaveLookalikeRequestResult(new SaveLookalikeRequestResultParams
			{
				AccountId = 123,
				Level = 2,
				RequestId = 1488
			});

			result.AudienceCount.Should().Be(38000);
		}
	}
}