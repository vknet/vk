using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]

	public class GetRejectionReasonTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetRejectionReason()
		{
			Url = "https://api.vk.com/method/ads.getRejectionReason";

			ReadCategoryJsonPath(nameof(Api.Ads.GetRejectionReason));

			var result = Api.Ads.GetRejectionReason(123,123);
			result.Comment.Should().Be("123");
		}
	}
}