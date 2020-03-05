using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams.Ads;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
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

			Assert.That(result.Count, Is.EqualTo(1));
			Assert.That(result.Items[0].Id, Is.EqualTo(37564));
		}
	}
}