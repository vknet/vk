using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetRejectionReasonTest : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void GetRejectionReason()
		{
			Url = "https://api.vk.com/method/ads.getRejectionReason";

			ReadCategoryJsonPath(nameof(Api.Ads.GetRejectionReason));

			var result = Api.Ads.GetRejectionReason(123,123);
			Assert.That(result.Comment, Is.EqualTo(123));
		}
	}
}