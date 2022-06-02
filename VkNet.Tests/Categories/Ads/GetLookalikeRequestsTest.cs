using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetLookalikeRequestsTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetLookalikeRequests()
		{
			Url = "https://api.vk.com/method/ads.getLookalikeRequests";

			ReadCategoryJsonPath(nameof(Api.Ads.GetLookalikeRequests));


			var result = Api.Ads.GetLookalikeRequests(new GetLookalikeRequestsParams()
			{
				AccountId = 1605245430
			});

			result.Count.Should().Be(1);
			result.Items[0].Id.Should().Be(37564);
		}
	}
}