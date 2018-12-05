using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Ads
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AdsCheckLinkTests : CategoryBaseTest
	{
		protected override string Folder => "Ads";

		[Test]
		public void CheckLink()
		{
			Url = "https://api.vk.com/method/ads.checkLink";

			ReadCategoryJsonPath(nameof(Api.Ads.CheckLink));

			var link = Api.Ads.CheckLink(123, AdsLinkType.Application, Url);

			Assert.NotNull(link);

			Assert.IsNotEmpty(link.Description);
			Assert.That(link.Status, Is.EqualTo(LinkStatusType.Disallowed));
		}
	}
}